using Microsoft.EntityFrameworkCore;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Service.Models.Service> Services  { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<Category> Categories { get; set; }

    }
}
