using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CopyUpdate
{
    public partial class MainForm : Form
    {

        private string[] filePaths;

        public MainForm(string[] args)
        {
            this.InitializeComponent();

            if (args.Length < 4) {

                //use for test;
                /*
	            args = new string[4];
	            args[0] = "E:\\project\\工作工具\\CopyUpdate\\bin\\Debug\\path.txt";
	            args[1] = "3";
	            args[2] = "E:\\project\\工作工具\\CopyUpdate\\bin\\Debug\\msg.txt";
	            args[3] = "E:\\project\\open source\\FlashDevelop\\FD3";
                 */
                return;
            }


            string path = args[0].ToString();       //有更新的路径
            int depth = int.Parse(args[1]);         //更新深度
            string msgPath = args[2].ToString();    //日志消息路径
            string cwdPath = args[3].ToString();    //当前工作路径

            this.initSelWorkFolder(cwdPath);
            this.readPath(path);
        }

        /// <summary>
        /// 初始化选择
        /// </summary>
        /// <param name="cwdPath"></param>
        private void initSelWorkFolder(string cwdPath){
            
            if(!Directory.Exists(cwdPath)){
                Console.Error.WriteLine("工作目录不存在,请重新提交!");
                this.selWorkFolder.Enabled = false;
                //this.Close();
                return;
            }

            this.selWorkFolder.Enabled = true;
            this.selWorkFolder.Items.Add(cwdPath);
            DirectoryInfo di = Directory.GetParent(cwdPath);
            while(di != null){
                this.selWorkFolder.Items.Add(di.FullName);
                di = di.Parent;
            }

            this.selWorkFolder.SelectedIndex = 0;
        }

        /// <summary>
        /// 读路径
        /// </summary>
        /// <param name="path"></param>
        private void readPath(string path){

            if(!File.Exists(path)){
                Console.Error.WriteLine("路径临时文件被删除了,请重新提交!");
                //this.Close();
                return;
            }

            string pathStr = File.ReadAllText(path,Encoding.Default);
            this.filePaths = pathStr.Split(new String[1]{"\r\n"},StringSplitOptions.RemoveEmptyEntries);

            //显示到更新文件列表
            int len = this.filePaths.Length;
            for (int i = 0; i < len;i++ ){
                this.updateFileList.Items.Add(this.filePaths[i]);
            }
        }

        /// <summary>
        /// 拷贝到某地方
        /// </summary>
        /// <param name="workDirPath"></param>
        /// <param name="copyToDirPath"></param>
        /// <param name="copyFileList"></param>
        private int copyTo(string workDirPath,string copyToDirPath,string[] copyFileList){

            if (copyFileList == null) return 1;
            if (!Directory.Exists(workDirPath)) return 2;
            if (!Directory.Exists(copyToDirPath)) return 3;

            int pathLen = workDirPath.Length;

            int totalNum = copyFileList.Length;
            int curNum = 1;
            
            foreach ( string path in copyFileList)
            {
                string tpath = path.Replace("/", "\\");
                string copyToPath = tpath.Replace(workDirPath, copyToDirPath);

                this.progressBar.Value = curNum / totalNum * 100;
                curNum++;
                
                if(File.Exists(tpath)){
                    string folder = Path.GetDirectoryName(copyToPath);
                    if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                    File.Copy(tpath, copyToPath,true);
                }else if(Directory.Exists(tpath)){
                    Directory.CreateDirectory(copyToPath);
                }else{
                    continue;
                }
            }

            return 0;
            
        }

        private void tickHandler(object sender, EventArgs e)
        {
            Console.WriteLine("xxoo");
        }

        private void copyBtn_Click(object sender, EventArgs e)
        {
            this.copyTo(this.selWorkFolder.Text, this.copyToFolderTxt.Text, this.filePaths);
            Console.Error.WriteLine("已经把修改的文件完全复制到" + this.copyToFolderTxt.Text + "了");
            this.Close();
        }

    }
}
