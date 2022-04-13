using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webbanraucu_Ass.Models
{
    [Table("Customers")]
    public class Customers
    {
        [Key]
        public int CustomerID { get; set; }
        [StringLength(150)]
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        [StringLength(250)]
        public string Avatar { get; set; }
        [StringLength(250)]
        public string Address { get; set; }
        [StringLength(150)]
        public string Email { get; set; }
        [StringLength(12)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        [StringLength(150)]
        public string Salt { get; set; }
        public DateTime Lastlogin { get; set; }
        public bool Actice { get; set; }
        public DateTime CreatDate { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }

    }
}
