﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AynaCoffee.Areas.Admin.Models;
using AynaCoffee.ValidationAttributes;
using Microsoft.AspNetCore.Http;

namespace AynaCoffee.Areas.Admin.ViewModels
{
    public class SlideUpdateViewModel
    {
        public int ContentId { get; set; }
        public string Description { get; set; }
        
        public string PhotoPath { get; set; }

        [AllowedExtensions(new string[] { ".jpg", ".png", ".jpeg" })]
        [MaxFileSize(10 * 1024 * 1024)]
        public List<IFormFile> PhotoToUpload { get; set; }
        public Content Content { get; set; }
    }
}
