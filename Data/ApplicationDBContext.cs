using DemoAngulardotnet.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAngulardotnet.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(): base()
        {

        }
        public ApplicationDBContext(DbContextOptions options) : base(options)
        { 
            
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
