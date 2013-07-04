using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fiddler;
using System.Collections;
using System.IO;
using System.Diagnostics;

namespace WebsiteDownloader
{
    public partial class MainForm : Form
    {
        delegate void addLogCallback(string txt);

        private FiddlerCoreStartupFlags option;
        private Boolean isStart;

        public MainForm()
        {
            InitializeComponent();

            /*
                Fiddler.FiddlerCoreStartupFlags.RegisterAsSystemProxy |
                Fiddler.FiddlerCoreStartupFlags.DecryptSSL |
                Fiddler.FiddlerCoreStartupFlags.AllowRemoteClients |
                Fiddler.FiddlerCoreStartupFlags.ChainToUpstreamGateway | 
                Fiddler.FiddlerCoreStartupFlags.MonitorAllConnections | 
                Fiddler.FiddlerCoreStartupFlags.CaptureLocalhostTraffic
             */

            option = FiddlerCoreStartupFlags.Default;
            isStart = false;

            FiddlerApplication.BeforeResponse += new SessionStateHandler(FiddlerApplication_BeforeResponse);
        }

        void FiddlerApplication_BeforeResponse(Session oSession)
        {
            string url = oSession.url;
            int qIndex = url.IndexOf("?");
            if (qIndex > -1)
            {
                url = url.Substring(0, qIndex);
            }

            url = "WebsiteFile/" + url;
            qIndex = url.LastIndexOf("/");
            string path = url.Substring(0, qIndex);
            string name = url.Substring(qIndex + 1);

            if (name == "") return;

            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            File.WriteAllBytes(url, oSession.responseBodyBytes);
            this.addLog("保存了文件：" + url);
        }



        private void startBtn_Click(object sender, EventArgs e)
        {
            if (isStart)
            {
                FiddlerApplication.Shutdown();
                this.startBtn.Text = "开始";
            }
            else
            {
                FiddlerApplication.Startup((int)this.portNumber.Value, this.option);
                this.startBtn.Text = "停止";
            }

            isStart = !isStart;
           
        }

        public void addLog(string txt)
        {
            if (logTxt.InvokeRequired)
            {
                this.Invoke(new addLogCallback(this.addLog),new object[]{txt});
            }
            else
            {
                logTxt.AppendText(txt + "\n");
                logTxt.ScrollToCaret();
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            FiddlerApplication.Shutdown();
        }

        private void clearLogBtn_Click(object sender, EventArgs e)
        {
            this.logTxt.Text = "";
        }

        private void ClearIECacheBtn_Click(object sender, EventArgs e)
        {
            WinINETCache.ClearFiles();
        }

        private void helpBtn_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.fanflash.org");
        }

        private void openFolderBtn_Click(object sender, EventArgs e)
        {
            string path = System.Windows.Forms.Application.StartupPath + "\\WebsiteFile";
            if (!Directory.Exists(path))
            {
                path = System.Windows.Forms.Application.StartupPath;
            }
            Process.Start(path);
        }
    }
}
