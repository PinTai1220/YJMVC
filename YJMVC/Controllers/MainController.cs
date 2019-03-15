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
        //主页面
        public ActionResult MainIndex()
        {
            return View();
        }
        //关于我们
        public ActionResult AboutIndex()
        {
            return View();
        }
        //经常解答的问题
        public ActionResult JieDaIndex()
        {
            return View();
        }
        //条款
        public ActionResult TiaoIndex()
        {
            return View();
        }
        //隐私政策
        public ActionResult YinSiIndex()
        {
            return View();
        }
        //咨询代理
        public ActionResult ZiDaiIndex()
        {
            return View();
        }
        //服务
        public ActionResult FuWuIndex()
        {
            return View();
        }
        //联系我们
        public ActionResult LianXiIndex()
        {
            return View();
        }
    }
}