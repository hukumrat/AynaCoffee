using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AynaCoffee.Areas.Admin.Models;

namespace AynaCoffee.Areas.Admin.ViewModels
{
    public class SlidesListViewModel
    {
        public int ContentId { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
        public Content Content { get; set; }
    }
}
