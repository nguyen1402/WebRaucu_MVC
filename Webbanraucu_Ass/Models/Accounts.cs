using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webbanraucu_Ass.Models
{
    [Table("Accounts")]
    public class Accounts
    {
        [Key]
        public int AccountID { get; set; }
        [StringLength(150)]
        public string Email { get; set; }
        [StringLength(12)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        [StringLength(6)]
        public string Salt { get; set; }
        public bool Active { get; set; }
        [StringLength(150)]
        public string Fullname { get; set; }
        public int RoleID { get; set; }
        public virtual Roles Roles { get; set; }

    }
}
