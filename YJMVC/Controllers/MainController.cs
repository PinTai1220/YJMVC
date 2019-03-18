using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YJMVC.Helper;
using YJMVC.Models;
using Newtonsoft.Json;

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
            string json = HttpClientHelper.SendRequest("http://localhost:17547/api/HomeInfo/Show", "get");
            List<HomeInfoModel> homes = JsonConvert.DeserializeObject<List<HomeInfoModel>>(json);
            //根据房屋信息类型判断是出售还是出租
            homes = homes.Where(C => C.HomeInfo_InfoType == 1).ToList();
            return View(homes);
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