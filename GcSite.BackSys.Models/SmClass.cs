using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcSite.BackSys.Models
{
    /// <summary>
    /// 资讯小类
    /// </summary>
    public class SmClass:EntityBase
    {
        /// <summary>
        /// 资讯类名
        /// </summary>
        [Required(ErrorMessage = "资讯类名不能为空"), MaxLength(100)]
        [Display(Name = "资讯类名")]
        public string SmName { get; set; }
        /// <summary>
        /// 资讯大类(外键)
        /// </summary>
        public virtual LgClass Lg { get; set; }
        /// <summary>
        /// 资讯信息
        /// </summary>
        public virtual ICollection<Information> Information { get; set; } 
    }
}
