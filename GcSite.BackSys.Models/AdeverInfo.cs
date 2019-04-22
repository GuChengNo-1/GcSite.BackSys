using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcSite.BackSys.Models
{
    /// <summary>
    /// 广告信息
    /// </summary>
    public class AdeverInfo:EntityBase
    {
        /// <summary>
        /// 广告图片路径
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "广告图片路径")]
        public string AdeverImg { get; set; }
        /// <summary>
        /// 广告描述
        /// </summary>
        [Display(Name = "广告描述")]
        public string Describe { get; set; }
        /// <summary>
        /// 广告链接
        /// </summary>
        [MaxLength(150)]
        [Display(Name = "广告链接")]
        public string Link { get; set; }
        /// <summary>
        /// 发布日期
        /// </summary>
        [Display(Name = "发布日期")]
        public DateTime ReleaseDate { get; set; }
        /// <summary>
        /// 广告类型(外键)
        /// </summary>
        public virtual AdverType Type { get; set; }
    }
}
