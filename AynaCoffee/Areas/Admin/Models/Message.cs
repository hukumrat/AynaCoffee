using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AynaCoffee.Areas.Admin.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

    }
}
