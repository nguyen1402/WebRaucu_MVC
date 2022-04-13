using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webbanraucu_Ass.Models
{
    [Table("Products")]
    public class Products
    {
        [Key]
        public int ProductID { get; set; }
        [StringLength(150)]
        public string ProductName { get; set; }
        [StringLength(150)]
        public string SortDesc { get; set; }
        public string Description { get; set; }
        public int CatID { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        [StringLength(250)]
        public string Hinhanh { get; set; }
        public DateTime DateCreat { get; set; }
        public DateTime DateModifier { get; set; }
        public virtual Categories Categories { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

    }
}
