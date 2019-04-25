using GcSite.BackSys.DAL;
using GcSite.BackSys.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GcSite.BackSys.BLL
{
    // ******************************************************************
    // 文件版本： GcSys 1.0
    // Copyright  (c)  2019 Shanghai GuCheng
    // 创建时间： 2019/4
    // 主要内容：  用户管理，用于用户信息增删查改
    // ******************************************************************
    public class UserManage
    {
        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public static int GetNameAndPwdByWhere(Expression<Func<UserInfo, bool>> where)
        {
            using (WorkOfUnit work = new WorkOfUnit())
            {
                //判断用户是否存在
                var model = work.CreateRepository<UserInfo>().GetList(where).ToList();
                return model.Count;
            }
        }
        public static List<UserInfo> GetUserId(Expression<Func<UserInfo, bool>> where)
        {
            using (WorkOfUnit work = new WorkOfUnit())
            {
                var model = work.CreateRepository<UserInfo>().GetList(where).ToList();
                return model;
            }
        }

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
