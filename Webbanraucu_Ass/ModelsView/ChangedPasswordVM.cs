using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webbanraucu_Ass.ModelsView
{
    public class ChangedPasswordVM
    {
        [Key]
        public int CustomerID { get; set; }
        [StringLength(50)]
        [Display(Name = "Mật Khẩu hiện tại")]
        public string PasswordNow { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Mật Khẩu Mới")]
        [MinLength(5, ErrorMessage = "Bạn cần đặt mật khẩu tối thiểu 5 kí tự")]
        [Display(Name = "Nhập Lại Mật Khẩu")]
        public string PasswordNew { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Lại mật khẩu")]
        [Display(Name = "Nhập Lại Mật Khẩu")]
        [Compare("PasswordNew", ErrorMessage = "Bạn cần nhập giống mật khẩu")]
        public string NhaplaiPassword { get; set; }
    }
}
