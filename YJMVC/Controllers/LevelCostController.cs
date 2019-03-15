using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YJMVC.Controllers
{
    public class LevelCostController : Controller
    {
        /// <summary>
        /// 等级付费规则控制器
        /// </summary>
        /// <returns></returns>
        // GET: LevelCost
        public ActionResult Index()
        {
            return View();
        }
    }
}