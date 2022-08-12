using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Extension
{
    public static class Extension
    {
        public static string toVND(this double dongia)
        {
            return dongia.ToString("#,##0") + "Đ";
        }
        public static string totitlecase(string str)
        {
            string result = str;
            if (!string.IsNullOrEmpty(str))
            {
                var w = str.Split(' ');
                for(int index = 0; index < w.Length; index++)
                {
                    var s = w[index];
                    if (s.Length > 0)
                    {
                        w[index] = s[0].ToString().ToUpper() + s.Substring(1);
                    }
                }
                result = string.Join("", w);
            }
            return result;
        }
      
    }
}
