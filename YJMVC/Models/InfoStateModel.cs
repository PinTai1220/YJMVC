using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YJMVC.Models
{
    /// <summary>
    /// 信息状态
    /// </summary>
    public class InfoStateModel
    {
        /// <summary>
        /// 标识列
        /// </summary>
        public int InfoState_Id { get; set; }
        /// <summary>
        /// HomeInfo表Id
        /// </summary>
        public int InfoState_HomeInfoId { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public int InfoState_Start { get; set; }
        /// <summary>
        /// 上挂等级
        /// </summary>
        public int InfoState_Level { get; set; }
        /// <summary>
        /// 持续时间
        /// </summary>
        public int InfoState_Continuou { get; set; }
        /// <summary>
        /// 续费时间
        /// </summary>
        public string InfoState_Time { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int InfoState_State { get; set; }
    }
}