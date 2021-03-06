﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YJMVC.Models
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class UsersModel
    {
        /// <summary>
        /// 标识列
        /// </summary>
        public int User_Id { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string User_Phone { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string User_PhoneName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string User_Pwd { get; set; }
        /// <summary>
        /// 用户头像路径
        /// </summary>
        public string User_PhotoUrl { get; set; }
        /// <summary>
        /// 微信号Id
        /// </summary>
        public int User_Wx_Id { get; set; }
        /// <summary>
        /// 微信名
        /// </summary>
        public string User_Wx_Name { get; set; }
        /// <summary>
        /// 微信头像
        /// </summary>
        public string User_Wx_PhotoUrl { get; set; }
        /// <summary>
        /// 微信用户性别
        /// </summary>
        public int User_Wx_Sex { get; set; }
        /// <summary>
        /// 微信用户国家
        /// </summary>
        public string User_Wx_Country { get; set; }
        /// <summary>
        /// 用户类型（一般用户，房地产开发商，管理员）
        /// </summary>
        public string User_Wx_Type { get; set; }
        /// <summary>
        /// 退回金额
        /// </summary>
        public double User_BackMoey { get; set; }
    }
}