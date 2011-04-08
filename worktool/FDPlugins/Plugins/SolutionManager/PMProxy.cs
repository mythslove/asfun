using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PluginCore;

namespace SolutionManager
{
    class PMProxy
    {
        private static ProjectManager.PluginMain PMain;

        public static void Initialize()
        {
            PMain = PluginBase.MainForm.FindPlugin("30018864-fadd-1122-b2a5-779832cbbf23") as ProjectManager.PluginMain;
        }

        public static void OpenFile(string path)
        {
            if (PMain == null) return;
            PMain.OpenFile(path);
        }
    }

}
