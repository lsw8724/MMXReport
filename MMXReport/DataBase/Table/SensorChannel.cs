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
    public class SensorChannel
    {
        public int Id { get; set; }
        public int ChannelType { get; set; }
        public string Name { get; set; }
        public ExtraChannelConfig ExtraJson { get; set; }
    }

    public class SensorChannelTable
    {
        private SqlConnection DBConnection;

        public SensorChannelTable(SqlConnection conn)
        {
            DBConnection = conn;
        }

        public SensorChannel[] GetAllSensorChannel()
        {
            string query = "SELECT [Id],[ChannelType],[Name],[ExtraJson] FROM [dbo].[SensorChannel] WHERE [ChannelType] != 100";
            using (SqlCommand cmd = new SqlCommand(query, DBConnection))
            {
                return GetResultByQuery(cmd);
            }
        }

        private SensorChannel[] GetResultByQuery(SqlCommand cmd)
        {
            DBConnection.Open();
            List<SensorChannel> channels = new List<SensorChannel>();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    channels.Add(new SensorChannel()
                    {
                        Id = reader.GetInt32(0),
                        ChannelType = reader.GetInt32(1),
                        Name = reader.GetString(2),
                        ExtraJson = JsonConvert.DeserializeObject<ExtraChannelConfig>(reader.GetString(3))
                    });
                }
            }
            DBConnection.Close();
            return channels.ToArray();
        }
    }
}
