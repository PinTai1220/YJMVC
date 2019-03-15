using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YJMVC.Models
{
    /// <summary>
    /// 金额记录表
    /// </summary>
    public class MoneyReCordModel
    {
        /// <summary>
        /// 标识列
        /// </summary>
        public int MoneyRecord_Id { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public int MoneyRecord_UserId { get; set; }
        /// <summary>
        /// 金钱流水记录
        /// </summary>
        public int MoneyRecord_Record { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public string MoneyRecord_Time { get; set; }
    }
}