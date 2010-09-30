using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Resources;
using System.Reflection;


namespace ImportAllClass
{
    public partial class ImportToolForm : Form
    {

        private ResourceManager resource = new ResourceManager("ImportAllClass.Properties.Resources", Assembly.GetEntryAssembly());
        private Setting setobj;

        public ImportToolForm()
        {
            InitializeComponent();
            this.readSetting();
        }

        private void readSetting(){
            ToolSetting.read();
            this.setobj = ToolSetting.settingObj;

            foreach (string item in setobj.libList)
            {
                this.libFolderList.Items.Add(item);
            }

            foreach (string item in setobj.exLibList)
            {
                this.exLibFodlerList.Items.Add(item);
            }

            this.asPathTxt.Text = setobj.classPath;
            this.packNameTxt.Text = setobj.packname;
        }

        private void saveSetting(){
            setobj.classPath = this.asPathTxt.Text;
            setobj.packname = this.packNameTxt.Text;
            ToolSetting.save();
        }

        private void addClassFolderBtn_Click(object sender, EventArgs e)
        {
            
            FolderBrowserDialog fbDialog = new FolderBrowserDialog();
            fbDialog.Description = "请选择你需要导入的类库";
            fbDialog.ShowNewFolderButton = false;
            if (fbDialog.ShowDialog() == DialogResult.OK)
            {
                if (this.libFolderList.Items.Contains(fbDialog.SelectedPath)) return;
                this.libFolderList.Items.Add(fbDialog.SelectedPath);
                setobj.libList.Add(fbDialog.SelectedPath);

                //if (setobj.libList.Contains(fbDialog.SelectedPath)) return;
                //setobj.libList.Add(fbDialog.SelectedPath);
            }
        }

        private void removeLibFolderBtn_Click(object sender, EventArgs e)
        {
            if (this.libFolderList.SelectedItem == null)
            {
                MessageBox.Show("你还未选择类库目录，请在上边列表中先选择目录！", "提示");
                return;
            }
            setobj.libList.Remove((string)this.libFolderList.SelectedItem);
            this.libFolderList.Items.Remove(this.libFolderList.SelectedItem);
            
        }

        private void addExLibFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Title = "请选择你要排除的文件";
            ofd.Filter = "AS类文件(.as)|*.as";
            
            if(ofd.ShowDialog() == DialogResult.OK){
                foreach (string filename in ofd.FileNames)
                {
                    if (this.exLibFodlerList.Items.Contains(filename)) continue;
                    this.exLibFodlerList.Items.Add(filename);
                    setobj.exLibList.Add(filename);

                    //if (setobj.exLibList.Contains(filename)) continue;
                    //setobj.exLibList.Add(filename);
                }
            }
        }

        private void addExLibFolderBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbDialog = new FolderBrowserDialog();
            fbDialog.Description = "请选择你需要排除的类库";
            fbDialog.ShowNewFolderButton = false;
            if (fbDialog.ShowDialog() == DialogResult.OK)
            {
                if (this.exLibFodlerList.Items.Contains(fbDialog.SelectedPath)) return;
                this.exLibFodlerList.Items.Add(fbDialog.SelectedPath);
                setobj.exLibList.Add(fbDialog.SelectedPath);

                //if (setobj.exLibList.Contains(fbDialog.SelectedPath)) return;
                //setobj.exLibList.Add(fbDialog.SelectedPath);
            }
        }

        private void removeExLibFolderBtn_Click(object sender, EventArgs e)
        {
            if (this.exLibFodlerList.SelectedItem == null)
            {
                MessageBox.Show("你还未选择类库目录，请在上边列表中先选择目录！", "提示");
                return;
            }
            setobj.exLibList.Remove((string)this.exLibFodlerList.SelectedItem);
            this.exLibFodlerList.Items.Remove(this.exLibFodlerList.SelectedItem);

        }

        private void selSavePathBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "请输入你要保存的文件名";
            sfd.Filter = "AS类文件(.as)|*.as";
            sfd.DefaultExt = "as";
            if(sfd.ShowDialog() == DialogResult.OK){
                asPathTxt.Text = sfd.FileName;
                asPathTxt.SelectionStart = asPathTxt.Text.Length;
                asPathTxt.ScrollToCaret();
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            //检查有无库文件
            if(this.libFolderList.Items.Count<1){
               MessageBox.Show("你还未选择类库目录，请在上边列表中先选择目录！", "提示");
               return;
            }

            string path = asPathTxt.Text;

            //检查有文件路径
            if(path.Length<7){
                MessageBox.Show("你输入的保存路径不正确，请检查后重新输入", "提示");
                return;
            }

            string dirStr = Path.GetDirectoryName(path);
            if(!Directory.Exists(dirStr)){
                MessageBox.Show("你输入的保存路径不正确，请检查后重新输入", "提示");
                return;
            }

            //检查文件名
            string fileName = Path.GetFileName(path);
            if(fileName.Length<4){
                MessageBox.Show("你输入的文件名字不合法，请检查后重新输入", "提示");
                return;
            }

            //检查扩展名
            string exName = Path.GetExtension(path);
            if(exName != ".as"){
                MessageBox.Show("你输入的文件名字扩展名不为as，请检查后重新输入", "提示");
                return;
            }


            string[] libPaths = new string[libFolderList.Items.Count];
            string[] exlibPaths = new string[exLibFodlerList.Items.Count+1];

            int i =0;
            foreach ( string pathStr in libFolderList.Items)
            {
                libPaths[i++] = pathStr;
            }

            i = 0;
            foreach (string pathStr in exLibFodlerList.Items)
            {
                exlibPaths[i++] = pathStr;
            }

            //把自己也加入例外文件
            exlibPaths[i] = asPathTxt.Text;

            string className = Path.GetFileName(asPathTxt.Text);
            className = className.Substring(0, className.Length - 3);

            if (packNameTxt.Text.Length > 0) className = packNameTxt.Text+"." + className;

            string importClassStr = this.createImportClass(libPaths, exlibPaths, className);

            File.WriteAllText(asPathTxt.Text, importClassStr, Encoding.UTF8);

            ToolSetting.save();
            MessageBox.Show("文件已经保存", "提示");
        }

        private string createImportClass(string[] libPaths,string[] exLibPaths,string classname){

            if (libPaths.Length < 1) return "";

            //例外文件哈希表
            Hashtable exMap = new Hashtable();
            foreach (string expath in exLibPaths)
            {
                string exname = Path.GetExtension(expath);
                if (exname == ".as")
                {
                    //是代码文件
                    exMap["asFile::" + expath] = true;
                }
                else
                {
                    //是目录
                    exMap[expath] = true;
                }
            }

            //写入全部的文件路径
            List<string> classPaths = new List<string>();
            foreach (string libPath in libPaths){
                writeAllAsClassPath(libPath, libPath.Length, classPaths, exMap);
            }

            string importStr = "";
            string varStr = "";
            int varID = 0;
            foreach (string classpath in classPaths)
            {
                //在加入例外目录那里已经干过这事了
                //if (classpath == classname) continue;
                
                importStr += "import " + classpath + ";\r\n";
                varStr += "	public var class" + varID.ToString() + ":" + classpath+"\r\n";
                varID++;
            }

            string classContent = resource.GetString("templet");
            classContent = classContent.Replace("$(importallclass)", importStr);
            classContent = classContent.Replace("$(classname)", classname);
            classContent = classContent.Replace("$(varclass)", varStr);
            
            return classContent;
        }

        /// <summary>
        /// 写入全部的AS文件路径(弃用)
        /// </summary>
        /// <param name="path"></param>
        /// <param name="asFiles"></param>
        /// <param name="exMap">
        /// 例外文件哈希表，key值为AS文件路径或库文件夹路径
        /// as文件路径要加前缀"asFile::"
        /// </param>
        private void writeAllAsFilePath(string path, List<string> asFiles,Hashtable exMap){

            string[] asPaths = Directory.GetFiles(path, "*.as");
            foreach(string asPath in asPaths){
                if(exMap["asFile::" + asPath] == null){
                    if (!asFiles.Contains(asPath)) asFiles.Add(asPath);
                }
            }

            string[] dirs = Directory.GetDirectories(path);
            if (dirs.Length < 1) return;

            foreach(string dirPath in dirs){
                if(exMap[dirPath] == null){
                    writeAllAsFilePath(dirPath, asFiles,exMap);
                }
            }

        }

        /// <summary>
        /// 写入全部的AS类路径
        /// </summary>
        /// <param name="path"></param>
        /// <param name="rootPath"></param>
        /// <param name="classPaths"></param>
        /// <param name="exMap">
        /// 例外文件哈希表，key值为AS文件路径或库文件夹路径
        /// as文件路径要加前缀"asFile::"
        /// </param>
        private void writeAllAsClassPath(string path, int offsetLen,List<string> classPaths, Hashtable exMap)
        {

            string[] asPaths = Directory.GetFiles(path, "*.as");
            foreach (string asPath in asPaths)
            {
                if (exMap["asFile::" + asPath] == null)
                {
                    string classname = asPath.Substring(offsetLen + 1);
                    classname = classname.Replace("\\", ".");
                    classname = classname.Substring(0, classname.Length - 3);

                    if (!classPaths.Contains(classname)) classPaths.Add(classname);
                }
            }

            string[] dirs = Directory.GetDirectories(path);
            if (dirs.Length < 1) return;

            foreach (string dirPath in dirs)
            {
                if (exMap[dirPath] == null)
                {
                    writeAllAsClassPath(dirPath, offsetLen, classPaths, exMap);
                }
            }

        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            this.saveSetting();
        }
    }
}
