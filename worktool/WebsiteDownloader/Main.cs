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

            //有些网址是是类似http://www.baidu.com/，这样的网址没有名字，但我要给他一个默认名
            string tt = url.Substring(url.Length - 2);
            if (url.Substring(url.Length - 1) == "/")
            {
                this.addLog(LogType.TIPS, "因为URL\"" + url + "\"没有找到文件名，所以使用默认文件名\"index.html\""); 
                url += "index.html";
            }

            url = url.Replace(":", "：");
            url = "WebsiteFile/" + url;
            qIndex = url.LastIndexOf("/");
            string path = url.Substring(0, qIndex);
            string name = url.Substring(qIndex + 1);

            if (name == ""){
                this.addLog(LogType.ERROR, "没解析出文件名，地址是：" + url);
                return;
            }

            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception e)
                {
                    this.addLog(LogType.ERROR, e.Message + ", 地址是：" + url);
                    return;
                }
            }

            try
            {

                byte[] data = oSession.responseBodyBytes;
                if (autoDezipMI.Checked && GZipTool.IsGZipFile(data))
                {
                    data = GZipTool.Decompress(data);
                    File.WriteAllBytes(url, data);
                    this.addLog("保存了文件：" + url + "(GZip)");
                }
                else
                {
                    File.WriteAllBytes(url, data);
                    this.addLog("保存了文件：" + url);
                }

            }
            catch (Exception e)
            {
                this.addLog(LogType.ERROR, e.Message + ", 地址是：" + url);
                return;
            }
            
            
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

        public void addLog(LogType type, string txt)
        {
            switch (type)
            {
                case LogType.NONE:
                    this.addLog(txt);
                    break;

                case LogType.ERROR:
                    this.addLog("错误:" + txt);
                    break;

                case LogType.TIPS:
                    this.addLog("提示:" + txt);
                    break;
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

        private void openFolderBtn_Click(object sender, EventArgs e)
        {
            string path = System.Windows.Forms.Application.StartupPath + "\\WebsiteFile";
            if (!Directory.Exists(path))
            {
                path = System.Windows.Forms.Application.StartupPath;
            }
            Process.Start(path);
        }

        private void visitBlogBtn_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.fanflash.org");
            
        }

        private void decodeGzipFileBtn_Click(object sender, EventArgs e)
        {
            GZipForm newForm = new GZipForm();
            newForm.ShowDialog(this);
        }

    }


    public enum LogType
    {
        [Description("普通的")]
        NONE,

        [Description("错误")]
        ERROR,

        [Description("提示")]
        TIPS
    }
}
