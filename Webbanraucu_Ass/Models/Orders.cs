using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webbanraucu_Ass.Models
{
    [Table("Orders")]
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDat { get; set; }
        public int TransacStatuID { get; set; }
        public double TotoMoney { get; set; }
        public virtual Customers Customers { get; set; }
        public virtual TransacStatus TransacStatus { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
