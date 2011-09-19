using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ShortcutBox.utils;

namespace ShortcutBox
{
    public partial class SBoxMainForm : Form
    {

        public SBoxMainForm()
        {
            InitializeComponent();

            this.initHotKey();
        }

        private void initHotKey()
        {
            bool ok = HotKey.RegisterHotKey(this.Handle, 899, HotKey.KeyModifiers.Ctrl | HotKey.KeyModifiers.Alt | HotKey.KeyModifiers.Shift, Keys.Q);
        }


        private void SBoxMainFrom_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = HotKey.GetKeyState(2).ToString();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == HotKey.WM_HOTKEY)
            {

                switch (m.WParam.ToInt32()) 
                {
                    case 899:
                        this.Show();
                        break;
                }
            }

            base.WndProc(ref m);
        }

    }
}
