using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Resources;
using System.Collections;
using System.Net;
using System.Diagnostics;
using System.Runtime.InteropServices;
using MSScriptControl;

namespace FlashInterfaceViewer
{
    public partial class FIVForm : Form
    {

        private ConfigReader cr;
        public string appName = "Flash接口查看器";
        private GfxPlayerInfo[] curPlayerList;

        public FIVForm()
        {
            InitializeComponent();
            this.initUI();
        }

        private void initUI()
        {
            this.eventTestPage.Parent = null;
            //this.scriptTxt.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.checkVersion();
            this.cr = new ConfigReader();
        }

        private void openFileMI_Click(object sender, EventArgs e)
        {
            
#if DEBUG
            this.setPath("flashinterface.txt");
#else

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择配置文件";
            ofd.Filter = "flash接口配置文件(*.txt)|*.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.setPath(ofd.FileName);
            }

#endif

        }


        private void setPath(string filePath)
        {
            
            this.cr.setPath(filePath);
            if (!this.cr.isReaded) return;
            if (this.cr.groupList == null)
            {
                MessageBox.Show("配置文件的格式可能错误，请检查后再打开", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.configTree.BeginUpdate();
            this.configTree.Nodes.Clear();
            
            int groupLen = this.cr.groupList.Length;
            for (int i = 0; i < groupLen; i++)
            {
                GroupNode gn = new GroupNode();
                gn.setData(this.cr.groupList[i]);
                this.configTree.Nodes.Add(gn);
            }

            this.configTree.EndUpdate();
        }

        private void updatePlayerList() {

            /*
             * 不使用这种查找方式，因为有时间会找不到目标窗口
            //this.curPlayerList = Process.GetProcessesByName("FxPlayer_D3D9_Debug");
            Process[] t = Process.GetProcesses();
            this.curPlayerList.Clear();
            foreach (Process p in t)
            {
                if (p.MainWindowTitle.IndexOf("Scaleform GFxPlayer") == 0)
                {
                    this.curPlayerList.Add(p);
                }
            }
             */

            this.curPlayerList = GfxPlayerTool.getAllPlayer();
            
            this.playerList.Items.Clear();
            int len = this.curPlayerList.Length;

            for (int i = 0; i < len; i++)
            {
                GfxPlayerInfo info = this.curPlayerList[i];
                this.playerList.Items.Add(info.windowsName);
            }

            if (len > 0)
            {
                this.playerList.SelectedIndex = 0;
            }

        }

        private void sendTestMsg()
        {
            if (this.playerList.SelectedIndex < 0)
            {
                this.updatePlayerList();
                if (this.playerList.SelectedIndex < 0)
                {
                    MessageBox.Show("你还未打开播放器!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }

            GfxPlayerInfo player = this.curPlayerList[this.playerList.SelectedIndex];
            if (player.hasExited())
            {
                this.updatePlayerList();
                MessageBox.Show("你选择的播放器已经关闭，已为你刷新了播放器列表，请重新选择!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            //事件名|类型,值长度|值
            string sendData;
            EventNode node = this.configTree.SelectedNode as EventNode;
            sendData = node.data.name;
            if (node.data.paramList != null && node.data.paramList.Length > 0)
            {
                sendData += "," + node.data.paramList.Length + "|";

                int len = node.data.paramList.Length;
                for (int i = 0; i < len; i++)
                {
                    string type = this.paramList.Rows[i].Cells[1].Value as string;
                    if (type == "JsonString") type = "String";
                    string value = this.paramList.Rows[i].Cells[2].Value as string;
                    //sendData += type + "," + value.Length.ToString() + "|" + value; <---这在VC读取的时候出错了。
                    sendData += type + "," + Encoding.Default.GetBytes(value).Length.ToString() + "|" + value;
                    
                }
            }
            


            //播放器窗口句柄
            IntPtr hwndRecvWindow = player.hwnd;

            //自己窗口的句柄
            IntPtr hwndSendWindow = Process.GetCurrentProcess().MainWindowHandle;


            //填充COPYDATA结构
            ImportFromDLL.COPYDATASTRUCT copydata = new ImportFromDLL.COPYDATASTRUCT();

            //得是字节的长度
            copydata.cbData = Encoding.Default.GetBytes(sendData).Length;
            copydata.lpData = sendData;

            ImportFromDLL.SendMessage(hwndRecvWindow, ImportFromDLL.WM_COPYDATA, hwndSendWindow, ref copydata);

        }

        private void expandAllBtn_Click(object sender, EventArgs e)
        {
            this.configTree.ExpandAll();
        }

        private void collapseAllBtn_Click(object sender, EventArgs e)
        {
            this.configTree.CollapseAll();
        }

        private bool keepOpenEventTestPage = false;
        private void configTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            ConfigTreeNode ctn = e.Node as ConfigTreeNode;
            this.descTxt.Text = ctn.getInfo();
            this.asCodeTxt.Text = ctn.getAsCode();

            if (ctn is EventNode)
            {
                if(this.eventTestPage.Parent == null)this.eventTestPage.Parent = this.tabControl;

                EventNode en = ctn as EventNode;
                en.updateDataGrid(this.paramList);
                this.eventInfoTxt.Text = en.getInfo(false);

                if (keepOpenEventTestPage)
                {
                    this.tabControl.SelectedIndex = 2;
                }
                
            }
            else
            {
                this.eventTestPage.Parent = null;

                if (ctn is FunInfo && this.keepOpenEventTestPage) this.keepOpenEventTestPage = false;
            }
        }


        private void FIVForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void FIVForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);
            string path = paths[0];

            if (Path.GetExtension(path) != ".txt")
            {
                MessageBox.Show("这不是一个配置文件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.setPath(path);
        }



        ////////////////////////////////////////////////////////////////////////
        //                        帮助相关
        ////////////////////////////////////////////////////////////////////////

        private void submitButMI_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请91U联系高帆","提交BUG");
        }

        private void useInfoIM_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Properties.Resources.help,"帮助");
        }

        private void checkVersion()
        {

            string aname = Path.GetFileName(Application.ExecutablePath);
            if ( aname.LastIndexOf("_nc") == (aname.Length - 7)) return;

            this.Text = this.appName + "（检查更新中...）";

            WebClient wc = new WebClient();
            wc.DownloadStringAsync(new Uri("http://softdatadb.googlecode.com/svn/trunk/flash_interface_viewer/version.txt"));
            wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
        }

        /// <summary>
        ///  版本号下载完
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {

            WebClient wc = sender as WebClient;
            wc.DownloadStringCompleted -= this.wc_DownloadStringCompleted;

            try
            {
                string newVersionStr = e.Result;

                string t = newVersionStr.Replace(".", "");
                int newVersion = Convert.ToInt32("1" + t);
                int oldVersion = Convert.ToInt32("1" + Application.ProductVersion.Replace(".", ""));

                if (newVersion > oldVersion)
                {
                    string[] userToKen = new string[2];
                    userToKen[0] = newVersionStr;
                    userToKen[1] = t;

                    wc.DownloadStringAsync(new Uri("http://softdatadb.googlecode.com/svn/trunk/flash_interface_viewer/log/" + newVersionStr + ".log"), userToKen);
                    wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadLogCompleted);
                }
            }
            catch
            {
            }

            this.Text = this.appName;
        }

        /// <summary>
        /// LOG文件下载完
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void wc_DownloadLogCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            WebClient wc = sender as WebClient;
            wc.DownloadStringCompleted -= this.wc_DownloadLogCompleted;

            string[] userToKey = e.UserState as string[];
            string logStr = "无更新说明文件或更新说明下载出错";

            try
            {
                if (StrTool.isNotNull(e.Result))
                {
                    logStr = e.Result;
                }
            }
            catch
            {
            }

            string msg = String.Format(Properties.Resources.versionUpdateMsg, Application.ProductVersion, userToKey[0], logStr);

            if (MessageBox.Show(msg, "版本更新", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                string newName = "fiv_" + userToKey[1] as string + ".exe";
                wc.DownloadFileAsync(new Uri("http://softdatadb.googlecode.com/svn/trunk/flash_interface_viewer/fiv.exe"), newName, newName);
                wc.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileCompleted);
            }
        }

        /// <summary>
        /// 新程序下载完
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            
            WebClient wc = sender as WebClient;
            wc.DownloadFileCompleted -= this.wc_DownloadFileCompleted;
     

            try
            {
                string msg = String.Format(Properties.Resources.appDowened,e.UserState as String);

                MessageBox.Show(msg, "下载完成", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
                MessageBox.Show(Properties.Resources.appDownError, "更新失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void curVersionMI_Click(object sender, EventArgs e)
        {
            MessageBox.Show("软件版本:" + Application.ProductVersion, "版本号");
        }

        private void verLogMI_Click(object sender, EventArgs e)
        {

            VersionForm vf = new VersionForm();
            vf.ShowDialog();
            
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl.SelectedIndex == 2)
            {
                this.keepOpenEventTestPage = true;
                this.updatePlayerList();
            }
            else
            {
                //this.keepOpenEventTestPage = false;
            }
        }

        private void refreshPlayer_Click(object sender, EventArgs e)
        {
            this.updatePlayerList();
        }

        private void testMsgBtn_Click(object sender, EventArgs e)
        {
            this.sendTestMsg();
        }

        private void randomBtn_Click(object sender, EventArgs e)
        {

            if (this.paramList.Rows.Count < 1) return;
            int len = this.paramList.Rows.Count;

            for (int i = 0; i < len; i++)
            {
                string type = this.paramList.Rows[i].Cells[1].Value as string;
                this.paramList.Rows[i].Cells[2].Value = RandomTool.GetValue(type);
            }
        }

        private void paramList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 1) return;
            if (e.RowIndex < 0) return;

            string type = this.paramList.Rows[e.RowIndex].Cells[1].Value as string;
            this.paramList.Rows[e.RowIndex].Cells[2].Value = RandomTool.GetValue(type);
        }

        private void paramList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 3) return;
            string type = this.paramList.Rows[e.RowIndex].Cells[1].Value as string;
            this.paramList.Rows[e.RowIndex].Cells[2].Value = RandomTool.GetValue(type);
        }

    }


    /// <summary>
    /// 配置读取器
    /// </summary>
    public class ConfigReader
    {
        private bool _isReaded = false;
        private string configData;
        public GroupData[] groupList;

        /// <summary>
        /// 设置文件的地址
        /// </summary>
        /// <param name="path"></param>
        public void setPath(string path)
        {
            this._isReaded = false;
            this.configData = null;
            this.groupList = null;

            string configStr = File.ReadAllText(path, Encoding.Default);
            this.setData(configStr);
        }

        /// <summary>
        /// 设置数据
        /// </summary>
        /// <param name="configStr"></param>
        public void setData(string configStr)
        {
            if (configStr == null) return;
            if (configStr.Length < 11) return;


            this._isReaded = true;
            this.configData = configStr;

            this.processConfig();
        }

        /// <summary>
        /// 是否已经读取文件
        /// </summary>
        public bool isReaded
        {
            get
            {
                return this._isReaded;
            }
        }




        private void processConfig()
        {

            ValueData vd = GetValue(this.configData, "group_num", 0);
            int groupNum = vd.toInt();
            if(groupNum<1)return;

            this.groupList = new GroupData[groupNum];
            string[] itemList = GetItemList(this.configData, "[group{0}]", groupNum, vd.lastIndex);
            for (int gid = 0; gid < groupNum; gid++)
            {
                GroupData gd = new GroupData();
                gd.setData(itemList[gid]);
                this.groupList[gid] = gd;
            }
        }

        /// <summary>
        /// 跟据关键字，得到值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static ValueData GetValue(string data, string key, int startIndex)
        {
            ValueData vd = new ValueData();
            int index = data.IndexOf(key + "=", startIndex);
            if (index < 0)
            {
                vd.key = key;
                vd.value = null;
                vd.lastIndex = startIndex;
                return vd;
            }

            startIndex = index + key.Length + 1;
            int endIndex = data.IndexOf("\r",startIndex);
            if (endIndex < 0) endIndex = data.Length;

            vd.key = key;
            vd.value = data.Substring(startIndex, endIndex - startIndex);
            vd.lastIndex = endIndex;
            
            return vd;
        }

        public static ValueData GetValue(string data)
        {
            ValueData vd = new ValueData();
            int index = data.IndexOf("=");
            if (index < 0)
            {
                vd.key = data;
                vd.value = null;
                vd.lastIndex = data.Length;

                return vd;
            }

            vd.key = data.Substring(0, index);
            vd.value = data.Substring(index +1);
            vd.lastIndex = data.Length;
            return vd;
        }

        /// <summary>
        /// 得到列表
        /// </summary>
        /// <param name="data">源数据</param>
        /// <param name="title">类似"[group{0}]"的数据</param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string[] GetItemList(string data, string title, int len,int startIndex)
        {
           
            string titleName = String.Format(title, 0);
            startIndex = data.IndexOf(titleName,startIndex);
            if(startIndex< 0)return null;
            startIndex += titleName.Length +2;

            string[] items = new string[len];
            for(int i = 0;i<len;i++){

                titleName = String.Format(title, i + 1);
                int endIndex = data.IndexOf(titleName,startIndex);
                if(endIndex<0)endIndex = data.Length;

                items[i] = data.Substring(startIndex, endIndex - startIndex).TrimEnd('\r', '\n');
                startIndex = endIndex + titleName.Length + 2;
            }

            return items;
        }

    }



    /// <summary>
    /// 代表一个组
    /// </summary>
    public class GroupData
    {

        public string name;
        public FunInfo[] funList;
        public FunInfo[] eventList;

        public void setData(string data)
        {
            ValueData vd = ConfigReader.GetValue(data, "name", 0);
            this.name = vd.value;

            vd = ConfigReader.GetValue(data,"func_num",vd.lastIndex);
            int funcNum = vd.toInt();

            vd = ConfigReader.GetValue(data, "event_num", vd.lastIndex);
            int eventNum = vd.toInt();

            int startIndex = vd.lastIndex + 2;
            int endIndex = data.IndexOf("event0", startIndex);
            if(endIndex <0)endIndex = data.Length;

            string funcStr = data.Substring(startIndex, endIndex - startIndex);
            string eventStr = data.Substring(endIndex);

            //全部的方法
            if (funcNum > 0)
            {
                this.funList = new FunInfo[funcNum];
                string[] fl = ConfigReader.GetItemList(funcStr, "func{0}", funcNum, 0);
                for (int fid = 0; fid < funcNum; fid++)
                {
                    FunInfo fi = new FunInfo();
                    fi.setData(fl[fid]);
                    this.funList[fid] = fi;
                }
            }
           
            //全部的事件
            if (eventNum > 0)
            {
                this.eventList = new FunInfo[eventNum];
                string[] el = ConfigReader.GetItemList(eventStr, "event{0}", eventNum, 0);
                for (int eid = 0; eid < eventNum; eid++)
                {
                    FunInfo fi = new FunInfo();
                    fi.setData(el[eid]);
                    this.eventList[eid] = fi;
                }
            }
            
        }
        
    }

    /// <summary>
    /// 代表每个函数 
    /// </summary>
    public class FunInfo
    {
        public string name;
        public string desc;
        public string ret;
        public string remark;

        public ParamInfo[] paramList;

        public void setData(string data)
        {

            int pi = data.IndexOf("param_num=");
            if(pi <0)pi = data.Length;
            int ri = data.LastIndexOf("remark_line_num=");
            if (ri < 0) ri = data.Length;

            string funInfoStr = data.Substring(0,pi -2);
            string paramStr = data.Substring(pi, ri - pi);
            string remarkStr = data.Substring(ri);

            ValueData vd;
             int i;
            
            //处理函数信息
            string[] itemlist = funInfoStr.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int fiLen = itemlist.Length;
            for (i = 0; i < fiLen; i++)
            {
                vd = ConfigReader.GetValue(itemlist[i]);

                switch (vd.key)
                {
                    case "name":
                        this.name = vd.value;
                        break;
                    
                    case "desc":
                        this.desc = vd.value;
                        break;

                    case "ret":
                        this.ret = vd.value;
                        break;

                    case "retmul":
                        this.ret = vd.value;
                        break;    

                }
            }


            //处理参数信息
            vd = ConfigReader.GetValue(paramStr, "param_num", 0);
            int paramNum = vd.toInt();
            if (paramNum > 0)
            {
                this.paramList = new ParamInfo[paramNum];
                string[] paramList = ConfigReader.GetItemList(paramStr, "param{0}", paramNum, vd.lastIndex);
                for (i = 0; i < paramNum; i++)
                {
                    ParamInfo pinfo = new ParamInfo();
                    pinfo.setData(paramList[i]);
                    this.paramList[i] = pinfo;
                }
            }

            //处理额外信息
            vd = ConfigReader.GetValue(remarkStr, "remark_line_num", 0);
            if (vd.toInt() < 1) return;

            this.remark = remarkStr.Substring(vd.lastIndex + 2);
        }
    }

    /// <summary>
    /// 代表参数的每一项
    /// </summary>
    public class ParamInfo
    {
        public string type;
        public string name;
        public string desc;

        public void setData(string data)
        {
            ValueData vd = ConfigReader.GetValue(data, "type", 0);
            this.type = vd.value;

            vd = ConfigReader.GetValue(data, "name", vd.lastIndex);
            this.name = vd.value;
            this.name = this.name.Trim();       //去尾空格
            this.name = this.name.TrimEnd(','); //去尾逗号

            vd = ConfigReader.GetValue(data, "desc", vd.lastIndex);
            this.desc = vd.value;
        }

        /// <summary>
        /// 得到代码字符串
        /// </summary>
        /// <param name="isAS"></param>
        public string toCodeString(bool isAS)
        {
            string t = "";
            if(StrTool.isNotNull(this.desc)){
                t = "\t//" + this.desc; 
            }

            if (isAS)
            {
                return String.Format("var {0}:{1}", name, type, desc) + t;
            }

            return String.Format("{0} {1}", type, name, desc) + t;
        }
    }


    /// <summary>
    /// 代表取值时的每一项
    /// </summary>
    public struct ValueData
    {
        public string key;
        public string value;
        public int lastIndex;

        public bool isNull()
        {
            if (value == null) return true;
            if (value == "") return true;

            return false;
        }

        public int toInt()
        {
            if (this.isNull()) return -1;
            return Convert.ToInt32(value);
        }
    }




    ////////////////////////////////////////////////////////////////////////
    //                          节点定义
    ////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// 接着口组节点
    /// </summary>
    public class GroupNode:TreeNode, ConfigTreeNode
    {
        public GroupData data;

        public void setData(GroupData data)
        {
            this.data = data;

            this.Text = data.name;

            if(data.funList != null && data.funList.Length>0){
                FuncFolderNode ffn = new FuncFolderNode();
                ffn.setData(data.funList);
                this.Nodes.Add(ffn);
            }

            if(data.eventList != null && data.eventList.Length > 0){
                EventFolderNode efn = new EventFolderNode();
                efn.setData(data.eventList);
                this.Nodes.Add(efn);
            }
        }

        public string getInfo(bool isShowTitle)
        {

            string t = "无";

            if(this.Nodes.Count> 0){
                FuncFolderNode ffn = this.Nodes[0] as FuncFolderNode;

                t = String.Format(Properties.Resources.groupTitleATmp,this.Text,ffn.getInfo(false));
            }

            if(this.Nodes.Count > 1){
                EventFolderNode efn = this.Nodes[1] as EventFolderNode;
                t += "\r\n" + String.Format(Properties.Resources.groupTitleBTmp,efn.getInfo(false));
            }

            return t;
        }

        public string getAsCode(bool isShowTitle)
        {

            string t = "无";

            if (this.Nodes.Count > 0)
            {
                FuncFolderNode ffn = this.Nodes[0] as FuncFolderNode;
                t = ffn.getAsCode();
            }

            if (this.Nodes.Count > 1)
            {
                EventFolderNode efn = this.Nodes[1] as EventFolderNode;
                t += "\r\n\r\n\r\n\r\n\r\n" + efn.getAsCode();
            }

            return t;
        }


        #region ConfigTreeNode 成员

        public string getInfo()
        {
            return this.getInfo(true);
        }

        public string getAsCode()
        {
            return this.getAsCode(true);
        }

        #endregion
    }

    /// <summary>
    /// 方法目录节点
    /// </summary>
    public class FuncFolderNode : TreeNode, ConfigTreeNode
    {

        private FunInfo[] data;
        private string cacheData;
        private string cacheAsCode;

        public void setData(FunInfo[] data)
        {
            this.data = data;

            this.Text = "方法列表";

            int len = data.Length;
            for (int i = 0; i < len; i++)
            {

                FuncNode fn = new FuncNode();
                fn.setData(data[i]);
                this.Nodes.Add(fn);
            }
        }

        public string getInfo(bool isShowTitle)
        {
            if (this.cacheData == null)
            {
                this.cacheData = "";
                int len = this.Nodes.Count;
                for (int i = 0; i < len; i++)
                {
                    FuncNode fn = this.Nodes[i] as FuncNode;
                    this.cacheData += fn.getInfo(false) + "\r\n\r\n---------------------------------------\r\n\r\n";
                }

            }


            if (isShowTitle)
            {
                return String.Format(Properties.Resources.folderTitleTmp, this.FullPath, this.Parent.Text, "方法", this.cacheData);
            }

            return this.cacheData;
        }

        public string getAsCode(bool isShowTitle)
        {

            if (this.cacheAsCode == null)
            {
                this.cacheAsCode = "";
                int len = this.Nodes.Count;
                for (int i = 0; i < len; i++)
                {
                    FuncNode fn = this.Nodes[i] as FuncNode;
                    this.cacheAsCode += fn.getAsCode(false) + "\r\n\r\n";
                }

                this.cacheAsCode = String.Format(Properties.Resources.tileTmp, "\t\t\t\t\t\t\tVC方法", this.cacheAsCode);
            }


            return this.cacheAsCode;
        }


        #region ConfigTreeNode 成员

        public string getInfo()
        {
            return this.getInfo(true);
        }

        public string getAsCode()
        {
            return this.getAsCode(true);
        }

        #endregion
    }

    /// <summary>
    /// 事件目录节点
    /// </summary>
    public class EventFolderNode : TreeNode, ConfigTreeNode
    {

        private FunInfo[] data;
        private string cacheData;
        private string cacheAsCode;

        public void setData(FunInfo[] data)
        {
            this.data = data;

            this.Text = "事件列表";

            int len = data.Length;
            for (int i = 0; i < len; i++)
            {
                EventNode en = new EventNode();
                en.setData(data[i]);
                this.Nodes.Add(en);
            }
        }

        public string getInfo(bool isShowTitle)
        {
            if (this.cacheData == null)
            {
                this.cacheData = "";
                int len = this.Nodes.Count;
                for (int i = 0; i < len; i++)
                {
                    EventNode en = this.Nodes[i] as EventNode;
                    this.cacheData += en.getInfo(false) + "\r\n\r\n---------------------------------------\r\n\r\n";
                }

            }


            if (isShowTitle)
            {
                return String.Format(Properties.Resources.folderTitleTmp, this.FullPath, this.Parent.Text, "事件", this.cacheData);
            }

            return this.cacheData;
        }

        public string getAsCode(bool isShowTitle)
        {
            if (this.cacheAsCode == null)
            {
                string addEventCodes = "";
                string revEventCodes = "";
                string varEventCodes = "";

                this.cacheAsCode = "";
                int len = this.Nodes.Count;
                for (int i = 0; i < len; i++)
                {
                    EventNode en = this.Nodes[i] as EventNode;
                    this.cacheAsCode += en.getAsCode(false) + "\r\n\r\n";

                    string[] eventCodes = en.getEventCodes;
                    addEventCodes += en.getEventCodes[0] + "\r\n";
                    revEventCodes += en.getEventCodes[1] + "\r\n";
                    varEventCodes += en.getEventCodes[2] + "\r\n\r\n";

                }

                addEventCodes = addEventCodes.Remove(addEventCodes.Length - 2);
                revEventCodes = revEventCodes.Remove(revEventCodes.Length - 2);
                varEventCodes = varEventCodes.Remove(varEventCodes.Length - 4);

                this.cacheAsCode = String.Format(Properties.Resources.tileTmp, "\t\t\t\t\t\t\tVC事件", this.cacheAsCode);
                this.cacheAsCode += "\r\n" + String.Format(Properties.Resources.allEventCode, addEventCodes, revEventCodes, varEventCodes);
            } 

            return this.cacheAsCode;
        }


        #region ConfigTreeNode 成员

        public string getInfo()
        {
            return this.getInfo(true);
        }

        public string getAsCode()
        {
            return this.getAsCode(true);
        }

        #endregion
    }

    /// <summary>
    /// 方法节点
    /// </summary>
    public class FuncNode : TreeNode, ConfigTreeNode
    {

        private FunInfo data;
        private string cacheData;
        private string cacheASCode;

        public void setData(FunInfo data)
        {
            this.data = data;

            this.Text = data.name;
            this.ToolTipText = data.desc;
        }

        public string getInfo(bool isShowTitle)
        {

            if (this.cacheData == null)
            {
                string temp = Properties.Resources.funTmp;

                string paramStr = "";

                if (this.data.paramList != null && this.data.paramList.Length > 0)
                {

                    int plen = data.paramList.Length;
                    for (var pindex = 0; pindex < plen; pindex++)
                    {
                        paramStr += "\t" + data.paramList[pindex].toCodeString(false) + "\r\n";
                    }
                }
                else
                {
                    paramStr = "\t无\r\n";
                }

                string desc = "无";
                if (StrTool.isNotNull(data.desc)) desc = data.desc;

                string ret = "无";
                if (StrTool.isNotNull(data.ret)) ret = data.ret;

                string remark = "\t无";
                if (StrTool.isNotNull(data.remark))
                {
                    remark = "\t" + data.remark;
                    remark = remark.Replace("\r\n", "\r\n\t");
                }

                this.cacheData = String.Format(temp, data.name, desc, ret, paramStr, remark);
            }

            if (isShowTitle)
            {
                return String.Format(Properties.Resources.itemTitleTmp, this.FullPath, this.cacheData);
            }
            else
            {
                return this.cacheData;
            }
            
        }

        public string getAsCode(bool isShowTitle)
        {

            if (this.cacheASCode == null)
            {

                string firstStr = this.data.desc;

                if (StrTool.isNotNull(this.data.remark))
                {
                    string remark = this.data.remark;
                    remark = remark.Replace("\r\n","\r\n	 * ");
                    firstStr += "\r\n	 * " + remark;
                }

                string params1 = "";
                string params2 = "";
                string returnStr="";
                string returnType = "";

                Hashtable typeMap = new Hashtable();
                typeMap["bool"] = "Boolean";
                typeMap["int"] = "Number";
                typeMap["string"] = "String";

                if (this.data.paramList != null && this.data.paramList.Length > 0)
                {
                    int plen = data.paramList.Length;
                    for (var pindex = 0; pindex < plen; pindex++)
                    {

                        ParamInfo pi = data.paramList[pindex];
                        firstStr += "\r\n" + String.Format(Properties.Resources.paramTmp, pi.name);

                        if (StrTool.isNotNull(pi.desc))
                        {
                            firstStr += "\t" + pi.desc;
                        }

                        string type = typeMap[pi.type] as String;
                        if (type == null) type = pi.type;

                        params1 += pi.name + ":" + type + ", ";
                        params2 += ", " + pi.name;
                    }

                    params1 = params1.Remove(params1.Length - 2);
                }

                if (StrTool.isNotNull(this.data.ret))
                {
                    firstStr += "\r\n" + String.Format(Properties.Resources.returnTmp, this.data.ret);
                    returnStr = "return ";

                    Hashtable tht = new Hashtable();
                    tht.Add("int", ":Number");
                    tht.Add("json", ":Object");
                    tht.Add("是否", ":Boolean");
                    tht.Add("bool", ":Boolean");
                    tht.Add("string", ":String");

                    string trt = StrTool.getFuzzyValue(this.data.ret, tht);
                    if (trt != null)returnType = trt;


                    //附加类型转化
                    switch (trt)
                    {
                        case ":Number":
                            returnStr += "Number(";
                            params2 += ")";
                            break;

                        case ":Boolean":
                            returnStr += "Boolean(";
                            params2 += ")";
                            break;

                        case ":String":
                            returnStr += "String(";
                            params2 += ")";
                            break;
                    }

                }

                
                this.cacheASCode = String.Format(Properties.Resources.asFuncTmp,
                                                firstStr,
                                                this.data.name,
                                                params1,
                                                returnType,
                                                params2,
                                                returnStr);
                 


            }


            return this.cacheASCode;
        }


        #region ConfigTreeNode 成员

        public string getInfo()
        {
            return this.getInfo(true);
        }

        public string getAsCode()
        {
            return this.getAsCode(true);
        }

        #endregion
    }

    /// <summary>
    /// 事件节点
    /// </summary>
    public class EventNode : TreeNode,ConfigTreeNode
    {
        public FunInfo data;
        private string cacheData;
        private string cacheASCode;


        //监听事件用的代码
        //[0]：增加事件代码
        //[1]：删除事件代码
        //[2]：事件处理函数代码
        //[3]：全部代码
        private string[] cUseEventCode;
        public string[] getEventCodes { get { return this.cUseEventCode; } }

        public void setData(FunInfo data)
        {
            this.data = data;

            this.Text = data.name;
            this.ToolTipText = data.desc;
        }

        /// <summary>
        /// 更新参数显示
        /// </summary>
        /// <param name="paramList"></param>
        public void updateDataGrid(DataGridView paramList)
        {
            paramList.Rows.Clear();

            Hashtable typeMap = new Hashtable();
            typeMap["bool"] = "Boolean";
            typeMap["int"] = "Number";
            typeMap["string"] = "String";

            if (this.data.paramList != null && this.data.paramList.Length > 0)
            {

                int plen = data.paramList.Length;
                for (var pindex = 0; pindex < plen; pindex++)
                {
                    ParamInfo pi = data.paramList[pindex];
                    String type;
                    if(pi.name == "json")
                    {
                        type = "JsonString";
                    }
                    else
                    {
                        type = typeMap[pi.type] as String;
                        if(type == null)type = "String";
                    }

                    paramList.Rows.Add(pi.name, type, RandomTool.GetValue(type), "随机数", pi.desc);
                }
            }

        }

        public string getInfo(bool isShowTitle)
        {
            if (this.cacheData == null)
            {
                string temp = Properties.Resources.funTmp;

                string paramStr = "";

                if (this.data.paramList != null && this.data.paramList.Length > 0)
                {

                    int plen = data.paramList.Length;
                    for (var pindex = 0; pindex < plen; pindex++)
                    {
                        paramStr += "\t" + data.paramList[pindex].toCodeString(false) + "\r\n";
                    }
                }
                else
                {
                    paramStr = "\t无\r\n";
                }

                string desc = "无";
                if (StrTool.isNotNull(data.desc)) desc = data.desc;

                string ret = "无";
                if (StrTool.isNotNull(data.ret)) ret = data.ret;

                string remark = "\t无";
                if (StrTool.isNotNull(data.remark))
                {
                    remark = "\t" + data.remark;
                    remark = remark.Replace("\r\n", "\r\n\t");
                }

                this.cacheData = String.Format(temp, data.name, desc, ret, paramStr, remark);
            }

            if (isShowTitle)
            {
                return "\r\n" + String.Format(Properties.Resources.itemTitleTmp, this.FullPath, this.cacheData);
            }
            else
            {
                return this.cacheData;
            }
        }

        public string getAsCode(bool isShowTitle)
        {

            if (this.cacheASCode == null)
            {

                this.cUseEventCode = new string[4];
                

                string newEventName = this.data.name;
                if (newEventName.IndexOf("Event_") != 0)
                {
                    newEventName = "Event_" + newEventName;
                }

                this.cUseEventCode[0] = String.Format(Properties.Resources.vcListenerCode, newEventName, "");
                this.cUseEventCode[1] = String.Format(Properties.Resources.vcListenerCode, newEventName, ",true");

                string firstStr = this.data.desc;

                if (StrTool.isNotNull(this.data.remark))
                {
                    string remark = this.data.remark;
                    remark = remark.Replace("\r\n", "\r\n		 * ");
                    firstStr += "\r\n		 * " + remark;
                }

                
                //////////////////////////////////////////////
                //             以下生成参数列表
                //////////////////////////////////////////////

                string varParamsCode = "\t\t\t//无参数";      //事件定义时注释

                Hashtable typeMap = new Hashtable();
                typeMap["bool"] = "Boolean";
                typeMap["int"] = "Number";
                typeMap["string"] = "String";

                if (this.data.paramList != null && this.data.paramList.Length > 0)
                {
                    varParamsCode = "";

                    int plen = data.paramList.Length;
                    for (var pindex = 0; pindex < plen; pindex++)
                    {

                        ParamInfo pi = data.paramList[pindex];

                        string type = typeMap[pi.type] as String;
                        if (type == null) type = pi.type;

                        //声明事件参数代码字符
                        varParamsCode += String.Format(Properties.Resources.varEventParamCode, pi.name, type, pindex);

                        if (StrTool.isNotNull(pi.desc)) varParamsCode += "\t//" + pi.desc;
                        varParamsCode += "\r\n";

                    }

                    varParamsCode = varParamsCode.Remove(varParamsCode.Length - 2);
                }

                this.cUseEventCode[2] = String.Format(Properties.Resources.eventHandlerCode,
                                                     firstStr.Replace("\r\n		 * ", "\r\n	 * "),
                                                     newEventName,
                                                     varParamsCode.Replace("\t\t\t", "\t\t"));

                this.cUseEventCode[3] = String.Format(Properties.Resources.allEventCode,
                                                      this.cUseEventCode[0],
                                                      this.cUseEventCode[1],
                                                      this.cUseEventCode[2]);

                                                                    
                this.cacheASCode = String.Format(Properties.Resources.asEventTmp,
                                                this.data.desc,
                                                newEventName,
                                                firstStr,
                                                varParamsCode,
                                                this.data.name);

            }


            if (isShowTitle)
            {

                return this.cacheASCode + "\r\n" + this.cUseEventCode[3];
            }


            return this.cacheASCode;
        }


        #region ConfigTreeNode 成员

        public string getInfo()
        {
            return this.getInfo(true);
        }

        public string getAsCode()
        {
            return this.getAsCode(true);
        }

        #endregion
    }

    public class StrTool
    {
        public static bool isNotNull(string str){
            return str != null && str.Length > 0;
        }

        /// <summary>
        /// 糊糊匹配，只要data里出现hashMap key，则就返回这个key对应的值
        /// </summary>
        /// <param name="data"></param>
        /// <param name="hashMap"></param>
        /// <returns>找到的话，返回相就的值，没找到返回null</returns>
        public static String getFuzzyValue(string data,Hashtable hashMap)
        {

            foreach (string key in hashMap.Keys)
            {
                if (data.IndexOf(key) > -1) return hashMap[key] as String;
            }

            return null;

        }
    }


    public interface ConfigTreeNode {
        string getInfo();
        string getAsCode();
    }


    /// <summary>
    ///专门用来操作外部代码
    /// </summary>
    public class ImportFromDLL
    {
        public const int WM_COPYDATA = 0x004A;

        //启用非托管代码
        [StructLayout(LayoutKind.Sequential)]
        public struct COPYDATASTRUCT
        {
            public int dwData;    //not used
            public int cbData;    //长度
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }

        [DllImport("User32.dll")]
        public static extern int SendMessage(
            IntPtr hWnd,　　　  // handle to destination window 
            int Msg,　　　      // message
            IntPtr wParam,　   // first message parameter 
            ref COPYDATASTRUCT pcd // second message parameter 
        );

        /*
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("Kernel32.dll", EntryPoint = "GetConsoleWindow")]
        public static extern IntPtr GetConsoleWindow();
         */
    }

    public class RandomTool
    {

        private static int count = 0;

        private static Random GetRandom()
        {
            Random t = new Random(count);
            if (count < int.MaxValue)
            {
                count++;
            }
            else
            {
                count = 0;
            }
            return t;
        }

        /// <summary>
        /// 得到随机字符值
        /// </summary>
        /// <param name="minLen">最小长度</param>
        /// <param name="maxLen">最大长度</param>
        /// <returns></returns>
        public static string GetStrValue(int minLen, int maxLen)
        {
            string t = "这是测试字符串,";
            Random rd = GetRandom();
            int len = rd.Next(minLen, maxLen + 1);
            
            return t;
        }

        /// <summary>
        /// 取得十到一百之间长度的字符串
        /// </summary>
        /// <returns></returns>
        public static string GetStrValue()
        {
            return GetStrValue(10, 100);
        }

        /// <summary>
        /// 得到整数
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static string GetIntValueStr(int minValue, int maxValue)
        {
            Random rd = GetRandom();
            return rd.Next(minValue, maxValue).ToString();
        }

        /// <summary>
        /// 得到字符串
        /// </summary>
        /// <returns></returns>
        public static string GetIntValueStr()
        {
            return GetIntValueStr(10, 101);
        }

        /// <summary>
        /// 得到布尔值
        /// </summary>
        /// <returns></returns>
        public static string GetBoolValueStr()
        {
            Random rd = GetRandom();

            if (rd.Next(2) == 0)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }

        /// <summary>
        /// 得到随机值
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static String GetValue(string type)
        {

            switch (type)
            {
                case "Boolean":
                    return GetBoolValueStr();

                case "Number":
                    return GetIntValueStr();

                case "String":
                case "JsonString":
                    return GetStrValue();

            }

            return "未知类型";
        }
    }


    class GfxPlayerTool
    {

        private delegate bool CallBack(int hwnd, int lParam);

        [DllImport("user32")]
        private static extern int EnumWindows(CallBack x, int y);

        [DllImport("user32", CharSet = CharSet.Unicode)]
        private static extern int GetWindowText(int hWnd, StringBuilder sbWinName, int nMaxCount);

        /*
        [DllImport("user32")]
        private static extern int IsWindowVisible(int hwnd);

        [DllImport("user32")]
        private static extern int GetParent(int hwnd);
         */


        private static List<GfxPlayerInfo> playerNameList = new List<GfxPlayerInfo>();

        public static GfxPlayerInfo[] getAllPlayer()
        {

            CallBack myCallBack = new CallBack(handler);
            EnumWindows(myCallBack, 0);
            GfxPlayerInfo[] infos = playerNameList.ToArray();
            playerNameList.Clear();
            return infos;
        }

        private static bool handler(int hwnd, int lparam)
        {
            //if (GetParent(hwnd) == 0 && IsWindowVisible(hwnd) == 1)
            //{
                StringBuilder sbWinName = new StringBuilder(512);
                GetWindowText(hwnd, sbWinName, sbWinName.Capacity);
                if (sbWinName.Length > 0)
                {
                    if (sbWinName.ToString().IndexOf("Scaleform GFxPlayer") == 0)
                    {
                        GfxPlayerInfo info = new GfxPlayerInfo();
                        info.hwnd = (IntPtr)hwnd;
                        info.windowsName = sbWinName.ToString();
                        playerNameList.Add(info);
                    }
                }
            //}
            return true;
        }

    }

    class GfxPlayerInfo
    {
        [DllImport("user32.dll", EntryPoint = "IsWindow")]
        private static extern bool IsWindow(IntPtr hWnd);

        public IntPtr hwnd;
        public string windowsName;

        public Boolean hasExited(){
            if(hwnd == null)return true;
            return !IsWindow(this.hwnd);
        }
    }

    /// <summary>
    /// JS工具箱
    /// </summary>
    class JSTool
    {

        private static bool isInit = false;
        private static ScriptControlClass scc;

        private static void Init()
        {
            if (isInit) return;
            isInit = true;

            scc = new ScriptControlClass();
            scc.UseSafeSubset = true;
            scc.AllowUI = false;
            scc.Language = "JavaScript";
            scc.AddCode(Properties.Resources.jsJsonCode);
        }

        public static Exception LastErrorMsg;

        public static string GetJsonStr(string code){
            Init();

            LastErrorMsg = null;

            try
            {
                code += "JSON.stringify(data);";
                return scc.Eval(code).ToString();
            }
            catch (Exception e)
            {
                LastErrorMsg = e;
                return null;
            }
        }
    }


}
