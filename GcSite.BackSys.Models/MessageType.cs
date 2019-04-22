using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcSite.BackSys.Models
{
    /// <summary>
    /// 留言类型
    /// </summary>
    public class MessageType:EntityBase
    {
        /// <summary>
        /// 类型名
        /// </summary>
        [Required(ErrorMessage = "类型名不能为空"), MaxLength(30, ErrorMessage = "长度不能超过30字符")]
        [Display(Name = "类型名")]
        public string TypeName { get; set; }
        /// <summary>
        /// 类型描述
        /// </summary>
        [Display(Name = "类型描述")]
        public string Describe { get; set; }
    }
}
