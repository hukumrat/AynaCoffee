using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AynaCoffee.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AynaCoffee.Areas.Admin.Data
{
    public class DataContext:IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Slide> Slides { get; set; }
    }
}
