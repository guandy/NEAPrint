/***************************************************************************
*projectname:NEAPrint.Excel
*classname:ExcelCreateException
*des:ExcelCreateException
*author:guandy   https://github.com/guandy/NEAPrint
*createtime:2019-04-11 09:25:17
*updatetime:2019-04-11 09:25:17
***************************************************************************/
using System;

namespace NEAPrint
{
	/// <summary>
	/// 创建Excel错误
	/// </summary>
	public class ExcelCreateException:Exception
	{
		
		private string _message = "创建Excel错误！";

        public override string Message
        {
            get
            {
                return this._message;
            }
        }

        public ExcelCreateException()
		{		
		}
		
		public ExcelCreateException(string message)
		{
			this._message = message;
		}
	}


	/// <summary>
	/// 打开Excel错误
	/// </summary>
	public class ExcelOpenException:Exception
	{
        private string _message = "打开Excel错误！";

        public override string Message
        {
            get
            {
                return this._message;
            }
        }

        public ExcelOpenException()
		{
            	
		}
		
		public ExcelOpenException(string message)
		{
			this._message = message;
		}
	}

}
