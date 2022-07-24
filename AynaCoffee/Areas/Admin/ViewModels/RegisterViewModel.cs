using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AynaCoffee.Areas.Admin.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen geçerli bir e-posta adresi giriniz.")]
        [EmailAddress]
        [DisplayName("E-Posta Adresi")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen bir kullanıcı adı giriniz.")]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen bir şifre giriniz.")]
        [DataType(DataType.Password)]
        [DisplayName("Şifre")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Şifre Tekrar")]
        [Compare("Password",
            ErrorMessage = "Şifreler uyuşmuyor.")]
        [Required(ErrorMessage="Lütfen şifreyi tekrar giriniz.")]
        public string ConfirmPassword { get; set; }
    }
}
