using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCC_ASPNC_WebApp.Models;
using FCC_ASPNC_WebApp;

namespace FCC_ASPNC_WebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //DB Set For Categories Entity/Table
        public DbSet<Category> Categories { get; set; }

        //DB set for Application Type Entity/Table
        public DbSet<ApplicationType> ApplicationTypes { get; set; }
    }
}
