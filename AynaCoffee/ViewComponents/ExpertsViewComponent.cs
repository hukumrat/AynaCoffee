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
    public class ExpertsViewComponent:ViewComponent
    {
        private readonly IAppRepository _appRepository;

        public ExpertsViewComponent(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }

        public ViewViewComponentResult Invoke()
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
    }
}
