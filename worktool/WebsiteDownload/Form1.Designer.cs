namespace WebsiteDownload
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
            this.cacheTxt = new System.Windows.Forms.TextBox();
            this.fileListBox = new System.Windows.Forms.ListBox();
            this.downloadBtn = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.savePathTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.selFolderBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.urlTxt = new System.Windows.Forms.ComboBox();
            this.cacheFileTxt = new System.Windows.Forms.TextBox();
            this.loadCacheBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cacheTxt
            // 
            this.cacheTxt.Location = new System.Drawing.Point(12, 53);
            this.cacheTxt.Multiline = true;
            this.cacheTxt.Name = "cacheTxt";
            this.cacheTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.cacheTxt.Size = new System.Drawing.Size(347, 378);
            this.cacheTxt.TabIndex = 0;
            this.cacheTxt.DoubleClick += new System.EventHandler(this.cacheTxt_DoubleClick);
            this.cacheTxt.TextChanged += new System.EventHandler(this.cacheTxt_TextChanged);
            // 
            // fileListBox
            // 
            this.fileListBox.FormattingEnabled = true;
            this.fileListBox.HorizontalScrollbar = true;
            this.fileListBox.ItemHeight = 12;
            this.fileListBox.Location = new System.Drawing.Point(365, 24);
            this.fileListBox.Name = "fileListBox";
            this.fileListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.fileListBox.Size = new System.Drawing.Size(342, 436);
            this.fileListBox.TabIndex = 1;
            // 
            // downloadBtn
            // 
            this.downloadBtn.Location = new System.Drawing.Point(284, 464);
            this.downloadBtn.Name = "downloadBtn";
            this.downloadBtn.Size = new System.Drawing.Size(75, 23);
            this.downloadBtn.TabIndex = 2;
            this.downloadBtn.Text = "下载";
            this.downloadBtn.UseVisualStyleBackColor = true;
            this.downloadBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(365, 464);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(342, 23);
            this.progressBar.TabIndex = 3;
            // 
            // savePathTxt
            // 
            this.savePathTxt.Location = new System.Drawing.Point(81, 439);
            this.savePathTxt.Name = "savePathTxt";
            this.savePathTxt.Size = new System.Drawing.Size(197, 21);
            this.savePathTxt.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Firefox cache data:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(363, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "文件列表：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 442);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "保存目录：";
            // 
            // selFolderBtn
            // 
            this.selFolderBtn.Location = new System.Drawing.Point(284, 437);
            this.selFolderBtn.Name = "selFolderBtn";
            this.selFolderBtn.Size = new System.Drawing.Size(75, 23);
            this.selFolderBtn.TabIndex = 8;
            this.selFolderBtn.Text = "选择目录";
            this.selFolderBtn.UseVisualStyleBackColor = true;
            this.selFolderBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 469);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "网站域名：";
            // 
            // urlTxt
            // 
            this.urlTxt.FormattingEnabled = true;
            this.urlTxt.Location = new System.Drawing.Point(81, 467);
            this.urlTxt.Name = "urlTxt";
            this.urlTxt.Size = new System.Drawing.Size(197, 20);
            this.urlTxt.TabIndex = 12;
            // 
            // cacheFileTxt
            // 
            this.cacheFileTxt.Location = new System.Drawing.Point(12, 24);
            this.cacheFileTxt.Name = "cacheFileTxt";
            this.cacheFileTxt.Size = new System.Drawing.Size(265, 21);
            this.cacheFileTxt.TabIndex = 13;
            // 
            // loadCacheBtn
            // 
            this.loadCacheBtn.Location = new System.Drawing.Point(283, 24);
            this.loadCacheBtn.Name = "loadCacheBtn";
            this.loadCacheBtn.Size = new System.Drawing.Size(75, 23);
            this.loadCacheBtn.TabIndex = 14;
            this.loadCacheBtn.Text = "加载文件";
            this.loadCacheBtn.UseVisualStyleBackColor = true;
            this.loadCacheBtn.Click += new System.EventHandler(this.loadCacheBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 501);
            this.Controls.Add(this.loadCacheBtn);
            this.Controls.Add(this.cacheFileTxt);
            this.Controls.Add(this.cacheTxt);
            this.Controls.Add(this.urlTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.selFolderBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.savePathTxt);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.downloadBtn);
            this.Controls.Add(this.fileListBox);
            this.Name = "Form1";
            this.Text = "网站下载器（www.fanflash.cn）";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cacheTxt;
        private System.Windows.Forms.ListBox fileListBox;
        private System.Windows.Forms.Button downloadBtn;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox savePathTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button selFolderBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox urlTxt;
        private System.Windows.Forms.TextBox cacheFileTxt;
        private System.Windows.Forms.Button loadCacheBtn;
    }
}

