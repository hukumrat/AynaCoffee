using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AynaCoffee.Areas.Admin.ViewModels
{
    public class ContactUsViewModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Lütfen isminizi giriniz.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen soyisminizi giriniz.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Lütfen e-posta adresinizi giriniz.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Lütfen mesajınızı giriniz.")]
        [MaxLength(3000)]
        public string Messages { get; set; }

        public string GoogleMessageCaptchaToken { get; set; }
    }
}
