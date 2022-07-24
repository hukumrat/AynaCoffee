using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AynaCoffee.Areas.Admin.Data;
using AynaCoffee.Areas.Admin.Models;
using AynaCoffee.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;

namespace AynaCoffee.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class GalleryController : Controller
    {
        private readonly IAppRepository _appRepository;
        private readonly IWebHostEnvironment _environment;

        public GalleryController(IAppRepository appRepository, IWebHostEnvironment environment)
        {
            _appRepository = appRepository;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var galleries = _appRepository.GetGalleries();
            GalleryViewModel model = new GalleryViewModel
            {
                Galleries = galleries
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(GalleryViewModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var photoToUpload in model.PhotosToUpload)
                {
                    var imagesFolderString = $@"Images\Gallery";
                    var imagesFolder = Path.Combine(_environment.WebRootPath, imagesFolderString);
                    if (!Directory.Exists(imagesFolder))
                        Directory.CreateDirectory(imagesFolder);
                    var fileExtension = Path.GetExtension(photoToUpload.FileName);
                    var uniqueFileName = Guid.NewGuid() + fileExtension;
                    var filePath = Path.Combine(imagesFolder, uniqueFileName);
                    photoToUpload.CopyTo(new FileStream(filePath, FileMode.Create));
                    var imagePath = $"/Images/Gallery/{uniqueFileName}";
                    Gallery gallery = new Gallery
                    {
                        Path = imagePath
                    };
                    _appRepository.Add(gallery);
                }
                
                _appRepository.IziToast("İşlem başarıyla gerçekleştirildi.", "Başarılı");
            }
            else
            {
                _appRepository.IziToast("Lütfen gerekli alanları doldurunuz.","Uyarı","warning");
                return View(model);
            }
            return RedirectToAction("Index", "Gallery");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var galleryToDelete = _appRepository.GetGalleryById(id);
            if (galleryToDelete == null)
            {
                return View("404");
            }
            var webRootPath = _environment.WebRootPath;
            var photoPath = webRootPath + galleryToDelete.Path;
            if (System.IO.File.Exists(photoPath))
            {
                try
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    System.IO.File.Delete(photoPath);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            _appRepository.Delete(galleryToDelete);
            _appRepository.IziToast("İşlem başarıyla gerçekleşti.", "Başarılı");
            return RedirectToAction("Index", "Gallery");
        }
    }
}
