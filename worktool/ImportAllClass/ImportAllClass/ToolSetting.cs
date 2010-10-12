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
        //配置文件名的路径
        private static string configPath;

        public static void read(){

            updatePath();

            if (File.Exists(configPath))
            {
                FileStream fs = new FileStream(configPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                settingObj = (Setting)bf.Deserialize(fs);
                fs.Close();
            }
        }

        public static void save() {
            updatePath();

            FileStream fs = new FileStream(configPath, FileMode.Create);
            bf.Serialize(fs, settingObj);
            fs.Close();
        }

        private static void updatePath(){
            if (configPath != null) return;
            string settingFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ngs";
            if (!Directory.Exists(settingFolder)) Directory.CreateDirectory(settingFolder);
            configPath = settingFolder + "\\ImportAllClass.config";
        }

        //System.Environment.CurrentDirectory返回的路径会被选择文件对话框干扰
        //string configPath = Path.Combine(System.Environment.CurrentDirectory, "setting.cfg");

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
