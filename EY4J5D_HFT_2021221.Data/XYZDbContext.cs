﻿using Microsoft.EntityFrameworkCore;
using EY4J5D_HFT_2021221.Models;
using System;

namespace EY4J5D_HFT_2021221.Data
{
    public class XYZDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CarDb.mdf;Integrated Security=True
        public virtual DbSet<Car_Model> Cars { get; set; }
        public virtual DbSet<Car_Brand> Brands { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public XYZDbContext()
        {
            Database.EnsureCreated();
        }
        public void OnModelCreating(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CarDb.mdf;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car_Model>(entity => entity.HasOne(model => model.Brand).WithMany(brand => brand.Models).HasForeignKey(model => model.Brand_Id).OnDelete(DeleteBehavior.ClientSetNull));
            modelBuilder.Entity<Car_Model>(entity => entity.HasMany(model => model.Purchases).WithOne(purchase => purchase.Model).HasForeignKey(purchase => purchase.Model).OnDelete(DeleteBehavior.Cascade));

            // -------------------------------------------------------------------------------------------------------

            Car_Model c0 = new Car_Model() { Brand_Id = 1, Id = 1, Model_Name = "Multipla" };
            Car_Model c1 = new Car_Model() { Brand_Id = 2, Id = 2, Model_Name = "Civic" };
            Car_Model c2 = new Car_Model() { Brand_Id = 3, Id = 3, Model_Name = "Slingshot" };

            // -------------------------------------------------------------------------------------------------------

            Car_Brand b0 = new Car_Brand() { Id = 1, BrandName = "Fiat" };
            Car_Brand b1 = new Car_Brand() { Id = 2, BrandName = "Honda" };
            Car_Brand b2 = new Car_Brand() { Id = 3, BrandName = "Polaris" };

            // -------------------------------------------------------------------------------------------------------

            Purchase p0 = new Purchase() { Id = 1, Car_Id = 1, Price = 69 };
            Purchase p1 = new Purchase() { Id = 2, Car_Id = 2, Price = 69420 };
            Purchase p2 = new Purchase() { Id = 3, Car_Id = 3, Price = 1337 };

            // -------------------------------------------------------------------------------------------------------

            b0.Id = c0.Brand_Id;
            b1.Id = c1.Brand_Id;
            b2.Id = c2.Brand_Id;
            c0.Id = p0.Car_Id;
            c1.Id = p1.Car_Id;
            c2.Id = p2.Car_Id;

            //-------------------------------------------------------------------------------------------------------

            modelBuilder.Entity<Car_Brand>().HasData(b0, b1, b2);
            modelBuilder.Entity<Car_Model>().HasData(c0, c1, c2);
            modelBuilder.Entity<Purchase>().HasData(p0, p1, p2);
        }
    }
}
