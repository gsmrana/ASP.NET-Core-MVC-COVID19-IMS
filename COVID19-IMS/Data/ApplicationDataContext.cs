using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COVID19IMS.Models;
using Microsoft.EntityFrameworkCore;

namespace COVID19IMS.Data
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options)
            : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<UserRule> UserRules { get; set; }
        public DbSet<CovidTesting> CovidTestings { get; set; }
        public DbSet<CovidVaccine> CovidVaccines { get; set; }        
    }
}
