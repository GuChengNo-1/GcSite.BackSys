using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcSite.BackSys.Common
{
    // ******************************************************************
    // 文件版本： GcSys 1.0
    // Copyright  (c)  2019 Shanghai GuCheng
    // 创建时间： 2019/4
    // 主要内容：  帮助类,主要用于数据库产生表的主键ID
    // ******************************************************************
    /// <summary>
    /// 帮助类,主要用于数据库产生表的主键ID
    /// </summary>
    public class Helper
    {
        /// <summary>
        /// 产生部分表的主键ID
        /// </summary>
        /// <param name="Head">自定义的ID开头</param>
        /// <param name="MaxID">当前表中的最大ID</param>
        public static string GenerateID(string Head, string MaxID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Head);
            sb.Append(DateTime.Now.ToString("yyyyMMddHHmm"));
            if (string.IsNullOrEmpty(MaxID))
            {
                sb.Append("0001");
            }
            else if (MaxID.Contains(DateTime.Now.ToString("yyyyMMddHHmm")))
            {
                int HeadLength = Head.Length;
                int MinuteMax = int.Parse(MaxID.Substring(HeadLength + 12, 4));
                string NowMax = (MinuteMax + 1).ToString();
                for (int i = NowMax.Length; i < 4; i++)
                {
                    sb.Append("0");
                }
                sb.Append((MinuteMax + 1).ToString());
            }
            else
            {
                sb.Append("0001");
            }
            return sb.ToString();
        }



        /// <summary>
        /// 产生部分表的主键ID
        /// </summary>
        /// <param name="Head">自定义的ID开头</param>
        /// <param name="MaxID">当前表中的最大ID</param>
        public static string GenerateIDEx(string Head, string MaxID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Head);
            sb.Append(DateTime.Now.ToString("yyyyMMdd"));
            if (string.IsNullOrEmpty(MaxID))
            {
                sb.Append("001");
            }
            else if (MaxID.Contains(DateTime.Now.ToString("yyyyMMdd")))
            {
                int HeadLength = Head.Length;
                int MinuteMax = int.Parse(MaxID.Substring(HeadLength + 8, 3));
                string NowMax = (MinuteMax + 1).ToString();
                for (int i = NowMax.Length; i < 3; i++)
                {
                    sb.Append("0");
                }
                sb.Append((MinuteMax + 1).ToString());
            }
            else
            {
                sb.Append("001");
            }
            return sb.ToString();
        }

        /// <summary>
        /// 产生部分表的主键ID
        /// </summary>
        /// <param name="Head">自定义的ID开头</param>
        /// <param name="MaxID">当前表中的最大ID</param>
        public static string GenerateID2(string Head, string MaxID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Head);
            if (string.IsNullOrEmpty(MaxID))
            {
                sb.Append("000001");
            }
            else
            {
                int HeadLength = Head.Length;
                int MinuteMax = int.Parse(MaxID.Substring(HeadLength, 6));
                string NowMax = (MinuteMax + 1).ToString();
                for (int i = NowMax.Length; i < 6; i++)
                {
                    sb.Append("0");
                }
                sb.Append((MinuteMax + 1).ToString());
            }

            return sb.ToString();
        }
        /// <summary>
        /// 随机生成指定长度的字符串（只包括数字）
        /// </summary>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static int RandNumStr(int length)
        {
            string str = "1234567890";
            Random r = new Random();
            string result = "";
            for (int i = 0; i < length; i++)
            {
                int m = r.Next(0, str.Length);
                string s = str.Substring(m, 1);
                result += s;
            }
            return int.Parse(result);

        }
    }
}
