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
            List<HomeInfoModel> homes = GetHomeInfos();
            //根据房屋信息类型判断是出售还是出租
            homes = homes.Where(C => C.HomeInfo_InfoType == 2).ToList();
            return View(homes);
        } 

        /// <summary>
        /// 查询 出租房屋查询
        /// </summary>
        /// <returns></returns>
        public ActionResult GetChuZhuHomeInfos(string position = "", string city = "", double minPrice = 0, double maxPrice = 99999999999, string houseType = "", string type = "")
        {
            List<HomeInfoModel> homes = GetHomeInfos();
            homes = homes.Where(c => c.HomeInfo_InfoType == 2 && c.HomeInfo_PosiTion.Contains(position + city) && c.HomeInfo_AvgPrice >= minPrice && c.HomeInfo_AvgPrice <= maxPrice && c.HomeInfo_HouseType.Contains(houseType) && c.HomeInfo_Type.Contains(type)).ToList();

            return View("ChuZuIndex", homes);
        }
        public ActionResult ChuShouIndex()
        {
            List<HomeInfoModel> homes = GetHomeInfos();
            //根据房屋信息类型判断是出售还是出租
            homes = homes.Where(C => C.HomeInfo_InfoType == 1).ToList();
            return View(homes);
        }
        /// <summary>
        /// 查询 出售房屋查询
        /// </summary>
        /// <returns></returns>
        public ActionResult GetChuShowHomeInfos(string position = "", string city = "", string price = "0-999999999", string houseType = "", string type = "", string area = "0-999999999")
        {
            #region 价钱计算

            int minPrice=0, maxPrice=0;
            if (price.Equals("200以下"))
            {
                minPrice = 0;
                maxPrice = 200;
            }
            else if (price.Equals("500以上"))
            {
                minPrice = 500;
                maxPrice = 999999999;
            }
            else
            {
                minPrice = Convert.ToInt32(price.Split('-')[0]);
                maxPrice = Convert.ToInt32(price.Split('-')[1]);
            }

            #endregion


            #region 面积计算
            int minArea, maxArea;
            if (area.Equals("50以下"))
            {
                minArea = 0;
                maxArea = 200;
            }
            else if (area.Equals("110以上"))
            {
                minArea = 500;
                maxArea = 999999999;
            }
            else
            {
                minArea = Convert.ToInt32(area.Split('-')[0]);
                maxArea = Convert.ToInt32(area.Split('-')[1]);
            }
            #endregion


            List<HomeInfoModel> homes = GetHomeInfos();
            homes = homes.Where(c => c.HomeInfo_InfoType == 1 && c.HomeInfo_PosiTion.Contains(position) && c.HomeInfo_Price >= minPrice && c.HomeInfo_Price <= maxPrice && c.HomeInfo_HouseType.Contains(houseType) && c.HomeInfo_Type.Contains(type) && c.HomeInfo_Area >= minArea && c.HomeInfo_Area <= maxArea).ToList();

            return View("ChuShouIndex", homes);
        }
        public ActionResult SelectIndex()
        {
            return View();
        }
        public ActionResult TwoIndex()
        {
            List<HomeInfoModel> homes = GetHomeInfos();
            //根据房屋信息类型判断是出售还是出租
            return View(homes);
        }
        public ActionResult ThreeIndex()
        {
            List<HomeInfoModel> homes = GetHomeInfos();
            //根据房屋信息类型判断是出售还是出租
            return View(homes);
        }
        public ActionResult FourIndex()
        {
            List<HomeInfoModel> homes = GetHomeInfos();
            //根据房屋信息类型判断是出售还是出租
            return View(homes);
        }

        private static List<HomeInfoModel> GetHomeInfos()
        {
            string json = HttpClientHelper.SendRequest("http://localhost:17547/api/HomeInfo/Show", "get");
            List<HomeInfoModel> homes = JsonConvert.DeserializeObject<List<HomeInfoModel>>(json);
            return homes;
        }

        [HttpPost]
        public ActionResult MaiFang(HttpPostedFileBase HomeInfo_PhotoPath, HomeInfoModel home)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Images\\" + HomeInfo_PhotoPath.FileName);
            HomeInfo_PhotoPath.SaveAs(path);
            home.HomeInfo_InfoType = 1;
            home.HomeInfo_CreateTime = DateTime.Now.ToShortDateString().ToString();
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
            home.HomeInfo_CreateTime = DateTime.Now.ToShortDateString().ToString();
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
            List<HomeInfoModel> house= GetHomeInfos();
            //根据房屋信息类型判断是出售还是出租
            house = house.Where(C => C.HomeInfo_InfoType == 3).ToList();
            ViewBag.homes = house;
            return View(homes);
        }
    }
}