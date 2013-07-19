namespace WebsiteDownloader
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
            this.portNumber = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.startBtn = new System.Windows.Forms.Button();
            this.helpBtn = new System.Windows.Forms.Button();
            this.clearLogBtn = new System.Windows.Forms.Button();
            this.ClearIECacheBtn = new System.Windows.Forms.Button();
            this.logTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.responseNumber = new System.Windows.Forms.NumericUpDown();
            this.requestNumber = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.portNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.responseNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // portNumber
            // 
            this.portNumber.Location = new System.Drawing.Point(86, 12);
            this.portNumber.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.portNumber.Name = "portNumber";
            this.portNumber.Size = new System.Drawing.Size(70, 21);
            this.portNumber.TabIndex = 0;
            this.portNumber.Value = new decimal(new int[] {
            6698,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "端口号：";
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(213, 12);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 75);
            this.startBtn.TabIndex = 2;
            this.startBtn.Text = "开始";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // helpBtn
            // 
            this.helpBtn.Location = new System.Drawing.Point(456, 12);
            this.helpBtn.Name = "helpBtn";
            this.helpBtn.Size = new System.Drawing.Size(75, 75);
            this.helpBtn.TabIndex = 6;
            this.helpBtn.Text = "帮助";
            this.helpBtn.UseVisualStyleBackColor = true;
            this.helpBtn.Click += new System.EventHandler(this.helpBtn_Click);
            // 
            // clearLogBtn
            // 
            this.clearLogBtn.Location = new System.Drawing.Point(375, 12);
            this.clearLogBtn.Name = "clearLogBtn";
            this.clearLogBtn.Size = new System.Drawing.Size(75, 75);
            this.clearLogBtn.TabIndex = 10;
            this.clearLogBtn.Text = "清空log";
            this.clearLogBtn.UseVisualStyleBackColor = true;
            this.clearLogBtn.Click += new System.EventHandler(this.clearLogBtn_Click);
            // 
            // ClearIECacheBtn
            // 
            this.ClearIECacheBtn.Location = new System.Drawing.Point(294, 12);
            this.ClearIECacheBtn.Name = "ClearIECacheBtn";
            this.ClearIECacheBtn.Size = new System.Drawing.Size(75, 75);
            this.ClearIECacheBtn.TabIndex = 11;
            this.ClearIECacheBtn.Text = "清空IE缓存";
            this.ClearIECacheBtn.UseVisualStyleBackColor = true;
            this.ClearIECacheBtn.Click += new System.EventHandler(this.ClearIECacheBtn_Click);
            // 
            // logTxt
            // 
            this.logTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.logTxt.Location = new System.Drawing.Point(13, 96);
            this.logTxt.Multiline = true;
            this.logTxt.Name = "logTxt";
            this.logTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logTxt.Size = new System.Drawing.Size(517, 269);
            this.logTxt.TabIndex = 7;
            this.logTxt.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "上传速度:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "下载速度:";
            // 
            // responseNumber
            // 
            this.responseNumber.Location = new System.Drawing.Point(86, 39);
            this.responseNumber.Maximum = new decimal(new int[] {
            10240,
            0,
            0,
            0});
            this.responseNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.responseNumber.Name = "responseNumber";
            this.responseNumber.Size = new System.Drawing.Size(70, 21);
            this.responseNumber.TabIndex = 14;
            this.responseNumber.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.responseNumber.ValueChanged += new System.EventHandler(this.responseNumber_ValueChanged);
            // 
            // requestNumber
            // 
            this.requestNumber.Location = new System.Drawing.Point(86, 66);
            this.requestNumber.Maximum = new decimal(new int[] {
            10240,
            0,
            0,
            0});
            this.requestNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.requestNumber.Name = "requestNumber";
            this.requestNumber.Size = new System.Drawing.Size(70, 21);
            this.requestNumber.TabIndex = 15;
            this.requestNumber.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.requestNumber.ValueChanged += new System.EventHandler(this.requestNumber_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(162, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "kb/s";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(162, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "kb/s";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 374);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.logTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ClearIECacheBtn);
            this.Controls.Add(this.requestNumber);
            this.Controls.Add(this.clearLogBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.responseNumber);
            this.Controls.Add(this.helpBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.portNumber);
            this.MinimumSize = new System.Drawing.Size(558, 412);
            this.Name = "MainForm";
            this.Text = "网速模拟器（by www.fanflash.org）";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.portNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.responseNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown portNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button helpBtn;
        private System.Windows.Forms.Button clearLogBtn;
        private System.Windows.Forms.Button ClearIECacheBtn;
        private System.Windows.Forms.TextBox logTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown responseNumber;
        private System.Windows.Forms.NumericUpDown requestNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

