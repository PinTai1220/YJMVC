using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YJMVC.Helper;
using YJMVC.Models;
using System.IO;

namespace YJMVC.Controllers
{
    public class Developers_Apply_ForController : Controller
    {
        /// <summary>
        /// 开发商申请记录表控制器
        /// </summary>
        /// <returns></returns>
        // GET: Developers_Apply_For
        [HttpPost]
        public ActionResult AddDev(HttpPostedFileBase HomeInfo_PhotoPath, HomeInfoModel home)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Images\\" + HomeInfo_PhotoPath.FileName);
            HomeInfo_PhotoPath.SaveAs(path);
            home.HomeInfo_InfoType = 3;
            home.HomeInfo_CreateTime = DateTime.Now.ToShortDateString().ToString();
            home.HomeInfo_PhotoPath = HomeInfo_PhotoPath.FileName;
            home.HomeInfo_UserId = Convert.ToInt32(Session["Account_Id"]);
            string json = JsonConvert.SerializeObject(home);
            string jsonStr = HttpClientHelper.SendRequest("api/HomeInfo/Create", "post", json);
            int result = JsonConvert.DeserializeObject<int>(jsonStr);
            if (result > 0)
            {
                return Content("<script>location.href='/Developers_Apply_For/QianTaiIndex/'</script>");
            }
            else
            {
                return Content("<script>alert('发布失败了!')</script>");
            }
        }
        public ActionResult QianTaiIndex()
        {
            string json = HttpClientHelper.SendRequest("http://localhost:17547/api/HomeInfo/Show", "get");
            List<HomeInfoModel> homes = JsonConvert.DeserializeObject<List<HomeInfoModel>>(json);
            //根据房屋信息类型判断是出售还是出租
            homes = homes.Where(C => C.HomeInfo_InfoType == 3).ToList();
            return View(homes);
        }
    }
}