using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webbanraucu_Ass.ModelsView
{
    public class MuaHangVM
    {
        [Key]
        public int Customerid { get; set; }
        [Required(ErrorMessage = "Vui lòng không được để trống !")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Vui lòng không được để trống !")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng không được để trống !")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Vui lòng không được để trống !")]
        public string Address { get; set; }
    }
}
