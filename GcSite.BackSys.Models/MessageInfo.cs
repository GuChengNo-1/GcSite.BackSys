using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcSite.BackSys.Models
{
    /// <summary>
    /// 留言反馈
    /// </summary>
    public class MessageInfo:EntityBase
    {
        /// <summary>
        /// 留言日期
        /// </summary>
        [Display(Name = "留言日期")]
        public DateTime MessageDate { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        [MaxLength(30, ErrorMessage = "长度不能超过30字符")]
        [Display(Name = "公司名称")]
        public string CompanyName { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        [Required(ErrorMessage = "联系人不能为空"), MaxLength(30, ErrorMessage = "长度不能超过30字符")]
        [Display(Name = "联系人")]
        public string ContactName { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [Required(ErrorMessage = "联系电话不能为空"), MaxLength(20, ErrorMessage = "长度不能超过20字符")]
        [Display(Name = "联系电话")]
        public string ContactTel { get; set; }
        /// <summary>
        /// 联系邮箱
        /// </summary>
        [MaxLength(30, ErrorMessage = "长度不能超过30字符")]
        [Display(Name = "类型名")]
        public string ContactEmail { get; set; }
        /// <summary>
        /// 公司传真
        /// </summary>
        [MaxLength(20, ErrorMessage = "长度不能超过20字符")]
        [Display(Name = "公司传真")]
        public string CompanyFax { get; set; }
        /// <summary>
        /// 联系QQ
        /// </summary>
        [MaxLength(20, ErrorMessage = "长度不能超过20字符")]
        [Display(Name = "联系QQ")]
        public string CompanyQQ { get; set; }
        /// <summary>
        /// 留言描述
        /// </summary>
        [Display(Name = "留言描述")]
        public string Describe { get; set; }
        /// <summary>
        /// 处理状态(0 or 1)默认
        /// </summary>
        [Display(Name = "处理状态")]
        public int Dispose { get; set; }
        /// <summary>
        /// 留言类型(外键)
        /// </summary>
        public virtual MessageType Type { get; set; }
    }
}
