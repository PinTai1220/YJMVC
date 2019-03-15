using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YJMVC.Controllers
{
    public class HomeInfoController : Controller
    {
        /// <summary>
        /// 房屋信息控制器
        /// </summary>
        /// <returns></returns>
        // GET: HomeInfo
        public ActionResult ChuZuIndex()
        {
            return View();
        }
        public ActionResult ChuShouIndex()
        {
            return View();
        }
        public ActionResult SelectIndex()
        {
            return View();
        }
        public ActionResult TwoIndex()
        {
            return View();
        }
        public ActionResult ThreeIndex()
        {
            return View();
        }
        public ActionResult FourIndex()
        {
            return View();
        }
    }
}