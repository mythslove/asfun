<%@ WebHandler Language="C#" Class="ByteArray" %>

using System;
using System.Web;
using System.IO;

/// <summary>
/// 接收客户端数据
/// </summary>
public class ByteArray : IHttpHandler {
    
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Write("Hello World");

        Stream intput = context.Request.InputStream;
        byte[] data = new byte[intput.Length];
        intput.Read(data, 0, data.Length);
        intput.Seek(0, SeekOrigin.Begin);
        
        File.WriteAllBytes("c://ByteArray.data", data);

        context.Response.End();
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}