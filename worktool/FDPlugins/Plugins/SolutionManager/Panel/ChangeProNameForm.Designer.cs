namespace SolutionManager.Panel
{
    partial class ChangeProNameForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.projPathTxt = new System.Windows.Forms.TextBox();
            this.projNameTxt = new System.Windows.Forms.TextBox();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "项目地址：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "项目名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "备注名：";
            // 
            // projPathTxt
            // 
            this.projPathTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.projPathTxt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.projPathTxt.Location = new System.Drawing.Point(74, 11);
            this.projPathTxt.Name = "projPathTxt";
            this.projPathTxt.ReadOnly = true;
            this.projPathTxt.Size = new System.Drawing.Size(311, 14);
            this.projPathTxt.TabIndex = 3;
            this.projPathTxt.WordWrap = false;
            // 
            // projNameTxt
            // 
            this.projNameTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.projNameTxt.Location = new System.Drawing.Point(74, 38);
            this.projNameTxt.Name = "projNameTxt";
            this.projNameTxt.ReadOnly = true;
            this.projNameTxt.Size = new System.Drawing.Size(311, 14);
            this.projNameTxt.TabIndex = 4;
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(74, 60);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(311, 21);
            this.nameTxt.TabIndex = 5;
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okBtn.Location = new System.Drawing.Point(310, 95);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 6;
            this.okBtn.Text = "确定";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(229, 95);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 7;
            this.cancelBtn.Text = "取消";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // ChangeProNameForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.cancelBtn;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(397, 130);
            this.ControlBox = false;
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.projNameTxt);
            this.Controls.Add(this.projPathTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeProNameForm";
            this.ShowInTaskbar = false;
            this.Text = "更改项目备注名";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ChangeProNameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox projPathTxt;
        private System.Windows.Forms.TextBox projNameTxt;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}