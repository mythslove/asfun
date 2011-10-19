using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace FlashInterfaceViewer
{
    public partial class VersionForm : Form
    {
        public VersionForm()
        {
            InitializeComponent();
        }

        private void VersionForm_Load(object sender, EventArgs e)
        {

            //加载log信息
            WebClient wc = new WebClient();
            wc.DownloadStringAsync(new Uri("http://softdatadb.googlecode.com/svn/trunk/flash_interface_viewer/log/all.log"));
            wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);

            this.verLogTxt.Text = "正在加载全部的LOG信息...";
        }

        void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {

            WebClient wc = sender as WebClient;
            wc.DownloadStringCompleted -= this.wc_DownloadStringCompleted;

            try
            {
                this.verLogTxt.Text = e.Result;
            }
            catch
            {
                this.verLogTxt.Text = "下载日志时出错，可以过一会儿，再次打开这个窗口再次尝试。";
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
