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
    public class SlidesController : Controller
    {
        private readonly IAppRepository _appRepository;
        private readonly IWebHostEnvironment _environment;

        public SlidesController(IAppRepository appRepository, IWebHostEnvironment environment)
        {
            _appRepository = appRepository;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var slides = _appRepository.GetSlides();
            List<SlidesListViewModel> models = new List<SlidesListViewModel>();
            foreach (var slide in slides)
            {
                SlidesListViewModel model = new SlidesListViewModel
                {
                    ContentId = slide.ContentId,
                    Content = slide.Content,
                    Description = slide.Content.Description,
                    PhotoPath = slide.Content.Photo.Path
                };
                models.Add(model);
            }
            return View(models);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(SlideAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                string imagePath = String.Empty;
                foreach (var photoToUpload in model.PhotoToUpload)
                {
                    var imagesFolderString = $@"Images\Slides";
                    var imagesFolder = Path.Combine(_environment.WebRootPath, imagesFolderString);
                    if (!Directory.Exists(imagesFolder))
                        Directory.CreateDirectory(imagesFolder);
                    var fileExtension = Path.GetExtension(photoToUpload.FileName);
                    var uniqueFileName = Guid.NewGuid() + fileExtension;
                    var filePath = Path.Combine(imagesFolder, uniqueFileName);
                    photoToUpload.CopyTo(new FileStream(filePath, FileMode.Create));
                    imagePath = $"/Images/Slides/{uniqueFileName}";
                }

                Content content = new Content
                {
                    Description = model.Description
                };
                _appRepository.Add(content);

                Photo photo = new Photo
                {
                    Path = imagePath,
                    ContentId = content.Id
                };
                _appRepository.Add(photo);

                Slide slide = new Slide
                {
                    ContentId = content.Id,
                };
                _appRepository.Add(slide);

                _appRepository.IziToast("İşlem başarıyla gerçekleştirildi.", "Başarılı");
                return RedirectToAction("Index", "Slides");
            }
            else
            {
                _appRepository.IziToast("Lütfen gerekli alanları doldurunuz.","Uyarı","warning");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var slideToUpdate = _appRepository.GetSlideByContentId(id);
            if (slideToUpdate == null)
            {
                return View("404");
            }
            SlideUpdateViewModel model = new SlideUpdateViewModel
            {
                Content = slideToUpdate.Content,
                ContentId = slideToUpdate.ContentId,
                Description = slideToUpdate.Content.Description,
                PhotoPath = slideToUpdate.Content.Photo.Path
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(SlideUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var slideToUpdate = _appRepository.GetSlideByContentId(model.ContentId);
                if (slideToUpdate == null)
                {
                    return View("404");
                }

                slideToUpdate.Content.Description = model.Description;
                if (model.PhotoToUpload == null)
                {
                    _appRepository.SaveAll();
                    _appRepository.IziToast("İşlem başarıyla gerçekleştirildi.", "Başarılı");
                    return RedirectToAction("Index", "Slides");
                }
                if (model.PhotoToUpload.Count >= 0 && model.PhotoToUpload != null)
                {
                    var webRootPath = _environment.WebRootPath;
                    var photoPath = webRootPath + slideToUpdate.Content.Photo.Path;
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
                    string imagePath = String.Empty;
                    foreach (var photoToUpload in model.PhotoToUpload)
                    {
                        var imagesFolderString = $@"Images\Slides";
                        var imagesFolder = Path.Combine(_environment.WebRootPath, imagesFolderString);
                        if (!Directory.Exists(imagesFolder))
                            Directory.CreateDirectory(imagesFolder);
                        var fileExtension = Path.GetExtension(photoToUpload.FileName);
                        var uniqueFileName = Guid.NewGuid() + fileExtension;
                        var filePath = Path.Combine(imagesFolder, uniqueFileName);
                        photoToUpload.CopyTo(new FileStream(filePath, FileMode.Create));
                        imagePath = $"/Images/Slides/{uniqueFileName}";
                    }
                    slideToUpdate.Content.Photo.Path = imagePath;
                    _appRepository.SaveAll();
                    _appRepository.IziToast("İşlem başarıyla gerçekleştirildi.", "Başarılı");
                    return RedirectToAction("Index", "Slides");
                }

            }
            else
            {
                _appRepository.IziToast("Lütfen gerekli alanları doldurunuz.", "Uyarı", "warning");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteSlide(int id)
        {
            var slideToDelete = _appRepository.GetSlideByContentId(id);
            var contentToDelete = _appRepository.GetContentById(id);
            var photoToDelete = _appRepository.GetPhotoByContentId(id);
            if (slideToDelete == null || contentToDelete == null || photoToDelete == null)
            {
                return View("404");
            }
            var webRootPath = _environment.WebRootPath;
            var photoPath = webRootPath + slideToDelete.Content.Photo.Path;
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
            _appRepository.Delete(slideToDelete);
            _appRepository.Delete(contentToDelete);
            _appRepository.IziToast("İşlem başarıyla gerçekleşti.", "Başarılı");
            return RedirectToAction("Index", "Slides");
        }
    }
}
