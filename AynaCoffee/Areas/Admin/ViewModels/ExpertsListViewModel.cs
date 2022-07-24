using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AynaCoffee.Areas.Admin.Models;

namespace AynaCoffee.Areas.Admin.ViewModels
{
    public class ExpertsListViewModel
    {
  
        public int ContentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }

        public Content Content { get; set; }
        public Photo Photo { get; set; }
    }
}
