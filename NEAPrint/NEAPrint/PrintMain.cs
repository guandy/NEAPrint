using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace NEAPrint
{
    public partial class PrintMain : Form
    {
        PrintHttpListener _PrintHttpListener;

        public PrintMain()
        {
            InitializeComponent();
            InitMenu();
            Listener();
        }

        private void InitMenu() {
            string strFilePath = Application.ExecutablePath;
            string strFileName = System.IO.Path.GetFileName(strFilePath);
            try
            {
                var isAuto = SystemHelper.IsAutoRun(strFilePath + " -autostart", strFileName);
                if (!isAuto)
                {
                    SystemHelper.SetAutoRun(strFilePath + " -autostart", strFileName, true);
                    isAuto = true;
                }
                AppIsAutoRun.Checked = isAuto;
            }
            catch { }
        }


        public void Listener()
        {
            string[] arryUrl = new string[] { "http://127.0.0.1:31250/", "http://127.0.0.1:31149/" };
            _PrintHttpListener = new PrintHttpListener(arryUrl);
            _PrintHttpListener.ResponseEvent += _HttpListener_ResponseEvent;
            _PrintHttpListener.Start();
        }

        void _HttpListener_ResponseEvent(System.Net.HttpListenerContext ctx)
        {
            Dictionary<string, string> retPosts = _PrintHttpListener.GetRequestData(ctx, HttpMethodType.POST);
            var result = DoPrint(retPosts);
            JavaScriptSerializer js = new JavaScriptSerializer();
            var resultJosn = js.Serialize(result);
            ResponseWrite(ctx.Request.AcceptTypes[0], resultJosn, ctx.Response);
        }

        private CommonResult DoPrint(Dictionary<string, string> postDict)
        {
            var controller = postDict["Controller"];
            CommonResult result = new CommonResult();
            var printFlag = string.Empty;
            switch (controller)
            {
                case "print":
                    var base64 = postDict["FileBase64"];
                    printFlag = postDict["PrintFlag"];
                    result = new PrintService().PrintExcelBase64(base64, printFlag);
                    break;
                case "printurl":
                    var fileUrl = postDict["FileUrl"];
                    printFlag = postDict["PrintFlag"];
                    result = new PrintService().PrintExcelUrl(fileUrl, printFlag);
                    break;
                case "getversion":
                    result = new PrintService().GetVersion();
                    break;
                default:
                    break;
            }
            return result;
        }

        static void ResponseWrite(string type, string msg, System.Net.HttpListenerResponse response)
        {
            response.ContentType = "application/json;charset=UTF-8";
            response.AddHeader("Content-type", "application/json");//添加响应头信息
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            response.ContentEncoding = Encoding.UTF8;
            response.StatusCode = 200;
            response.StatusDescription = "200";

            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(msg);
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            
            output.Write(buffer, 0, buffer.Length);
            output.Close();
            response.Close();
        }


        private void 退出MenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AppIsAutoRun_Click(object sender, EventArgs e)
        {
            string strFilePath = Application.ExecutablePath;
            string strFileName = System.IO.Path.GetFileName(strFilePath);
            try
            {
                SystemHelper.SetAutoRun(strFilePath + " -autostart", strFileName, !AppIsAutoRun.Checked);
                AppIsAutoRun.Checked = !AppIsAutoRun.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NEA打印服务MenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

    }
}
