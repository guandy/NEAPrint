/***************************************************************************
*projectname:NEAPrint.Core
*classname:PrintService
*des:PrintService
*author:guandy   https://github.com/guandy/NEAPrint
*createtime:2019-04-08 17:06:39
*updatetime:2019-04-08 17:06:39
***************************************************************************/
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace NEAPrint
{
    public class PrintService
    {
        /// <summary>
        /// 根据链接打印excel
        /// </summary>
        /// <param name="url"></param>
        /// <param name="printType"></param>
        /// <param name="isOpenPrintDialog"></param>
        /// <returns></returns>
        public CommonResult PrintExcelUrl(string url, string printType, bool isOpenPrintDialog)
        {
            string path = Utils.NewExcelFullName();
            bool saveResult = Utils.UrlToFile(url, path);
            if (!saveResult)
                return JResult.Error("下载文件失败");

            var printResult = PrintFile(path, printType, isOpenPrintDialog);

            return printResult;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="excelBase64"></param>
        /// <param name="printType"></param>
        /// <param name="isOpenPrintDialog"></param>
        /// <returns></returns>
        public CommonResult PrintExcelBase64(string excelBase64, string printType, bool isOpenPrintDialog)
        {
            string path = Utils.NewExcelFullName();
            bool saveResult = Utils.Base64ToFile(excelBase64, path);
            if (!saveResult)
                return JResult.Error("不是有效的base64数据");

            var printResult = PrintFile(path, printType, isOpenPrintDialog);

            return printResult;
        }

        public CommonResult PrintFile(string filePath, string printType, bool isOpenPrintDialog)
        {
            if (!File.Exists(filePath))
                return JResult.Error("文件不存在");
            ExcelApp excel = new ExcelApp();
            excel.Open(filePath);

            if (printType == PrintType.Preview.GetHashCode().ToString())
            {
                excel.IsExcelAppVisibled = true;
                excel.PrintPreview();
            }
            else
            {
                if (isOpenPrintDialog)
                {
                    var app = excel.Application;
                    app.WindowState = XlWindowState.xlNormal;
                    app.Width = app.Height = 0;
                    var dialogResult = app.Dialogs[XlBuiltInDialog.xlDialogPrint].Show();
                    app.Quit();
                    excel.Close();
                }
                else
                {
                    excel.Application.Application.WindowState = XlWindowState.xlMaximized;
                    excel.IsExcelAppVisibled = false;
                    excel.Print();
                }
            }
            Utils.DeleteExcel();
            return JResult.Success();
        }

        public CommonResult GetVersion() {
            var version = Utils.GetAssemblyInfo();
            return JResult.Success("获取成功","0",version);
        }
    }
}
