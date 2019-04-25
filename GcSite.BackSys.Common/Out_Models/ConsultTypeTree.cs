using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcSite.BackSys.Common.Out_Models
{
    /// <summary>
    /// 资讯类型节点,用以查询数据
    /// </summary>
    public class ConsultTypeTree
    {
        public int Sort { get; set; }
        public int Sign { get; set; }
        public int Id { get; set; }
        public int C_Id { get; set; }
        public int P_Id { get; set; }
        public string Name { get; set; }
        public int Display { get; set; }
        public string Pid { get; set; }
        public string Describe { get; set; }
    }
}
