using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webbanraucu_Ass.Models
{
    [Table("TransacStatus")]
    public class TransacStatus
    {
        [Key]
        public int TransacStatuID { get; set; }
        [StringLength(150)]
        public string Status { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
