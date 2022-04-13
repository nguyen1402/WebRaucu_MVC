using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbanraucu_Ass.Models;

namespace Webbanraucu_Ass.ModelsView
{
    public class XemDonHang
    {
        public Orders DonHang { get; set; }
        public List<OrderDetails> ChiTietDonHang { get; set; }
    }
}
