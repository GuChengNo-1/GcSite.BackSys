using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcSite.BackSys.Models
{
    /// <summary>
    /// 产品图片
    /// </summary>
    public class ProductImg:EntityBase
    {
        /// <summary>
        /// 图片路径
        /// </summary>
        [Required(ErrorMessage = "图片路径不能为空")]
        [Display(Name = "图片路径")]
        public string Img { get; set; }
        /// <summary>
        /// 产品信息
        /// </summary>
        public virtual ProductInfo Product { get; set; }
    }
}
