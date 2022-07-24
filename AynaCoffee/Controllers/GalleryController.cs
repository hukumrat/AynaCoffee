using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AynaCoffee.Areas.Admin.Data;
using AynaCoffee.Areas.Admin.Models;

namespace AynaCoffee.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IAppRepository _appRepository;

        public GalleryController(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var galleries = _appRepository.GetGalleries();
            return View(galleries);
        }
    }
}
