using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbanraucu_Ass.Models;

namespace Webbanraucu_Ass.ModelsView
{
    public class GioHang
    {
        public Products _products { get; set; }
        public int soluong { get; set; }
        public double Tongtien => soluong * _products.Price;

    }
}
