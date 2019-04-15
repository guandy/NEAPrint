using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NEAPrintDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetExcelBase64()
        {
            var path = $@"{AppDomain.CurrentDomain.BaseDirectory}Content\print.xls";
            //这里可以根据业务生成excel模板
            var excelBase64 = ExcelHelper.GetBase64ByPath(path);
            return Json(JResult.Success("成功","0",excelBase64));
        }
    }
}