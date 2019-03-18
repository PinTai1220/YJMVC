using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YJMVC.Helper;

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
            string json = HttpClientHelper.SendRequest("api/Developer/Show", "get");
            List<>
            return View();
        }

        [HttpGet]
        public ActionResult AddDev()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDev(Developers_Apply_ForController developers)
        {
            return View();
        }
    }
}