using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webbanraucu_Ass.Models
{
    [Table("OrderDetails")]
    public class OrderDetails
    {
        [Key]
        public int OrderDetailsID { get; set; }
        public int OrderID { get; set; }
        public int ProductsID { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
        public double TotalMoney { get; set; }
        public DateTime Shipdate { get; set; }
        public virtual Orders Orders { get; set; }
        public virtual Products Products { get; set; }
    }
}
