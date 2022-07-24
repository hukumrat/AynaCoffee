using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AynaCoffee.Areas.Admin.Data;
using AynaCoffee.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace AynaCoffee.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class InboxController : Controller
    {
        private readonly IAppRepository _appRepository;

        public InboxController(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var messages = _appRepository.GetMessages();
            return View(messages);
        }

        [HttpPost]
        public IActionResult Index(ContactUsViewModel model)
        {
            var messages = _appRepository.GetMessages();
            return View(messages);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var message = _appRepository.GetMessageById(id);
            if (message == null)
            {
                return View("404");
            }
            return View(message);
        }

        [HttpPost]
        public IActionResult DeleteMessage(int id)
        {
            var messageToDelete = _appRepository.GetMessageById(id);
            if (messageToDelete == null)
            {
                return View("404");
            }
            _appRepository.Delete(messageToDelete);
            _appRepository.IziToast("İşlem başarıyla gerçekleştirildi.","Başarılı");
            return RedirectToAction("Index", "Inbox");
        }
    }
}
