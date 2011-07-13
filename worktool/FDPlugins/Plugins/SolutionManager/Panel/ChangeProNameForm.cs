using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SolutionManager.Panel
{
    public partial class ChangeProNameForm : Form
    {
        private ProjNode curNode;

        public ChangeProNameForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 显示并设置节点
        /// </summary>
        /// <param name="node"></param>
        public void ShowAndSetNode(ProjNode node)
        {
            this.Show();

            this.curNode = node;
            this.projPathTxt.Text = node.path;
            this.projNameTxt.Text = Path.GetFileName(node.path);
            this.nameTxt.Text = node.Text;
            this.nameTxt.Select();

            this.initPos();
        }



        /******************************************
         *               私有方法
         * ***************************************/

        private void ChangeProNameForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化这个窗口在屏幕中的位置
        /// </summary>
        private void initPos()
        {

            int x = MousePosition.X - this.nameTxt.Location.X - this.nameTxt.Width / 2  - 70;
            int y = MousePosition.Y - this.nameTxt.Location.Y  - 35;

            Rectangle screenArea = System.Windows.Forms.Screen.PrimaryScreen.Bounds;

            int maxW = screenArea.Width - this.Width -70;
            int maxH = screenArea.Height - this.Height - 25;

            if (x < 0)
            {
                x = 0;
            }
            else if (x > maxW)
            {
                x = maxW;
            }

            if (y < 0)
            {
                y = 0;
            }
            else if (y > maxH)
            {
                y = maxH;
            }

            this.SetDesktopLocation(x,y);

        }






        /******************************************
         *                事件处理
         * ***************************************/

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (this.nameTxt.Text.Length < 1)
            {
                MessageBox.Show("你还没有输入备注名","提示");
                return;
            }

            this.curNode.SetProjName(this.nameTxt.Text);

            //有更改了。
            PluginUI.GetInstance().ChangeSol();

            this.Hide();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
