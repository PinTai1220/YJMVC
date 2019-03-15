using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YJMVC.Controllers
{
    public class MainController : Controller
    {
        /// <summary>
        /// 没有功能的主页面
        /// </summary>
        /// <returns></returns>
        // GET: Main
        public ActionResult MainIndex()
        {
            return View();
        }
        public ActionResult AboutIndex()
        {
            return View();
        }
        public ActionResult JieDaIndex()
        {
            return View();
        }
        public ActionResult TiaoIndex()
        {
            return View();
        }
        public ActionResult YinSiIndex()
        {
            return View();
        }
        public ActionResult ZiDaiIndex()
        {
            return View();
        }
        public ActionResult FuWuIndex()
        {
            return View();
        }
    }
}