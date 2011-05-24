namespace WebDevServer
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PathTxt = new System.Windows.Forms.TextBox();
            this.VPathTxt = new System.Windows.Forms.TextBox();
            this.PathSelBtn = new System.Windows.Forms.Button();
            this.ProtNUD = new System.Windows.Forms.NumericUpDown();
            this.BootBtn = new System.Windows.Forms.Button();
            this.GotoBlogBtn = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ProtNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "物理路径:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "虚拟路径:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "端口号:";
            // 
            // PathTxt
            // 
            this.PathTxt.Location = new System.Drawing.Point(78, 9);
            this.PathTxt.Name = "PathTxt";
            this.PathTxt.Size = new System.Drawing.Size(235, 21);
            this.PathTxt.TabIndex = 3;
            // 
            // VPathTxt
            // 
            this.VPathTxt.Location = new System.Drawing.Point(78, 37);
            this.VPathTxt.Name = "VPathTxt";
            this.VPathTxt.Size = new System.Drawing.Size(235, 21);
            this.VPathTxt.TabIndex = 4;
            // 
            // PathSelBtn
            // 
            this.PathSelBtn.Location = new System.Drawing.Point(320, 8);
            this.PathSelBtn.Name = "PathSelBtn";
            this.PathSelBtn.Size = new System.Drawing.Size(75, 23);
            this.PathSelBtn.TabIndex = 5;
            this.PathSelBtn.Text = "选择";
            this.PathSelBtn.UseVisualStyleBackColor = true;
            // 
            // ProtNUD
            // 
            this.ProtNUD.Location = new System.Drawing.Point(78, 64);
            this.ProtNUD.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.ProtNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ProtNUD.Name = "ProtNUD";
            this.ProtNUD.Size = new System.Drawing.Size(235, 21);
            this.ProtNUD.TabIndex = 8;
            this.ProtNUD.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // BootBtn
            // 
            this.BootBtn.Location = new System.Drawing.Point(319, 37);
            this.BootBtn.Name = "BootBtn";
            this.BootBtn.Size = new System.Drawing.Size(75, 49);
            this.BootBtn.TabIndex = 9;
            this.BootBtn.Text = "启动";
            this.BootBtn.UseVisualStyleBackColor = true;
            this.BootBtn.Click += new System.EventHandler(this.BootBtn_Click);
            // 
            // GotoBlogBtn
            // 
            this.GotoBlogBtn.AutoSize = true;
            this.GotoBlogBtn.Location = new System.Drawing.Point(221, 104);
            this.GotoBlogBtn.Name = "GotoBlogBtn";
            this.GotoBlogBtn.Size = new System.Drawing.Size(173, 12);
            this.GotoBlogBtn.TabIndex = 10;
            this.GotoBlogBtn.TabStop = true;
            this.GotoBlogBtn.Text = "help: www.fanflash.org/?p=47";
            this.GotoBlogBtn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GotoBlogBtn_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(413, 125);
            this.Controls.Add(this.GotoBlogBtn);
            this.Controls.Add(this.BootBtn);
            this.Controls.Add(this.ProtNUD);
            this.Controls.Add(this.PathSelBtn);
            this.Controls.Add(this.VPathTxt);
            this.Controls.Add(this.PathTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Asp.net虚拟机(v0.1)";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProtNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PathTxt;
        private System.Windows.Forms.TextBox VPathTxt;
        private System.Windows.Forms.Button PathSelBtn;
        private System.Windows.Forms.NumericUpDown ProtNUD;
        private System.Windows.Forms.Button BootBtn;
        private System.Windows.Forms.LinkLabel GotoBlogBtn;
    }
}

