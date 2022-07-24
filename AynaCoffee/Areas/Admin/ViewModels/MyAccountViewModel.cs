using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AynaCoffee.Areas.Admin.ViewModels
{
    public class MyAccountViewModel
    {
        [Required(ErrorMessage = "Lütfen bir kullanıcı adı giriniz.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen bir e-posta giriniz.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen geçerli şifrenizi giriniz.")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Şifreler uyuşmuyor.")]
        public string ConfirmPassword { get; set; }
    }
}
