using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TSvnTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void delFileBtn_Click(object sender, EventArgs e)
        {

             SvnHalper.getFileList(this.projPathTxt.Text, this.filePathTxt.Text,new string[2]{"缺少","已删除"} );
        }

    }
}
