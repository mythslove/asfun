namespace WebsiteDownload2
{
    partial class Form1
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
            this.listFileTxt = new System.Windows.Forms.TextBox();
            this.downloadItemList = new System.Windows.Forms.ListBox();
            this.downloadBtn = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.savePathTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listFilePathTxt = new System.Windows.Forms.TextBox();
            this.loadUrlFileBtn = new System.Windows.Forms.Button();
            this.domainList = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.processBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listFileTxt
            // 
            this.listFileTxt.Location = new System.Drawing.Point(12, 53);
            this.listFileTxt.Multiline = true;
            this.listFileTxt.Name = "listFileTxt";
            this.listFileTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.listFileTxt.Size = new System.Drawing.Size(700, 200);
            this.listFileTxt.TabIndex = 0;
            this.listFileTxt.WordWrap = false;
            // 
            // downloadItemList
            // 
            this.downloadItemList.FormattingEnabled = true;
            this.downloadItemList.HorizontalScrollbar = true;
            this.downloadItemList.ItemHeight = 12;
            this.downloadItemList.Location = new System.Drawing.Point(335, 271);
            this.downloadItemList.Name = "downloadItemList";
            this.downloadItemList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.downloadItemList.Size = new System.Drawing.Size(377, 316);
            this.downloadItemList.TabIndex = 1;
            // 
            // downloadBtn
            // 
            this.downloadBtn.Location = new System.Drawing.Point(662, 24);
            this.downloadBtn.Name = "downloadBtn";
            this.downloadBtn.Size = new System.Drawing.Size(50, 23);
            this.downloadBtn.TabIndex = 2;
            this.downloadBtn.Text = "下载";
            this.downloadBtn.UseVisualStyleBackColor = true;
            this.downloadBtn.Click += new System.EventHandler(this.downloadBtn_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(335, 588);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(377, 23);
            this.progressBar.TabIndex = 3;
            // 
            // savePathTxt
            // 
            this.savePathTxt.Location = new System.Drawing.Point(335, 24);
            this.savePathTxt.Name = "savePathTxt";
            this.savePathTxt.Size = new System.Drawing.Size(265, 21);
            this.savePathTxt.TabIndex = 4;
            this.savePathTxt.Text = "c:\\WebsiteTmp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "下载列表文件";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(333, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "保存目录：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "要下载的域:";
            // 
            // listFilePathTxt
            // 
            this.listFilePathTxt.Location = new System.Drawing.Point(12, 24);
            this.listFilePathTxt.Name = "listFilePathTxt";
            this.listFilePathTxt.Size = new System.Drawing.Size(261, 21);
            this.listFilePathTxt.TabIndex = 13;
            this.listFilePathTxt.Text = "C:\\DownloadList.txt";
            // 
            // loadUrlFileBtn
            // 
            this.loadUrlFileBtn.Location = new System.Drawing.Point(279, 24);
            this.loadUrlFileBtn.Name = "loadUrlFileBtn";
            this.loadUrlFileBtn.Size = new System.Drawing.Size(50, 23);
            this.loadUrlFileBtn.TabIndex = 14;
            this.loadUrlFileBtn.Text = "加载";
            this.loadUrlFileBtn.UseVisualStyleBackColor = true;
            this.loadUrlFileBtn.Click += new System.EventHandler(this.loadUrlFileBtn_Click);
            // 
            // domainList
            // 
            this.domainList.FormattingEnabled = true;
            this.domainList.Location = new System.Drawing.Point(12, 271);
            this.domainList.Name = "domainList";
            this.domainList.Size = new System.Drawing.Size(317, 340);
            this.domainList.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(333, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "下载信息:";
            // 
            // processBtn
            // 
            this.processBtn.Location = new System.Drawing.Point(606, 24);
            this.processBtn.Name = "processBtn";
            this.processBtn.Size = new System.Drawing.Size(50, 23);
            this.processBtn.TabIndex = 18;
            this.processBtn.Text = "分析";
            this.processBtn.UseVisualStyleBackColor = true;
            this.processBtn.Click += new System.EventHandler(this.processBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 624);
            this.Controls.Add(this.processBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.domainList);
            this.Controls.Add(this.loadUrlFileBtn);
            this.Controls.Add(this.listFilePathTxt);
            this.Controls.Add(this.listFileTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.savePathTxt);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.downloadBtn);
            this.Controls.Add(this.downloadItemList);
            this.Name = "Form1";
            this.Text = "网站下载器（www.fanflash.cn）";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox listFileTxt;
        private System.Windows.Forms.ListBox downloadItemList;
        private System.Windows.Forms.Button downloadBtn;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox savePathTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox listFilePathTxt;
        private System.Windows.Forms.Button loadUrlFileBtn;
        private System.Windows.Forms.CheckedListBox domainList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button processBtn;
    }
}

