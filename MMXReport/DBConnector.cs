﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using MMXReport.Properties;
using System.Windows.Forms;
using MMXReport.TsiConfig;
using Newtonsoft.Json;

namespace MMXReport
{
    public class DBConnector
    { 
        public SqlConnection ConfigConnection { get; set; }
        public SqlConnection DataConnection { get; set; }
        public DBConnector()
        {
            ConfigConnection = new SqlConnection(
                "server=" + Settings.Default.ServerIP + ";" +
                "uid=" + Settings.Default.DB_Id + ";" +
                "pwd=" + Settings.Default.DB_Pwd + ";" +
                "database=" + Settings.Default.ConfigDBName + ";");  
            DataConnection = new SqlConnection(
                "server=" + Settings.Default.ServerIP + ";" +
                "uid=" + Settings.Default.DB_Id + ";" +
                "pwd=" + Settings.Default.DB_Pwd + ";" +
                "database=" +  Settings.Default.DataDBName + ";"); 
        }
        private DataTable GetResultByQuery(string query, SqlConnection conn)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dataTable);
                da.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dataTable;
        }

        #region 쿼리문
        public ExtraChannelConfig LoadExtraJSON(int chid)
        {
            string query = "SELECT [ExtraJson] " +
                           "FROM [" + ConfigConnection.Database + "].[dbo].[SensorChannel] " +
                           "WHERE [Id] = " + chid;
            DataTable data = GetResultByQuery(query, ConfigConnection);
            return JsonConvert.DeserializeObject<ExtraChannelConfig>(data.Rows[0].ItemArray[0].ToString());
        }

        public DataTable LoadMimicNodeList()
        {
            string query = "SELECT [Id],[Name],[NodeType],[ParentId],[ChannelId]" +
                           "FROM [" + ConfigConnection.Database + "].[dbo].[MimicNode] " +
                           "WHERE [ParentId] != -1 AND [Name] != 'spare' AND [Name] NOT LIKE 'Trigger%' "+
                           "ORDER BY [NodeType] ASC";
            return GetResultByQuery(query, ConfigConnection);
        }

        public List<DataTable> LoadMultiPointTrendData(MultiPointConfiguration multiPointConf)
        {
            List<DataTable> dataList = new List<DataTable>();
            BandpassConfig selectedbandpass = multiPointConf.CommonBandpassList.Where(x => x.Active).First() as BandpassConfig;
            string query = string.Empty;
            switch (multiPointConf.StatTermType)
            {
                case "week":
                    foreach (var channel in multiPointConf.SelectedChannelList)
                    {
                        query =
                            "SELECT DATEPART(yy, [DateTime]),DATEPART(ww, [DateTime])," + multiPointConf.ValueMeasureType + "([" + selectedbandpass.BandpassName + "]) " +
                            "FROM " + DataConnection.Database + ".[dbo].[VectorData_day_" + multiPointConf.ValueMeasureType + "] " +
                            "WHERE [ChannelId]=" + channel.Id + " AND [DateTime] BETWEEN '" + multiPointConf.StartDateStr + "' AND '" + multiPointConf.EndDateStr + "' " +
                            "GROUP BY DATEPART(yy, [DateTime]),DATEPART(ww, [DateTime]) " +
                            "ORDER BY DATEPART(yy, [DateTime]),DATEPART(ww, [DateTime])";
                        DataTable dt = GetResultByQuery(query, DataConnection);
                        dt.TableName = channel.PointName;
                        dataList.Add(dt);

                    }
                    break;

                case "day":
                    foreach (var channel in multiPointConf.SelectedChannelList)
                    {
                        query =
                            "SELECT DATEPART(yy, [DateTime]),DATEPART(mm, [DateTime]),DATEPART(dd, [DateTime])," + multiPointConf.ValueMeasureType + "([" + selectedbandpass.BandpassName + "]) " +
                            "FROM " + DataConnection.Database + ".[dbo].[VectorData_day_" + multiPointConf.ValueMeasureType + "] " +
                            "WHERE [ChannelId]=" + channel.Id + " AND [DateTime] BETWEEN '" + multiPointConf.StartDateStr + "' AND '" + multiPointConf.EndDateStr + "' " +
                            "GROUP BY DATEPART(yy, [DateTime]),DATEPART(mm, [DateTime]),DATEPART(dd, [DateTime]) " +
                            "ORDER BY DATEPART(yy, [DateTime]),DATEPART(mm, [DateTime]),DATEPART(dd, [DateTime])";
                        DataTable dt = GetResultByQuery(query, DataConnection);
                        dt.TableName = channel.PointName;
                        dataList.Add(dt);

                    }
                    break;

                case "month":
                    foreach (var channel in multiPointConf.SelectedChannelList)
                    {
                        query =
                        "SELECT DATEPART(yy, [DateTime]),DATEPART(mm, [DateTime])," + multiPointConf.ValueMeasureType + "([" + selectedbandpass.BandpassName + "]) " +
                        "FROM " + DataConnection.Database + ".[dbo].[VectorData_month_" + multiPointConf.ValueMeasureType + "] " +
                        "WHERE [ChannelId]=" + channel.Id + " AND [DateTime] BETWEEN '" + multiPointConf.StartDateStr + "' AND '" + multiPointConf.EndDateStr + "' " +
                        "GROUP BY DATEPART(yy, [DateTime]),DATEPART(mm, [DateTime]) " +
                        "ORDER BY DATEPART(yy, [DateTime]),DATEPART(mm, [DateTime]) ";
                        DataTable dt = GetResultByQuery(query, DataConnection);
                        dt.TableName = channel.PointName;
                        dataList.Add(dt);
                    }
                    break;
            }
            return dataList;
        }

        public List<DataTable> LoadMultiBandpassTrendData(MultiBandpassConfiguration multiBandConf)
        {
            List<DataTable> dataList = new List<DataTable>();
            
            string query = string.Empty;
            switch (multiBandConf.StatTermType)
            {
                case "week":
                    foreach (var bandpass in multiBandConf.Channel.BandpassArr)
                    {
                        if (bandpass.Active)
                        {
                            query =
                                "SELECT DATEPART(yy, [DateTime]),DATEPART(ww, [DateTime])," + multiBandConf.ValueMeasureType + "([" + bandpass.BandpassName + "]) " +
                                "FROM " + DataConnection.Database + ".[dbo].[VectorData_day_" + multiBandConf.ValueMeasureType + "] " +
                                "WHERE [ChannelId]=" + multiBandConf.Channel.Id + " AND [DateTime] BETWEEN '" + multiBandConf.StartDateStr + "' AND '" + multiBandConf.EndDateStr + "' " +
                                "GROUP BY DATEPART(yy, [DateTime]),DATEPART(ww, [DateTime]) " +
                                "ORDER BY DATEPART(yy, [DateTime]),DATEPART(ww, [DateTime])";
                            DataTable dt = GetResultByQuery(query, DataConnection);
                            dt.TableName = bandpass.DisplayName;
                            dataList.Add(dt);
                        }
                    }
                    break;

                case "day": 
                    foreach (var bandpass in multiBandConf.Channel.BandpassArr)
                    {
                        if (bandpass.Active)
                        {
                            query =
                                "SELECT DATEPART(yy, [DateTime]),DATEPART(mm, [DateTime]),DATEPART(dd, [DateTime])," + multiBandConf.ValueMeasureType + "([" + bandpass.BandpassName + "]) " +
                                "FROM " + DataConnection.Database + ".[dbo].[VectorData_day_" + multiBandConf.ValueMeasureType + "] " +
                                "WHERE [ChannelId]=" + multiBandConf.Channel.Id + " AND [DateTime] BETWEEN '" + multiBandConf.StartDateStr + "' AND '" + multiBandConf.EndDateStr + "' " +
                                "GROUP BY DATEPART(yy, [DateTime]),DATEPART(mm, [DateTime]),DATEPART(dd, [DateTime]) " +
                                "ORDER BY DATEPART(yy, [DateTime]),DATEPART(mm, [DateTime]),DATEPART(dd, [DateTime])";
                            DataTable dt = GetResultByQuery(query, DataConnection);
                            dt.TableName = bandpass.DisplayName;
                            dataList.Add(dt);
                        }
                    }
                    break;

                case "month":
                    foreach (var bandpass in multiBandConf.Channel.BandpassArr)
                    {
                        if (bandpass.Active)
                        {
                            query =
                            "SELECT DATEPART(yy, [DateTime]),DATEPART(mm, [DateTime])," + multiBandConf.ValueMeasureType + "([" + bandpass.BandpassName + "]) " +
                            "FROM " + DataConnection.Database + ".[dbo].[VectorData_month_" + multiBandConf.ValueMeasureType + "] " +
                            "WHERE [ChannelId]=" + multiBandConf.Channel.Id + " AND [DateTime] BETWEEN '" + multiBandConf.StartDateStr + "' AND '" + multiBandConf.EndDateStr + "' " +
                            "GROUP BY DATEPART(yy, [DateTime]),DATEPART(mm, [DateTime]) " +
                            "ORDER BY DATEPART(yy, [DateTime]),DATEPART(mm, [DateTime]) ";
                            DataTable dt = GetResultByQuery(query, DataConnection);
                            dt.TableName = bandpass.DisplayName;
                            dataList.Add(dt);
                        }
                    }
                    break;
            }
            return dataList;
        }

        public List<DataTable> LoadDayOfWeekData(DayOfWeekConfiguration dowConf)
        {
            List<DataTable> dataList = new List<DataTable>();
            foreach(var bandpass in dowConf.Channel.BandpassArr)
            {
                if (bandpass.Active)
                {
                    string query =
                        "SELECT WEEK_NAME, " + dowConf.ValueMeasureType + "([" + bandpass.BandpassName + "]) " +
                        "FROM(SELECT CASE " +
                        "WHEN DATEPART(dw, [DateTime]) = 1 THEN '일' " +
                        "WHEN DATEPART(dw, [DateTime]) = 2 THEN '월' " +
                        "WHEN DATEPART(dw, [DateTime]) = 3 THEN '화' " +
                        "WHEN DATEPART(dw, [DateTime]) = 4 THEN '수' " +
                        "WHEN DATEPART(dw, [DateTime]) = 5 THEN '목' " +
                        "WHEN DATEPART(dw, [DateTime]) = 6 THEN '금' " +
                        "WHEN DATEPART(dw, [DateTime]) = 7 THEN '토' " +
                        "END WEEK_NAME,[" + bandpass.BandpassName + "]" +
                        "FROM [" + DataConnection.Database + "].[dbo].[VectorData_Day_" + dowConf.ValueMeasureType + "] " +
                        "WHERE [ChannelId]=" + dowConf.Channel.Id + " AND [DateTime] BETWEEN '" + dowConf.StartDateStr + "' AND '" + dowConf.EndDateStr + "' " +
                        "GROUP BY DATEPART(dw, [DateTime]),[" + bandpass.BandpassName + "])AS t1 " +

                        "WHERE WEEK_NAME != '일' AND WEEK_NAME != '토' " +

                        "GROUP BY WEEK_NAME " +
                        "ORDER BY CASE " +
                        "WHEN WEEK_NAME = '토' THEN 1 " +
                        "WHEN WEEK_NAME = '금' THEN 2 " +
                        "WHEN WEEK_NAME = '목' THEN 3 " +
                        "WHEN WEEK_NAME = '수' THEN 4 " +
                        "WHEN WEEK_NAME = '화' THEN 5 " +
                        "WHEN WEEK_NAME = '월' THEN 6 " +
                        "WHEN WEEK_NAME = '일' THEN 7 " +
                        "END";
                    DataTable dt = GetResultByQuery(query, DataConnection);
                    dt.TableName = bandpass.DisplayName;
                    dataList.Add(dt);
                }
            }
            return dataList;
        }

        public List<DataTable> LoadPeriodData(PeriodConfiguration periodConf)
        {
            List<DataTable> dataList = new List<DataTable>();
            foreach (var channel in periodConf.SelectedChannelList)
            {
                string query =
                    "SELECT DATEPART(yy, [DateTime]),Year_Quarter, " + periodConf.ValueMeasureType + "([" + periodConf.SelectedBandpass.BandpassName + "]) " +
                    "FROM(SELECT CASE " +
                    "WHEN DATEPART(mm, [DateTime]) = 1 THEN '1분기' WHEN DATEPART(mm, [DateTime]) = 2 THEN '1분기' WHEN DATEPART(mm, [DateTime]) = 3 THEN '1분기' " +
                    "WHEN DATEPART(mm, [DateTime]) = 4 THEN '2분기' WHEN DATEPART(mm, [DateTime]) = 5 THEN '2분기' WHEN DATEPART(mm, [DateTime]) = 6 THEN '2분기' " +
                    "WHEN DATEPART(mm, [DateTime]) = 7 THEN '3분기' WHEN DATEPART(mm, [DateTime]) = 8 THEN '3분기' WHEN DATEPART(mm, [DateTime]) = 9 THEN '3분기' " +
                    "WHEN DATEPART(mm, [DateTime]) = 10 THEN '4분기' WHEN DATEPART(mm, [DateTime]) = 11 THEN '4분기' WHEN DATEPART(mm, [DateTime]) = 12 THEN '4분기' " +
                    "END Year_Quarter,[" + periodConf.SelectedBandpass.BandpassName + "],[DateTime] " +
                    "FROM " + DataConnection.Database + ".[dbo].[VectorData_month_" + periodConf.ValueMeasureType + "] " +
                    "WHERE [ChannelId]=" + channel.Id + " AND [DateTime] >= '" + periodConf.StartDateStr + "' AND  [DateTime] < '" + periodConf.StartDate.AddYears(1).ToString("yyyy-MM-dd") + "')AS T " +
                    "GROUP BY DATEPART(yy, [DateTime]),Year_Quarter " +
                    "ORDER BY DATEPART(yy, [DateTime]),Year_Quarter ";
                DataTable table = GetResultByQuery(query, DataConnection);
                table.TableName = channel.PointName;
                dataList.Add(table);
            }
            return dataList;
        }

        public DataTable LoadDailyData(DailyConfiguration dailyConf)
        {
            string query = string.Empty;
            string[] bandpassStringArr = Enum.GetNames(typeof(VectorOverrideOrder));
            for (int i = 0; i < bandpassStringArr.Length; i++)
            {
                query +=
                    "SELECT point.[ChannelId], machine.[Name] as Machine, point.[Name] as Point, Bandpass = '" + bandpassStringArr[i] + "',Unit = '',Alarm = '' ,data_max.[" + bandpassStringArr[i] + "] as 'Max', data_min.[" + bandpassStringArr[i] + "] as 'Min', data_avg.[" + bandpassStringArr[i] + "] as 'Avg' " +
                    "FROM [MMX_MODULE_Config].[dbo].[MimicNode]  as point " +
                    "JOIN [MMX_MODULE_Config].[dbo].[MimicNode] as machine " +
                    "ON point.ParentId = machine.Id " +
                    "JOIN MMX_MODULE_Data.dbo.VectorData_day_max as data_max ON point.ChannelId = data_max.ChannelId " +
                    "JOIN MMX_MODULE_Data.dbo.VectorData_day_min as data_min ON point.ChannelId = data_min.ChannelId " +
                    "JOIN MMX_MODULE_Data.dbo.VectorData_day_avg as data_avg ON point.ChannelId = data_avg.ChannelId " +
                    "WHERE point.[NodeType]=300 AND point.Name != 'spare' AND point.[Name] NOT LIKE 'Trigger%' AND data_max.[DateTime] = '" + dailyConf.StartDateStr + "' AND data_min.[DateTime] = '" + dailyConf.StartDateStr + "' AND data_avg.[DateTime] = '" + dailyConf.StartDateStr + "' ";
                if (i < bandpassStringArr.Length - 1)
                    query += "UNION ";
            }
            return GetResultByQuery(query, DataConnection);
        }

        public List<DataTable> LoadRepairData(RepairConfiguration repairConf)
        {
            List<DataTable> dataList = new List<DataTable>();
            string query = string.Empty;
            foreach (var bandpass in repairConf.Channel.BandpassArr)
            {
                if (bandpass.Active)
                {
                    query =
                        "SELECT [DateTime]," + repairConf.ValueMeasureType + "([" + bandpass.BandpassName + "]) " +
                        "FROM " + DataConnection.Database + ".[dbo].[VectorData_day_" + repairConf.ValueMeasureType + "] " +
                        "WHERE [ChannelId]=" + repairConf.Channel.Id + " AND [DateTime] BETWEEN '" + repairConf.StartDateStr + "' AND '" + repairConf.EndDateStr + "' " +
                        "GROUP BY [DateTime] " +
                        "ORDER BY [DateTime]";
                    DataTable dt = GetResultByQuery(query, DataConnection);
                    dt.TableName = bandpass.DisplayName;
                    dataList.Add(dt);
                }
            }
            return dataList;
        }
        #endregion
    }
}
