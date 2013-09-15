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
using System.Net;
using System.Threading;

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
            lock (this)
            {
                Log.Start(oSession.url);
                string url = oSession.url;
                int qIndex = url.IndexOf("?");
                if (qIndex > -1)
                {
                    url = url.Substring(0, qIndex);
                }

                //有些网址是是类似http://www.baidu.com/，这样的网址没有名字，但我要给他一个默认名
                if (url.Substring(url.Length - 1) == "/")
                {
                    url += "index.html";
                }

                url = url.Replace(":", "：");
                url = "WebsiteFile/" + url;
                qIndex = url.LastIndexOf("/");
                string path = url.Substring(0, qIndex);
                string name = url.Substring(qIndex + 1);
                Log.SetSavePath(url);

                if (name == "")
                {
                    Log.SetResponse(false, "没解析出文件名!");
                    Log.END();
                    this.addLog(Log.GetLog());
                    return;
                }


                byte[] data = oSession.ResponseBody;
                if (data == null || data.Length < 1)
                {
                    Log.SetResponse(false, "文件大小为0!");
                    Log.END();
                    this.addLog(Log.GetLog());
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
                        Log.SetResponse(false, e.Message);
                        Log.END();
                        this.addLog(Log.GetLog());
                        return;
                    }
                }

                try
                {
                    if (autoDezipMI.Checked && GZipTool.IsGZipFile(oSession))
                    {
                        data = GZipTool.Decompress(data);
                        File.WriteAllBytes(url, data);
                        Log.SetResponse(true, "文件使用了GZip解压缩");
                    }
                    else
                    {
                        File.WriteAllBytes(url, data);
                        Log.SetResponse(true);
                    }
                }
                catch (Exception e)
                {
                    Log.SetResponse(false,e.Message);
                    Log.END();
                    this.addLog(Log.GetLog());
                    return;
                }

                Log.END();
                this.addLog(Log.GetLog());
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
                if (autoClearIECacheMI.Checked)
                {
                    WinINETCache.ClearFiles();
                }
                
                FiddlerApplication.Startup((int)this.portNumber.Value, this.option);
                this.startBtn.Text = "停止";
            }

            isStart = !isStart;
        }


        private bool isFrist = true;

        public void addLog(string txt)
        {
            if (logTxt.InvokeRequired)
            {
                this.Invoke(new addLogCallback(this.addLog),new object[]{txt});
            }
            else
            {
                
                string log = txt + "\r\n";

                if (autoSaveLogMI.Checked)
                {
                    string logPath = "WebsiteFile/DownloadFileLog.txt";
                    if (isFrist)
                    {
                        isFrist = false;
                        File.Delete(logPath);
                    }

                    
                    File.AppendAllText(logPath, log, Encoding.UTF8);
                }
                
                logTxt.AppendText(log);
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

    public enum LogState
    {
        [Description("还没有开始记录状态")]
        NONE,

        [Description("开始记录")]
        START,

        [Description("记录保存路径")]
        PATH,

        [Description("处理结果")]
        RESPONSE,
    }


    public class Log
    {
        private static LogState state = LogState.NONE;
        private static string logStr;

        /// <summary>
        /// 开始处理一个新的网址
        /// </summary>
        /// <param name="url"></param>
        public static void Start(string url)
        {
            verifyStage(LogState.NONE);
            logStr = "捕获URL: " + url + "\r\n";
            state = LogState.START;
        }

        /// <summary>
        /// 设置保存路径
        /// </summary>
        /// <param name="path"></param>
        public static void SetSavePath(string path)
        {
            verifyStage(LogState.START);
            logStr += "保存路径: " + path + "\r\n";
            state = LogState.PATH;
        }

        /// <summary>
        /// 设置处理结果
        /// </summary>
        /// <param name="isOK"></param>
        /// <param name="info"></param>
        public static void SetResponse(bool isOK, string info = null)
        {
            verifyStage(LogState.PATH);
            if (isOK)
            {
                logStr += "处理结果: 成功\r\n";
                if (info != null)
                {
                    logStr += "附带信息: " + info + "\r\n"; 
                }
            }
            else
            {
                logStr += "处理结果: 失败\r\n";
                if (info != null)
                {
                    logStr += "失败原因：" + info + "\r\n";
                }
            }
            state = LogState.RESPONSE;
        }

        /// <summary>
        /// 处理结束
        /// </summary>
        public static void END()
        {
            verifyStage(LogState.RESPONSE);
            logStr += "-----------------------------\r\n";
            state = LogState.NONE;
        }

        /// <summary>
        /// 得到处log信息
        /// </summary>
        /// <returns></returns>
        public static string GetLog()
        {
            verifyStage(LogState.NONE);
            return logStr;
        }

        /// <summary>
        /// 验证状态
        /// </summary>
        /// <param name="rightState">正确的状态</param>
        private static void verifyStage(LogState rightState)
        {
            if (state != rightState)
            {
                throw new Exception("执行错误!");
            }
        }
    }
}
