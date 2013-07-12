using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            if (!IsGZipFile(file)) return null;

            
            GZipStream gs = new GZipStream(new MemoryStream(file), CompressionMode.Decompress, true);
            
            //从压缩流中读出所有数据
            MemoryStream source = new MemoryStream();
            byte[] buff = new byte[4096];
            int n;
            while((n = gs.Read(buff,0,buff.Length)) != 0){
                source.Write(buff,0,n);
            }

            return source.ToArray();
        }
    }
}
