using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace WebDevServer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BootBtn_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(this.PathTxt.Text))
            {
                MessageBox.Show("物理路径目录不存在", "提示");
                return;
            }

            string webDevPath = Application.StartupPath + "\\WebDev.WebServer.EXE";

            if (!File.Exists(webDevPath))
            {
                MessageBox.Show("程序文件不完整,请确保WebDev.WebServer.EXE在应用程序目录下", "提示");
                return;
            }

            Process.Start(webDevPath, String.Format("/port:{0} /path:\"{1}\" \vpath:\"{2}\"", this.ProtNUD.Value, this.PathTxt.Text, this.VPathTxt.Text));

            this.Close();
        }

        private void GotoBlogBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("www.fanflash.org/?p=47");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
