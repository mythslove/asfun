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

            FiddlerApplication.BeforeRequest += new SessionStateHandler(FiddlerApplication_BeforeRequest);
        }

        void FiddlerApplication_BeforeRequest(Session oSession)
        {
            oSession["request-trickle-delay"] = this.requestDelay;
            oSession["response-trickle-delay"] = this.responseDelay;
            this.addLog(oSession.url);
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
            Process.Start("www.fanflash.org");
        }

        private string responseDelay;
        private void responseNumber_ValueChanged(object sender, EventArgs e)
        {
            this.responseDelay = Math.Round(1000 / this.responseNumber.Value).ToString();
        }

        private string requestDelay;
        private void requestNumber_ValueChanged(object sender, EventArgs e)
        {
            this.requestDelay = Math.Round(1000 / this.requestNumber.Value).ToString();
        }


        private void delayTimeUpdate()
        {
            this.responseNumber_ValueChanged(null, null);
            this.requestNumber_ValueChanged(null, null);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.delayTimeUpdate();
        }


    }
}
