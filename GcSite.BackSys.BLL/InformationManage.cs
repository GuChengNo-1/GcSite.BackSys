using GcSite.BackSys.DAL;
using GcSite.BackSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GcSite.BackSys.BLL
{
    // ******************************************************************
    // 文件版本： GcSys 1.0
    // Copyright  (c)  2019 Shanghai GuCheng
    // 创建时间： 2019/4
    // 主要内容：  资讯管理，用于资讯增删查改
    // ******************************************************************
    /// <summary>
    /// 资讯管理
    /// </summary>
    public class InformationManage
    {
        /// <summary>
        /// 根据表达式树获取资讯
        /// </summary>
        /// <returns></returns>
        public static List<Information> GetMationByWhere(Expression<Func<Information,bool>> where)
        {
            using (WorkOfUnit work = new WorkOfUnit())
            {
                var query = work.CreateRepository<Information>().GetList(where).ToList();
                return query;
            }
        }
        /// <summary>
        /// 根据表达式树获取资讯数量
        /// </summary>
        /// <returns></returns>
        public static int GetCountByWhere(Expression<Func<Information, bool>> where)
        {
            using (WorkOfUnit work = new WorkOfUnit())
            {
                var query = work.CreateRepository<Information>().GetList(where).ToList();
                return query.Count;
            }
        }
        public static List<Information> GetMationPageByWhere(
            Expression<Func<Information, bool>> where, string order,int pageIndex,int pageSize)
        {
            using (WorkOfUnit work = new WorkOfUnit())
            {
                var query = work.CreateRepository<Information>().GetPageList(
                    where,order:order,pageIndex:pageIndex,pageSize:pageSize).ToList();
                return query;
            }
        }
        /// <summary>
        /// 获取所有大类
        /// </summary>
        /// <returns></returns>
        public static List<LgClass> GetAllLg()
        {
            using (WorkOfUnit work = new WorkOfUnit())
            {
                var query = work.CreateRepository<LgClass>().GetList().ToList();
                return query;
            }
        }
        /// <summary>
        /// 根据大类获取小类
        /// </summary>
        /// <param name="lg_Id"></param>
        /// <returns></returns>
        public static List<SmClass> GetSmByLg(int lg_Id)
        {
            using (WorkOfUnit work = new WorkOfUnit())
            {
                var query = work.CreateRepository<SmClass>().GetList(m => m.Lg.Id == lg_Id).ToList();
                return query;
            }
        }
    }
}
