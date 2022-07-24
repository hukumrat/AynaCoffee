using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AynaCoffee.Areas.Admin.Data;
using AynaCoffee.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace AynaCoffee.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
