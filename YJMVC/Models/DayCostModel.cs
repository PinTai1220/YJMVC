using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YJMVC.Models
{
    /// <summary>
    /// 天数付费规则
    /// </summary>
    public class DayCostModel
    {
        /// <summary>
        /// 标识列
        /// </summary>
        public int DayCost_Id { get; set; }
        /// <summary>
        /// 多少元/天
        /// </summary>
        public double DayCost_Money { get; set; }
    }
}