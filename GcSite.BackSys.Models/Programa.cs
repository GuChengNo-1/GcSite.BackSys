using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcSite.BackSys.Models
{
    /// <summary>
    /// 栏目信息
    /// </summary>
    public class Programa:EntityBase
    {
        /// <summary>
        /// 栏目标题
        /// </summary>
        [Required(ErrorMessage = "栏目标题不能为空"), MaxLength(30, ErrorMessage = "长度不能超过30字符")]
        [Display(Name = "栏目标题")]
        public string Title { get; set; }
        /// <summary>
        /// 栏目图片
        /// </summary>
        [Display(Name = "栏目图片")]
        public string ProgramaImg { get; set; }
        /// <summary>
        /// 栏目描述
        /// </summary>
        [Display(Name = "栏目描述")]
        public string Describe { get; set; }
        /// <summary>
        /// 发布日期
        /// </summary>
        [Display(Name = "发布日期")]
        public DateTime ReleaseDate { get; set; }
        /// <summary>
        /// 最后更新日期
        /// </summary>
        [Display(Name = "最后更新日期")]
        public DateTime? UpdateDate { get; set; }
        /// <summary>
        /// 发布人(外键)
        /// </summary>
        public UserInfo User { get; set; }
    }
}
