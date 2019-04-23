using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcSite.BackSys.Models
{
    /// <summary>
    /// 招聘信息
    /// </summary>
    public class Recruited : EntityBase
    {
        /// <summary>
        /// 招聘职位
        /// </summary>
        [MaxLength(100, ErrorMessage = "长度不能超过100字符")]
        [Display(Name = "招聘职位")]
        public string Position { get; set; }
        /// <summary>
        /// 月薪
        /// </summary>
        [Display(Name = "月薪")]
        public string MonthlyPay { get; set; }
        /// <summary>
        /// 所属地区
        /// </summary>
        [Display(Name = "所属地区")]
        public string AreaName { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        [Display(Name = "来源")]
        public string RecruitSource { get; set; }
        /// <summary>
        /// 发布日期
        /// </summary>
        [Display(Name = "发布日期")]
        public DateTime ReleaseDate { get; set; }
        /// <summary>
        /// 发布人(外键)
        /// </summary>
        public virtual UserInfo User { get; set; }
    }
}
