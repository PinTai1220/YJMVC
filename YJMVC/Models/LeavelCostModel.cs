using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YJMVC.Models
{
    /// <summary>
    /// 等级付费规则
    /// </summary>
    public class LeavelCostModel
    {
        /// <summary>
        /// 标识列
        /// </summary>
        public int LeavelCost_Id { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        public int LeavelCost_Level { get; set; }
        /// <summary>
        /// 元/天
        /// </summary>
        public double LevelCost_Money { get; set; }
    }
}