using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using MMXReport.Properties;
using System.Windows.Forms;
using MMXReport.TsiConfig;
using Newtonsoft.Json;
using System.IO;

namespace MMXReport
{
    public class DBConnector
    { 
        public SqlConnection ConfigConnection { get; set; }
        public SqlConnection DataConnection { get; set; }
        public string DataTableName { get; set; }

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
            SqlDataAdapter da = null;
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                conn.Open();
                LogGenerator.AppendLog(query, LogType.SQLQuery, this);
                da = new SqlDataAdapter(cmd);

                da.Fill(dataTable);
                da.Dispose();
                
            }
            catch (Exception ex)
            {
                LogGenerator.AppendLog(ex.StackTrace, LogType.Exception, this);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dataTable;
        }

        #region 쿼리문
        public WaveData[] LoadWaveDatas(RepairConfiguration repairConf)
        {
            WaveData[] datas = new WaveData[2];
            string query =
                   "SELECT TOP 1 [AsyncData],[AsyncFMax],[AsyncLine] " +
                   "FROM [" + DataConnection.Database + "].[dbo].[WaveData] " +
                   "WHERE [ChannelId]=" + repairConf.Channel.Id + " AND [DateTime] BETWEEN '" + repairConf.StartDateStr + "' AND '" + repairConf.BeforeRepairDate.ToString("yyyy-MM-dd") + "' ";
            DataTable table = GetResultByQuery(query, DataConnection);
            if (table.Rows.Count > 0)
            {
                DataRow data = table.Rows[0];
                byte[] binData = data.ItemArray[0] as byte[];
                float[] waveArr = new float[binData.Length / 4];
                for (int i = 0; i < waveArr.Length; i++)
                    waveArr[i] = BitConverter.ToSingle(binData, i * 4);
                datas[0] = new WaveData() { AsyncData = waveArr, FMax = Convert.ToInt32(data.ItemArray[1]), Line = Convert.ToInt32(data.ItemArray[2]) };
            }
            query =
                  "SELECT TOP 1 [AsyncData],[AsyncFMax],[AsyncLine] " +
                  "FROM [" + DataConnection.Database + "].[dbo].[WaveData] " +
                  "WHERE [ChannelId]=" + repairConf.Channel.Id + " AND [DateTime] BETWEEN '" + repairConf.AfterRepairDate.ToString("yyyy-MM-dd") + "' AND '" + repairConf.EndDateStr + "' ";
            table = GetResultByQuery(query, DataConnection);
            if (table.Rows.Count > 0)
            {
                DataRow data = table.Rows[0];
                byte[] binData = data.ItemArray[0] as byte[];
                float[] waveArr = new float[binData.Length / 4];
                for (int i = 0; i < waveArr.Length; i++)
                    waveArr[i] = BitConverter.ToSingle(binData, i * 4);
                datas[1] = new WaveData() { AsyncData = waveArr, FMax = Convert.ToInt32(data.ItemArray[1]), Line = Convert.ToInt32(data.ItemArray[2]) };
            }
            return datas;
        }

        public List<DataTable> LoadMultiPointTrendData(MultiPointConfiguration multiPointConf)
        {
            List<DataTable> dataList = new List<DataTable>();
            BandpassConfig selectedbandpass = multiPointConf.CommonBandpassList.Where(x => x.Active).FirstOrDefault() as BandpassConfig;
            if (selectedbandpass == null) selectedbandpass = multiPointConf.CommonBandpassList.First();
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

        public List<DataTable> LoadMultiBandpassTrendData(MultiMeasureConfiguration multiBandConf)
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
                            dt.TableName = bandpass.OverrideInfo.OverrideName;
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
                            dt.TableName = bandpass.OverrideInfo.OverrideName;
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
                            dt.TableName = bandpass.OverrideInfo.OverrideName;
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
            foreach(var bandpass in dowConf.Channel.BandpassArr.Where(x=>x.DisplayName != null))
            {
                if (bandpass.Active)
                {
                    string query =
                        "SELECT WEEK_NAME, " + dowConf.ValueMeasureType + "([" + bandpass.BandpassName + "]) " +
                        "FROM(SELECT CASE " +
                        "WHEN DATEPART(dw, [DateTime]) = 1 THEN 'Sun' " +
                        "WHEN DATEPART(dw, [DateTime]) = 2 THEN 'Mon' " +
                        "WHEN DATEPART(dw, [DateTime]) = 3 THEN 'Tue' " +
                        "WHEN DATEPART(dw, [DateTime]) = 4 THEN 'Wed' " +
                        "WHEN DATEPART(dw, [DateTime]) = 5 THEN 'Thu' " +
                        "WHEN DATEPART(dw, [DateTime]) = 6 THEN 'Fri' " +
                        "WHEN DATEPART(dw, [DateTime]) = 7 THEN 'Sat' " +
                        "END WEEK_NAME,[" + bandpass.BandpassName + "]" +
                        "FROM [" + DataConnection.Database + "].[dbo].[VectorData_Day_" + dowConf.ValueMeasureType + "] " +
                        "WHERE [ChannelId]=" + dowConf.Channel.Id + " AND [DateTime] BETWEEN '" + dowConf.StartDateStr + "' AND '" + dowConf.EndDateStr + "' " +
                        "GROUP BY DATEPART(dw, [DateTime]),[" + bandpass.BandpassName + "])AS t1 " +

                        "WHERE WEEK_NAME != 'Sun' AND WEEK_NAME != 'Sat' " +

                        "GROUP BY WEEK_NAME " +
                        "ORDER BY CASE " +
                        "WHEN WEEK_NAME = 'Sun' THEN 7 " +
                        "WHEN WEEK_NAME = 'Mon' THEN 6 " +
                        "WHEN WEEK_NAME = 'Tue' THEN 5 " +
                        "WHEN WEEK_NAME = 'Wed' THEN 4 " +
                        "WHEN WEEK_NAME = 'Thu' THEN 3 " +
                        "WHEN WEEK_NAME = 'Fri' THEN 2 " +
                        "WHEN WEEK_NAME = 'Sat' THEN 1 " +
                        "END";
                    DataTable dt = GetResultByQuery(query, DataConnection);
                    dt.TableName = bandpass.OverrideInfo.OverrideName;
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
                    "WHEN DATEPART(mm, [DateTime]) = 1 THEN '1th' WHEN DATEPART(mm, [DateTime]) = 2 THEN '1th' WHEN DATEPART(mm, [DateTime]) = 3 THEN '1th' " +
                    "WHEN DATEPART(mm, [DateTime]) = 4 THEN '2nd' WHEN DATEPART(mm, [DateTime]) = 5 THEN '2nd' WHEN DATEPART(mm, [DateTime]) = 6 THEN '2nd' " +
                    "WHEN DATEPART(mm, [DateTime]) = 7 THEN '3rd' WHEN DATEPART(mm, [DateTime]) = 8 THEN '3rd' WHEN DATEPART(mm, [DateTime]) = 9 THEN '3rd' " +
                    "WHEN DATEPART(mm, [DateTime]) = 10 THEN '4th' WHEN DATEPART(mm, [DateTime]) = 11 THEN '4th' WHEN DATEPART(mm, [DateTime]) = 12 THEN '4th' " +
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
                    "SELECT DISTINCT point.[ChannelId], machine.[Name] as Machine, point.[Name] as Point, " +
                    "Bandpass = '" + bandpassStringArr[i] + "', " +
                    "data_min.[" + bandpassStringArr[i] + "] as 'MIN', data_max.[" + bandpassStringArr[i] + "] as 'MAX', data_avg.[" + bandpassStringArr[i] + "] as 'AVG', " +
                    "Ch.ExtraJson " +
                    "FROM [" + ConfigConnection.Database + "].[dbo].[MimicNode]  as point " +
                    "JOIN [" + ConfigConnection.Database + "].[dbo].[MimicNode] as machine " +
                    "ON point.[ParentId] = machine.[Id] " +
                    "JOIN [" + DataConnection.Database + "].[dbo].[VectorData_day_min] as data_min ON point.[ChannelId] = data_min.[ChannelId] " +
                    "JOIN [" + DataConnection.Database + "].[dbo].[VectorData_day_max] as data_max ON point.[ChannelId] = data_max.[ChannelId] " +
                    "JOIN [" + DataConnection.Database + "].[dbo].[VectorData_day_avg] as data_avg ON point.[ChannelId] = data_avg.[ChannelId] " +
                    "JOIN [" + ConfigConnection.Database + "].[dbo].[SensorChannel] as Ch ON point.[ChannelId] = Ch.[Id] " +
                    "WHERE point.[NodeType]=300 AND point.[Name] != 'spare' AND point.[Name] NOT LIKE 'Trigger%' AND data_min.[DateTime] = '" + dailyConf.StartDateStr + "' AND data_max.[DateTime] = '" + dailyConf.StartDateStr + "' AND data_avg.[DateTime] = '" + dailyConf.StartDateStr + "' ";
                    
                if (i < bandpassStringArr.Length - 1)
                    query += " UNION ";
            }
            return GetResultByQuery(query, DataConnection);
        }

        public DataTable LoadShiftData(DailyConfiguration dailyConf)
        {
            string query = string.Empty;
            string[] bandpassStringArr = Enum.GetNames(typeof(VectorOverrideOrder));
            for (int i = 0; i < bandpassStringArr.Length; i++)
            {
                query += string.Format(
                    "SELECT DISTINCT point.[ChannelId], machine.[Name] as Machine, point.[Name] as Point, " +
                    "Bandpass = '{0}', " +
                    "data_min.[{0}] as 'MIN', data_max.[{0}] as 'MAX', data_avg.[{0}] as 'AVG', " +
                    "Ch.ExtraJson " +
                    "FROM [{1}].[dbo].[MimicNode]  as point " +
                    "JOIN [{1}].[dbo].[MimicNode] as machine " +
                    "ON point.[ParentId] = machine.[Id] " +
                    "JOIN [{2}].[dbo].[VectorData_hour_min] as data_min ON point.[ChannelId] = data_min.[ChannelId] " +
                    "JOIN [{2}].[dbo].[VectorData_hour_max] as data_max ON point.[ChannelId] = data_max.[ChannelId] " +
                    "JOIN [{2}].[dbo].[VectorData_hour_avg] as data_avg ON point.[ChannelId] = data_avg.[ChannelId] " +
                    "JOIN [{1}].[dbo].[SensorChannel] as Ch ON point.[ChannelId] = Ch.[Id] " +
                    "WHERE point.[NodeType]=300 AND point.[Name] != 'spare' AND point.[Name] NOT LIKE 'Trigger%' "+
                    "AND data_min.[DateTime] >= '{3} {4}' AND data_min.[DateTime] <= '{3} {5}'"+
                    "AND data_max.[DateTime] >= '{3} {4}' AND data_max.[DateTime] <= '{3} {5}'"+
                    "AND data_avg.[DateTime] >= '{3} {4}' AND data_avg.[DateTime] <= '{3} {5}'"
                    ,bandpassStringArr[i], ConfigConnection.Database, DataConnection.Database, dailyConf.StartDateStr, dailyConf.SelectedItem.TimeStrFrom, dailyConf.SelectedItem.TimeStrTo);

                if (i < bandpassStringArr.Length - 1)
                    query += " UNION ";
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
                    dt.TableName = bandpass.OverrideInfo.OverrideName;
                    dataList.Add(dt);
                }
            }
            return dataList;
        }
        #endregion
    }
}
