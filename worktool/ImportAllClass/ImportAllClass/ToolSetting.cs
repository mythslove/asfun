using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ImportAllClass
{
    
    class ToolSetting
    {
        
        public static Setting settingObj = new Setting();
        private static BinaryFormatter bf = new BinaryFormatter();

        public static void read(){
            //System.Environment.CurrentDirectory返回的路径会被选择文件对话框干扰
            //string configPath = Path.Combine(System.Environment.CurrentDirectory, "setting.cfg");
            string configPath = Path.Combine(System.Windows.Forms.Application.StartupPath, "setting.cfg");
            if (File.Exists(configPath))
            {
                FileStream fs = new FileStream(configPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                settingObj = (Setting)bf.Deserialize(fs);
                fs.Close();
            }
        }

        public static void save() {
            //string configPath = Path.Combine(System.Environment.CurrentDirectory, "setting.cfg");
            string configPath = Path.Combine(System.Windows.Forms.Application.StartupPath, "setting.cfg");
            FileStream fs = new FileStream(configPath, FileMode.Create);
            bf.Serialize(fs, settingObj);
            fs.Close();
        }
    }

    [Serializable]
    class Setting
    {

        public List<string> libList = new List<string>();
        public List<string> exLibList = new List<string>();
        public string classPath = "";
        public string packname = "";

    }
}
