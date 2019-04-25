using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcSite.BackSys.Models
{
    /// <summary>
    /// 新闻信息
    /// </summary>
    public class NewsInfo:EntityBase
    {
        /// <summary>
        /// 新闻标题
        /// </summary>
        [Required(ErrorMessage = "新闻标题不能为空"), MaxLength(100)]
        [Display(Name = "新闻标题")]
        public string NewsTitle { get; set; }
        /// <summary>
        /// 新闻内容
        /// </summary>
        [Display(Name = "新闻内容")]
        public string NewsContent { get; set; }
        /// <summary>
        /// 新闻图片
        /// </summary>
        [Display(Name = "新闻图片")]
        public string NewsImg { get; set; }
        /// <summary>
        /// 发布日期
        /// </summary>
        [Display(Name = "发布日期")]
        public DateTime ReleaseDate { get; set; }
        /// <summary>
        /// 发布人(外键)
        /// </summary>
        public virtual UserInfo User { get; set; }
        /// <summary>
        /// 新闻类型(外键)
        /// </summary>
        public virtual NewsType Type { get; set; }
    }
}
