using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Collections;

namespace WebsiteDownload
{
    public partial class Form1 : Form
    {

        private WebClient downloader;
        private int downIndex;
        private string curDownloadURL;
        private string websiteURL;

        public Form1()
        {
            InitializeComponent();
            this.init();
        }

        private void init()
        {
            this.downloader = new WebClient();
            this.downloader.DownloadFileCompleted += new AsyncCompletedEventHandler(downloader_DownloadFileCompleted);
            this.downloader.DownloadProgressChanged += new DownloadProgressChangedEventHandler(downloader_DownloadProgressChanged);

            this.websiteURL = "3dtank.com";
        }


        /// <summary>
        /// 得到所有资源的链接
        /// </summary>
        /// <param name="siteUrl"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private string[] getResUrlList(string siteUrl, string content)
        {
            MatchCollection matches = Regex.Matches(content, "http://.*" + siteUrl + "/.*\r\n", RegexOptions.Multiline | RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase);
            string[] list = new string[matches.Count];
            int i = 0;
            foreach (Match item in matches)
            {
                list[i++] = item.Value.Substring(0, item.Value.Length - 2);
            }
            return list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.startDownLoad();
        }


        private void setData(string[] data) {

            int length = data.Length;
            for (int i = 0; i < length; i++) {
                this.fileListBox.Items.Add(data[i]);
            }
        }

        private void startDownLoad() {


            if (!Directory.Exists(this.savePathTxt.Text)) {
                this.showMsg("目录不合法，请检查目录");
                this.savePathTxt.Focus();
                return;
            }

            if (!Regex.IsMatch(this.urlTxt.Text, @"^[0-9a-zA-Z]+\.[a-zA-Z]+$")) {
                this.showMsg("网站址名错误，请检查网站域名，如http://www.test.fanfalsh.cn，只要输入fanflash.cn即可，不需要全部输入！");
                this.urlTxt.Focus();
                return;
            }

            this.websiteURL = this.urlTxt.Text;
            string[] list = this.getResUrlList(this.websiteURL, this.cacheTxt.Text);
            if (list.Length < 1)
            {
                this.showMsg("你的Firefox缓存数据中没有你要找的资源，请确认后重新输入缓存数据");
                return;
            }

            this.fileListBox.Items.Clear();

            this.cacheTxt.Enabled = false;
            this.savePathTxt.Enabled = false;
            this.selFolderBtn.Enabled = false;
            this.urlTxt.Enabled = false;
            this.downloadBtn.Enabled = false;

            this.setData(list);
            this.downIndex = 0;
           
            this.doDownload();
        }

        private void showMsg(string info) {
            MessageBox.Show(info, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void doDownload()
        {
            if (this.downIndex > (this.fileListBox.Items.Count - 1))
            {
                this.onAllDownloaded();
                return;
            }
            string url = (string)this.fileListBox.Items[this.downIndex];
            this.curDownloadURL = url;

            int endIndex = url.IndexOf("?");
            if(endIndex<0)endIndex = url.Length;
            int startIndex = url.IndexOf(this.websiteURL) + this.websiteURL.Length;

            string filePath = this.savePathTxt.Text + url.Substring(startIndex, endIndex - startIndex);
            string dir = filePath.Substring(0, filePath.LastIndexOf("/"));
            Directory.CreateDirectory(dir);

            this.downloader.DownloadFileAsync(new Uri(url), filePath);
            this.fileListBox.Items[this.downIndex] = "(正在下载)" + this.curDownloadURL;
            this.fileListBox.TopIndex = this.downIndex;
        }

        void downloader_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {

            if (e.Error == null)
            {
                this.fileListBox.Items[this.downIndex] = "(已下载)" + this.curDownloadURL;
                
            }
            else
            {
                this.fileListBox.Items[this.downIndex] = "(失败)" + this.curDownloadURL;
            }

            this.downIndex++;
            this.doDownload();
            this.progressBar.Value = 0;
        }

        void downloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.progressBar.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// 全部下载完了
        /// </summary>
        void onAllDownloaded()
        {
            this.cacheTxt.Enabled = true;
            this.savePathTxt.Enabled = true;
            this.selFolderBtn.Enabled = true;
            this.urlTxt.Enabled = true;
            this.downloadBtn.Enabled = true;

            MessageBox.Show("全部下载完了", "提示");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "选择你要保存的目录";
            fbd.SelectedPath = this.savePathTxt.Text;
            fbd.ShowDialog();
            this.savePathTxt.Text = fbd.SelectedPath;
        }

        private void cacheTxt_DoubleClick(object sender, EventArgs e)
        {
            this.cacheTxt.Text = "";
        }

        private void cacheTxt_TextChanged(object sender, EventArgs e)
        {

            this.urlTxt.Items.Clear();
            MatchCollection matches = Regex.Matches(this.cacheTxt.Text, @"[0-9a-zA-Z]+\.(com|net|org|cn|mobi|name|tv|cc|hk|biz|info)", RegexOptions.Multiline | RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase);
            Hashtable map = new Hashtable();

            foreach (Match item in matches)
            {
                if (map[item.Value] == null)
                {
                    this.urlTxt.Items.Add(item.Value);
                    map[item.Value] = true;
                }
               
            }
        }

        /// <summary>
        /// 加载缓存文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadCacheBtn_Click(object sender, EventArgs e)
        {
            if (!File.Exists(this.cacheFileTxt.Text))
            {
                MessageBox.Show("你输入的文件路径错误", "提示");
                return;
            }

            string data = File.ReadAllText(this.cacheFileTxt.Text);
            this.cacheTxt.MaxLength = data.Length + 1000;
            this.cacheTxt.Text = data;

            MessageBox.Show("文本长度为：" + data.Length, "提示");
            
        }
    }
}
