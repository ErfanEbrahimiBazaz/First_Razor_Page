using FirstApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApp.Data
{
    public class DataContext: DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }
        public DbSet<Country> Countries{ get; set; }
        public DbSet<City> Cities{ get; set; }
    }
}
