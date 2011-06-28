namespace CMDEditor
{
    partial class CMDEditorMain
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.addEventTab = new System.Windows.Forms.TabPage();
            this.addEventBtn = new System.Windows.Forms.Button();
            this.eventParamTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.eventInfoTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.eventTitleTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.eventNameTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.addEventTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl);
            this.splitContainer1.Size = new System.Drawing.Size(735, 581);
            this.splitContainer1.SplitterDistance = 245;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(245, 581);
            this.treeView1.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.addEventTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Enabled = false;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(486, 581);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(478, 555);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "查看";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(478, 555);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "增加方法";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // addEventTab
            // 
            this.addEventTab.Controls.Add(this.addEventBtn);
            this.addEventTab.Controls.Add(this.eventParamTxt);
            this.addEventTab.Controls.Add(this.label4);
            this.addEventTab.Controls.Add(this.eventInfoTxt);
            this.addEventTab.Controls.Add(this.label3);
            this.addEventTab.Controls.Add(this.eventTitleTxt);
            this.addEventTab.Controls.Add(this.label2);
            this.addEventTab.Controls.Add(this.eventNameTxt);
            this.addEventTab.Controls.Add(this.label1);
            this.addEventTab.Location = new System.Drawing.Point(4, 22);
            this.addEventTab.Name = "addEventTab";
            this.addEventTab.Padding = new System.Windows.Forms.Padding(3);
            this.addEventTab.Size = new System.Drawing.Size(478, 555);
            this.addEventTab.TabIndex = 2;
            this.addEventTab.Text = "增加事件";
            this.addEventTab.UseVisualStyleBackColor = true;
            // 
            // addEventBtn
            // 
            this.addEventBtn.Location = new System.Drawing.Point(272, 214);
            this.addEventBtn.Name = "addEventBtn";
            this.addEventBtn.Size = new System.Drawing.Size(75, 23);
            this.addEventBtn.TabIndex = 19;
            this.addEventBtn.Text = "<<增加事件";
            this.addEventBtn.UseVisualStyleBackColor = true;
            this.addEventBtn.Click += new System.EventHandler(this.addEventBtn_Click);
            // 
            // eventParamTxt
            // 
            this.eventParamTxt.Location = new System.Drawing.Point(57, 139);
            this.eventParamTxt.Multiline = true;
            this.eventParamTxt.Name = "eventParamTxt";
            this.eventParamTxt.Size = new System.Drawing.Size(290, 69);
            this.eventParamTxt.TabIndex = 18;
            this.eventParamTxt.Text = "第一行\r\n第二行\r\n第三行\r\n第四行\r\n第五行";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "参数：";
            // 
            // eventInfoTxt
            // 
            this.eventInfoTxt.Location = new System.Drawing.Point(57, 64);
            this.eventInfoTxt.Multiline = true;
            this.eventInfoTxt.Name = "eventInfoTxt";
            this.eventInfoTxt.Size = new System.Drawing.Size(290, 69);
            this.eventInfoTxt.TabIndex = 16;
            this.eventInfoTxt.Text = "第一行\r\n第二行\r\n第三行\r\n第四行\r\n第五行";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "长说明：";
            // 
            // eventTitleTxt
            // 
            this.eventTitleTxt.Location = new System.Drawing.Point(57, 37);
            this.eventTitleTxt.Name = "eventTitleTxt";
            this.eventTitleTxt.Size = new System.Drawing.Size(290, 21);
            this.eventTitleTxt.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "短说明：";
            // 
            // eventNameTxt
            // 
            this.eventNameTxt.Location = new System.Drawing.Point(57, 10);
            this.eventNameTxt.Name = "eventNameTxt";
            this.eventNameTxt.Size = new System.Drawing.Size(290, 21);
            this.eventNameTxt.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "事件名：";
            // 
            // CMDEditorMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 581);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CMDEditorMain";
            this.Text = "消息编辑器";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.CMDEditor_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.CMDEditor_DragEnter);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.addEventTab.ResumeLayout(false);
            this.addEventTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage addEventTab;
        private System.Windows.Forms.Button addEventBtn;
        private System.Windows.Forms.TextBox eventParamTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox eventInfoTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox eventTitleTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox eventNameTxt;
        private System.Windows.Forms.Label label1;
    }
}

