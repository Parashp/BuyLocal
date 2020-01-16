using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class BuyLocalContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:buylocal.database.windows.net,1433;Initial Catalog=buylocal_dev;Persist Security Info=False;User ID=dbadmin;Password=buylocal@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role() { RoleID = 1, RoleCode = "UR01", RoleName = "Farmer", Description = "", IsVisible = true },
                new Role() { RoleID = 2, RoleCode = "UR02", RoleName = "Retailer", Description = "", IsVisible = true },
                new Role() { RoleID = 3, RoleCode = "UR03", RoleName = "Consumer", Description = "", IsVisible = true }
            );
        }
    }
}
