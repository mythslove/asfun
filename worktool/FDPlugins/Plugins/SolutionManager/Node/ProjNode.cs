using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace SolutionManager
{
    public class ProjNode:TreeNode
    {
        public string path;
        public XmlNode xmlNode;

        /// <summary>
        /// 设置XML节点
        /// </summary>
        /// <param name="node"></param>
        public void SetXmlNode(XmlNode node)
        {
            this.Text = node.Attributes["name"].Value.ToString();
            this.path = node.Attributes["path"].Value.ToString();
            this.xmlNode = node;
        }

        //设置项目名
        public void SetProjName(string name)
        {
            this.Text = name;
            this.xmlNode.Attributes["name"].Value = name;
        }
    }
}
