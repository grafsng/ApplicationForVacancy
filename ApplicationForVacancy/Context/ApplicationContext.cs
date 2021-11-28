using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ApplicationForVacancy.Models;

namespace ApplicationForVacancy.Context
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Product> Product { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product>().HasData(
        //        new Product { Id = new Guid("38883938-36d7-47f8-a486-b75d4ae15744"), Name = "testname1", Description = "testdescription 1"}
        //        //new Product { Name = "testname2", Id = Guid.NewGuid(), Description = "testdescription 2" }
        //        );
        //}
    }
    
}
