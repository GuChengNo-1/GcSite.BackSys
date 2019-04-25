using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GcSite.BackSys.UI.Controllers
{
    // ******************************************************************
    // 文件版本： GcSys 1.0
    // Copyright  (c)  2019 Shanghai GuCheng
    // 创建时间： 2019/4
    // 主要内容：  帮助接口，主要用于图片上传
    // ******************************************************************
    public class HelperController : Controller
    {
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="file">文件对象</param>
        /// <param name="path">服务器保存路径</param>
        /// <param name="ext">文件类型集合</param>
        /// <param name="size">文件大小</param>
        /// <returns></returns>
        public ActionResult Upload(HttpPostedFileBase file, string path)
        {
            string ext = ".jpg.jpeg.png";
            int size = 512;
            string pic = "", error = "ok";
            try
            {
                if (file == null)
                {
                    file = Request.Files[0];
                }
                string fileName = System.IO.Path.GetFileName(file.FileName);
                string extName = System.IO.Path.GetExtension(file.FileName).ToLower();

                if (!ext.Contains(extName))
                {
                    throw (new Exception(string.Format("当前不支持您所选的文件类型：【{0}】", extName)));
                }
                if (file.ContentLength > size * 1024)
                {
                    throw (new Exception(string.Format("文件太大，最大允许：【{0}K】", size)));
                }
                //path = "/upload/image/";
                //path = "/Upload/" + Guid.NewGuid().ToString() + file.FileName;
                String ymd = DateTime.Now.ToString("/yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
                path += ymd;
                string physicalPath = Server.MapPath(path);
                if (!Directory.Exists(physicalPath))
                {
                    Directory.CreateDirectory(physicalPath);
                }

                String newFileName = DateTime.Now.ToString("HHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + extName;
                string filePhysicalPath = Server.MapPath(System.IO.Path.Combine(path, newFileName));
                file.SaveAs(filePhysicalPath);
                pic = string.Format("{0}/{1}", path, newFileName);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return Json(new
            {
                pic = pic,
                error = error
            });

        }
    }
}