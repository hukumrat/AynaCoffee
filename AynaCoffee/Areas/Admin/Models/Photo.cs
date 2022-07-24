using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AynaCoffee.Areas.Admin.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public int ContentId { get; set; }
        public string Path { get; set; }

        [ForeignKey("ContentId")]
        public Content Content { get; set; }
    }
}
