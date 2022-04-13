using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Webbanraucu_Ass.Models
{
    [Table("Categories")]
    public class Categories
    {
        [Key]
        public int CatID { get; set; }
        [StringLength(150)]
        public string CatName { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        [StringLength(250)]
        public virtual ICollection<Products> Products { get; set; }
    }
}
