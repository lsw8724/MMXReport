using DevExpress.XtraTreeList;
using MMXReport.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMXReport
{
    public class MimicTreeNode
    {
        public bool Active { get; set; }
        public MimicNode ThisNode { get; set; }
        public MimicTreeNode ParentNode { get; set; }
        public MimicTreeNodes Nodes { get; set; }
        public MimicTreeNodes ChildNodes { get; set; }

        public MimicTreeNode(MimicNode node)
        {
            this.ThisNode = node;
            ChildNodes = new MimicTreeNodes();
        }

        public MimicTreeNode(MimicNode node, MimicTreeNode pNode) {
            this.ThisNode = node;
            this.ChildNodes = new MimicTreeNodes();
            this.ParentNode = pNode;
        }
    }

    public class MimicTreeNodes : BindingList<MimicTreeNode>, TreeList.IVirtualTreeListData
    {
        private void AddRange(IEnumerable<MimicTreeNode> collection)
        {
            foreach (var item in collection)
                this.Add(item);
        }
        public MimicTreeNodes SearchNodes(int nodeType)
        {
            if (this.Count == 0) return null;
            MimicTreeNodes result = new MimicTreeNodes();
            foreach (var node in this)
            {
                if (node.ThisNode.NodeType == nodeType)
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
        public MimicTreeNodes SearchNodes(int nodeType, MimicTreeNodes nodes)
        {
            if (nodes.Count == 0) return null;
            MimicTreeNodes result = new MimicTreeNodes();
            foreach (var node in nodes)
            {
                if (node.ThisNode.NodeType == nodeType)
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
            MimicTreeNode obj = info.Node as MimicTreeNode;
            info.Children = obj.ChildNodes;
        }
        protected override void InsertItem(int index, MimicTreeNode item)
        {
            item.Nodes = this;
            base.InsertItem(index, item);
        }
        void TreeList.IVirtualTreeListData.VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
        {
            MimicTreeNode obj = info.Node as MimicTreeNode;
            switch (info.Column.Caption)
            {
                case "Name":
                    info.CellData = obj.ThisNode.Name;
                    break;
            }
        }
        void TreeList.IVirtualTreeListData.VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
        {
            MimicTreeNode obj = info.Node as MimicTreeNode;
            switch (info.Column.Caption)
            {
                case "Name":
                    obj.ThisNode.Name = (string)info.NewCellData;
                    break;
            }
        }
    }
}
