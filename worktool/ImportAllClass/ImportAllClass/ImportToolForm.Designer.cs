namespace ImportAllClass
{
    partial class ImportToolForm
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
            System.Windows.Forms.Button selSavePathBtn;
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addClassFolderBtn = new System.Windows.Forms.Button();
            this.removeLibFolderBtn = new System.Windows.Forms.Button();
            this.asPathTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.packNameTxt = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.libFolderList = new System.Windows.Forms.ListBox();
            this.exLibFodlerList = new System.Windows.Forms.ListBox();
            this.addExLibFileBtn = new System.Windows.Forms.Button();
            this.removeExLibFolderBtn = new System.Windows.Forms.Button();
            this.addExLibFolderBtn = new System.Windows.Forms.Button();
            selSavePathBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selSavePathBtn
            // 
            selSavePathBtn.Location = new System.Drawing.Point(282, 263);
            selSavePathBtn.Name = "selSavePathBtn";
            selSavePathBtn.Size = new System.Drawing.Size(65, 23);
            selSavePathBtn.TabIndex = 1;
            selSavePathBtn.Text = "浏览";
            selSavePathBtn.UseVisualStyleBackColor = true;
            selSavePathBtn.Click += new System.EventHandler(this.selSavePathBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "类库目录：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "选择要排除的目录或类：";
            // 
            // addClassFolderBtn
            // 
            this.addClassFolderBtn.Location = new System.Drawing.Point(282, 22);
            this.addClassFolderBtn.Name = "addClassFolderBtn";
            this.addClassFolderBtn.Size = new System.Drawing.Size(65, 23);
            this.addClassFolderBtn.TabIndex = 7;
            this.addClassFolderBtn.Text = "增加";
            this.addClassFolderBtn.UseVisualStyleBackColor = true;
            this.addClassFolderBtn.Click += new System.EventHandler(this.addClassFolderBtn_Click);
            // 
            // removeLibFolderBtn
            // 
            this.removeLibFolderBtn.Location = new System.Drawing.Point(282, 51);
            this.removeLibFolderBtn.Name = "removeLibFolderBtn";
            this.removeLibFolderBtn.Size = new System.Drawing.Size(65, 23);
            this.removeLibFolderBtn.TabIndex = 8;
            this.removeLibFolderBtn.Text = "删除";
            this.removeLibFolderBtn.UseVisualStyleBackColor = true;
            this.removeLibFolderBtn.Click += new System.EventHandler(this.removeLibFolderBtn_Click);
            // 
            // asPathTxt
            // 
            this.asPathTxt.Location = new System.Drawing.Point(12, 265);
            this.asPathTxt.Name = "asPathTxt";
            this.asPathTxt.Size = new System.Drawing.Size(264, 21);
            this.asPathTxt.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "选择保存路径：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 301);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "包路径：";
            // 
            // packNameTxt
            // 
            this.packNameTxt.Location = new System.Drawing.Point(12, 316);
            this.packNameTxt.Name = "packNameTxt";
            this.packNameTxt.Size = new System.Drawing.Size(264, 21);
            this.packNameTxt.TabIndex = 13;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(282, 314);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(65, 23);
            this.saveBtn.TabIndex = 16;
            this.saveBtn.Text = "保存";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // libFolderList
            // 
            this.libFolderList.FormattingEnabled = true;
            this.libFolderList.ItemHeight = 12;
            this.libFolderList.Location = new System.Drawing.Point(12, 22);
            this.libFolderList.Name = "libFolderList";
            this.libFolderList.Size = new System.Drawing.Size(264, 88);
            this.libFolderList.TabIndex = 18;
            // 
            // exLibFodlerList
            // 
            this.exLibFodlerList.FormattingEnabled = true;
            this.exLibFodlerList.ItemHeight = 12;
            this.exLibFodlerList.Location = new System.Drawing.Point(12, 145);
            this.exLibFodlerList.Name = "exLibFodlerList";
            this.exLibFodlerList.Size = new System.Drawing.Size(264, 88);
            this.exLibFodlerList.TabIndex = 19;
            // 
            // addExLibFileBtn
            // 
            this.addExLibFileBtn.Location = new System.Drawing.Point(282, 145);
            this.addExLibFileBtn.Name = "addExLibFileBtn";
            this.addExLibFileBtn.Size = new System.Drawing.Size(65, 23);
            this.addExLibFileBtn.TabIndex = 20;
            this.addExLibFileBtn.Text = "增加文件";
            this.addExLibFileBtn.UseVisualStyleBackColor = true;
            this.addExLibFileBtn.Click += new System.EventHandler(this.addExLibFileBtn_Click);
            // 
            // removeExLibFolderBtn
            // 
            this.removeExLibFolderBtn.Location = new System.Drawing.Point(282, 203);
            this.removeExLibFolderBtn.Name = "removeExLibFolderBtn";
            this.removeExLibFolderBtn.Size = new System.Drawing.Size(65, 23);
            this.removeExLibFolderBtn.TabIndex = 21;
            this.removeExLibFolderBtn.Text = "删除";
            this.removeExLibFolderBtn.UseVisualStyleBackColor = true;
            this.removeExLibFolderBtn.Click += new System.EventHandler(this.removeExLibFolderBtn_Click);
            // 
            // addExLibFolderBtn
            // 
            this.addExLibFolderBtn.Location = new System.Drawing.Point(282, 174);
            this.addExLibFolderBtn.Name = "addExLibFolderBtn";
            this.addExLibFolderBtn.Size = new System.Drawing.Size(65, 23);
            this.addExLibFolderBtn.TabIndex = 23;
            this.addExLibFolderBtn.Text = "增加目录";
            this.addExLibFolderBtn.UseVisualStyleBackColor = true;
            this.addExLibFolderBtn.Click += new System.EventHandler(this.addExLibFolderBtn_Click);
            // 
            // ImportToolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 356);
            this.Controls.Add(this.libFolderList);
            this.Controls.Add(this.addClassFolderBtn);
            this.Controls.Add(this.removeLibFolderBtn);
            this.Controls.Add(this.addExLibFolderBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.removeExLibFolderBtn);
            this.Controls.Add(this.addExLibFileBtn);
            this.Controls.Add(this.exLibFodlerList);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.packNameTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.asPathTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(selSavePathBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportToolForm";
            this.Text = "项目代码导入类生成器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addClassFolderBtn;
        private System.Windows.Forms.Button removeLibFolderBtn;
        private System.Windows.Forms.TextBox asPathTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox packNameTxt;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.ListBox libFolderList;
        private System.Windows.Forms.ListBox exLibFodlerList;
        private System.Windows.Forms.Button addExLibFileBtn;
        private System.Windows.Forms.Button removeExLibFolderBtn;
        private System.Windows.Forms.Button addExLibFolderBtn;
    }
}

