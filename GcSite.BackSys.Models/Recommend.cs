using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcSite.BackSys.Models
{
    /// <summary>
    /// 推荐表
    /// </summary>
    public class Recommend:EntityBase
    {
        /// <summary>
        /// 是否推荐 (0 or 1)
        /// </summary>
        [Required(ErrorMessage = "不能为空")]
        [Display(Name = "是否推荐")]
        public int Whether { get; set; }
        /// <summary>
        /// 资讯信息
        /// </summary>
        public ICollection<Information> Information { get; set; }
    }
}
