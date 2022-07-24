using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AynaCoffee.Areas.Admin.Models
{
    public class Content
    {
     //   [Key]
        public int Id { get; set; }
        public string Description { get; set; }

      //  [ForeignKey("Id")]
        public Photo Photo { get; set; }
    }
}
