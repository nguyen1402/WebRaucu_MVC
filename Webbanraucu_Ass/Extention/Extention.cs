using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webbanraucu_Ass.Extention
{
    public static class Extention
    {
        public static string ToVnd(this double donGia)
        {
            return donGia.ToString("##,##0") + "đ";
        }
    }
}
