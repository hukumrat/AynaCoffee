using AynaCoffee.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AynaCoffee.Areas.Admin.Data;
using AynaCoffee.Areas.Admin.Models;
using AynaCoffee.Areas.Admin.ViewModels;

namespace AynaCoffee.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAppRepository _appRepository;

        public HomeController(ILogger<HomeController> logger, IAppRepository appRepository)
        {
            _logger = logger;
            _appRepository = appRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactUsViewModel model)
        {
            if (ModelState.IsValid)
            {
                Message message = new Message
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Description = model.Messages,
                    Email = model.Email
                };
                _appRepository.Add(message);
                _appRepository.IziToast("Mesajınız başarıyla gönderildi.","Başarılı");
            }
            else
            {
                _appRepository.IziToast("Lütfen gerekli alanları doldurunuz.", "Uyarı","warning");
            }

            return Redirect("/#ContactUs");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
