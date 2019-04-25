using GcSite.BackSys.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcSite.BackSys.BLL
{
    /// <summary>
    /// 数据库临时处理
    /// </summary>
    public class DataBaseManage
    {
        /// <summary>
        /// 删除数据库重新创建数据库
        /// </summary>
        public static bool DeleteIfNotCreate()
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<GcSiteDb>());
            using (GcSiteDb db = new GcSiteDb())
            {
                db.Database.Delete();
                return db.Database.CreateIfNotExists();
            }
        }
        /// <summary>
        /// 当models发生改变时修改数据库
        /// </summary>
        public static void SetInitializer()
        {
            //当models发生改变时修改数据库
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<GcSiteDb, GcSite.BackSys.DAL.Migrations.Configuration>());
            //var dbMigrator = new DbMigrator(new GcSite.BackSys.DAL.Migrations.Configuration());
            //dbMigrator.Update();
        }
    }
}
