using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webbanraucu_Ass.Models
{
    [Table("Roles")]
    public class Roles
    {
        [Key]
        public int RoleID { get; set; }
        [StringLength(150)]
        public string RoleName { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        public virtual ICollection<Accounts> Accounts { get; set; }
    }
}
