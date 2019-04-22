using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcSite.BackSys.Models
{
    /// <summary>
    /// 新闻类型
    /// </summary>
    public class NewsType : EntityBase
    {
        /// <summary>
        /// 类型名称
        /// </summary>
        [Required(ErrorMessage = "类型名称不能为空"), MaxLength(100)]
        [Display(Name = "类型名称")]
        public string TypeName { get; set; }
        /// <summary>
        /// 类型描述
        /// </summary>
        [Display(Name = "类型描述")]
        public string Describe { get; set; }
        /// <summary>
        /// 新闻
        /// </summary>
        public virtual ICollection<NewsInfo> NewsInfo { get; set; }
    }
}
