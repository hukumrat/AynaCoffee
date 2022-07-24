using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AynaCoffee.Areas.Admin.ViewModels
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "Lütfen bir kullanıcı adı giriniz.")]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen bir şifre giriniz.")]
        [DataType(DataType.Password)]
        [DisplayName("Şifre")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
