namespace WebsiteDownloader
{
    partial class HasFileMsgBox
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
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            this.rememberCB = new System.Windows.Forms.CheckBox();
            this.msgLabel = new System.Windows.Forms.Label();
            this.filePathLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(44, 104);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(93, 23);
            this.okBtn.TabIndex = 0;
            this.okBtn.Text = "可以覆盖";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(242, 104);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(93, 23);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "跳过(不覆盖)";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(143, 104);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(93, 23);
            this.stopBtn.TabIndex = 2;
            this.stopBtn.Text = "停止解压";
            this.stopBtn.UseVisualStyleBackColor = true;
            // 
            // rememberCB
            // 
            this.rememberCB.AutoSize = true;
            this.rememberCB.Location = new System.Drawing.Point(44, 133);
            this.rememberCB.Name = "rememberCB";
            this.rememberCB.Size = new System.Drawing.Size(216, 16);
            this.rememberCB.TabIndex = 3;
            this.rememberCB.Text = "之后再碰到这种情况都执行这个动作";
            this.rememberCB.UseVisualStyleBackColor = true;
            // 
            // msgLabel
            // 
            this.msgLabel.AutoSize = true;
            this.msgLabel.Location = new System.Drawing.Point(12, 72);
            this.msgLabel.Name = "msgLabel";
            this.msgLabel.Size = new System.Drawing.Size(353, 12);
            this.msgLabel.TabIndex = 4;
            this.msgLabel.Text = "上面的文件（点击可以打开所在的目录）已经存在，可以覆盖么？";
            // 
            // filePathLabel
            // 
            this.filePathLabel.AccessibleDescription = "";
            this.filePathLabel.AutoEllipsis = true;
            this.filePathLabel.Location = new System.Drawing.Point(12, 9);
            this.filePathLabel.Name = "filePathLabel";
            this.filePathLabel.Size = new System.Drawing.Size(359, 63);
            this.filePathLabel.TabIndex = 5;
            this.filePathLabel.TabStop = true;
            this.filePathLabel.Text = "D:\\Program Files (x86)\\网站下载器\\已经下载完的网站\\深渊\\v4\\uri.xdcdn.net\\syk\\tree\\3ab907a958b941" +
                "d229c4988173016223d0a7614d";
            this.filePathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HasFileMsgBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 163);
            this.Controls.Add(this.filePathLabel);
            this.Controls.Add(this.msgLabel);
            this.Controls.Add(this.rememberCB);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Name = "HasFileMsgBox";
            this.Text = "发现同名文件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.CheckBox rememberCB;
        private System.Windows.Forms.Label msgLabel;
        private System.Windows.Forms.LinkLabel filePathLabel;
    }
}