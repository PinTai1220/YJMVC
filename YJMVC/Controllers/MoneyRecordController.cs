using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YJMVC.Controllers
{
    public class MoneyRecordController : Controller
    {
        /// <summary>
        /// 金额记录表控制器
        /// </summary>
        /// <returns></returns>
        // GET: MoneyRecord
        public ActionResult Index()
        {
            return View();
        }
    }
}