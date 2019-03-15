using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YJMVC.Models
{
    /// <summary>
    /// 用户session表
    /// </summary>
    public class SessionidsModel
    {
        /// <summary>
        /// 标识列
        /// </summary>
        public int SessionId_Id { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public int SessionId_UserId { get; set; }
        /// <summary>
        /// 应用服务器分配给用户的sessionId
        /// </summary>
        public int SessionId_SessionId { get; set; }
    }
}