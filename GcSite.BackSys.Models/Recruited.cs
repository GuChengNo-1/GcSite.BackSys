using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcSite.BackSys.Models
{
    /// <summary>
    /// 招聘信息
    /// </summary>
    public class Recruited : EntityBase
    {
        // PublishTime VARCHAR(50) NULL,			--发布时间
        // RecruitPosition VARCHAR(100) NOT NULL,  --招聘职位
        // MonthlyPay VARCHAR(50) NULL,			--月薪
        // AreaName VARCHAR(100) NULL,				--所属地区
        // RecruitSource VARCHAR(200) NOT NULL,   --来源
        //SourceUrl VARCHAR(200)NULL,				--来源地址
        //CompanyId int references CompanyInfo(CompanyId) NOT NULL	--企业信息（外键约束）
        /// <summary>
        /// 广告图片路径
        /// </summary>
        [MaxLength(100, ErrorMessage = "长度不能超过100字符")]
        [Display(Name = "招聘职位")]
        public string AdeverImg { get; set; }
        /// <summary>
        /// 广告描述
        /// </summary>
        [Display(Name = "广告描述")]
        public string Describe { get; set; }
        /// <summary>
        /// 广告链接
        /// </summary>
        [MaxLength(150, ErrorMessage = "长度不能超过150字符")]
        [Display(Name = "广告链接")]
        public string Link { get; set; }
        /// <summary>
        /// 发布日期
        /// </summary>
        [Display(Name = "发布日期")]
        public DateTime ReleaseDate { get; set; }
        /// <summary>
        /// 广告类型(外键)
        /// </summary>
        public virtual AdverType Type { get; set; }
    }
}
