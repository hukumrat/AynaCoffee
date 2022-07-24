using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AynaCoffee.Areas.Admin.Models
{
    public class Expert
    {
        [Key]
        public int ContentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }

        [ForeignKey("ContentId")]
        public Content Content { get; set; }
    }
}
