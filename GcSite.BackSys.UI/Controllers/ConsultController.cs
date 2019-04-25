using GcSite.BackSys.BLL;
using GcSite.BackSys.Common;
using GcSite.BackSys.Common.Out_Models;
using GcSite.BackSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace GcSite.BackSys.UI.Controllers
{
    // ******************************************************************
    // 文件版本： GcSys 1.0
    // Copyright  (c)  2019 Shanghai GuCheng
    // 创建时间： 2019/4
    // 主要内容：  资讯管理
    // ******************************************************************
    /// <summary>
    /// 资讯管理
    /// </summary>
    public class ConsultController : Controller
    {
        /// <summary>
        /// 资讯列表
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            return View();
        }
        /// <summary>
        /// 资讯分类
        /// </summary>
        /// <returns></returns>
        public ActionResult Type()
        {
            return View();
        }
        /// <summary>
        /// 资讯分类数据
        /// </summary>
        /// <returns></returns>
        public ActionResult TypeTree()
        {
            var query = InformationManage.GetAllLg();
            List<ConsultTypeTree> ctt = new List<ConsultTypeTree>();
            for (int i = 0; i < query.Count(); i++)
            {
                ConsultTypeTree model = new ConsultTypeTree();
                model.Sort = query[i].Sort;
                model.Id = query[i].Id;
                model.C_Id = query[i].Id;
                model.P_Id = 0;
                model.Name = query[i].LgName;
                model.Pid = "0";
                model.Display = query[i].Lock;
                model.Describe = query[i].Describe;
                model.Sign = query[i].Sign;
                ctt.Add(model);
                List<ConsultTypeTree> ctt2 = new List<ConsultTypeTree>();
                var query2 = InformationManage.GetSm(query[i].Id);
                for (int j = 0; j < query2.Count(); j++)
                {
                    ConsultTypeTree model2 = new ConsultTypeTree();
                    model2.Sort = query2[j].Sort;
                    model2.Id = -1;
                    model2.C_Id = query2[j].Id;
                    model2.P_Id = query2[j].Lg.Id;
                    model2.Name = query2[j].SmName;
                    model2.Pid = query2[j].Lg.Id.ToString();
                    model2.Display = query2[j].Lock;
                    model2.Describe = query2[j].Describe;
                    model.Sign = query2[j].Sign;
                    ctt2.Add(model2);
                }
                ctt.AddRange(ctt2);
            }
            return Json(new { code = 0, msg = "ok", data = ctt.ToList().OrderBy(m=>m.Sort), count = ctt.Count }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 资讯列表数据
        /// </summary>
        /// <param name="page">当前页</param>
        /// <param name="limit">数据数量</param>
        /// <param name="consult_id">资讯id</param>
        /// <param name="consult_author">作者</param>
        /// <param name="consult_title">资讯标题</param>
        /// <param name="consult_sm">资讯小类</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult List(int page, int limit)
        {
            #region 条件筛选
            int consult_id = int.Parse(string.IsNullOrEmpty(Request.Params["consult_id"]) ? "0" : Request.Params["consult_id"]);
            var consult_author = string.IsNullOrEmpty(Request.Params["consult_author"]) ? "" : Request.Params["consult_author"];
            var consult_title = string.IsNullOrEmpty(Request.Params["consult_title"]) ? "" : Request.Params["consult_title"];
            int consult_sm = int.Parse(string.IsNullOrEmpty(Request.Params["consult_sm"])
                || Request.Params["consult_sm"].Contains("请选择") ? "0" : Request.Params["consult_sm"]);
            Expression<Func<Information, bool>> where = null;
            if (!string.IsNullOrEmpty(Request.Params["consult_id"]) && consult_sm != 0)
            {
                where = m => m.Id == consult_id && m.User.LoginName.Contains(consult_author)
                        && m.Title.Contains(consult_title) && m.Sm.Id == consult_sm;
            }
            if (!string.IsNullOrEmpty(Request.Params["consult_id"]))
            {
                where = m => m.Id == consult_id && m.User.LoginName.Contains(consult_author)
                        && m.Title.Contains(consult_title);
            }
            if (consult_sm != 0)
            {
                where = m => m.Sm.Id == consult_sm && m.User.LoginName.Contains(consult_author)
                        && m.Title.Contains(consult_title);
            }
            #endregion

            #region 数据处理
            var query = InformationManage.GetMationPageByWhere(where, "", page, limit).Select(m => new
            {
                Id = m.Id,
                Title = m.Title,
                User_Id = m.User.Id,
                User_Name = m.User.LoginName,
                ReleaseDate = m.ReleaseDate,
                UpdateDate = m.UpdateDate,
                Describe = m.Describe,
                R_Str = m.Recommend.Whether == 1 ? "否" : "是",
                R_Id = m.Recommend.Whether,
                Sm_Id = m.Sm.Id,
                Sm_Name = m.Sm.SmName
            }).ToList();
            var count = InformationManage.GetCountByWhere(where);
            #endregion
            return Json(new { code = 0, msg = "", count = count, data = query.ToList() }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除资讯
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteConsult(int id)
        {
            //扩展:判断操作员权限
            ReturnInfo rif = new ReturnInfo();
            rif = InformationManage.DeleteConsultById(id);
            return Json(rif, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 批量删除资讯
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public ActionResult BatchDeletConsult(int[] arr)
        {
            //扩展:判断操作员权限
            ReturnInfo rif = new ReturnInfo();
            StringBuilder sb = new StringBuilder();
            if (arr.Length != 0)
            {
                foreach (var item in arr)
                {
                    var query = InformationManage.DeleteConsultById(item);
                    rif.IsSuccess = query.IsSuccess;
                    sb.Append(query.ErrorInfo);
                }
            }
            rif.ErrorInfo = sb.ToString();
            return Json(rif, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteType(int p_id, int f_id)
        {
            ReturnInfo rif = new ReturnInfo();
            StringBuilder sb = new StringBuilder();
            try
            {
                rif = InformationManage.DeleteClassById(p_id, f_id);
            }
            catch (Exception ex)
            {
                rif.IsSuccess = false;
                sb.Append(ex.Message);
                rif.ErrorInfo = sb.ToString();
            }
            return Json(rif, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取资讯大类
        /// </summary>
        /// <returns></returns>
        public ActionResult GetLgData()
        {
            var query = InformationManage.GetAllLg().Select(m => new
            {
                Id = m.Id,
                LgName = m.LgName
            });
            return Json(query.ToList(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据资讯大类获取小类
        /// </summary>
        /// <param name="lg_Id"></param>
        /// <returns></returns>
        public ActionResult GetSmData(int lg_Id)
        {
            var query = InformationManage.GetSm(lg_Id).Select(m => new
            {
                Id = m.Id,
                SmName = m.SmName
            });
            return Json(query.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}