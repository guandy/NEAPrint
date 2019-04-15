/***************************************************************************
*projectname:NEAPrint.Core.Common
*classname:PrintHttpListener
*des:PrintHttpListener
*author:guandy   https://github.com/guandy/NEAPrint
*createtime:2019-04-08 16:45:35
*updatetime:2019-04-08 16:45:35
***************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace NEAPrint
{
    /// <summary>
    /// 打印监听程序
    /// </summary>
    public class PrintHttpListener
    {
        /// <summary>
        /// http监听
        /// </summary>
        private HttpListener listerner;


        public delegate void ResponseEventArges(HttpListenerContext httpListenerContext);


        public event ResponseEventArges ResponseEvent;


        private AsyncCallback AsyncCallback = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prefixes">["http://127.0.0.1:888",""http://127.0.0.1:999"] </param>
        /// <param name="authent"></param>
        public PrintHttpListener(string[] prefixes, AuthenticationSchemes authent = AuthenticationSchemes.Anonymous)
        {
            listerner = new HttpListener();
            listerner.AuthenticationSchemes = authent;//指定身份验证 Anonymous匿名访问
            foreach (var item in prefixes)
            {
                listerner.Prefixes.Add(item);
            }
        }


        public void Start()
        {
            if (!listerner.IsListening)
            {
                listerner.Start();
                AsyncCallback = new AsyncCallback(GetContextAsyncCallback);
                listerner.BeginGetContext(AsyncCallback, null);
            }
        }

        /// <summary>
        /// 停止监听服务
        /// </summary>
        public void Stop()
        {
            listerner.Stop();
        }

        /// <summary>
        /// 收到监听请求回调
        /// </summary>
        /// <param name="iAsyncResult"></param>
        public void GetContextAsyncCallback(IAsyncResult iAsyncResult)
        {
            if (iAsyncResult.IsCompleted)
            {
                HttpListenerContext httpListenerContext = listerner.EndGetContext(iAsyncResult);
                httpListenerContext.Response.StatusCode = 200;
                if (ResponseEvent != null)
                {
                    ResponseEvent.BeginInvoke(httpListenerContext, null, null);
                }
                else
                {
                    System.IO.BinaryWriter br = new System.IO.BinaryWriter(httpListenerContext.Response.OutputStream, new UTF8Encoding());
                    httpListenerContext.Response.Close();
                    br.Close();
                }
            }
            listerner.BeginGetContext(AsyncCallback, null);
        }


        public Dictionary<string, string> GetRequestData(HttpListenerContext httpListenerContext, HttpMethodType httpMethodType)
        {
            var dict = new Dictionary<string, string>();
            var httpRequest = httpListenerContext.Request;
            switch (httpMethodType)
            {
                case HttpMethodType.POST:
                    if (httpRequest.HttpMethod == HttpMethodType.POST.ToString())
                    {
                        string postData;
                        using (var streamReader = new StreamReader(httpRequest.InputStream, httpRequest.ContentEncoding))
                        {
                            postData = streamReader.ReadToEnd();
                        }
                        string[] postParams = postData.Split('&');
                        foreach (string param in postParams)
                        {
                            string[] kvPair = param.Split('=');
                            dict[kvPair[0]] = kvPair[1];
                        }
                    }
                    break;
                case HttpMethodType.GET:
                    if (httpRequest.HttpMethod == HttpMethodType.GET.ToString())
                    {
                        string[] keys = httpRequest.QueryString.AllKeys;
                        foreach (string key in keys)
                        {
                            dict[key] = httpRequest.QueryString[key];
                        }
                    }
                    break;
            }
            return dict;
        }
    }

    /// <summary>
    /// 数据提交方式
    /// </summary>
    public enum HttpMethodType
    {
        POST = 1,
        GET = 2,
    }
}
