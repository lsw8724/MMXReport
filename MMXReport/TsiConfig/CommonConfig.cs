using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMXReport.DataBase;

namespace MMXReport.TsiConfig
{
    public class CommonConfig
    {
        public MimicTreeNodes MimicNodes { get; set; }
        public CommonConfig()
        {
            MimicNodes = LoadMimicNodes();
        }
        public MimicTreeNodes LoadMimicNodes()
        {
            MimicTreeNodes mimicNodes = new MimicTreeNodes();
            foreach(var node in SQLRepository.MimicNodeCache.Values)
            {
                switch (node.NodeType)
                {
                    case 100: mimicNodes.Add(new MimicTreeNode(node)); break;
                    case 200:
                        var treeNode = mimicNodes.Where(x => x.ThisNode.Id == node.ParentId).FirstOrDefault();
                        treeNode.ChildNodes.Add(new MimicTreeNode(node, treeNode)); break;
                    case 300:
                        foreach (var m in mimicNodes)
                        {
                            var temp = m.ChildNodes.Where(x => x.ThisNode.Id == node.ParentId);
                            if (temp.Count() > 0)
                            {
                                var pNode = temp.First();
                                pNode.ChildNodes.Add(new MimicTreeNode(node, pNode));
                                break;
                            }
                        }break;
                }
            }
            return mimicNodes;
        }
    }
}
