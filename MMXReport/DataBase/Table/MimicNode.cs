using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMXReport.DataBase
{
    public class MimicNode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NodeType { get; set; }
        public int ParentId { get; set; }
        public int ChannelId { get; set; }
    }

    public class MimicNodeTable
    {
        private SqlConnection DBConnection;

        public MimicNodeTable(SqlConnection conn)
        {
            DBConnection = conn;
        }

        public MimicNode[] GetAllMimicNode()
        {
            string query = "SELECT [Id],[Name],[NodeType],[ParentId],[ChannelId] FROM [dbo].[MimicNode] WHERE [Name] != 'spare' AND [Name] NOT LIKE 'Trigger%' ORDER BY [NodeType] ASC";
            using (SqlCommand cmd = new SqlCommand(query, DBConnection))
            {
                return GetResultByQuery(cmd);
            }
        }

        private MimicNode[] GetResultByQuery(SqlCommand cmd)
        {
            DBConnection.Open();
            List<MimicNode> mimicNodes = new List<MimicNode>();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    mimicNodes.Add(new MimicNode()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        NodeType = reader.GetInt32(2),
                        ParentId = reader.GetInt32(3),
                        ChannelId = reader.GetInt32(4)
                    });
                }
            }
            DBConnection.Close();
            return mimicNodes.ToArray();
        }
    }
}
