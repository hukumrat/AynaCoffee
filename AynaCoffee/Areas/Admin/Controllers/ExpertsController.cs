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
using Microsoft.EntityFrameworkCore;

namespace AynaCoffee.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ExpertsController : Controller
    {
        private readonly IAppRepository _appRepository;
        private readonly IWebHostEnvironment _environment;

        public ExpertsController(IAppRepository appRepository, IWebHostEnvironment environment)
        {
            _appRepository = appRepository;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var experts = _appRepository.GetExperts();
            List<ExpertsListViewModel> models = new List<ExpertsListViewModel>();
            foreach (var expert in experts)
            {
                ExpertsListViewModel model = new ExpertsListViewModel
                {
                    ContentId = expert.ContentId,
                    Name = expert.Name,
                    Position = expert.Position,
                    Surname = expert.Surname,
                    Content = expert.Content
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
        public IActionResult Add(ExpertsAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                string imagePath = String.Empty;
                foreach (var photoToUpload in model.PhotoToUpload)
                {
                    var imagesFolderString = $@"Images\Experts";
                    var imagesFolder = Path.Combine(_environment.WebRootPath, imagesFolderString);
                    if (!Directory.Exists(imagesFolder))
                        Directory.CreateDirectory(imagesFolder);
                    var fileExtension = Path.GetExtension(photoToUpload.FileName);
                    var uniqueFileName = Guid.NewGuid() + fileExtension;
                    var filePath = Path.Combine(imagesFolder, uniqueFileName);
                    photoToUpload.CopyTo(new FileStream(filePath, FileMode.Create));
                    imagePath = $"/Images/Experts/{uniqueFileName}";
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

                Expert expert = new Expert
                {
                    Name = model.Name.Trim(),
                    Surname = model.Surname.Trim(),
                    Position = model.Position.Trim(),
                    ContentId = content.Id
                };
                _appRepository.Add(expert);

                _appRepository.IziToast("İşlem başarıyla gerçekleştirildi.", "Başarılı");
                return RedirectToAction("Index", "Experts");
            }
            else
            {
                _appRepository.IziToast("Lütfen gerekli alanları doldurunuz.", "Uyarı", "warning");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var expert = _appRepository.GetExpertById(id);
            if (expert == null)
            {
                return View("404");
            }
            ExpertsUpdateViewModel model = new ExpertsUpdateViewModel
            {
                ContentId = expert.ContentId,
                Name = expert.Name,
                Surname = expert.Surname,
                Position = expert.Position,
                Description = expert.Content.Description,
                Content = expert.Content,
                Photo = expert.Content.Photo,
                PhotoPath = expert.Content.Photo.Path
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(ExpertsUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var expertToUpdate = _appRepository.GetExpertById(model.ContentId);
                if (expertToUpdate == null)
                {
                    return View("404");
                }
                expertToUpdate.Name = model.Name;
                expertToUpdate.Surname = model.Surname;
                expertToUpdate.Position = model.Position;
                expertToUpdate.Content.Description = model.Description;
                if (model.PhotoToUpload == null)
                {
                    _appRepository.SaveAll();
                    _appRepository.IziToast("İşlem başarıyla gerçekleştirildi.", "Başarılı");
                    return RedirectToAction("Index", "Experts");
                }
                if (model.PhotoToUpload.Count >= 0 && model.PhotoToUpload != null)
                {
                    var webRootPath = _environment.WebRootPath;
                    var photoPath = webRootPath + expertToUpdate.Content.Photo.Path;
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
                        var imagesFolderString = $@"Images\Experts";
                        var imagesFolder = Path.Combine(_environment.WebRootPath, imagesFolderString);
                        if (!Directory.Exists(imagesFolder))
                            Directory.CreateDirectory(imagesFolder);
                        var fileExtension = Path.GetExtension(photoToUpload.FileName);
                        var uniqueFileName = Guid.NewGuid() + fileExtension;
                        var filePath = Path.Combine(imagesFolder, uniqueFileName);
                        photoToUpload.CopyTo(new FileStream(filePath, FileMode.Create));
                        imagePath = $"/Images/Experts/{uniqueFileName}";
                    }
                    expertToUpdate.Content.Photo.Path = imagePath;
                }
                _appRepository.SaveAll();
                _appRepository.IziToast("İşlem başarıyla gerçekleştirildi.", "Başarılı");
                return RedirectToAction("Index", "Experts");
            }
            else
            {
                _appRepository.IziToast("Lütfen gerekli alanları doldurunuz.", "Uyarı", "warning");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteExpert(int id)
        {
            var expertToDelete = _appRepository.GetExpertById(id);
            var contentToDelete = _appRepository.GetContentById(id);
            var photoToDelete = _appRepository.GetPhotoByContentId(id);
            if (expertToDelete == null || contentToDelete == null || photoToDelete == null)
            {
                return View("404");
            }
            var webRootPath = _environment.WebRootPath;
            var photoPath = webRootPath + expertToDelete.Content.Photo.Path;
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
            _appRepository.Delete(expertToDelete);
            _appRepository.Delete(contentToDelete);
            //_appRepository.Delete(photoToDelete); contenti silince photo da siliniyor muhtemelen veritabanı tasarımında fk ile ilgili bir şeydir.
            _appRepository.IziToast("İşlem başarıyla gerçekleşti.", "Başarılı");
            return RedirectToAction("Index", "Experts");
        }
    }
}

