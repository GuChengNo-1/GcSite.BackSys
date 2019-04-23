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
    // 主要内容：  系统管理，管理员登录及注册
    // ******************************************************************
    /// <summary>
    /// 系统管理
    /// </summary>
    public class SysAdminController : Controller
    {
        // GET: SysAdmin
        public ActionResult Login()
        {
            return View();
        }
    }
}