using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YJMVC.Controllers
{
    public class InfoStateController : Controller
    {
        /// <summary>
        /// 信息状态控制器
        /// </summary>
        /// <returns></returns>
        // GET: InfoState
        public ActionResult Index()
        {
            return View();
        }
    }
}