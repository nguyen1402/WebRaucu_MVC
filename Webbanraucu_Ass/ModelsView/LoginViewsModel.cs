using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webbanraucu_Ass.ModelsView
{
    public class LoginViewsModel
    {
        [MaxLength(100)]
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Mật Khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [MinLength(5, ErrorMessage = "Bạn cần đặt mật khẩu tối thiểu 5 kí tự")]
        public string Password { get; set; }
    }
}
