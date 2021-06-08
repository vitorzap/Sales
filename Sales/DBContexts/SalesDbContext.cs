using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sales.Models;

namespace Sales.DBContexts
{

    public class SalesDbContext : DbContext
    {
        public SalesDbContext(DbContextOptions<SalesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
    }
}