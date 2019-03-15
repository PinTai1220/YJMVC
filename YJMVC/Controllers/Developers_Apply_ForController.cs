using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YJMVC.Controllers
{
    public class Developers_Apply_ForController : Controller
    {
        /// <summary>
        /// 开发商申请记录表控制器
        /// </summary>
        /// <returns></returns>
        // GET: Developers_Apply_For
        public ActionResult Index()
        {
            return View();
        }
    }
}