/***************************************************************************
*projectname:NEAPrint.Excel
*classname:ExcelApp
*des:ExcelApp
*author:guandy   https://github.com/guandy/NEAPrint
*createtime:2019-04-11 09:25:17
*updatetime:2019-04-11 09:25:17
***************************************************************************/
using System;
using System.Data;
using System.Drawing;
using Excel = Microsoft.Office.Interop.Excel;

namespace NEAPrint
{
	public class ExcelApp 
	{
        /// <summary>
        /// Excel应用程序
        /// </summary>
        private Excel.Application _excelApp;                          
        /// <summary>
        /// 默认只有一个，用Open()创建
        /// </summary>
        private Excel.Workbook _excelWorkbook;
        /// <summary>
        /// 打印或预览时是否还要显示Excel窗体
        /// </summary>
        private bool _IsExcelAppVisibled;
        /// <summary>
        /// 打印预览Excel窗体的标题栏
        /// </summary>                      
        private string _FormCaption;
        /// <summary>
        /// 实例化参数对象,excel空对象
        /// </summary>
        private object oMissing = System.Reflection.Missing.Value; 


        /// <summary>
        /// Excel应用程序
        /// </summary>
        public Excel.Application Application
        {
            get
            {
                return _excelApp;
            }
        }

        /// <summary>
        /// Excel，默认只有一个，用Open()创建
        /// </summary>
        public Excel.Workbook Workbooks
        {
            get
            {
                return _excelWorkbook;
            }
        }

        /// <summary>
        /// 打印或预览时是否还要显示Excel窗体
        /// </summary>
        public bool IsExcelAppVisibled
        {
            get
            {
                return _IsExcelAppVisibled;
            }
            set
            {
                _IsExcelAppVisibled = value;
            }
        }

        /// <summary>
        /// 打印预览Excel窗体的标题栏
        /// </summary>
        public string FormCaption
        {
            get
            {
                return _FormCaption;
            }
            set
            {
                _FormCaption = value;
            }
        }

        /// <summary>
        /// 创建立Excel新的实例
        /// </summary>
        public ExcelApp()
        {
            //打印及预览时Excel显示
            _IsExcelAppVisibled = false;               
            _FormCaption = "打印预览";

            try
            {
                _excelApp = new Excel.ApplicationClass();
            }
            catch (System.Exception ex)
            {
                throw new ExcelCreateException("创建Excel类实例时错误，详细信息：" + ex.Message);
            }
            //关闭程序建立的Excel文件时，不会提示是否要保存修改
            _excelApp.DisplayAlerts = false;            
        }

        #region 打开关闭

        /// <summary>
        /// 根据现有工作薄模板打开，如果指定的模板不存在，则用默认的空模板
        /// </summary>
        /// <param name="excelFileName">用作模板的工作薄文件名</param>
        public void Open(string excelFileName)
        {
            if (System.IO.File.Exists(excelFileName))
            {
                try
                {
                    _excelWorkbook = _excelApp.Workbooks.Add(excelFileName);
                }
                catch (System.Exception ex)
                {
                    throw new ExcelOpenException("打开Excel时错误，详细信息：" + ex.Message);
                }
            }
            else
            {
                Open();
            }
        }


        /// <summary>
        /// 打开Excel，并建立默认的Workbooks。
        /// </summary>
        /// <returns></returns>
        public void Open()
        {
            try
            {
                _excelWorkbook = _excelApp.Workbooks.Add(oMissing);
            }
            catch (System.Exception ex)
            {
                throw new ExcelOpenException("打开Excel时错误，详细信息：" + ex.Message);
            }

        }

        /// <summary>
        /// 关闭
        /// </summary>
        public void Close()
        {
            _excelApp.Workbooks.Close();
            _excelWorkbook = null;
            _excelApp.Quit();
            _excelApp = null;
            oMissing = null;
            System.GC.Collect();//释放GC,避免多个Excel对象
        }
        #endregion

        /// <summary>
        /// 显示Excel
        /// </summary>
        public void ShowExcel()
        {
            _excelApp.Visible = true;
        }

        /// <summary>
        /// 打印预览，如果要显示Excel窗口，IsVisibledExcel = true
        /// </summary>
        public void PrintPreview()
        {
            _excelApp.Caption = _FormCaption;
            _excelApp.Visible = true;

            try
            {
                _excelApp.WindowState = Excel.XlWindowState.xlMaximized;//最大化展示
                _excelApp.ActiveWorkbook.PrintPreview(oMissing);
            }
            catch { }

            _excelApp.Visible = this.IsExcelAppVisibled;

        }

        /// <summary>
        /// 打印
        /// </summary>
        public void Print()
        {
            _excelApp.Visible = this.IsExcelAppVisibled;

            object oMissing = System.Reflection.Missing.Value;  //实例化参数对象
            try
            {
                _excelApp.ActiveWorkbook.PrintOut(oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);
            }
            catch
            {
            }
        }
    }
}