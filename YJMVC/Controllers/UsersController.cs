using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Mvc;
using YJMVC.Helper;
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
        /// 
        [HttpPost]
        public int Login(string email, string password)
        {
            // 调用 Api的登录方法  或者调用返回所有值 然后 Lambda表达式判断
            // 返回MD5 加密格式的字符串
            string passworld = password.CalcMD5();
            List<UsersModel> users = GetUsers();            // 调用方法获得所有的用户信息
            UsersModel user = users.Where(c => c.User_Phone.Equals(email) && c.User_Pwd.Equals(passworld)).FirstOrDefault();

            if (user != null)
            {
                Session["Account"] = email;
                Session["Account_Id"] = user.User_Id;
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
        /// <summary>
        /// 存储上传的图片
        /// </summary>
        private static Bitmap headImg = null;
        /// <summary>
        /// 注册账户
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>

        public ActionResult Register(UsersModel users)
        {
            string path = Server.MapPath(@"/HeadImg/");
            string imgPath = $"{path}/{users.User_Phone}.png";

            // 判断该图片是否存在

            headImg.Save(imgPath, ImageFormat.Png);
            users.User_PhotoUrl = imgPath;

            // 调用Api 注册方法
            // 将密码进行MD5加密
            users.User_Pwd = users.User_Pwd.CalcMD5();

            users.User_Wx_Type = "1";
            string json = JsonConvert.SerializeObject(users);

            #region 调用Api进行注册
            string jsonStr = HttpClientHelper.SendRequest("api/Users/Create", "post", json);
            int result = JsonConvert.DeserializeObject<int>(jsonStr);

            if (result > 0)
            {
                return Content("<script>alert('注册成功！');location.href='/Main/MainIndex'</script>");
            }
            else
            {
                return Content("<script>alert('注册失败！');location.href='/Main/MainIndex'</script>");
            }

            #endregion

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

        /// <summary>
        /// 获得所有的用户信息
        /// </summary>
        /// <returns></returns>
        private List<UsersModel> GetUsers()
        {
            string jsonStr = HttpClientHelper.SendRequest("api/Users/Show", "Get");
            List<UsersModel> result = JsonConvert.DeserializeObject<List<UsersModel>>(jsonStr);
            return result;
        }


        /// <summary>
        /// 焦点消失后 检测手机号是否存在
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public int CheckPhoneExists(string phone)
        {
            List<UsersModel> users = GetUsers();
            UsersModel user = users.Where(c => c.User_Phone.Equals(phone)).FirstOrDefault();
            if (user != null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}