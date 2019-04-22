using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcSite.BackSys.Models
{
    /// <summary>
    /// 友情链接
    /// </summary>
    public class Blogroll:EntityBase
    {
        /// <summary>
        /// 链接名称
        /// </summary>
        [Required(ErrorMessage = "类型名不能为空")]
        [MaxLength(20, ErrorMessage = "长度不能超过20字符")]
        [Display(Name = "链接名称")]
        public string BlogrollName { get; set; }
        /// <summary>
        /// 链接地址
        /// </summary>
        [MaxLength(150, ErrorMessage = "长度不能超过150字符")]
        [Display(Name = "链接地址")]
        public string Link { get; set; }
        /// <summary>
        /// 发布日期
        /// </summary>
        [Display(Name = "发布日期")]
        public DateTime ReleaseDate { get; set; }
        /// <summary>
        /// 发布人(外键)
        /// </summary>
        [Display(Name = "发布人")]
        public UserInfo User { get; set; }
    }
}
