using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using GcSite.BackSys.Models;
using GcSite.BackSys.DAL.Migrations;

namespace GcSite.BackSys.DAL
{
    public class GcSiteDb : DbContext
    {
        public GcSiteDb()
            : base("connStr")
        {
            //当models发生改变时修改数据库
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GcSiteDb, Configuration>());
            //Update-Database
        }

        #region 管理员模块
        public IDbSet<UserType> UserTypes { get; set; }
        public IDbSet<UserInfo> UserInfos { get; set; }
        #endregion

        #region 资讯模块
        public IDbSet<LgClass> LgClasses { get; set; }
        public IDbSet<SmClass> SmClasses { get; set; }
        public IDbSet<Information> Informations { get; set; }
        public IDbSet<Recommend> Recommends { get; set; }
        public IDbSet<RmationImg> RmationImgs { get; set; }
        #endregion

        #region 新闻模块
        public IDbSet<NewsType> NewsTypes { get; set; }
        public IDbSet<NewsInfo> NewsInfoes { get; set; }
        #endregion

        #region 留言反馈模块
        public IDbSet<MessageType> MessageTypes { get; set; }
        public IDbSet<MessageInfo> MessageInfoes { get; set; }
        #endregion

        #region 产品模块
        public IDbSet<ProductType> ProductTypes { get; set; }
        public IDbSet<ProductImg> ProductImgs { get; set; }
        public IDbSet<ProductInfo> ProductInfos { get; set; }
        #endregion

        #region 广告模块
        public IDbSet<AdverType> AdverTypes { get; set; }
        public IDbSet<AdeverInfo> AdeverInfoes { get; set; }
        #endregion

        #region 友情链接模块
        public IDbSet<Blogroll> Blogrolls { get; set; }
        #endregion

        #region 招聘模块
        public IDbSet<Recruited> Recruiteds { get; set; }
        #endregion

        #region 栏目模块
        public IDbSet<Programa> Programas { get; set; }
        #endregion

        #region 法律申明
        public IDbSet<Statement> Statement { get; set; }
        #endregion
    }
}
