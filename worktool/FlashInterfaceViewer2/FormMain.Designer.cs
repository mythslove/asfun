namespace FlashInterfaceViewer
{
    partial class FIVForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileMI = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMI = new System.Windows.Forms.ToolStripMenuItem();
            this.useInfoIM = new System.Windows.Forms.ToolStripMenuItem();
            this.versionIM = new System.Windows.Forms.ToolStripMenuItem();
            this.curVersionMI = new System.Windows.Forms.ToolStripMenuItem();
            this.verLogMI = new System.Windows.Forms.ToolStripMenuItem();
            this.submitButMI = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.collapseAllBtn = new System.Windows.Forms.Button();
            this.expandAllBtn = new System.Windows.Forms.Button();
            this.configTree = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.descTxt = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.asCodeTxt = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.helpMI});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(888, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileMI});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // openFileMI
            // 
            this.openFileMI.Name = "openFileMI";
            this.openFileMI.Size = new System.Drawing.Size(100, 22);
            this.openFileMI.Text = "打开";
            this.openFileMI.Click += new System.EventHandler(this.openFileMI_Click);
            // 
            // helpMI
            // 
            this.helpMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.useInfoIM,
            this.versionIM,
            this.submitButMI});
            this.helpMI.Name = "helpMI";
            this.helpMI.Size = new System.Drawing.Size(44, 21);
            this.helpMI.Text = "帮助";
            // 
            // useInfoIM
            // 
            this.useInfoIM.Name = "useInfoIM";
            this.useInfoIM.Size = new System.Drawing.Size(152, 22);
            this.useInfoIM.Text = "使用说明";
            this.useInfoIM.Click += new System.EventHandler(this.useInfoIM_Click);
            // 
            // versionIM
            // 
            this.versionIM.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.curVersionMI,
            this.verLogMI});
            this.versionIM.Name = "versionIM";
            this.versionIM.Size = new System.Drawing.Size(152, 22);
            this.versionIM.Text = "软件版本";
            // 
            // curVersionMI
            // 
            this.curVersionMI.Name = "curVersionMI";
            this.curVersionMI.Size = new System.Drawing.Size(152, 22);
            this.curVersionMI.Text = "当前版本信息";
            this.curVersionMI.Click += new System.EventHandler(this.curVersionMI_Click);
            // 
            // verLogMI
            // 
            this.verLogMI.Name = "verLogMI";
            this.verLogMI.Size = new System.Drawing.Size(152, 22);
            this.verLogMI.Text = "版本日志";
            this.verLogMI.Click += new System.EventHandler(this.verLogMI_Click);
            // 
            // submitButMI
            // 
            this.submitButMI.Name = "submitButMI";
            this.submitButMI.Size = new System.Drawing.Size(152, 22);
            this.submitButMI.Text = "提交BUG";
            this.submitButMI.Click += new System.EventHandler(this.submitButMI_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.collapseAllBtn);
            this.splitContainer1.Panel1.Controls.Add(this.expandAllBtn);
            this.splitContainer1.Panel1.Controls.Add(this.configTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(864, 529);
            this.splitContainer1.SplitterDistance = 205;
            this.splitContainer1.TabIndex = 1;
            // 
            // collapseAllBtn
            // 
            this.collapseAllBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.collapseAllBtn.Location = new System.Drawing.Point(47, 506);
            this.collapseAllBtn.Name = "collapseAllBtn";
            this.collapseAllBtn.Size = new System.Drawing.Size(75, 23);
            this.collapseAllBtn.TabIndex = 2;
            this.collapseAllBtn.Text = "全部收缩";
            this.collapseAllBtn.UseVisualStyleBackColor = true;
            this.collapseAllBtn.Click += new System.EventHandler(this.collapseAllBtn_Click);
            // 
            // expandAllBtn
            // 
            this.expandAllBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.expandAllBtn.Location = new System.Drawing.Point(128, 506);
            this.expandAllBtn.Name = "expandAllBtn";
            this.expandAllBtn.Size = new System.Drawing.Size(75, 23);
            this.expandAllBtn.TabIndex = 1;
            this.expandAllBtn.Text = "全部展开";
            this.expandAllBtn.UseVisualStyleBackColor = true;
            this.expandAllBtn.Click += new System.EventHandler(this.expandAllBtn_Click);
            // 
            // configTree
            // 
            this.configTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.configTree.Location = new System.Drawing.Point(0, 0);
            this.configTree.Name = "configTree";
            this.configTree.ShowNodeToolTips = true;
            this.configTree.Size = new System.Drawing.Size(202, 500);
            this.configTree.TabIndex = 0;
            this.configTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.configTree_NodeMouseClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(655, 529);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(655, 529);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.descTxt);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(647, 503);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "方法说明";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // descTxt
            // 
            this.descTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descTxt.Location = new System.Drawing.Point(3, 3);
            this.descTxt.Multiline = true;
            this.descTxt.Name = "descTxt";
            this.descTxt.ReadOnly = true;
            this.descTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.descTxt.Size = new System.Drawing.Size(641, 497);
            this.descTxt.TabIndex = 0;
            this.descTxt.WordWrap = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.asCodeTxt);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(647, 503);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "AS代码";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // asCodeTxt
            // 
            this.asCodeTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.asCodeTxt.Location = new System.Drawing.Point(3, 3);
            this.asCodeTxt.Multiline = true;
            this.asCodeTxt.Name = "asCodeTxt";
            this.asCodeTxt.ReadOnly = true;
            this.asCodeTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.asCodeTxt.Size = new System.Drawing.Size(641, 497);
            this.asCodeTxt.TabIndex = 0;
            this.asCodeTxt.WordWrap = false;
            // 
            // FIVForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 569);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FIVForm";
            this.Text = "Flash接口查看器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FIVForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FIVForm_DragEnter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileMI;
        private System.Windows.Forms.ToolStripMenuItem helpMI;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView configTree;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button collapseAllBtn;
        private System.Windows.Forms.Button expandAllBtn;
        private System.Windows.Forms.ToolStripMenuItem submitButMI;
        private System.Windows.Forms.ToolStripMenuItem useInfoIM;
        private System.Windows.Forms.ToolStripMenuItem versionIM;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox descTxt;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox asCodeTxt;
        private System.Windows.Forms.ToolStripMenuItem curVersionMI;
        private System.Windows.Forms.ToolStripMenuItem verLogMI;



    }
}

