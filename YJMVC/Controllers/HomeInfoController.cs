using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YJMVC.Models;
using YJMVC.Helper;

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
            string json = HttpClientHelper.SendRequest("http://localhost:17547/api/HomeInfo/Show", "get");
            List<HomeInfoModel> homes = JsonConvert.DeserializeObject<List<HomeInfoModel>>(json);
            //根据房屋信息类型判断是出售还是出租
            homes = homes.Where(C => C.HomeInfo_InfoType == 2).ToList();
            return View(homes);
        }
        public ActionResult ChuShouIndex()
        {
            string json = HttpClientHelper.SendRequest("http://localhost:17547/api/HomeInfo/Show", "get");
            List<HomeInfoModel> homes = JsonConvert.DeserializeObject<List<HomeInfoModel>>(json);
            //根据房屋信息类型判断是出售还是出租
            homes = homes.Where(C => C.HomeInfo_InfoType == 1).ToList();
            return View(homes);
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
        [HttpPost]
        public ActionResult MaiFang(HttpPostedFileBase HomeInfo_PhotoPath, HomeInfoModel home)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Images\\" + HomeInfo_PhotoPath.FileName);
            HomeInfo_PhotoPath.SaveAs(path);
            home.HomeInfo_InfoType = 1;
            home.HomeInfo_PhotoPath = HomeInfo_PhotoPath.FileName;
            home.HomeInfo_UserId =Convert.ToInt32(Session["Account_Id"]);
            string json = JsonConvert.SerializeObject(home);
            string jsonStr = HttpClientHelper.SendRequest("api/HomeInfo/Create", "post", json);
            int result = JsonConvert.DeserializeObject<int>(jsonStr);
            if (result > 0)
            {
                return Content("<script>location.href='/HomeInfo/ChuShouIndex/'</script>");
                
            }
            else
            {
                return Content("<script>alert('发布失败了!')</script>");
            }
        }
        [HttpPost]
        public ActionResult ZuFang(HttpPostedFileBase HomeInfo_PhotoPath, HomeInfoModel home)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Images\\" + HomeInfo_PhotoPath.FileName);
            HomeInfo_PhotoPath.SaveAs(path);
            home.HomeInfo_InfoType = 2;
            home.HomeInfo_PhotoPath = HomeInfo_PhotoPath.FileName;
            home.HomeInfo_UserId = Convert.ToInt32(Session["Account_Id"]);
            string json = JsonConvert.SerializeObject(home);
            string jsonStr = HttpClientHelper.SendRequest("api/HomeInfo/Create", "post", json);
            int result = JsonConvert.DeserializeObject<int>(jsonStr);
            if (result > 0)
            {
                return Content("<script>location.href='/HomeInfo/ChuZuIndex/'</script>");
            }
            else
            {
                return Content("<script>alert('发布失败了!')</script>");
            }
        }
    }
}