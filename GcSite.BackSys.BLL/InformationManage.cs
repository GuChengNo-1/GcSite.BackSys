using GcSite.BackSys.Common;
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
        public static List<Information> GetMationByWhere(Expression<Func<Information, bool>> where)
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
            Expression<Func<Information, bool>> where, string order, int pageIndex, int pageSize)
        {
            using (WorkOfUnit work = new WorkOfUnit())
            {
                var query = work.CreateRepository<Information>().GetPageList(
                    where, order: order, pageIndex: pageIndex, pageSize: pageSize).ToList();
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
                var query = work.CreateRepository<LgClass>().GetList(m => m.Lock == 0).ToList();
                return query;
            }
        }
        /// <summary>
        /// 获取所有小类
        /// </summary>
        /// <returns></returns>
        public static List<SmClass> GetSm()
        {
            using (WorkOfUnit work = new WorkOfUnit())
            {
                var query = work.CreateRepository<SmClass>().GetList(m => m.Lock == 0).ToList();
                return query;
            }
        }
        /// <summary>
        /// 根据大类获取小类
        /// </summary>
        /// <param name="lg_Id"></param>
        /// <returns></returns>
        public static List<SmClass> GetSm(int lg_Id)
        {
            using (WorkOfUnit work = new WorkOfUnit())
            {
                var query = work.CreateRepository<SmClass>().GetList(m => m.Lg.Id == lg_Id && m.Lock == 0).ToList();
                return query;
            }
        }
        /// <summary>
        /// 根据id删除资讯实体
        /// </summary>
        /// <param name="id"></param>
        public static ReturnInfo DeleteConsultById(int id)
        {
            ReturnInfo rif = new ReturnInfo();
            StringBuilder sb = new StringBuilder();
            using (WorkOfUnit work = new WorkOfUnit())
            {
                try
                {
                    //假如存在外键约束则先删除关联数据
                    var img = work.CreateRepository<RmationImg>().GetList(m => m.Information.Id == id);
                    if (img.Count() != 0)
                    {
                        foreach (var item in img)
                        {
                            try
                            {
                                work.CreateRepository<RmationImg>().Delete(item.Id);
                                rif.IsSuccess = work.Save() >= 1;
                            }
                            catch (Exception ex)
                            {
                                item.Lock = 1;
                                work.CreateRepository<RmationImg>().Update(item);
                                rif.IsSuccess = work.Save() >= 1;
                                sb.Append("删除失败" + item.Id + ":" + ex.Message);
                                continue;
                            }
                        }
                    }
                    work.CreateRepository<Information>().Delete(id);
                    rif.IsSuccess = work.Save() >= 1;
                }
                catch (Exception ex)
                {
                    rif.IsSuccess = false;
                    sb.Append(ex.Message);
                }
            }
            rif.ErrorInfo = sb.ToString();
            return rif;
        }
        /// <summary>
        /// 删除资讯分类
        /// </summary>
        /// <param name="p_id"></param>
        /// <param name="f_id"></param>
        /// <returns></returns>
        public static ReturnInfo DeleteClassById(int p_id, int f_id)//需考虑情况：可能操作者选择了大类，现在情况操作者选择了小类
        {
            ReturnInfo rif = new ReturnInfo();
            StringBuilder sb = new StringBuilder();
            List<int> arrId = new List<int>();
            using (WorkOfUnit work = new WorkOfUnit())
            {
                try
                {
                    //判断是否是父级 如果不是父级
                    if (f_id != 0)
                    {
                        //假如存在外键约束则先删除关联数据
                        var smQuery = work.CreateRepository<SmClass>().GetList(m => m.Id == p_id);
                        if (smQuery.Count() != 0)
                        {
                            foreach (var item in smQuery.ToList())
                            {
                                #region 获取资讯
                                //var mQuery = work.CreateRepository<Information>().GetList(m => m.Sm.Id == item.Id);
                                if (item.Information.Count() != 0)
                                {
                                    foreach (var mation in item.Information.ToList())
                                    {
                                        arrId.Add(mation.Id);
                                    }
                                }
                                #endregion
                            }
                            if (arrId.Count() != 0)
                            {
                                foreach (var item in arrId)
                                {
                                    //删除资讯
                                    var query = DeleteConsultById(item);
                                    rif.IsSuccess = query.IsSuccess;
                                    sb.Append(query.ErrorInfo);
                                }
                            }
                            foreach (var sm in smQuery.ToList())
                            {
                                try
                                {
                                    //删除资讯小类
                                    work.CreateRepository<SmClass>().Delete(sm);
                                    rif.IsSuccess = work.Save() >= 1;
                                }
                                catch (Exception ex)
                                {
                                    sm.Lock = 1;
                                    work.CreateRepository<SmClass>().Update(sm);
                                    work.Save();
                                    sb.Append("删除失败" + sm.Id + ":" + ex.Message);
                                    continue;
                                }
                            }
                        }
                    }
                    //如果是父级
                    if (f_id == 0)
                    {
                        var lgQuery = work.CreateRepository<LgClass>().GetEntityById(p_id);
                        //假如存在外键约束则先删除关联数据
                        var smQuery = work.CreateRepository<SmClass>().GetList(m => m.Lg.Id == lgQuery.Id);
                        if (smQuery.Count() != 0)
                        {
                            foreach (var item in smQuery.ToList())
                            {
                                #region 获取资讯
                                //var mQuery = work.CreateRepository<Information>().GetList(m => m.Sm.Id == item.Id);
                                if (item.Information.Count() != 0)
                                {
                                    foreach (var mation in item.Information.ToList())
                                    {
                                        arrId.Add(mation.Id);
                                    }
                                }
                                #endregion
                            }
                            if (arrId.Count() != 0)
                            {
                                foreach (var item in arrId)
                                {
                                    //删除资讯
                                    var query = DeleteConsultById(item);
                                    rif.IsSuccess = query.IsSuccess;
                                    sb.Append(query.ErrorInfo);
                                }
                            }
                            foreach (var sm in smQuery.ToList())
                            {
                                try
                                {
                                    //删除资讯小类
                                    work.CreateRepository<SmClass>().Delete(sm);
                                    rif.IsSuccess = work.Save() >= 1;
                                }
                                catch (Exception ex)
                                {
                                    sm.Lock = 1;
                                    work.CreateRepository<SmClass>().Update(sm);
                                    work.Save();
                                    sb.Append("删除失败" + sm.Id + ":" + ex.Message);
                                    continue;
                                }
                            }
                        }
                        try
                        {
                            //删除资讯大类
                            work.CreateRepository<LgClass>().Delete(lgQuery);
                            rif.IsSuccess = work.Save() >= 1;
                        }
                        catch (Exception ex)
                        {
                            rif.IsSuccess = false;
                            sb.Append(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    rif.IsSuccess = false;
                    sb.Append(ex.Message);
                }
                rif.ErrorInfo = sb.ToString();
            }
            return rif;
        }
    }
}
