using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMXReport.DataBase
{
    public class WaveData
    {
        public int Id { get; set; }
        public int ChannelId { get; set; }
        public int SaveType { get; set; }
        public DateTime DateTime { get; set; }
        public float Rpm { get; set; }
        public float[] SyncData { get; set; }
        public float[] ASyncData { get; set; }
    }

    public class WaveDataTable
    {
        private SqlConnection DBConnection;

        public WaveDataTable(SqlConnection conn)
        {
            DBConnection = conn;
        }
    }
}
