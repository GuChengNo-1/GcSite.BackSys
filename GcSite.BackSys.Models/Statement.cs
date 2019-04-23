using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcSite.BackSys.Models
{
    /// <summary>
    /// 法律申明
    /// </summary>
    public class Statement:EntityBase
    {
        /// <summary>
        /// 免责申明
        /// </summary>
        public string Disclaimer { get; set; }
        /// <summary>
        /// 版权和商标
        /// </summary>
        public string Copyright { get; set; }
        /// <summary>
        /// 意见
        /// </summary>
        public string Opinion { get; set; }
        /// <summary>
        /// 网站信息
        /// </summary>
        public string SiteData { get; set; }
    }
}
