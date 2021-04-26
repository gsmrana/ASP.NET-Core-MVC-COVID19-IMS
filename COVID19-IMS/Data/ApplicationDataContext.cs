using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace COVID19IMS.Data
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext (DbContextOptions<ApplicationDataContext> options)
            : base(options)
        {
        }

        public DbSet<CovidTesting> CovidTestings { get; set; }
    }
}
