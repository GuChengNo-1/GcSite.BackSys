using GcSite.BackSys.BLL;
using GcSite.BackSys.Controllers;
using GcSite.BackSys.DAL;
using GcSite.BackSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GcSite.BackSys.UI.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            HttpCookie cookie = Request.Cookies["UserName"];
            HttpCookie cookiepwd = Request.Cookies["Password"];
            UserInfo Model = new UserInfo();
            if (cookie != null)
            {
                Model.LoginName = cookie["UserName"].ToString();
            }
            if (cookie != null)
            {
                Model.LoginPwd = cookie["Password"].ToString();
            }
            return View();
        }

        #region 登录验证
        public ActionResult GetLogin(string username, string password, string vercode, string remember)
        {
            Expression<Func<UserInfo, bool>> where = null;
            string userPwd = MD5Encrypt(password.Trim());
            password = userPwd = "123456";
            using (WorkOfUnit work = new WorkOfUnit())
            {
                //判断验证码是否正确
                if (vercode.ToLower() == Session["code"].ToString().ToLower())
                {
                    where = m => m.LoginName == username && m.LoginPwd == password;
                    int a = UserManage.GetNameAndPwdByWhere(where);
                    if (a > 0)
                    {
                        int id = 0;
                        List<UserInfo> list = UserManage.GetUserId(where);
                        for (int i = 0; i < list.Count; i++)
                        {
                            id = list[i].Id;
                        }
                        if (remember == "on")
                        {
                            HttpCookie cookie = new HttpCookie("UserName", username);
                            HttpCookie cookiepwd = new HttpCookie("Password", password);
                            cookie.Expires = System.DateTime.Now.AddSeconds(-1);//Expires过期时间
                            cookiepwd.Expires = System.DateTime.Now.AddSeconds(-1);//Expires过期时间
                            //如果存在cookie
                            if (Request.Cookies.AllKeys.Contains(username) && Request.Cookies.AllKeys.Contains(password))
                            {
                                cookie.Values.Add("UserName", username);
                                cookiepwd.Values.Add("Password", password);
                                cookie.Expires = System.DateTime.Now.AddDays(7.0);
                                cookiepwd.Expires = System.DateTime.Now.AddDays(7.0);
                                Request.Cookies.Add(cookie);
                                Request.Cookies.Add(cookiepwd);
                                var cookietest = Request.Cookies["UserName"];
                                var cookietestp = Request.Cookies["Password"];
                            }
                            return Json(new { success = 1, id = id }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { success = 1, id = id }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { success = 3 }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { success = 4 }, JsonRequestBehavior.AllowGet);
                }
            }
        }
        #endregion

        #region 验证码
        /// <summary>
        /// 验证码
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetCodeImg(double? id)
        {
            string code = new ValidataCode().GetCode(4);
            Session["code"] = code;
            Session.Timeout = 10;
            byte[] img = new ValidataCode().CreateValidateGraphic(code);
            return File(img, @"img/jpeg");
        }
        #endregion

        #region MD5 加密
        /// <summary>
        /// MD5 加密静态方法
        /// </summary>
        /// <param name="EncryptString">待加密的密文</param>
        /// <returns>returns</returns>
        public static string MD5Encrypt(string EncryptString)
        {
            if (string.IsNullOrEmpty(EncryptString)) { throw (new Exception("密文不得为空")); }
            MD5 m_ClassMD5 = new MD5CryptoServiceProvider();
            string m_strEncrypt = "";
            try
            {
                m_strEncrypt = BitConverter.ToString(m_ClassMD5.ComputeHash(Encoding.Default.GetBytes(EncryptString))).Replace("-", "");
            }
            catch (ArgumentException ex) { throw ex; }
            catch (CryptographicException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally { m_ClassMD5.Clear(); }
            return m_strEncrypt;
        }
        #endregion
    }
}