using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GcSite.BackSys.UI.Controllers
{
    // ******************************************************************
    // 文件版本： GcSys 1.0
    // Copyright  (c)  2019 Shanghai GuCheng
    // 创建时间： 2019/4
    // 主要内容：  产品管理，产品管理以及产品分类管理
    // ******************************************************************
    /// <summary>
    /// 产品管理
    /// </summary>
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult List()
        {
            return View();
        }
        public ActionResult Type()
        {
            return View();
        }
    }
}