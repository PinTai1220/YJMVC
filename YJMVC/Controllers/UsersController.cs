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
using YJMVC.MvcHelper;

namespace YJMVC.Controllers
{
    public class UsersController : Controller
    {
        /// <summary>
        /// 用户表控制器
        /// </summary>
        /// <returns></returns>
        // GET: Users
        public ActionResult Login()
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
            // 调用 Api的登录方法  或者调用返回所有值 然后 Lambda表达式判断
            // 返回MD5 加密格式的字符串
            string passworld = password.CalcMD5();

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
            // 将密码进行MD5加密
            users.User_Pwd = users.User_Pwd.CalcMD5();

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