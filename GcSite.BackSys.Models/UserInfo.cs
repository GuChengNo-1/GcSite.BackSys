using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcSite.BackSys.Models
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfo:EntityBase
    {
        /// <summary>
        /// 用户登录名
        /// </summary>
        [Required(ErrorMessage = "登录名不能为空"), MaxLength(100)]
        [Display(Name = "用户登录名")]
        public string LoginName { get; set; }
        /// <summary>
        /// 用户登录密码
        /// </summary>
        [Required(ErrorMessage = "登录密码不能为空")]
        [Display(Name = "登录密码")]
        public string LoginPwd { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        [Display(Name = "用户昵称")]
        public string UserRealName { get; set; }
        /// <summary>
        /// 用户头像
        /// </summary>
        [Display(Name = "用户头像")]
        public string UserPortrait { get; set; }
        /// <summary>
        /// 用户年龄
        /// </summary>
        [Display(Name = "用户年龄")]
        public int? UserAge { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        [Display(Name = "用户性别")]
        public string UserSex { get; set; }
        /// <summary>
        /// 用户地址
        /// </summary>
        [Display(Name = "用户地址"), MaxLength(150, ErrorMessage = "长度不能超过150字符")]
        public string UserAddress { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        [Display(Name = "用户邮箱"), MaxLength(50, ErrorMessage = "长度不能超过50字符")]
        public string UserEmail { get; set; }
        /// <summary>
        /// 用户手机号码
        /// </summary>
        [Display(Name = "用户手机号码"), MaxLength(20, ErrorMessage = "长度不能超过20字符")]
        public string UserPhone { get; set; }
        /// <summary>
        /// 用户登录次数
        /// </summary>
        [Display(Name = "用户登录次数")]
        public int LoginCount { get; set; }
        /// <summary>
        /// 用户注册日期
        /// </summary>
        [Display(Name = "用户注册日期")]
        public DateTime UserRegistrTime { get; set; }
        /// <summary>
        /// 用户最后登录时间
        /// </summary>
        [Display(Name = "用户最后登录时间")]
        public DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// 用户类型编号(用户类型表）
        /// </summary> 
        [Display(Name = "用户类型编号")]
        public virtual UserType Type { get; set; }
        /// <summary>
        /// 资讯
        /// </summary>
        public virtual ICollection<Information> Information { get; set; }
        /// <summary>
        /// 栏目
        /// </summary>
        public virtual ICollection<Programa> Programa { get; set; }
        /// <summary>
        /// 产品
        /// </summary>
        public virtual ICollection<ProductInfo> ProductInfo { get; set; }
        /// <summary>
        /// 招聘
        /// </summary>
        public virtual ICollection<Recruited> Recruited { get; set; }
        /// <summary>
        /// 友情链接
        /// </summary>
        public virtual ICollection<AdeverInfo> AdeverInfo { get; set; }
    }
}
