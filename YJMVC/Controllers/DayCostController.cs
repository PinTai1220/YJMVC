using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YJMVC.Controllers
{
    public class DayCostController : Controller
    {
        /// <summary>
        /// 天数付费规则控制器
        /// </summary>
        /// <returns></returns>
        // GET: DayCost
        public ActionResult Index()
        {
            return View();
        }
    }
}