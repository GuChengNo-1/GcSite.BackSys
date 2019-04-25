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
    // 主要内容：  基础验证的错误信息
    // ******************************************************************
    /// <summary>
    /// 基础验证的错误信息
    /// </summary>
    public class ModelValidationError
    {
        /// <summary>
        /// 错误字段
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Message { get; set; }
    }
}
