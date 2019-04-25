using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcSite.BackSys.Models
{
    /// <summary>
    /// 存储内存、CPU等信息
    /// </summary>
    public class MemoryCpu
    {
        /// <summary>
        /// CPU使用率
        /// </summary>
        public string Cpu { get; set; }
        /// <summary>
        /// 内存占有率
        /// </summary>
        public string Memory { get; set; }
    }
}
