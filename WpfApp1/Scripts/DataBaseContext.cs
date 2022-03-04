using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Scripts
{
    class DataBaseContext : DbContext
    {
        public  DbSet<User> Users { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Reports> Reports { get; set; }
        public DbSet<Protocol> Protocol { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=DESKTOP-32L6VN9;Database=GazpromProtocol;Trusted_Connection=True");
        }
    
       
    }
}
