using MMXReport.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMXReport.DataBase
{
    public class SQLRepository
    {
        private static SqlConnection DataDBConnection;
        private static SqlConnection ConfigDBConnection;

        public static MimicNodeTable MimicNodes;
        public static SensorChannelTable SensorChannels;

        public static VectorDataTable VectorDatas;
        public static WaveDataTable WaveDatas;

        public static Dictionary<int, MimicNode> MimicNodeCache = new Dictionary<int, MimicNode>();
        public static Dictionary<int, SensorChannel> SensorChannelCache = new Dictionary<int, SensorChannel>();

        public static void Init()
        {
            try
            {
                ConfigDBConnection = new SqlConnection(string.Format("server={0};uid={1};pwd={2};database={3};",
                    Settings.Default.ServerIP, Settings.Default.DB_Id, Settings.Default.DB_Pwd, Settings.Default.ConfigDBName));

                DataDBConnection = new SqlConnection(string.Format("server={0};uid={1};pwd={2};database={3};",
                    Settings.Default.ServerIP, Settings.Default.DB_Id, Settings.Default.DB_Pwd, Settings.Default.DataDBName));

                MimicNodes = new MimicNodeTable(ConfigDBConnection);
                SensorChannels = new SensorChannelTable(ConfigDBConnection);
                VectorDatas = new VectorDataTable(DataDBConnection);
                WaveDatas = new WaveDataTable(DataDBConnection);
                MimicNodeCache = MimicNodes.GetAllMimicNode().ToDictionary(x => x.Id);
                SensorChannelCache = SensorChannels.GetAllSensorChannel().ToDictionary(x => x.Id);
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
        }

        public static void Close()
        {
            DataDBConnection.Close();
            DataDBConnection.Dispose();
            ConfigDBConnection.Close();
            ConfigDBConnection.Dispose();
        }
    }
}
