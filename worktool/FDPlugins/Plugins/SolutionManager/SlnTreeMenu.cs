﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SolutionManager
{
    class SlnTreeMenu:ContextMenuStrip
    {

        private ToolStripSeparator toolStripSeparator1;

        private ToolStripMenuItem ChangeProNameMI;
        private ToolStripMenuItem ChangeProPathMI;
        private ToolStripMenuItem DelProMI;
        private ToolStripMenuItem AddProMI;

        public SlnTreeMenu()
        {

            this.toolStripSeparator1 = new ToolStripSeparator();
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);

            this.ChangeProNameMI = new ToolStripMenuItem();
            this.ChangeProNameMI.Name = "ChangeProNameMI";
            this.ChangeProNameMI.Text = "更改项目名称";

            this.ChangeProPathMI = new ToolStripMenuItem();
            this.ChangeProPathMI.Name = "ChangeProPathMI";
            this.ChangeProPathMI.Text = "更改项目路径";

            this.DelProMI = new ToolStripMenuItem();
            this.DelProMI.Name = "DelProMI";
            this.DelProMI.Text = "删除这个项目";

            this.AddProMI = new ToolStripMenuItem();
            this.AddProMI.Name = "AddProMI";
            this.AddProMI.Text = "增加一个项目";


        }

        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="node"></param>
        public void Config(TreeNode node) {

            this.Items.Clear();

            if( node is ProjNode){
                this.AddForProNode();
                return;
            }

        }

        /// <summary>
        /// 为项目节点增加的项
        /// </summary>
        private void AddForProNode()
        {
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangeProNameMI,
            this.ChangeProPathMI,
            this.toolStripSeparator1,
            this.DelProMI,
            this.AddProMI});
        }
    }
}