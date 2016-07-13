using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMXReport.TsiConfig
{
    public class CommonConfig
    {
        public MimicNodes MimicNodes { get; set; }
        public CommonConfig(DBConnector dbconn)
        {
            MimicNodes = LoadMimicNodes(dbconn);
        }
        public MimicNodes LoadMimicNodes(DBConnector dbconn)
        {
            DataTable data = dbconn.LoadMimicNodeList();
            MimicNodes mimicNodes = new MimicNodes();
            foreach(DataRow row in data.Rows)
            {
                int id = Convert.ToInt32(row.ItemArray[0]);
                string name = row.ItemArray[1].ToString();
                int nodeType = Convert.ToInt16(row.ItemArray[2]);
                int parentId = Convert.ToInt32(row.ItemArray[3]);
                int chid = Convert.ToInt32(row.ItemArray[4]);
                MimicNode mimicNode = new MimicNode(id, name, nodeType, chid);
                switch(nodeType)
                {
                    case 100: mimicNodes.Add(new MimicNode(id, name, nodeType, chid)); break;
                    case 200: 
                        var node = mimicNodes.Where(x => x.Id == parentId).FirstOrDefault();
                        node.ChildNodes.Add(new MimicNode(id, name, nodeType, chid, node)); break;
                    case 300:
                        foreach (var m in mimicNodes)
                        {
                            var temp = m.ChildNodes.Where(x => x.Id == parentId);
                            if (temp.Count() > 0)
                            {
                                var pNode = temp.First();
                                pNode.ChildNodes.Add(new MimicNode(id, name, nodeType, chid, pNode));
                                break;
                            }
                        }break;
                }
            }
            return mimicNodes;
        }
    }
}
