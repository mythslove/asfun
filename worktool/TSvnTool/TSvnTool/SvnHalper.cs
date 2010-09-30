using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TSvnTool
{
    class SvnHalper
    {
        public delegate bool SvnFileSelect(SvnFileInfo info);

        public static  List<SvnFileInfo> getFileList(string projPath, string fileInfo,string[] deleteIDStrs,SvnFileSelect selectFun)
        {

            if (!Directory.Exists(projPath)) return null;
            if (fileInfo == null) return null;

            string[] infoList = fileInfo.Split(new string[1]{"\r\n"},StringSplitOptions.RemoveEmptyEntries);

            List<SvnFileInfo> returnObj = new List<SvnFileInfo>(infoList.Length);

            foreach (string info in infoList)
            {
                string[] infoItem = info.Split('\t');
                SvnFileInfo svnInfo = new SvnFileInfo();
                svnInfo.path = Path.Combine(projPath, infoItem[0].Replace("/", "\\"));
                svnInfo.isDelete = deleteIDStrs.Contains(infoItem[3]);
                svnInfo.isError = !File.Exists(svnInfo.path) && !svnInfo.isDelete;

                
                if ((selectFun == null) || selectFun(svnInfo)) returnObj.Add(svnInfo);
            }

            return returnObj;
        }

        public static List<SvnFileInfo> getFileList(string projPath,string fileInfo,string[] deleteIDStrs){
            return getFileList(projPath, fileInfo, deleteIDStrs, null);
        }

    }

    class SvnFileInfo{
        public bool isError = false;
        public string path = "";
        public bool isDelete = false;
    }
}
