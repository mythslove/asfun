namespace WebsiteDownloader
{
    partial class GZipForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backupCB = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.logTxt = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // backupCB
            // 
            this.backupCB.AutoSize = true;
            this.backupCB.Checked = true;
            this.backupCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.backupCB.Location = new System.Drawing.Point(12, 12);
            this.backupCB.Name = "backupCB";
            this.backupCB.Size = new System.Drawing.Size(288, 16);
            this.backupCB.TabIndex = 0;
            this.backupCB.Text = "备份源文件（或文件夹）为.bak文件（或文件夹）";
            this.backupCB.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 383);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(538, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // logTxt
            // 
            this.logTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.logTxt.Location = new System.Drawing.Point(149, 34);
            this.logTxt.Multiline = true;
            this.logTxt.Name = "logTxt";
            this.logTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logTxt.Size = new System.Drawing.Size(401, 340);
            this.logTxt.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 34);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(131, 340);
            this.listBox1.TabIndex = 3;
            // 
            // GZipForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 418);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.logTxt);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.backupCB);
            this.Name = "GZipForm";
            this.Text = "解压GZip文件（将文件或文件夹挺拖到窗口开始还原）";
            this.Load += new System.EventHandler(this.GZipForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.GZipForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.GZipForm_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox backupCB;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox logTxt;
        private System.Windows.Forms.ListBox listBox1;
    }
}