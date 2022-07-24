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
    public class HomeViewComponent:ViewComponent
    {
        private readonly IAppRepository _appRepository;

        public HomeViewComponent(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }

        public ViewViewComponentResult Invoke()
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
    }
}
