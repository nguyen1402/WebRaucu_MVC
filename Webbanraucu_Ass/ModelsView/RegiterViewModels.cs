using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Webbanraucu_Ass.ModelsView
{
    public class RegiterViewModels
    {
        [Key]
        public int CustomerID { get; set; }
        [StringLength(150)]
        [Required(ErrorMessage = "Vui lòng nhập Họ Tên")]
        [Display(Name = "Họ Tên")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(12)]
        [Required(ErrorMessage = "Vui lòng nhập Số Điện Thoại")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập Mật Khẩu")]
        [MinLength(5, ErrorMessage = "Bạn cần đặt mật khẩu tối thiểu 5 kí tự")]
        [Display(Name = "Mật Khẩu")]
        public string Password { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập Mật Khẩu")]
        [MinLength(5, ErrorMessage = "Bạn cần đặt mật khẩu tối thiểu 5 kí tự")]
        [Display(Name = "Nhập Lại Mật Khẩu")]
        [Compare("Password", ErrorMessage = "Bạn cần nhập giống mật khẩu")]
        public string RP_Password { get; set; }
    }
}
