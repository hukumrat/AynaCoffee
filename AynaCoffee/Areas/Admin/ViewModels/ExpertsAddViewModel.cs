using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AynaCoffee.Areas.Admin.Models;
using AynaCoffee.ValidationAttributes;
using Microsoft.AspNetCore.Http;

namespace AynaCoffee.Areas.Admin.ViewModels
{
    public class ExpertsAddViewModel
    {
        [Required(ErrorMessage = "Lütfen bir isim giriniz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen bir soy isim giriniz.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen bir pozisyon giriniz.")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Lütfen bir açıklama giriniz.")]
        public string Description { get; set; }
        public string PhotoPath { get; set; }

        [AllowedExtensions(new string[]{".jpg",".png",".jpeg"})]
        [MaxFileSize(10*1024*1024)]
        [Required(ErrorMessage = "Lütfen bir görsel seçiniz.")]
        public List<IFormFile> PhotoToUpload { get; set; }

        public Content Content { get; set; }
        public Photo Photo { get; set; }
    }
}
