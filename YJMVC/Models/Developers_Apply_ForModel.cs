using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YJMVC.Models
{
    /// <summary>
    /// 开发商申请记录
    /// </summary>
    public class Developers_Apply_ForModel
    {
        /// <summary>
        /// 标识列
        /// </summary>
        public int Developers_Id { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public int Developers_UserId { get; set; }
        /// <summary>
        /// 图片材料路径
        /// </summary>
        public string Developers_PhotoPath { get; set; }
        /// <summary>
        /// 申请信息
        /// </summary>
        public string Developers_Info { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public string Developers_TimeG { get; set; }
    }
}