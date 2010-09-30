namespace TSvnTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.projPathTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.filePathTxt = new System.Windows.Forms.TextBox();
            this.delFileBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // projPathTxt
            // 
            this.projPathTxt.Location = new System.Drawing.Point(14, 24);
            this.projPathTxt.Name = "projPathTxt";
            this.projPathTxt.Size = new System.Drawing.Size(499, 21);
            this.projPathTxt.TabIndex = 0;
            this.projPathTxt.Text = "E:\\project\\open source\\CFlashDevelop";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "项目目录：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "文件路径：";
            // 
            // filePathTxt
            // 
            this.filePathTxt.Location = new System.Drawing.Point(14, 72);
            this.filePathTxt.Multiline = true;
            this.filePathTxt.Name = "filePathTxt";
            this.filePathTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.filePathTxt.Size = new System.Drawing.Size(499, 371);
            this.filePathTxt.TabIndex = 3;
            this.filePathTxt.Text = resources.GetString("filePathTxt.Text");
            this.filePathTxt.WordWrap = false;
            // 
            // delFileBtn
            // 
            this.delFileBtn.Location = new System.Drawing.Point(357, 458);
            this.delFileBtn.Name = "delFileBtn";
            this.delFileBtn.Size = new System.Drawing.Size(75, 23);
            this.delFileBtn.TabIndex = 4;
            this.delFileBtn.Text = "删除";
            this.delFileBtn.UseVisualStyleBackColor = true;
            this.delFileBtn.Click += new System.EventHandler(this.delFileBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(438, 458);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "打包";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 492);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.delFileBtn);
            this.Controls.Add(this.filePathTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.projPathTxt);
            this.Name = "Form1";
            this.Text = "TSvnTool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox projPathTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox filePathTxt;
        private System.Windows.Forms.Button delFileBtn;
        private System.Windows.Forms.Button button2;


    }
}

