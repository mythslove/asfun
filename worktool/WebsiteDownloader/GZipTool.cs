using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiddler;

namespace WebsiteDownloader
{
    static class GZipTool
    {

        public static bool IsQZipFile(string path)
        {
            if (!File.Exists(path)) return false;
            return IsGZipFile(File.ReadAllBytes(path));
        }
        
        /// <summary>
        /// 判断一段数据是滞经过GZIP压缩
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool IsGZipFile(byte[] file)
        {
            if (file.Length < 2) return false;
            if (file[0] != 0x1f) return false;
            if (file[1] != 0x8B) return false;
            return true;
        }

        public static bool IsGZipFile(Session oSession)
        {
            string contentEncoding = oSession.oResponse.headers["Content-Encoding"].ToString();
            if (contentEncoding == "gzip") return true;

            byte[] file = oSession.ResponseBody;
            if (file.Length < 2) return false;
            if (file[0] != 0x1f) return false;
            if (file[1] != 0x8B) return false;
            return true;
        }

        /// <summary>
        /// 解压GZip文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static byte[] Decompress(string path)
        {
            if (!File.Exists(path)) return null;
            return Decompress(File.ReadAllBytes(path));
        }

        public static byte[] Decompress(byte[] file)
        {

            int index = ByteIndexOf(file, new byte[] { 0x1f, 0x8b }, 0);
            if (index == -1) return file;

            if (index != 0)
            {
                byte[] newFile = new byte[file.Length - index];
                Buffer.BlockCopy(file, index, newFile, 0, newFile.Length);
                file = newFile;
            }

            GZipStream gs = new GZipStream(new MemoryStream(file), CompressionMode.Decompress, true);
            
            //从压缩流中读出所有数据
            MemoryStream source = new MemoryStream();
            byte[] buff = new byte[4096];
            int n;
            while((n = gs.Read(buff,0,buff.Length)) != 0){
                source.Write(buff,0,n);
            }

            byte[] outData = source.ToArray();
            if (outData == null) return file;
            return outData;
        }

        private static int ByteIndexOf(byte[] searched, byte[] find, int start)
        {
            bool matched = false;
            int end = find.Length - 1;
            int skip = 0;
            for (int index = start; index <= searched.Length - find.Length; ++index)
            {
                matched = true;
                if (find[0] != searched[index] || find[end] != searched[index + end]) continue;
                else skip++;
                if (end > 10)
                    if (find[skip] != searched[index + skip] || find[end - skip] != searched[index + end - skip])
                        continue;
                    else skip++;
                for (int subIndex = skip; subIndex < find.Length - skip; ++subIndex)
                {
                    if (find[subIndex] != searched[index + subIndex])
                    {
                        matched = false;
                        break;
                    }
                }
                if (matched)
                {
                    return index;
                }
            }
            return -1;
        }
    }
}
