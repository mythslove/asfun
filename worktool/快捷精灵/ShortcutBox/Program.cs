using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ShortcutBox
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            SBoxMainForm mainForm = new SBoxMainForm();
            Application.Run();
            //Application.Run(mainForm);
        }
    }
}
