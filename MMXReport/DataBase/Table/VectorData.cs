using MMXReport.Properties;
using MMXReport.TsiConfig;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMXReport.DataBase
{
    public class VectorData
    {
        public int Idx { get; set; }
        public int ChannelId { get; set; }
        public DateTime DateTime { get; set; }
        public float Rpm { get; set; }
        public float Direct { get; set; }
        public float OneXAmp { get; set; }
        public float OneXPhase { get; set; }
        public float TwoXAmp { get; set; }
        public float TwoXPhase { get; set; }
        public float NXAmp { get; set; }
        public float NXPhase { get; set; }
        public float Bandpass { get; set; }
        public float CrestFactor { get; set; }
    }

    public class VectorDataTable
    {
        private SqlConnection DBConnection;

        public VectorDataTable(SqlConnection conn)
        {
            DBConnection = conn;
        }

        private string GetSQLDateTimeString(DateTime date, DateTime time)
        {
            return date.ToString("yyyy-MM-dd ") + time.ToString("HH:mm:ss");
        }

        private string GetDailySummaryDataQuery(string measureType,string time_from, string time_to)
        {
            return string.Format("(SELECT [ChannelId]," +
            "CAST(CAST(DateTime AS date) AS datetime) AS DateTime," +
            "CAST({0}(Rpm) as float(24)) AS Rpm," +
            "CAST({0}(Direct) as float(24)) AS Direct," +
            "CAST({0}(OneXAmp) as float(24)) AS OneXAmp," +
            "CAST({0}(OneXPhase) as float(24)) AS OneXPhase," +
            "CAST({0}(TwoXAmp) as float(24)) AS TwoXAmp, " +
            "CAST({0}(TwoXPhase) as float(24)) AS TwoXPhase," +
            "CAST({0}(NXAmp) as float(24)) AS NXAmp," +
            "CAST({0}(NXPhase) as float(24)) AS NXPhase," +
            "CAST({0}(Bandpass) as float(24)) AS Bandpass," +
            "CAST({0}(CrestFactor) as float(24)) AS CrestFactor " +
            "FROM dbo.VectorData_hour_{0} AS v WITH (NOLOCK) " +
            "WHERE [DateTime] >= '{1}' and [DateTime] < '{2}' " +
            "GROUP BY CAST(DateTime AS date), ChannelId) ", measureType, time_from, time_to);
        }

        public DailyReportItem[] GetDailyData(DateTime timeStamp)
        {
            string query = string.Empty;
            var measures = Enum.GetNames(typeof(VectorOverrideOrder));
            for (int i = 0; i < measures.Length; i++)
            {
                query += string.Format("SELECT DISTINCT point.[ChannelId],machine.[Name] as Machine, point.[Name] as Point, Measure = '{0}', " +
                    "data_min.[{0}] as 'MIN'," +
                    "data_max.[{0}] as 'MAX'," +
                    "data_avg.[{0}] as 'AVG'," +
                    "Ch.ExtraJson " +
                    "FROM [{1}].dbo.MimicNode as point " +
                    "JOIN [{1}].dbo.MimicNode as machine " +
                    "ON point.ParentId = machine.Id " +
                    "JOIN dbo.VectorData_day_min as data_min ON point.ChannelId = data_min.ChannelId " +
                    "JOIN dbo.VectorData_day_max as data_max ON point.ChannelId = data_max.ChannelId " +
                    "JOIN dbo.VectorData_day_avg as data_avg ON point.ChannelId = data_avg.ChannelId " +
                    "JOIN [{1}].dbo.SensorChannel as Ch ON point.ChannelId = Ch.Id " +
                    "WHERE point.NodeType = 300 AND point.[Name] != 'spare' AND point.[Name] NOT LIKE 'Trigger%' " +
                    "AND data_min.[DateTime] = @TIMESTEMP " +
                    "AND data_max.[DateTime] = @TIMESTEMP " +
                    "AND data_avg.[DateTime] = @TIMESTEMP ", measures[i],Settings.Default.ConfigDBName);
                if (i < measures.Length - 1)
                    query += " UNION ";
            }
            query += "ORDER BY Machine DESC";

            using (SqlCommand cmd = new SqlCommand(query, DBConnection))
            {
                cmd.Parameters.AddWithValue("@TIMESTEMP", timeStamp);
                return GetDailyReportItemsByQuery(cmd);
            }
        }

        public DailyReportItem[] GetShiftData(DateTime date, DateTime from ,DateTime to)
        {
            string dateTime_from = GetSQLDateTimeString(date,from);
            string dateTime_to = GetSQLDateTimeString(date,to);
            string query = string.Empty;
            var measures = Enum.GetNames(typeof(VectorOverrideOrder));
            for (int i = 0; i < measures.Length; i++)
            {
                query += string.Format("SELECT DISTINCT point.[ChannelId],machine.[Name] as Machine, point.[Name] as Point, Measure = '{0}', " +
                    "data_min.[{0}] as 'MIN'," +
                    "data_max.[{0}] as 'MAX'," +
                    "data_avg.[{0}] as 'AVG'," +
                    "Ch.ExtraJson " +
                    "FROM [{1}].dbo.MimicNode as point " +
                    "JOIN [{1}].dbo.MimicNode as machine " +
                    "ON point.ParentId = machine.Id " +
                    "JOIN {2} as data_min ON point.ChannelId = data_min.ChannelId " +
                    "JOIN {3} as data_max ON point.ChannelId = data_max.ChannelId " +
                    "JOIN {4} as data_avg ON point.ChannelId = data_avg.ChannelId " +
                    "JOIN [{1}].dbo.SensorChannel as Ch ON point.ChannelId = Ch.Id " +
                    "WHERE point.NodeType = 300 AND point.[Name] != 'spare' AND point.[Name] NOT LIKE 'Trigger%' " +
                    "AND data_min.[DateTime] = @TIMESTEMP " +
                    "AND data_max.[DateTime] = @TIMESTEMP " +
                    "AND data_avg.[DateTime] = @TIMESTEMP ", measures[i], Settings.Default.ConfigDBName,
                GetDailySummaryDataQuery("min",dateTime_from, dateTime_to),
                GetDailySummaryDataQuery("max",dateTime_from, dateTime_to),
                GetDailySummaryDataQuery("avg",dateTime_from, dateTime_to));
                if (i < measures.Length - 1)
                    query += " UNION ";
            }
            query += "ORDER BY Machine DESC";

            using (SqlCommand cmd = new SqlCommand(query, DBConnection))
            {
                cmd.Parameters.AddWithValue("@TIMESTEMP", date);
                return GetDailyReportItemsByQuery(cmd);
            }
        }

        private DailyReportItem[] GetDailyReportItemsByQuery(SqlCommand cmd)
        {
            DBConnection.Open();
            List<DailyReportItem> items = new List<DailyReportItem>();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    
                    var overrides = JsonConvert.DeserializeObject<ExtraChannelConfig>(reader.GetString(7)).VectorOverrides;
                    int overrideIdx = Array.IndexOf(Enum.GetNames(typeof(VectorOverrideOrder)), reader.GetString(3));
                    var item = new DailyReportItem();
                    item.Function = overrides[overrideIdx].OverrideName;
                    if (string.IsNullOrWhiteSpace(item.Function)) continue;
                    item.ChannelId = reader.GetInt32(0);
                    item.Machine = reader.GetString(1);
                    item.Point = reader.GetString(2);
                    item.Unit = overrides[overrideIdx].OverrideUnit;
                    var alarms = overrides[overrideIdx].AlarmValues;
                    if (alarms == null) alarms = new float[] { 0f, 0f, 0f, 0f };
                    item.Caution = alarms[0];
                    item.Failure = alarms[1];
                    item.Repair = alarms[2];
                    item.Stop = alarms[3];
                    item.MIN = reader.GetFloat(4);
                    item.MAX = reader.GetFloat(5);
                    item.AVG = reader.GetFloat(6);
                    item.Status = DailyReportItem.CheckStatus(alarms, item.MAX);
                    item.Remark = "";
                    items.Add(item);
                }
            }
            DBConnection.Close();
            return items.ToArray();
        }

        private VectorData[] GetVectorDatasByQuery(SqlCommand cmd)
        {
            DBConnection.Open();
            List<VectorData> vectors = new List<VectorData>();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    vectors.Add(new VectorData()
                    {
                        Idx = reader.GetInt32(0),
                        ChannelId = reader.GetInt32(1),
                        DateTime = reader.GetDateTime(2),
                        Rpm = reader.GetFloat(3),
                        Direct = reader.GetFloat(4),
                        OneXAmp = reader.GetFloat(5),
                        OneXPhase = reader.GetFloat(6),
                        TwoXAmp = reader.GetFloat(7),
                        TwoXPhase = reader.GetFloat(8),
                        NXAmp = reader.GetFloat(9),
                        NXPhase = reader.GetFloat(10),
                        Bandpass = reader.GetFloat(11),
                        CrestFactor = reader.GetFloat(12),
                    });
                }
            }
            DBConnection.Close();
            return vectors.ToArray();
        }
    }
}
