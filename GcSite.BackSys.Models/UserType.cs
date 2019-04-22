using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcSite.BackSys.Models
{
    /// <summary>
    /// 用户类型信息
    /// </summary>
    public class UserType:EntityBase
    {
        /// <summary>
        /// 用户类型
        /// </summary>
        [Required(ErrorMessage = "用户类型不能为空"), MaxLength(100)]
        [Display(Name = "类型名")]
        public string TypeName { get; set; }
        /// <summary>
        /// 用户权限
        /// </summary>
        [MaxLength(150, ErrorMessage = "长度不能超过150字符")]
        [Display(Name = "类型名")]
        public string Access { get; set; }
        /// <summary>
        /// 用户类型描述
        /// </summary>
        [Display(Name = "类型名")]
        public string Describe { get; set; }
        /// <summary>
        /// 用户信息
        /// </summary>
        public virtual ICollection<UserInfo> UserInfo { get; set; }
    }
}
