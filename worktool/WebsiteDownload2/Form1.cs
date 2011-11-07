using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using System.Net;

namespace WebsiteDownload2
{
    public partial class Form1 : Form
    {
        private WebClient downloader;
        public List<DownloadItem> downloadList;
        public List<DownloadItem> filteredDownloadList;
        public int downIndex;
        public string curDownloadURL;
        public string savePathStr;

        public Form1()
        {
            InitializeComponent();

            this.downloader = new WebClient();
            this.downloader.DownloadFileCompleted += new AsyncCompletedEventHandler(downloader_DownloadFileCompleted);
            this.downloader.DownloadProgressChanged += new DownloadProgressChangedEventHandler(downloader_DownloadProgressChanged);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.readListFile(false);
        }

        private bool readListFile(bool isShowError)
        {

            if (!File.Exists(this.listFilePathTxt.Text))
            {
                if (isShowError) this.showMsg("你输入的【下载列表文件】路径错误！");
                return false;
            }

            string data = File.ReadAllText(this.listFilePathTxt.Text);
            this.listFileTxt.MaxLength = data.Length + 1000;
            this.listFileTxt.Text = data;

            return this.processURL();
        }

        /// <summary>
        /// 处理文本框内的URL
        /// </summary>
        /// <returns></returns>
        public bool processURL()
        {

            string data = this.listFileTxt.Text;
            this.domainList.Items.Clear();

            string[] list = data.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (list.Length < 1) return false;


            this.downloadList = new List<DownloadItem>();
            Hashtable urlMap = new Hashtable();
            Hashtable domainMap = new Hashtable();
            int autoCreateCount = 0;

            foreach (string url in list)
            {
                //去除重复项
                if (urlMap[url] != null) continue;
                urlMap[url] = true;

                //://[\w-]+\.[\w.-]+
                Match m = Regex.Match(url, "(?<=://)[\\w-]+\\.[\\w.-]+");
                if (!m.Success) continue;

                DownloadItem item = new DownloadItem();
                item.url = url;
                item.domain = m.Value;

                if (domainMap[item.domain] == null)
                {
                    domainMap[item.domain] = true;
                    this.domainList.Items.Add(item.domain);
                }

                int startIndex = m.Index + item.domain.Length;
                int endIndex = url.IndexOf("?", startIndex);
                if (endIndex < 0) endIndex = url.Length;

                string tPath = url.Substring(startIndex, endIndex - startIndex);
                int nameIndex = tPath.LastIndexOf("/");
                if (nameIndex < 0)
                {
                    nameIndex = tPath.Length;
                    tPath += "/index_ac" + autoCreateCount.ToString() + ".html";
                    autoCreateCount++;
                }
                else if (nameIndex == (tPath.Length - 1))
                {
                    tPath += "index_ac" + autoCreateCount.ToString() + ".html";
                    autoCreateCount++;
                }


                item.folder = item.domain + tPath.Substring(0, nameIndex);
                item.filePath = item.domain + tPath;
                this.downloadList.Add(item);
            }

            this.downloadItemList.Items.Clear();

            return true;
        }

        public void startDownload()
        {
            if (!Directory.Exists(this.savePathTxt.Text))
            {
                this.showMsg("目录不存在，请检查目录");
                this.savePathTxt.Focus();
                return;
            }

            if (this.downloadList.Count < 1)
            {
                this.showMsg("没有要下载的文件");
                return;
            }

            Hashtable t = new Hashtable();
            int len = this.domainList.Items.Count;
            for (int i = 0; i < len; i++)
            {
                t[this.domainList.Items[i].ToString()] = this.domainList.GetItemChecked(i);
            }

            this.filteredDownloadList = new List<DownloadItem>();
            len = this.downloadList.Count;
            for (int i = 0; i < len; i++)
            {
                DownloadItem item = this.downloadList[i];
                if ((bool)t[item.domain]) this.filteredDownloadList.Add(item);
            }


            //又正向的顺序加入待下载列表
            this.downloadItemList.Items.Clear();
            len = this.filteredDownloadList.Count;
            if (len < 1)
            {
                this.showMsg("没有要下载的文件");
                return;
            }

            this.savePathStr = this.savePathTxt.Text.Replace('\\', '/') + "/";


            for (int i = 0; i < len; i++)
            {
                this.downloadItemList.Items.Add(this.filteredDownloadList[i].url);
            }

            //正式开始下载
            this.downIndex = 0;

            bool enabled = false;
            this.listFilePathTxt.Enabled = enabled;
            this.loadUrlFileBtn.Enabled = enabled;
            this.savePathTxt.Enabled = enabled;
            this.processBtn.Enabled = enabled;
            this.downloadBtn.Enabled = enabled;
            this.listFileTxt.Enabled = enabled;
            this.domainList.Enabled = enabled;

            this.doDownload();
        }

        public void doDownload()
        {
            if (this.downIndex > (this.filteredDownloadList.Count - 1))
            {
                this.onAllDownloaded();
                return;
            }

            DownloadItem item = this.filteredDownloadList[this.downIndex];
            this.curDownloadURL = item.url;

            string filePath = this.savePathStr + item.filePath;
            string dir = this.savePathStr + item.folder;
            Directory.CreateDirectory(dir);

            this.downloader.DownloadFileAsync(new Uri(item.url), filePath);
            this.downloadItemList.Items[this.downIndex] = "(正在下载)" + this.curDownloadURL;
            this.downloadItemList.TopIndex = this.downIndex;
        }

        /// <summary>
        /// 全部下载完了
        /// </summary>
        void onAllDownloaded()
        {
            bool enabled = true;
            this.listFilePathTxt.Enabled = enabled;
            this.loadUrlFileBtn.Enabled = enabled;
            this.savePathTxt.Enabled = enabled;
            this.processBtn.Enabled = enabled;
            this.downloadBtn.Enabled = enabled;
            this.listFileTxt.Enabled = enabled;
            this.domainList.Enabled = enabled;

            MessageBox.Show("全部下载完了", "提示");
        }


        private void showMsg(string info)
        {
            MessageBox.Show(info, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void processBtn_Click(object sender, EventArgs e)
        {
            this.processURL();
        }

        private void loadUrlFileBtn_Click(object sender, EventArgs e)
        {
            this.readListFile(true);
        }

        private void downloadBtn_Click(object sender, EventArgs e)
        {
            this.startDownload();
        }

        void downloader_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {

            if (e.Error == null)
            {
                this.downloadItemList.Items[this.downIndex] = "(已下载)" + this.curDownloadURL;

            }
            else
            {
                this.downloadItemList.Items[this.downIndex] = "(失败)" + this.curDownloadURL;
            }

            this.downIndex++;
            this.doDownload();
            this.progressBar.Value = 0;
        }

        void downloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.progressBar.Value = e.ProgressPercentage;
        }
    }

    public class DownloadItem
    {
        public string url;
        public string domain;
        public string folder;
        public string filePath;
    }
}