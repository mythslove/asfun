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
        //context.Response.Write("Hello World");

        string fileName = context.Request["name"];
        if (fileName == null || fileName == "") fileName = "ByteArray.data";

        Stream intput = context.Request.InputStream;

        if (intput.Length <= 0)
        {
            context.Response.Write("没有传入文件");
            return;
        }
        
        
        byte[] data = new byte[intput.Length];
        intput.Read(data, 0, data.Length);
        intput.Seek(0, SeekOrigin.Begin);

        File.WriteAllBytes(context.Request.MapPath("output/" + fileName ), data);

        context.Response.Write("已经保存成功");
        context.Response.End();
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}