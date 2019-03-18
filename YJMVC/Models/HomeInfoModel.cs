using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YJMVC.Models
{
    /// <summary>
    /// 房屋信息
    /// </summary>
    public class HomeInfoModel
    {
        /// <summary>
        /// 标识列
        /// </summary>
        public int HomeInfo_Id { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public int HomeInfo_UserId { get; set; }
        /// <summary>
        /// 小区名称
        /// </summary>
        public string HomeInfo_Xq_Name { get; set; }
        /// <summary>
        /// 建筑面积
        /// </summary>
        public string HomeInfo_Area { get; set; }
        /// <summary>
        /// 均价
        /// </summary>
        public double HomeInfo_AvgPrice { get; set; }
        /// <summary>
        /// 介绍
        /// </summary>
        public string HomeInfo_IntroDuce { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public int HomeInfo_IsTao { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string HomeInfo_Type { get; set; }
        /// <summary>
        /// 房型
        /// </summary>
        public string HomeInfo_HouseType { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public double HomeInfo_Price { get; set; }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string HomeInfo_PhotoPath { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public string HomeInfo_PosiTion { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double HomeInfo_LongiTude { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public double HomeInfo_LatiTude { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string HomeInfo_Contact { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string HomeInfo_Phone { get; set; }
        /// <summary>
        /// 练习时间
        /// </summary>
        public string HomeInfo_CTime { get; set; }
        /// <summary>
        /// 信息类型（出售，出租，楼盘）
        /// </summary>
        public int HomeInfo_InfoType { get; set; }
        /// <summary>
        /// 环境
        /// </summary>
        public string HomeInfo_Environment { get; set; }
        /// <summary>
        /// 信息添加日期
        /// </summary>
        public string HomeInfo_CreateTime { get; set; }
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
        /// <summary>
        /// 等级
        /// </summary>
        public int LeavelCost_Level { get; set; }
        /// <summary>
        /// 多少元/天
        /// </summary>
        public double DayCost_Money { get; set; }
    }
}