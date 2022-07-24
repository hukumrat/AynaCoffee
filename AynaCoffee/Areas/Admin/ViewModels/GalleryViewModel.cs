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
    public class GalleryViewModel
    {
        public List<Gallery> Galleries { get; set; }

        [AllowedExtensions(new string[] { ".jpg", ".png", ".jpeg" })]
        [MaxFileSize(10 * 1024 * 1024)]
        [Required(ErrorMessage = "Lütfen bir görsel seçiniz.")]
        public List<IFormFile> PhotosToUpload { get; set; }
    }
}
