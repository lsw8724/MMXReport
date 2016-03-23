using DevExpress.XtraTreeList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMXReport
{
    public class MimicNode
    {
        public bool Active { get; set; }
        public int Id { get; set; }
        public string NodeName { get; set; }
        public int NodeType { get; set; }
        public int ChannelId { get; set; }
        public MimicNode ParentNode { get; set; }
        public MimicNodes Nodes { get; set; }
        public MimicNodes ChildNodes { get; set; }
        
        public MimicNode() 
        {
            this.NodeName = "";
            this.Nodes = null;
            this.ChildNodes = new MimicNodes();
        }
        public MimicNode(int id, string name, int type, int chid)
        {
            this.Id = id;
            this.NodeName = name;
            this.NodeType = type;
            this.ChannelId = chid;
            this.ChildNodes = new MimicNodes();
        }

        public MimicNode(int id,string name,int type, int chid, MimicNode pNode) {
            this.Id = id;
            this.NodeName = name;
            this.NodeType = type;
            this.ChannelId = chid;
            this.ChildNodes = new MimicNodes();
            this.ParentNode = pNode;
        }
    }

    public class MimicNodes : BindingList<MimicNode>, TreeList.IVirtualTreeListData
    {
        private void AddRange(IEnumerable<MimicNode> collection)
        {
            foreach (var item in collection)
                this.Add(item);
        }
        public MimicNodes SearchNodes(int nodeType)
        {
            if (this.Count == 0) return null;
            MimicNodes result = new MimicNodes();
            foreach (var node in this)
            {
                if (node.NodeType == nodeType)
                {
                    result.Add(node);
                }
                else
                {
                    result.AddRange(SearchNodes(nodeType, node.ChildNodes));
                }             
            }
            return result;
        }
        public MimicNodes SearchNodes(int nodeType, MimicNodes nodes)
        {
            if (nodes.Count == 0) return null;
            MimicNodes result = new MimicNodes();
            foreach (var node in nodes)
            {
                if (node.NodeType == nodeType)
                {
                    result.Add(node);
                }
                else
                {
                    result.AddRange(SearchNodes(nodeType, node.ChildNodes));
                }
            }
            return result;
        }

        void TreeList.IVirtualTreeListData.VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
        {
            MimicNode obj = info.Node as MimicNode;
            info.Children = obj.ChildNodes;
        }
        protected override void InsertItem(int index, MimicNode item)
        {
            item.Nodes = this;
            base.InsertItem(index, item);
        }
        void TreeList.IVirtualTreeListData.VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
        {
            MimicNode obj = info.Node as MimicNode;
            switch (info.Column.Caption)
            {
                case "Name":
                    info.CellData = obj.NodeName;
                    break;
            }
        }
        void TreeList.IVirtualTreeListData.VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
        {
            MimicNode obj = info.Node as MimicNode;
            switch (info.Column.Caption)
            {
                case "Name":
                    obj.NodeName = (string)info.NewCellData;
                    break;
            }
        }
    }
}
