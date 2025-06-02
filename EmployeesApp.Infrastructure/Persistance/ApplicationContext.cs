using EmployeesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Infrastructure.Persistance
{
    public class ApplicationContext(DbContextOptions<ApplicationContext> options)
: DbContext(options)
    {
        // Exponerar våra entiteter via properties av typen DbSet<T>
        public DbSet<Employee> Customers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Anropen nedan är exempel på att använda Fluent API (till skillnad från att
            // använda attribut direkt på entiteterna)
            // Specificerar vilken datatyp databasen ska använda för en specifik kolumn
            modelBuilder.Entity<Employee>();

            // Specificerar data som en specific tabell ska för-populeras med
            modelBuilder.Entity<Employee>().HasData(
                new Employee()
                {
                    Id = 562,
                    Name = "Anders Hejlsberg",
                    Email = "Anders.Hejlsberg@outlook.com",
                },
        new Employee()
        {
            Id = 62,
            Name = "Kathleen Dollard",
            Email = "k.d@outlook.com",
        },
        new Employee()
        {
            Id = 15662,
            Name = "Mads Torgersen",
            Email = "Admin.Torgersen@outlook.com",
        },
        new Employee()
        {
            Id = 52,
            Name = "Scott Hanselman",
            Email = "s.h@outlook.com",
        },
        new Employee()
        {
            Id = 563,
            Name = "Jon Skeet",
            Email = "j.s@outlook.com",
        });
        }
    }


}
