using Microsoft.EntityFrameworkCore;
using EY4J5D_HFT_2021221.Models;
using System;
using System.Collections.Generic;

namespace EY4J5D_HFT_2021221.Data
{
    public class CarDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CarDb.mdf;Integrated Security=True
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public CarDbContext()
        {
            Database.EnsureCreated();
        }
        public CarDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CarDb.mdf;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model>(entity => entity.HasOne(model => model.Brand).WithMany(brand => brand.Models).HasForeignKey(model => model.Brand_Id).OnDelete(DeleteBehavior.ClientSetNull));
            modelBuilder.Entity<Model>(entity => entity.HasMany(model => model.Purchases).WithOne(purchase => purchase.Model).HasForeignKey(purchase => purchase.Model_Id).OnDelete(DeleteBehavior.Cascade));

            // -------------------------------------------------------------------------------------------------------

            Brand b0 = new Brand()
            {
                Id = 1,
                Brand_Name = "Fiat"
            };
            Brand b1 = new Brand()
            {
                Id = 2,
                Brand_Name = "Honda"
            };
            Brand b2 = new Brand()
            {
                Id = 3,
                Brand_Name = "Polaris"
            };
            Brand b3 = new Brand()
            {
                Id = 4,
                Brand_Name = "Opel"
            };

            // -------------------------------------------------------------------------------------------------------

            Purchase p0 = new Purchase()
            {
                Id = 1,
                Model_Id = 1,
                Price = 69,
                Purchase_Date = Convert.ToDateTime("06/09/1969")
            };
            Purchase p1 = new Purchase()
            {
                Id = 2,
                Model_Id = 2,
                Price = 69420,
                Purchase_Date = Convert.ToDateTime("06/02/1981")
            };
            Purchase p2 = new Purchase()
            {
                Id = 3,
                Model_Id = 3,
                Price = 133,
                Purchase_Date = Convert.ToDateTime("09/11/2001")
            };
            Purchase p3 = new Purchase()
            {
                Id = 4,
                Model_Id = 3,
                Price = 123,
                Purchase_Date = Convert.ToDateTime("09/11/2021")
            };

            // -------------------------------------------------------------------------------------------------------

            Model m0 = new Model()
            {
                Model_Name = "Multipla",
                Brand_Id = 1,
                Id = 1
            };
            Model m1 = new Model()
            {
                Model_Name = "Civic",
                Brand_Id = 2,
                Id = 2
            };
            Model m2 = new Model()
            {
                Model_Name = "Slingshot",
                Brand_Id = 3,
                Id = 3
            };
            Model m3 = new Model()
            {
                Model_Name = "Astra",
                Brand_Id = 4,
                Id = 4
            };
            Model m4 = new Model()
            {
                Model_Name = "Corsa",
                Brand_Id = 4,
                Id = 5
            };

            //-------------------------------------------------------------------------------------------------------

            modelBuilder.Entity<Model>().HasData(m0, m1, m2, m3, m4);
            modelBuilder.Entity<Brand>().HasData(b0, b1, b2, b3);
            modelBuilder.Entity<Purchase>().HasData(p0, p1, p2, p3);
        }
    }
}
