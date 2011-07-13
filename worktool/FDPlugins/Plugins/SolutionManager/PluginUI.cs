using System;
using System.Collections;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI;
using PluginCore;
using System.Xml;
using System.IO;
using System.Text;

namespace SolutionManager
{
	public class PluginUI : UserControl
    {
    
        private static PluginUI instance;
        public static PluginUI GetInstance(){
            return instance;
        }


        private ToolStrip SMtoolStrip;
        private ToolStripButton ImportTSBtn;
        private TreeView SMTree;
        private ToolStripDropDownButton FileTSBtn;
        private ToolStripMenuItem NewFileBtn;
        private ToolStripMenuItem OpenFileBtn;
        private ToolStripMenuItem CloseFileBtn;
        private ToolStripMenuItem SaveFileBtn;
        private ToolStripMenuItem SaveNewBtn;
        private ImageList TreeImageList;
        private System.ComponentModel.IContainer components;
        private SlnTreeMenu TreeMenu;
		private PluginMain pluginMain;
        
		public PluginUI(PluginMain pluginMain)
		{
			this.InitializeComponent();
            this.InitComponent();
			this.pluginMain = pluginMain;

            this.Init();

            instance = this;
		}

		#region Windows Forms Designer Generated Code

		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent() 
        {
            this.components = new System.ComponentModel.Container();
            this.SMtoolStrip = new System.Windows.Forms.ToolStrip();
            this.FileTSBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.NewFileBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseFileBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveNewBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportTSBtn = new System.Windows.Forms.ToolStripButton();
            this.SMTree = new System.Windows.Forms.TreeView();
            this.TreeMenu = new SolutionManager.SlnTreeMenu();
            this.TreeImageList = new System.Windows.Forms.ImageList(this.components);
            this.SMtoolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // SMtoolStrip
            // 
            this.SMtoolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.SMtoolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileTSBtn,
            this.ImportTSBtn});
            this.SMtoolStrip.Location = new System.Drawing.Point(0, 0);
            this.SMtoolStrip.Name = "SMtoolStrip";
            this.SMtoolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.SMtoolStrip.Size = new System.Drawing.Size(308, 25);
            this.SMtoolStrip.TabIndex = 0;
            this.SMtoolStrip.Text = "toolStrip1";
            // 
            // FileTSBtn
            // 
            this.FileTSBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewFileBtn,
            this.OpenFileBtn,
            this.CloseFileBtn,
            this.SaveFileBtn,
            this.SaveNewBtn});
            this.FileTSBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FileTSBtn.Name = "FileTSBtn";
            this.FileTSBtn.Size = new System.Drawing.Size(45, 22);
            this.FileTSBtn.Text = "文件";
            // 
            // NewFileBtn
            // 
            this.NewFileBtn.Name = "NewFileBtn";
            this.NewFileBtn.Size = new System.Drawing.Size(112, 22);
            this.NewFileBtn.Text = "新建";
            this.NewFileBtn.Click += new System.EventHandler(this.NewFileBtn_Click);
            // 
            // OpenFileBtn
            // 
            this.OpenFileBtn.Name = "OpenFileBtn";
            this.OpenFileBtn.Size = new System.Drawing.Size(112, 22);
            this.OpenFileBtn.Text = "打开";
            this.OpenFileBtn.Click += new System.EventHandler(this.OpenFileBtn_Click);
            // 
            // CloseFileBtn
            // 
            this.CloseFileBtn.Enabled = false;
            this.CloseFileBtn.Name = "CloseFileBtn";
            this.CloseFileBtn.Size = new System.Drawing.Size(112, 22);
            this.CloseFileBtn.Text = "关闭";
            this.CloseFileBtn.Click += new System.EventHandler(this.CloseFileBtn_Click);
            // 
            // SaveFileBtn
            // 
            this.SaveFileBtn.Enabled = false;
            this.SaveFileBtn.Name = "SaveFileBtn";
            this.SaveFileBtn.Size = new System.Drawing.Size(112, 22);
            this.SaveFileBtn.Text = "保存";
            this.SaveFileBtn.Click += new System.EventHandler(this.SaveFileBtn_Click);
            // 
            // SaveNewBtn
            // 
            this.SaveNewBtn.Enabled = false;
            this.SaveNewBtn.Name = "SaveNewBtn";
            this.SaveNewBtn.Size = new System.Drawing.Size(112, 22);
            this.SaveNewBtn.Text = "另存为";
            this.SaveNewBtn.Click += new System.EventHandler(this.SaveNewBtn_Click);
            // 
            // ImportTSBtn
            // 
            this.ImportTSBtn.Enabled = false;
            this.ImportTSBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ImportTSBtn.Name = "ImportTSBtn";
            this.ImportTSBtn.Size = new System.Drawing.Size(36, 22);
            this.ImportTSBtn.Text = "导入";
            this.ImportTSBtn.Click += new System.EventHandler(this.ImportTSBtn_Click);
            // 
            // SMTree
            // 
            this.SMTree.ContextMenuStrip = this.TreeMenu;
            this.SMTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SMTree.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SMTree.ImageIndex = 0;
            this.SMTree.ImageList = this.TreeImageList;
            this.SMTree.ItemHeight = 18;
            this.SMTree.Location = new System.Drawing.Point(0, 25);
            this.SMTree.Name = "SMTree";
            this.SMTree.SelectedImageIndex = 0;
            this.SMTree.Size = new System.Drawing.Size(308, 365);
            this.SMTree.TabIndex = 1;
            this.SMTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.SMTree_NodeMouseDoubleClick);
            this.SMTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.SMTree_NodeMouseClick);
            // 
            // TreeMenu
            // 
            this.TreeMenu.Name = "slnTreeMenu1";
            this.TreeMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // TreeImageList
            // 
            this.TreeImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.TreeImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.TreeImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // PluginUI
            // 
            this.Controls.Add(this.SMTree);
            this.Controls.Add(this.SMtoolStrip);
            this.Name = "PluginUI";
            this.Size = new System.Drawing.Size(308, 390);
            this.Load += new System.EventHandler(this.PluginUI_Load);
            this.SMtoolStrip.ResumeLayout(false);
            this.SMtoolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        /// <summary>
        /// 自己的组件设置（怕被系统覆盖，所以这么做）
        /// </summary>
        private void InitComponent()
        {
            this.TreeImageList.Images.Add(PluginBase.MainForm.FindImage("274"));
            this.TreeImageList.Images.Add(PluginBase.MainForm.FindImage("523"));
            this.FileTSBtn.Image = PluginBase.MainForm.FindImage("275");
            this.ImportTSBtn.Image = PluginBase.MainForm.FindImage("415");
            this.SaveFileBtn.Image = PluginBase.MainForm.FindImage("168");
            this.OpenFileBtn.Image = PluginBase.MainForm.FindImage("519");
        }

		#endregion






        #region 与实际功能业务相关
        //////////////////////////////////////////////////////////////
        //                      逻辑处理
        //////////////////////////////////////////////////////////////

        private bool IsTest = false;

        private bool IsChange = false;
        private bool isOpen = false;

        private XmlDocument SlnXml;
        private string DefSlnStr;
        

        private string CurSlnPath;
        private string CurSlnDir;

        private void Init() {

            this.SlnXml = new XmlDocument();
            this.DefSlnStr = PluginMain.ResManager.GetString("DefSlnFile");

            this.IsChange = false;
            this.isOpen = false;

            if (IsTest)
            {
                this.OpenSolution("E:\\project\\绝对火力\\界面\\v1.0\\AF.fdsln");
            }
        }

        /// <summary>
        /// 判断是否是解决方案文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool IsSlnFile(string path)
        {
            return Path.GetExtension(path).ToLower() == ".fdsln";
        }

        /// <summary>
        /// 打开解决方案
        /// </summary>
        /// <param name="path"></param>
        public bool OpenSolution(string path)
        {
            if (!this.IsSlnFile(path)) return false;

            try
            {
                SlnXml.Load(path);
                this.UpdateTree();
            }
            catch
            {
                this.CreateSolution(path);
            }

            
            this.CurSlnPath = path;
            this.CurSlnDir = Path.GetDirectoryName(path);

            if (!this.isOpen)
            {
                this.isOpen = true;
                this.EnableBtn(true);
            }

            this.IsChange = false;
            this.UpdateTitle();
            return true;
        }

        /// <summary>
        /// 关闭解决方案
        /// </summary>
        public void CloseSolution(){
            if (!this.isOpen) return;

            this.isOpen = false;
            this.SMTree.Nodes.Clear();
            this.EnableBtn(false);
            this.CurSlnDir = null;
            this.CurSlnPath = null;

            this.UpdateTitle();
        }


        /// <summary>
        /// 创建解决方安
        /// </summary>
        /// <param name="path"></param>
        public void CreateSolution(string path)
        {
            File.WriteAllText(path, this.DefSlnStr, Encoding.UTF8);
            if (SlnXml == null) SlnXml = new XmlDocument();
            SlnXml.LoadXml(this.DefSlnStr);
        }

        /// <summary>
        /// 更改了解决方案
        /// </summary>
        public void ChangeSol()
        {
            this.IsChange = true;
            this.UpdateTitle();
        }

        /// <summary>
        /// 导入项目
        /// </summary>
        /// <param name="path"></param>
        public void ImportProjects(string path)
        {

            //参考：http://www.cnblogs.com/wequst/archive/2009/01/08/1371769.html

            string[] exList = ".as2proj,.as3proj,.hxproj".Split(',');
            int exLen = exList.Length;

            /*
            foreach (string ex in exList)
            {
                string[] files = Directory.GetFiles(path, ex, SearchOption.AllDirectories);
                foreach (string fileName in files)
                {
                    if (SlnXml.SelectSingleNode("/solution/projects/project[@path='" + fileName + "']") == null)
                    {
                        this.AddProject(fileName);
                    }
                }
            }
             */


            string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            foreach (string fileName in files)
            {
                string exName = Path.GetExtension(fileName);
                bool isFind = false;
                foreach (string ex in exList) { 
                    if(ex == exName){
                        isFind = true;
                        break;
                    }
                }

                if (!isFind) continue;
                //string t = this.GetRelativePath(this.CurSlnDir, fileName);
                if (SlnXml.SelectSingleNode("/solution/projects/project[@path='" + this.GetRelativePath(this.CurSlnDir, fileName) + "']") == null)
                {
                    //有导入就有修改
                    this.IsChange = true;
                    this.AddProject(fileName);
                }
                
            }

            this.UpdateTree();
            this.UpdateTitle();
        }

        /// <summary>
        /// 增加项目
        /// </summary>
        /// <param name="path"></param>
        private void AddProject(string path) {

            string defName = Path.GetFileName(path);
            defName = defName.Substring(0,defName.LastIndexOf('.'));

            XmlElement projNode =  SlnXml.CreateElement("project");
            projNode.SetAttribute("path", GetRelativePath(this.CurSlnDir, path));
            projNode.SetAttribute("name",defName);

            SlnXml.DocumentElement.FirstChild.AppendChild(projNode);
        }

        /// <summary>
        /// 保存解决方案
        /// </summary>
        /// <param name="path"></param>
        public void SaveSln(string path) {

            //没有修改不做保存
            if (path == this.CurSlnPath && !this.IsChange)
            {
                MessageBox.Show("未做修改，不需要保存", "提示");
                return;
            }

            SlnXml.Save(path);
            this.IsChange = false;
            this.UpdateTitle();

            MessageBox.Show("已保存", "提示");
        }

        /// <summary>
        /// 保存解决方案
        /// </summary>
        public void SaveSln()
        {
            this.SaveSln(this.CurSlnPath);
        }

        /// <summary>
        /// 更新树
        /// </summary>
        private void UpdateTree()
        {

            this.SMTree.Nodes.Clear();

            XmlNodeList projList = SlnXml.SelectNodes("/solution/projects/project");
            if (projList.Count < 1)
            {
                MessageBox.Show("没有项目", "提示");
                return;
            }

            this.SMTree.Nodes.Add("projects", "项目",1,1);
            foreach(XmlNode node in projList){
                ProjNode sn = new ProjNode();
                sn.SetXmlNode(node);
                this.SMTree.Nodes["projects"].Nodes.Add(sn);
            }

            this.SMTree.Nodes["projects"].Expand();
        }



        /// <summary>
        /// 获取路径2相对于路径1的相对路径
        /// </summary>
        /// <param name="rootPath">路径1</param>
        /// <param name="filePath">路径2</param>
        /// <returns>返回路径2相对于路径1的路径</returns>
        /// <example>
        /// string strPath = GetRelativePath(@"C:\WINDOWS\system32", @"C:\WINDOWS\system\*.*" );
        /// //strPath == @"..\system\*.*"
        /// </example>
        private string GetRelativePath(string rootPath, string filePath)
        {
            if (!rootPath.EndsWith("\\")) rootPath += "\\";    //如果不是以"\"结尾的加上"\"
            int intIndex = -1, intPos = rootPath.IndexOf('\\');
            ///以"\"为分界比较从开始处到第一个"\"处对两个地址进行比较,如果相同则扩展到
            ///下一个"\"处;直到比较出不同或第一个地址的结尾.
            while (intPos >= 0)
            {
                intPos++;
                if (string.Compare(rootPath, 0, filePath, 0, intPos, true) != 0) break;
                intIndex = intPos;
                intPos = rootPath.IndexOf('\\', intPos);
            }

            ///如果从不是第一个"\"处开始有不同,则从最后一个发现有不同的"\"处开始将strPath2
            ///的后面部分付值给自己,在strPath1的同一个位置开始望后计算每有一个"\"则在strPath2
            ///的前面加上一个"..\"(经过转义后就是"..\\").
            if (intIndex >= 0)
            {
                filePath = filePath.Substring(intIndex);
                intPos = rootPath.IndexOf("\\", intIndex);
                while (intPos >= 0)
                {
                    filePath = "..\\" + filePath;
                    intPos = rootPath.IndexOf("\\", intPos + 1);
                }
            }
            //否则直接返回strPath2
            return filePath;
        }

        private void EnableBtn(bool value)
        {
            this.CloseFileBtn.Enabled = value;
            this.SaveFileBtn.Enabled = value;
            this.SaveNewBtn.Enabled = value;
            this.ImportTSBtn.Enabled = value;
        }


        /// <summary>
        /// 更新标题
        /// </summary>
        private void UpdateTitle()
        {
            if (!this.isOpen)
            {
                this.Text = "解决方案管理器 - (未打开解决方案）";
                if (this.Parent != null) this.Parent.Text = this.Text;
                return;
            }

            string changeStr = "";
            if (this.IsChange) changeStr = "(*)";

            this.Text = "解决方案管理器 - " + Path.GetFileName(this.CurSlnPath) + changeStr;
            if (this.Parent != null) this.Parent.Text = this.Text;
            
        }

        #endregion




        //////////////////////////////////////////////////////////////
        //                       界面事件
        //////////////////////////////////////////////////////////////


        private void ImportTSBtn_Click(object sender, EventArgs e)
        {

            if (IsTest)
            {
                this.ImportProjects("E:\\project\\绝对火力\\界面\\v1.0\\UIProj");
                return;
            }

            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.SelectedPath = this.CurSlnDir;
            fd.Description = "请选择要导入的目录";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                this.ImportProjects(fd.SelectedPath);
                MessageBox.Show("导入成功", "提示");
            }  
        }

        private void OpenFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "选择解决方案";
            fd.Filter = "FD解决方案文件(*.fdsln)|*.fdsln";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                this.OpenSolution(fd.FileName);
            }
        }

        private void SMTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (!(e.Node is ProjNode)) return;
            ProjNode node = e.Node as ProjNode;
            PMProxy.OpenFile(Path.Combine(this.CurSlnDir, node.path));
        }

        private void CloseFileBtn_Click(object sender, EventArgs e)
        {
            this.CloseSolution();
        }

        private void PluginUI_Load(object sender, EventArgs e)
        {
            this.UpdateTitle();
        }

        private void SaveFileBtn_Click(object sender, EventArgs e)
        {
            this.SaveSln();
        }

        private void NewFileBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("还未实现", "提示");
        }

        private void SaveNewBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("还未实现", "提示");
        }

        private void SMTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right) {
                SMTree.SelectedNode = e.Node;
                TreeMenu.Config(e.Node);
            }
        }
	
 	}

}

/*
public string GetRelativePath(string root, string file)
{
    //check and add slash at the end of root 
    if (root[root.Length - 1] != '\\')
    {
        root = root + "\\";
    }
    root = root.ToUpper();
    file = file.ToUpper();

    //check if they are on the same driver 
    if (root[0] != file[0])
    {
        return file;
    }

    //find how much differnece 
    int index = 0;
    for (int i = 0; i < root.Length && i < file.Length; i++)
    {
        index = i;
        if (root[i] != file[i])
        {
            index = i - 1;
            break;
        }
    }

    //if the same value point is not \ 
    //go back and find the nearest \ 

    if (root[index] != '\\')
    {
        for (int i = index; i >= 0; i--)
        {
            if (root[i] == '\\')
            {
                index = i;
                break;
            }
        }
    }

    //get the sub string 

    string subFile = file.Substring(index + 1);
    if (root.Length == index + 1)
    {
        return subFile;
    }

    string subRoot = root.Substring(index + 1);

    //count how many \ in subRoot 
    string header = "";
    for (int i = 0; i < subRoot.Length; i++)
    {
        if (subRoot[i] == '\\')
        {
            header = header + "..\\";
        }
    }
    return header + subFile;

}
 */
