using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AynaCoffee.Areas.Admin.Data;
using AynaCoffee.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace AynaCoffee.ViewComponents
{
    public class ContactUsViewComponent:ViewComponent
    {
        private readonly IAppRepository _appRepository;

        public ContactUsViewComponent(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }

        [HttpGet]
        public ViewViewComponentResult Invoke()
        {
            return View();
        }
    }
}
