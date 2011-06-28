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

namespace CMDEditor
{
    public partial class CMDEditorMain : Form
    {
       
        public CMDEditorMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 文件拖到这个位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMDEditor_DragEnter(object sender, DragEventArgs e)
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

        private void CMDEditor_DragDrop(object sender, DragEventArgs e)
        {
            string filePath = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];

            if (Path.GetExtension(filePath) != ".as") return;
            this.setFile(filePath);

            if (!this.tabControl.Enabled) this.tabControl.Enabled = true;
        }


        private void addEventBtn_Click(object sender, EventArgs e)
        {
            this.addEvent(this.eventNameTxt.Text, this.eventTitleTxt.Text, this.eventInfoTxt.Text, this.eventParamTxt.Text);
            this.save();
        }




        ////////////////////////////////////////////////////////////////
        //                      处理函数
        ////////////////////////////////////////////////////////////////

        private string curFilePath;         //当前文件地址
        private string codeStr;             //当前文件的内容


        /// <summary>
        /// 设置文件
        /// </summary>
        /// <param name="file"></param>
        private void setFile(string file)
        {
            this.curFilePath = file;
            this.codeStr = File.ReadAllText(file);
        }

        /// <summary>
        /// 增加事件
        /// </summary>
        /// <param name="name"></param>
        /// <param name="title"></param>
        /// <param name="info"></param>
        /// <param name="param"></param>
        private void addEvent(string name,string title,string info,string param)
        {
            this.checkHasFile();
            string flagTemp = Properties.Resources.Templet_EventFlag;
            string codeTemp = Properties.Resources.Templet_Event;

            //先判断有没有加入事件的模块
            int id = this.codeStr.IndexOf(flagTemp);
            if (id < 0)
            {
                this.codeStr += "\r\n" + flagTemp;
                id = this.codeStr.Length;
            }

            codeTemp = codeTemp.Replace("$(EventTitle)", title);
            info = info.Replace("\r\n", "\r\n	 * ");
            codeTemp = codeTemp.Replace("$(EventInfo)", info);
            codeTemp = codeTemp.Replace("$(EventName)", name);

            if (param.Length > 0)
            {
                param = "//" + param.Replace("\r\n", "\r\n		//");
                codeTemp = codeTemp.Replace("$(EventParametrs)", param);
            }
            else
            {
                codeTemp = codeTemp.Replace("$(EventParametrs)", "无参数");
            }

        }

        /// <summary>
        /// 检查是否有文件
        /// </summary>
        private void checkHasFile()
        {
            if (this.codeStr == null) throw new Exception("文件还没有拖入");
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        private void save()
        {
            File.WriteAllText(this.curFilePath, this.codeStr);
        }
    }
}
