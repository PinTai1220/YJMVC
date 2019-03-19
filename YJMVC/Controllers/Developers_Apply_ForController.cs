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
        public ActionResult Index()
        {
            string json = HttpClientHelper.SendRequest("http://localhost:17547/api/HomeInfo/Show", "get");
            List<HomeInfoModel> homes = JsonConvert.DeserializeObject<List<HomeInfoModel>>(json);
            //根据房屋信息类型判断是出售还是出租
            homes = homes.Where(C => C.HomeInfo_InfoType == 2).ToList();
            return View();
        }

        [HttpGet]
        public ActionResult AddDev()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDev(Developers_Apply_ForModel developers,HttpPostedFileBase fileBase)
        {
            //上传图片
            string jue = Server.MapPath("/Images/");
            fileBase.SaveAs(jue+fileBase.FileName);
            developers.Developers_PhotoPath = fileBase.FileName;
            string json = JsonConvert.SerializeObject(developers);
            string jsonStr = HttpClientHelper.SendRequest("api/HomeInfo/Create", "post", json);
            int result = JsonConvert.DeserializeObject<int>(jsonStr);
            if (result > 0)
            {
                return Content("<script>location.href='/HomeInfo/ChuZuIndex/'</script>");
            }
            else
            {
                return Content("<script>alert('添加失败了!')</script>");
            }
        }
    }
}