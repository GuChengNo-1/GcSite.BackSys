using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcSite.BackSys.Models
{
    /// <summary>
    /// 产品信息
    /// </summary>
    public class ProductInfo:EntityBase
    {
        /// <summary>
        /// 产品名称
        /// </summary>
        [Required(ErrorMessage = "类型名不能为空"), MaxLength(100)]
        [Display(Name = "类型名")]
        public string ProductNmae { get; set; }
        /// <summary>
        /// 发布日期
        /// </summary>
        [Display(Name = "类型名")]
        public DateTime ProductDate { get; set; }
        /// <summary>
        /// 最后更新日期
        /// </summary>
        [Display(Name = "类型名")]
        public DateTime? UpdateDate { get; set; }
        /// <summary>
        /// 关键词
        /// </summary>
        [MaxLength(50, ErrorMessage = "长度不能超过50字符")]
        [Display(Name = "类型名")]
        public string Keyword { get; set; }
        /// <summary>
        /// 型号
        /// </summary>
        [Display(Name = "型号")]
        public string Version { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        [MaxLength(150, ErrorMessage = "长度不能超过150字符")]
        [Display(Name = "规格")]
        public string Specification { get; set; }
        /// <summary>
        /// 品牌
        /// </summary>
        [MaxLength(50, ErrorMessage = "长度不能超过50字符")]
        [Display(Name = "品牌")]
        public string Brand { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        [Display(Name = "单价")]
        public string Price { get; set; }
        /// <summary>
        /// 最小起订量
        /// </summary>
        [MaxLength(150, ErrorMessage = "长度不能超过150字符")]
        [Display(Name = "最小起订量")]
        public string Minimum { get; set; }
        /// <summary>
        /// 供货总量
        /// </summary>
        [MaxLength(150, ErrorMessage = "长度不能超过150字符")]
        [Display(Name = "供货总量")]
        public string TotalSupply { get; set; }
        /// <summary>
        /// 发货期限
        /// </summary>
        [MaxLength(150, ErrorMessage = "长度不能超过150字符")]
        [Display(Name = "发货期限")]
        public string Deadline { get; set; }
        /// <summary>
        /// 详情描述
        /// </summary>
        [Display(Name = "详情描述")]
        public string Describe { get; set; }
        /// <summary>
        /// 发布人
        /// </summary>
        public virtual UserInfo User { get; set; }
        /// <summary>
        /// 产品类型(外键)
        /// </summary>
        public virtual ProductType Type { get; set; }
        /// <summary>
        /// 产品图片
        /// </summary>
        public virtual ICollection<ProductImg> ProductImg { get; set; }

    }
}
