using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YJMVC.Controllers
{
    public class UsersController : Controller
    {
        /// <summary>
        /// 用户表控制器
        /// </summary>
        /// <returns></returns>
        // GET: Users
        public ActionResult GLogin()
        {
            return View();
        }
        public ActionResult Logined(string account,string pwd)
        {
            return View();
        }
    }
}