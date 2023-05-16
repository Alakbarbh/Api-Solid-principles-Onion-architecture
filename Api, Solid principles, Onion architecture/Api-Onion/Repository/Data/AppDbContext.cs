using Domain.Configurations;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Country> Countries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            //modelBuilder.ApplyConfiguration(new CountryConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                Id = 1,
                FullName = "Roya Meherremova",
                Address = "Sumqayit",
                Age = 27
            },

            new Employee
            {
                Id = 2,
                FullName = "Anar Aliyev",
                Address = "Xetai",
                Age = 28
            },

            new Employee
            {
                Id = 3,
                FullName = "Mubariz Agayev",
                Address = "Nesimi",
                Age = 18
            });


            modelBuilder.Entity<Country>().HasData(
            new Country
            {
                Id = 1,
                Name = "Azerbaycan"
            },

            new Country
            {
                Id = 2,
                Name = "Turkiye"
            },

            new Country
            {
                Id = 3,
                Name = "Ingiltere"
            }
        );
        }
    }
}
