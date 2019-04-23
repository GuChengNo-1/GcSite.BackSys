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
    // 主要内容：  首页
    // ******************************************************************
    /// <summary>
    /// 首页
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}