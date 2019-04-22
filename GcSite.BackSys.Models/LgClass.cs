using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcSite.BackSys.Models
{
    /// <summary>
    /// 资讯大类
    /// </summary>
    public class LgClass:EntityBase
    {
        /// <summary>
        /// 资讯类名
        /// </summary>
        [Required(ErrorMessage = "资讯类名不能为空"), MaxLength(100)]
        [Display(Name = "资讯类名")]
        public string LgName { get; set; }
        public virtual ICollection<SmClass> SmClass { get; set; }
    }
}
