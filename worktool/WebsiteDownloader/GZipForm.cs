using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebsiteDownloader
{
    public partial class GZipForm : Form
    {
        public GZipForm()
        {
            InitializeComponent();
        }

        private void GZipForm_Load(object sender, EventArgs e)
        {
        }

        private void GZipForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void GZipForm_DragDrop(object sender, DragEventArgs e)
        {

            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int len = fileList.Length;
            for (int i = 0; i < len; i++)
            {
                string filePath = fileList[i].Trim();
                if (filePath == "") continue;

                if (File.Exists(filePath))
                {
                    this.decompressFile(filePath, this.backupCB.Checked);
                }
                else if (Directory.Exists(filePath))
                {
                    this.decompressFolder(filePath, this.backupCB.Checked);
                }
                else
                {
                    this.addLog("未知文件（是文件，也不是文件夹：）" + filePath);
                }
            }
        }

        private void addLog(string log)
        {
            this.logTxt.AppendText(log + "\r\n");
        }

        /// <summary>
        /// 解压整个目录的文件
        /// </summary>
        /// <param name="path"></param>
        private void decompressFolder(string path, bool isBackup)
        {
            if (!Directory.Exists(path))
            {
                this.addLog(path + "不是文件夹");
                return;
            }

            DirectoryInfo dir = new DirectoryInfo(path);
            if(isBackup){
                string bakFolderName = this.getBakFolderName(path);
                if(bakFolderName == null){
                    this.addLog("因为无法正确得到备份文件夹名字(测试的重名次数超过五十次),所以中止了解压操作，请你检查后再试！");
                    return;
                }else{
                    this.processDir(dir,true,path.Length,bakFolderName);
                }
            }else{
                this.processDir(dir);
            }  
        }

        /// <summary>
        /// 递归处理目录相关的事
        /// </summary>
        private void processDir(DirectoryInfo dir, bool isBackup = false, int rootlen = 0, string rootBakPath = null){

            FileInfo[] files = dir.GetFiles();
            int len = files.Length;
            for (int i = 0; i < len; i++)
            {
                if (isBackup)
                {

                }
                else
                {

                }
            }
        }

        /// <summary>
        /// 解压单个文件
        /// </summary>
        /// <param name="path"></param>
        private void decompressFile(string path, bool isBackup)
        {
            if (!GZipTool.IsQZipFile(path))
            {
                this.addLog(path + "不是GZip文件!");
                return;
            }

            byte[] newFile = GZipTool.Decompress(path);

            string bakFileName = null;
            if (isBackup)bakFileName = this.backupFile(path);

            //写入解压的文件
            try
            {
                File.WriteAllBytes(path, newFile);
            }
            catch (Exception e)
            {
                this.addLog(e.ToString());

                //因为写入失败，所以就把文件删除了。
                if (bakFileName != null)
                {
                    File.Delete(bakFileName);
                }
            }

        }

        /// <summary>
        /// 备份旧名字
        /// </summary>
        /// <param name="path"></param>
        private string backupFile(string path)
        {
            if (!File.Exists(path)) return null;
            string newName = this.getBakFileName(path);
            if (newName == null)
            {
                this.addLog("Error:因为备份的名字被占用完，所以不有备份（" + path + ")");
                return null;
            }

            File.Copy(path, newName);
            return newName;
        }

        /// <summary>
        /// 得到备份的文件的新名字
        /// </summary>
        /// <param name="path"></param>
        /// <param name="tryCount"></param>
        /// <returns></returns>
        private string getBakFileName(string path, int tryCount = 0)
        {
            string newFile;
            if(tryCount == 0){
                newFile = path + ".bak";
            }else{
                newFile = path + "(" + tryCount + ").bak";
            }

            if (File.Exists(newFile))
            {
                if (tryCount > 50)
                {
                    return null;
                }

                return this.getBakFileName(path, tryCount++);
            }
            else
            {
                return newFile;
            }
        }

        /// <summary>
        /// 得到备份的文件夹的新名字
        /// </summary>
        /// <param name="path"></param>
        /// <param name="tryCount"></param>
        /// <returns></returns>
        private string getBakFolderName(string path, int tryCount = 0)
        {
            string newFolderName;
            if (tryCount == 0)
            {
                newFolderName = path + "_bak";
            }
            else
            {
                newFolderName = path + "(" + tryCount + ")_back";
            }

            if (Directory.Exists(newFolderName))
            {
                if (tryCount > 50)
                {
                    return null;
                }

                return this.getBakFolderName(path, tryCount++);
            }
            else
            {
                return newFolderName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HasFileMsgBox msgBox = new HasFileMsgBox();
            msgBox.ShowDialog();

            this.addLog("xxooooo");
        }
    }
}
