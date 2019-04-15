/***************************************************************************
*projectname:NEAPrint.Core.Common
*classname:Utils
*des:Utils
*author:guandy   https://github.com/guandy/NEAPrint
*createtime:2019-04-11 09:25:17
*updatetime:2019-04-11 09:25:17
***************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace NEAPrint
{
    public class Utils
    {

        public static string GetAssemblyInfo() {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        /// <summary>
        /// EXCEL临时文件存放目录
        /// </summary>
        /// <returns></returns>
        public static string ExcelTemPath()
        {
            return $@"{AppDomain.CurrentDomain.BaseDirectory}Excel";
        }

        /// <summary>
        /// 创建一个新的excel路径，用于保存
        /// </summary>
        /// <returns></returns>
        public static string NewExcelFullName()
        {
            var directory = $@"{ExcelTemPath()}\{DateTime.Now.ToString("yyyyMMdd")}";
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            string path = $@"{directory}\Print{DateTime.Now.ToString("yyyyMMddHHmmss")}.xls";
            return path;
        }
        /// <summary>
        /// 删除临时文件
        /// </summary>
        public static void DeleteExcel()
        {
            try
            {
                string directoryPath = ExcelTemPath();
                string directoryDayPath = $@"{ExcelTemPath()}\{DateTime.Now.ToString("yyyyMMdd")}";
                Directory.GetDirectories(directoryPath).ToList().ForEach(path =>
                {
                    if (path != directoryDayPath)
                    {
                        Directory.GetFiles(path).ToList().ForEach(File.Delete);
                    }
                    Directory.Delete(path);
                });
            }
            catch
            {

            }
        }
        /// <summary>
        /// Base64字符串转换成文件
        /// </summary>
        /// <param name="base64">base64字符串</param>
        /// <param name="fileName">保存文件的绝对路径</param>
        /// <returns></returns>
        public static bool Base64ToFile(string base64, string fileName)
        {
            try
            {
                base64 = UrlDecoder.UrlDecode(base64, Encoding.Default);
                byte[] buffer = Convert.FromBase64String(base64);
                FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
                fs.Write(buffer, 0, buffer.Length);
                fs.Close();
                fs.Dispose();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Base64字符串转换成文件
        /// </summary>
        /// <param name="strInput">base64字符串</param>
        /// <param name="fileName">保存文件的绝对路径</param>
        /// <returns></returns>
        public static bool UrlToFile(string url, string fileName)
        {
            try
            {
                url = UrlDecoder.UrlDecode(url, Encoding.Default);
                WebClient client = new WebClient();
                client.DownloadFile(url, fileName);
            }
            catch(Exception ex) {
                return false;
            }
            return true;
        }

    }
}
