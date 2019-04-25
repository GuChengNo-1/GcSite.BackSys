using GcSite.BackSys.BLL;
using GcSite.BackSys.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Web;
using System.Web.Mvc;

namespace GcSite.BackSys.UI.Controllers
{
    // ******************************************************************
    // 文件版本： GcSys 1.0
    // Copyright  (c)  2019 Shanghai GuCheng
    // 创建时间： 2019/4
    // 主要内容：  Home控制器，后台获取数据，返回到前台
    // ******************************************************************
    public class HomeController : Controller
    {
        private int id;
        public ActionResult Index(int id)
        {
            return View();
        }
        public ActionResult GetCPU()
        {
            MessageInfo memory = new MessageInfo();
            MemoryCpu model = SNMP_BLL.GetCPU();
            #region 内存
            //double capacity = 0.00;
            //double available = 0.00;
            ////获取总物理内存大小
            //ManagementClass cimobject1 = new ManagementClass("Win32_PhysicalMemory");
            //ManagementObjectCollection moc1 = cimobject1.GetInstances();
            //foreach (ManagementObject mo1 in moc1)
            //{
            //    capacity += Math.Round(Int64.Parse(mo1.Properties["Capacity"].Value.ToString()) / 1024 / 1024.0, 1);
            //    memory.CompanyFax = capacity.ToString();
            //}
            //moc1.Dispose();
            //cimobject1.Dispose();
            ////获取内存可用大小
            //ManagementClass cimobject2 = new ManagementClass("Win32_PerfFormattedData_PerfOS_Memory");
            //ManagementObjectCollection moc2 = cimobject2.GetInstances();
            //foreach (ManagementObject mo2 in moc2)
            //{
            //    available += Math.Round(Int64.Parse(mo2.Properties["AvailableMBytes"].Value.ToString()) / 1.0, 1);
            //    memory.CompanyName = available.ToString();
            //}
            //moc2.Dispose();
            //cimobject2.Dispose();
            //memory.CompanyQQ = (Math.Round((capacity-available) / capacity, 2) * 100).ToString() + "%";
            //#endregion

            //#region CPU
            //PerformanceCounter _oPerformanceCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            //memory.ContactEmail = Math.Round(_oPerformanceCounter.NextValue(), 2).ToString() + "%";
            #endregion
            return Json(new { data = model }, JsonRequestBehavior.AllowGet);
        }
    }
}