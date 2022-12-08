using Autovokzal_v1._0.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autovokzal_v1._0
{
    internal class ApplicationContext : DbContext
    {
        public string path = Path.GetFullPath(@"..\..\..\");
        public DbSet<Personal> Personals { get; set; } = null!;
        public DbSet<Driver> Drivers { get; set; } = null!;
        public DbSet<Technique> Techniques { get; set; } = null!;
        public DbSet<Route> Routes { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source="+path+"\\data.db");
        }
    }
}
