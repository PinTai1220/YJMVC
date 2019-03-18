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

        /// <summary>
        /// 查询 出租房屋查询
        /// </summary>
        /// <returns></returns>
        public ActionResult GetChuZhuHomeInfos(string position, double minPrice, double maxPrice, string houseType, string type)
        {
            string json = HttpClientHelper.SendRequest("http://localhost:17547/api/HomeInfo/Show", "get");
            List<HomeInfoModel> homes = JsonConvert.DeserializeObject<List<HomeInfoModel>>(json);
            homes = homes.Where(c => c.HomeInfo_InfoType == 2 || c.HomeInfo_PosiTion.Contains(position) || c.HomeInfo_AvgPrice >= minPrice || c.HomeInfo_AvgPrice <= maxPrice || c.HomeInfo_HouseType == houseType || c.HomeInfo_Type == type).ToList();

            return View("ChuZuIndex", homes);
        }
        public ActionResult ChuShouIndex()
        {
            string json = HttpClientHelper.SendRequest("http://localhost:17547/api/HomeInfo/Show", "get");
            List<HomeInfoModel> homes = JsonConvert.DeserializeObject<List<HomeInfoModel>>(json);
            //根据房屋信息类型判断是出售还是出租
            homes = homes.Where(C => C.HomeInfo_InfoType == 1).ToList();
            return View(homes);
        }
        /// <summary>
        /// 查询 出售房屋查询
        /// </summary>
        /// <returns></returns>
        public ActionResult GetChuShowHomeInfos(string position, double minPrice, double maxPrice, string houseType, string type)
        {
            string json = HttpClientHelper.SendRequest("http://localhost:17547/api/HomeInfo/Show", "get");
            List<HomeInfoModel> homes = JsonConvert.DeserializeObject<List<HomeInfoModel>>(json);
            homes = homes.Where(c => c.HomeInfo_InfoType == 1 || c.HomeInfo_PosiTion.Contains(position) || c.HomeInfo_AvgPrice >= minPrice || c.HomeInfo_AvgPrice <= maxPrice || c.HomeInfo_HouseType == houseType || c.HomeInfo_Type == type).ToList();

            return View("ChuShouIndex", homes);
        }
        public ActionResult SelectIndex()
        {
            return View();
        }
        public ActionResult TwoIndex()
        {
            string json = HttpClientHelper.SendRequest("http://localhost:17547/api/HomeInfo/Show", "get");
            List<HomeInfoModel> homes = JsonConvert.DeserializeObject<List<HomeInfoModel>>(json);
            //根据房屋信息类型判断是出售还是出租
            return View(homes);
        }
        public ActionResult ThreeIndex()
        {
            string json = HttpClientHelper.SendRequest("http://localhost:17547/api/HomeInfo/Show", "get");
            List<HomeInfoModel> homes = JsonConvert.DeserializeObject<List<HomeInfoModel>>(json);
            //根据房屋信息类型判断是出售还是出租
            return View(homes);
        }
        public ActionResult FourIndex()
        {
            string json = HttpClientHelper.SendRequest("http://localhost:17547/api/HomeInfo/Show", "get");
            List<HomeInfoModel> homes = JsonConvert.DeserializeObject<List<HomeInfoModel>>(json);
            //根据房屋信息类型判断是出售还是出租
            return View(homes);
        }
        [HttpPost]
        public ActionResult MaiFang(HttpPostedFileBase HomeInfo_PhotoPath, HomeInfoModel home)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Images\\" + HomeInfo_PhotoPath.FileName);
            HomeInfo_PhotoPath.SaveAs(path);
            home.HomeInfo_InfoType = 1;
            home.HomeInfo_PhotoPath = HomeInfo_PhotoPath.FileName;
            home.HomeInfo_UserId = Convert.ToInt32(Session["Account_Id"]);
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
        public ActionResult XiangQingIndex(int Id)
        {
            string json = HttpClientHelper.SendRequest("api/HomeInfo/ShowById?id=" + Id, "get");
            HomeInfoModel homes = JsonConvert.DeserializeObject<HomeInfoModel>(json);
            ViewBag.Id = homes.HomeInfo_Id;
            //根据房屋信息类型判断是出售还是出租
            return View(homes);
        }
    }
}