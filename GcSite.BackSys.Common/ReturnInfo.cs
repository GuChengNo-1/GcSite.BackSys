using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcSite.BackSys.Common
{
    // ******************************************************************
    // 文件版本： GcSys 1.0
    // Copyright  (c)  2019 Shanghai GuCheng
    // 创建时间： 2019/4
    // 主要内容：  用于返回执行登录,增删改等操作执行结果的信息
    // ******************************************************************
    /// <summary>
    /// 用于返回执行登录,增删改等操作执行结果的信息
    /// </summary>
    public class ReturnInfo
    {
        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 详细的错误信息
        /// </summary>
        public string ErrorInfo { get; set; }
    }
}
