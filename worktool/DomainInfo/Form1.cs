using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace DomainInfo
{
    public partial class Form1 : Form
    {
        private DomainTool tool;
 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.tool = new DomainTool();
        }
}
    }


    public class DomainTool
    {
        private const string API_URL = "http://chaojizhan.com/com/whoisb.asp?domain={0}&anticache={1}";

        private bool _isStartRequest = false;

        private HttpWebRequest request;
        private List<DomainInfo> requestList;
        private List<DomainInfo> domainInfoList;


        public DomainTool()
        {
            this.requestList = new List<DomainInfo>();
        }

        public void setDomainList(string[] domains)
        {
            this.requestList.Clear();
            if (this.request != null && this._isStartRequest) this.request.Abort();
            this.domainInfoList = new List<DomainInfo>();

            int len = domains.Length;
            for (int i = 0; i < len; i++)
            {
                DomainInfo di = new DomainInfo();
                di.domain = domains[i];
                this.requestList.Add(di);
            }

            this._isStartRequest = true;
            this.start();
        }

        public void addDomain(string url)
        {
            DomainInfo di = new DomainInfo();
            di.domain = url;
            this.requestList.Add(di);

            if (this._isStartRequest) return;

            this._isStartRequest = true;
            this.start();
        }


        public DomainInfo[] getDomainInfoList()
        {
            if (this.domainInfoList == null) return null;
            return this.domainInfoList.ToArray();
        }


        private void start()
        {
            DomainInfo domain = this.requestList[0];
            Random rd = new Random();
            this.request = (HttpWebRequest)WebRequest.Create(String.Format(API_URL, domain.domain,rd.Next(1000).ToString()));
            this.request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/534.24 (KHTML, like Gecko) Chrome/11.0.696.60 Safari/534.24";
            this.request.Method = "GET";
            this.request.Accept = "*/*";
            this.request.Referer = "http://chaojizhan.com/dev/baidu.asp?canvas_pos=search&keyword=%E6%89%B9%E9%87%8F%E5%9F%9F%E5%90%8D%E6%9F%A5%E8%AF%A2&bd_user=0&bd_sig=587a86456c5be6d64e3167e3417f2801";
            this.request.Headers.Add("X-Requested-With:XMLHttpRequest");
            this.request.Headers.Add("Accept-Charset:GBK,utf-8;q=0.7,*;q=0.3");
            this.request.Headers.Add("Accept-Encoding:gzip,deflate,sdch");
            this.request.Headers.Add("Accept-Language:zh-CN,zh;q=0.8");
            
            CookieContainer cookie = new CookieContainer();
            cookie.SetCookies(new Uri("http://chaojizhan.com/"),"ASPSESSIONIDQSASAQSQ=BHHDGJFBCMBIOKDDDNMHLAAD; cnzz_a1323913=6; sin1323913=http%3A//app.baidu.com/116470%3Fcanvas_pos%3Dsearch%26keyword%3D%25E6%2589%25B9%25E9%2587%258F%25E5%259F%259F%25E5%2590%258D%25E6%259F%25A5%25E8%25AF%25A2; rtime=0; ltime=1320911765273; cnzz_eid=56877895-1320889500-http%3A//app.baidu.com/116470%3Fcanvas_pos%3Dsearch%26keyword%3D%25E6%2589%25B9%25");
            this.request.CookieContainer = cookie;
            this.request.KeepAlive = true;
            this.request.BeginGetResponse(onResponseCallback, this.request);
        }


        private void onResponseCallback(IAsyncResult result)
        {

            HttpWebResponse response = (HttpWebResponse)this.request.EndGetResponse(result);

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream,Encoding.UTF8);
            string data = reader.ReadToEnd();

            //加载完毕
            DomainInfo domain = this.requestList[0];
            domain.setData(data);
            this.domainInfoList.Add(domain);

            this.requestList.RemoveAt(0);


        }
    }

    public class DomainInfo
    {
        public string domain;
        public bool isReg;
        public string createDate;      //注册时间
        public string updatedDate;     //续费时间
        public string expirationDate;  //到期时间
        public string price;           //大概价格
        public string data;

        public void setData(string data)
        {
            //续费|注册|到期
            //被注册：2011-10-21|2004-09-26|2012-09-26|55
            //没被注册：no|55

            string[] t = data.Split('|');

            if (t[0] == "no")
            {
                this.isReg = false;
                this.price = t[1];
                this.updatedDate = null;
                this.createDate = null;
                this.expirationDate = null;
            }
            else
            {
                this.isReg = false;
                this.price = t[3];
                this.updatedDate = t[0];
                this.createDate = t[1];
                this.expirationDate = t[2];
            }

            this.data = data;

        }
    }


}
