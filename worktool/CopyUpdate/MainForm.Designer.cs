namespace CopyUpdate
{
    partial class MainForm
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
            this.updateFileList = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.copyToFolderTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.selWorkFolder = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.copyBtn = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // updateFileList
            // 
            this.updateFileList.FormattingEnabled = true;
            this.updateFileList.Location = new System.Drawing.Point(12, 108);
            this.updateFileList.Name = "updateFileList";
            this.updateFileList.Size = new System.Drawing.Size(334, 228);
            this.updateFileList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "工作目录：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "复制到目录：";
            // 
            // copyToFolderTxt
            // 
            this.copyToFolderTxt.Location = new System.Drawing.Point(14, 63);
            this.copyToFolderTxt.Name = "copyToFolderTxt";
            this.copyToFolderTxt.Size = new System.Drawing.Size(275, 21);
            this.copyToFolderTxt.TabIndex = 5;
            this.copyToFolderTxt.Text = "E:\\project\\open source\\MyFlashDevelop";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "复制文件列表：";
            // 
            // selWorkFolder
            // 
            this.selWorkFolder.FormattingEnabled = true;
            this.selWorkFolder.Location = new System.Drawing.Point(14, 24);
            this.selWorkFolder.Name = "selWorkFolder";
            this.selWorkFolder.Size = new System.Drawing.Size(332, 20);
            this.selWorkFolder.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(295, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "浏览";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // copyBtn
            // 
            this.copyBtn.Location = new System.Drawing.Point(271, 342);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(75, 23);
            this.copyBtn.TabIndex = 9;
            this.copyBtn.Text = "复制";
            this.copyBtn.UseVisualStyleBackColor = true;
            this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(14, 341);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(251, 23);
            this.progressBar.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 376);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.copyBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.selWorkFolder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.copyToFolderTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.updateFileList);
            this.Name = "MainForm";
            this.Text = "更新复制工具V1.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox updateFileList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox copyToFolderTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox selWorkFolder;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button copyBtn;
        private System.Windows.Forms.ProgressBar progressBar;

    }
}

