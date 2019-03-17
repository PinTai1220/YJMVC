using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Mvc;
using YJMVC.Models;

namespace YJMVC.Controllers
{
    public class UsersController : Controller
    {
        /// <summary>
        /// 用户表控制器
        /// </summary>
        /// <returns></returns>
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="email">邮箱</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public int Login(string email, string password)
        {
            if (email.Equals("admin") && password.Equals("00000"))
            {
                Session["Account"] = email;
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        public int Logout()
        {
            Session["Account"] = null;
            return 1;
        }
        private static Bitmap headImg = null;

        public ActionResult Register(UsersModel users)
        {
            string path = Server.MapPath(@"/HeadImg/");
            string imgPath = $"{path}/{users.User_Phone}.png";
            headImg.Save(imgPath, ImageFormat.Png);
            users.User_PhotoUrl = imgPath;

            // 调用Api 注册方法
            return Content("<script>alert('注册成功！');location.href='/Main/MainIndex'</script>");
        }

        /// <summary>
        /// 专递 base64 字符串 然后上传图片
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public void UploadImg(string file)
        {
            ToImage(file);
        }

        /// <summary>
        /// 将Base 64 字符串转换为图片
        /// </summary>
        /// <param name="file"></param>
        private Bitmap ToImage(string file)
        {
            file = file.Substring(22);
            // 编码
            byte[] bytes = Convert.FromBase64String(file);
            MemoryStream memoryStream = new MemoryStream(bytes);
            Bitmap bmp = new Bitmap(memoryStream);
            headImg = bmp;
            return bmp;
        }
    }
}