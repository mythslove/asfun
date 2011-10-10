using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FlashInterfaceViewer
{
    public partial class Form1 : Form
    {

        private ConfigReader cr;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.cr = new ConfigReader();
            this.cr.setPath("E:\\project\\刹神\\界面\\v1_0\\UIProj\\拍卖行\\doc\\查看\\Copy of flashinterface.txt");
        }

    }

    public class ConfigReader
    {
        private bool readed = false;
        private string configData;
        private GroupData[] groupList;

        /// <summary>
        /// 设置文件的地址
        /// </summary>
        /// <param name="path"></param>
        public void setPath(string path)
        {
            this.readed = false;
            this.configData = null;
            this.groupList = null;

            string configStr = File.ReadAllText(path, Encoding.Default);
            this.setData(configStr);
        }

        /// <summary>
        /// 设置数据
        /// </summary>
        /// <param name="configStr"></param>
        public void setData(string configStr)
        {
            if (configStr == null) return;
            if (configStr.Length < 11) return;


            this.readed = true;
            this.configData = configStr;

            this.processConfig();
        }

        private void processConfig()
        {

            ValueData vd = GetValue(this.configData, "group_num", 0);
            int groupNum = vd.toInt();
            if(groupNum<1)return;

            this.groupList = new GroupData[groupNum];
            string[] itemList = GetItemList(this.configData, "[group{0}]", groupNum, vd.lastIndex);
            for (int gid = 0; gid < groupNum; gid++)
            {
                GroupData gd = new GroupData();
                gd.setData(itemList[gid]);
                this.groupList[gid] = gd;
            }
        }

        /// <summary>
        /// 跟据关键字，得到值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static ValueData GetValue(string data, string key, int startIndex)
        {
            ValueData vd = new ValueData();
            int index = data.IndexOf(key + "=", startIndex);
            if (index < 0)
            {
                vd.key = key;
                vd.value = null;
                vd.lastIndex = startIndex;
                return vd;
            }

            startIndex = index + key.Length + 1;
            int endIndex = data.IndexOf("\r",startIndex);
            if (endIndex < 0) endIndex = data.Length;

            vd.key = key;
            vd.value = data.Substring(startIndex, endIndex - startIndex);
            vd.lastIndex = endIndex;
            
            return vd;
        }

        public static ValueData GetValue(string data)
        {
            ValueData vd = new ValueData();
            int index = data.IndexOf("=");
            if (index < 0)
            {
                vd.key = data;
                vd.value = null;
                vd.lastIndex = data.Length;

                return vd;
            }

            vd.key = data.Substring(0, index);
            vd.value = data.Substring(index +1);
            vd.lastIndex = data.Length;
            return vd;
        }

        /// <summary>
        /// 得到列表
        /// </summary>
        /// <param name="data">源数据</param>
        /// <param name="title">类似"[group{0}]"的数据</param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string[] GetItemList(string data, string title, int len,int startIndex)
        {
           
            string titleName = String.Format(title, 0);
            startIndex = data.IndexOf(titleName,startIndex);
            if(startIndex< 0)return null;
            startIndex += titleName.Length +2;

            string[] items = new string[len];
            for(int i = 0;i<len;i++){

                titleName = String.Format(title, i + 1);
                int endIndex = data.IndexOf(titleName,startIndex);
                if(endIndex<0)endIndex = data.Length;

                items[i] = data.Substring(startIndex, endIndex - startIndex).TrimEnd('\r', '\n');
                startIndex = endIndex + titleName.Length + 2;
            }

            return items;
        }
    }



    /// <summary>
    /// 代表一个组
    /// </summary>
    public class GroupData
    {

        public string name;
        public FunInfo[] funList;
        public FunInfo[] eventList;

        public void setData(string data)
        {
            ValueData vd = ConfigReader.GetValue(data, "name", 0);
            this.name = vd.value;

            vd = ConfigReader.GetValue(data,"func_num",vd.lastIndex);
            int funcNum = vd.toInt();

            vd = ConfigReader.GetValue(data, "event_num", vd.lastIndex);
            int eventNum = vd.toInt();

            int startIndex = vd.lastIndex + 2;
            int endIndex = data.IndexOf("event0", startIndex);
            if(endIndex <0)endIndex = data.Length;

            string funcStr = data.Substring(startIndex, endIndex - startIndex);
            string eventStr = data.Substring(endIndex);

            //全部的方法
            if (funcNum > 0)
            {
                this.funList = new FunInfo[funcNum];
                string[] fl = ConfigReader.GetItemList(funcStr, "func{0}", funcNum, 0);
                for (int fid = 0; fid < funcNum; fid++)
                {
                    FunInfo fi = new FunInfo();
                    fi.setData(fl[fid]);
                    this.funList[fid] = fi;
                }
            }
           
            //全部的事件
            if (eventNum > 0)
            {
                this.eventList = new FunInfo[eventNum];
                string[] el = ConfigReader.GetItemList(eventStr, "event{0}", eventNum, 0);
                for (int eid = 0; eid < eventNum; eid++)
                {
                    FunInfo fi = new FunInfo();
                    fi.setData(el[eid]);
                    this.eventList[eid] = fi;
                }
            }
            
        }
        
    }

    /// <summary>
    /// 代表每个函数 
    /// </summary>
    public class FunInfo
    {
        public string name;
        public string desc;
        public string ret;
        public string remark;

        public ParamInfo[] paramList;

        public void setData(string data)
        {

            int pi = data.IndexOf("param_num=");
            if(pi <0)pi = data.Length;
            int ri = data.LastIndexOf("remark_line_num=");
            if (ri < 0) ri = data.Length;

            string funInfoStr = data.Substring(0,pi -2);
            string paramStr = data.Substring(pi, ri - pi);
            string remarkStr = data.Substring(ri);

            ValueData vd;
             int i;
            
            //处理函数信息
            string[] itemlist = funInfoStr.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int fiLen = itemlist.Length;
            for (i = 0; i < fiLen; i++)
            {
                vd = ConfigReader.GetValue(itemlist[i]);

                switch (vd.key)
                {
                    case "name":
                        this.name = vd.value;
                        break;
                    
                    case "desc":
                        this.desc = vd.value;
                        break;

                    case "ret":
                        this.ret = vd.value;
                        break;

                    case "retmul":
                        this.ret = vd.value;
                        break;    

                }
            }


            //处理参数信息
            vd = ConfigReader.GetValue(paramStr, "param_num", 0);
            int paramNum = vd.toInt();
            if (paramNum > 0)
            {
                this.paramList = new ParamInfo[paramNum];
                string[] paramList = ConfigReader.GetItemList(paramStr, "param{0}", paramNum, vd.lastIndex);
                for (i = 0; i < paramNum; i++)
                {
                    ParamInfo pinfo = new ParamInfo();
                    pinfo.setData(paramList[i]);
                    this.paramList[i] = pinfo;
                }
            }

            //处理额外信息
            vd = ConfigReader.GetValue(remarkStr, "remark_line_num", 0);
            if (vd.toInt() < 1) return;

            this.remark = remarkStr.Substring(vd.lastIndex + 2);
        }
    }

    /// <summary>
    /// 代表参数的每一项
    /// </summary>
    public class ParamInfo
    {
        public string type;
        public string name;
        public string desc;

        public void setData(string data)
        {
            ValueData vd = ConfigReader.GetValue(data, "type", 0);
            this.type = vd.value;

            vd = ConfigReader.GetValue(data, "name", vd.lastIndex);
            this.name = vd.value;

            vd = ConfigReader.GetValue(data, "desc", vd.lastIndex);
            this.desc = vd.value;
        }
    }


    /// <summary>
    /// 代表取值时的每一项
    /// </summary>
    public struct ValueData
    {
        public string key;
        public string value;
        public int lastIndex;

        public bool isNull()
        {
            if (value == null) return true;
            if (value == "") return true;

            return false;
        }

        public int toInt()
        {
            if (this.isNull()) return -1;
            return Convert.ToInt32(value);
        }
    }
}
