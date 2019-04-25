using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcSite.BackSys.Models
{
    /// <summary>
    /// 资讯信息
    /// </summary>
    public class Information:EntityBase
    {
        /// <summary>
        /// 标题
        /// </summary>
        [Required(ErrorMessage = "标题不能为空")]
        [Display(Name = "标题")]
        public string Title { get; set; }
        /// <summary>
        /// 发布人
        /// </summary>
        [Required(ErrorMessage = "发布人不能为空")]
        [Display(Name = "发布人")]
        public virtual UserInfo User { get; set; }
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
        /// 内容描述
        /// </summary>
        [Display(Name = "内容描述")]
        public string Describe { get; set; }
        /// <summary>
        /// 是否推荐(0 or 1)
        /// </summary>
        [Required(ErrorMessage = "推荐不能为空")]
        [Display(Name = "是否推荐")]
        public virtual Recommend Recommend { get; set; }
        /// <summary>
        /// 资讯小类
        /// </summary>
        [Required(ErrorMessage = "资讯小类不能为空")]
        [Display(Name = "资讯小类")]
        public virtual SmClass Sm { get; set; }
        /// <summary>
        /// 资讯图片
        /// </summary>
        public virtual ICollection<RmationImg> Img { get; set; }
    }
}
