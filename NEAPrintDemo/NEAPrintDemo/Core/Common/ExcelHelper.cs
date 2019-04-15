using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace NEAPrintDemo
{
    public class ExcelHelper
    {
        /// <summary>
        /// 文件转换成Base64字符串
        /// </summary>
        /// <param name="excelByte">文件byte</param>
        /// <returns></returns>
        public static string ByteToBase64(byte[] excelByte)
        {
            string strRet = "";
            try
            {
                strRet = Convert.ToBase64String(excelByte);
            }
            catch (Exception ex)
            {
                strRet = null;
            }

            return strRet;
        }


        public static string GetBase64ByPath(string path)
        {
            byte[] bytes;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                bytes = new byte[(int)fs.Length];
                fs.Read(bytes, 0, bytes.Length);
            }
            var excelBase64 = ByteToBase64(bytes);
            return excelBase64;
        }
    }
}