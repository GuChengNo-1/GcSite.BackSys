using GcSite.BackSys.Models;
using SnmpSharpNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GcSite.BackSys.BLL
{
    // ******************************************************************
    // 文件版本： GcSys 1.0
    // Copyright  (c)  2019 Shanghai GuCheng
    // 创建时间： 2019/4
    // 主要内容：  获取远程CPU使用率、内存占有率
    // ******************************************************************
    public class SNMP_BLL
    {
        public static MemoryCpu GetCPU()
        {
            MemoryCpu model = new MemoryCpu();
            SimpleSnmp snmp = new SimpleSnmp("192.168.1.200", "public");
            try
            {
                //获取运行内存
                double TotalMemory = 0.0;//内存总大小
                double UseMemory = 0.0;//内存使用大小
                Dictionary<SnmpSharpNet.Oid, AsnType> TotalMemorys = snmp.Get(SnmpVersion.Ver2, new string[] { ".1.3.6.1.2.1.25.2.2.0" }); ////获取总内存大小
                Dictionary<SnmpSharpNet.Oid, AsnType> UseMemorys = snmp.Walk(SnmpVersion.Ver2, ".1.3.6.1.2.1.25.2.3.1.6");    //使用内存大小
                foreach (var item in TotalMemorys)
                {
                    TotalMemory += double.Parse(item.Value.ToString());
                }
                foreach (var item in UseMemorys)
                {
                    UseMemory += double.Parse(item.Value.ToString());
                }
                UseMemory = UseMemory / TotalMemory;
                //获取cpu负载
                double TotalCPU = 0;
                Dictionary<SnmpSharpNet.Oid, AsnType> result = snmp.Walk(SnmpVersion.Ver2, ".1.3.6.1.2.1.25.3.3.1.2"); //查找内容大小.这个编号我是用mib browser查出来的
                foreach (var item in result)
                {
                    TotalCPU += double.Parse(item.Value.ToString());
                }
                double RatioCPU = TotalCPU / result.Count;//获取比率
                model.Cpu = RatioCPU.ToString()+"%";
                model.Memory = (UseMemory*100).ToString("F2")+ "%";
            }
            catch (Exception ee)
            {
                
            }
            return model;
        }
    }
}
