﻿using System;
using System.Collections.Generic;
using System.Linq;
using EY4J5D_HFT_2021221.Data;
using EY4J5D_HFT_2021221.Logic;
using EY4J5D_HFT_2021221.Models;
using EY4J5D_HFT_2021221.Repository;
using NUnit;
using NUnit.Framework;

namespace EY4J5D_HFT_2021221.Test
{
    [TestFixture]
    class NUnit
    {

        class FakeModelRepository : IRepository<Model>
        {
            public void Create(Model input)
            {

            }

            public void Delete(int id)
            {

            }

            public Model Read(int id)
            {
                return ReadAll().First(x => x.Id == id);
            }

            public IQueryable<Model> ReadAll()
            {
                Brand fakeBrand1 = new Brand()
                {
                    BrandName = "Fiat",
                    Id = 69

                };
                Brand fakeBrand2 = new Brand()
                {
                    BrandName = "Slingshot",
                    Id = 420

                };
                return new List<Model>()
                {
                    new Model()
                    {
                        Model_Name = "Multipla",
                        Id = 1,
                        Brand_Id = fakeBrand1.Id,
                        Brand = fakeBrand1
                    },
                    new Model()
                    {
                        Model_Name = "Punto",
                        Id = 1,
                        Brand_Id = fakeBrand1.Id,
                        Brand = fakeBrand1
                    },
                    new Model()
                    {
                        Model_Name = "Bravo",
                        Id = 1,
                        Brand_Id = fakeBrand1.Id,
                        Brand = fakeBrand1
                    },
                    new Model()
                    {
                        Model_Name = "Polaris",
                        Id = 4,
                        Brand_Id = fakeBrand2.Id,
                        Brand = fakeBrand2
                    }
                }.AsQueryable();
            }

            public void Update(Model updated)
            {
                throw new NotImplementedException();
            }
        }
        class FakePurchaseRepository : IRepository<Purchase>
        {
            public void Create(Purchase input)
            {
                throw new NotImplementedException();
            }

            public void Delete(int id)
            {
                throw new NotImplementedException();
            }

            public Purchase Read(int id)
            {
                throw new NotImplementedException();
            }

            public IQueryable<Purchase> ReadAll()
            {
                Brand fakeBrand1 = new Brand() { BrandName = "Opel"};
                Brand fakeBrand2 = new Brand() { BrandName = "Fiat"};
                Model fM1 = new Model() { Brand = fakeBrand1, Brand_Id = fakeBrand1.Id, Model_Name = "Astra" };
                Model fM2 = new Model() { Brand = fakeBrand1, Brand_Id = fakeBrand1.Id, Model_Name = "Corsa" };
                Model fM3 = new Model() { Brand = fakeBrand2, Brand_Id = fakeBrand2.Id, Model_Name = "Multipla" };
                Model fM4 = new Model() { Brand = fakeBrand2, Brand_Id = fakeBrand2.Id, Model_Name = "Punto" };
                return new List<Purchase>()
                {
                    new Purchase() { Price = 420, Model = fM1, Car_Id = fM1.Id, Purchase_Date = Convert.ToDateTime("05/01/1996") },
                    new Purchase() { Price = 69, Model = fM1, Car_Id = fM1.Id, Purchase_Date = Convert.ToDateTime("05/01/1996") },
                    new Purchase() { Price = 690, Model = fM2, Car_Id = fM2.Id, Purchase_Date = Convert.ToDateTime("05/01/1996") },
                    new Purchase() { Price = 100, Model = fM2, Car_Id = fM2.Id, Purchase_Date = Convert.ToDateTime("05/01/1996") },
                    new Purchase() { Price = 500, Model = fM3, Car_Id = fM3.Id, Purchase_Date = Convert.ToDateTime("05/01/1996") },
                    new Purchase() { Price = 360, Model = fM3, Car_Id = fM3.Id, Purchase_Date = Convert.ToDateTime("05/01/1996") },
                    new Purchase() { Price = 360, Model = fM3, Car_Id = fM3.Id, Purchase_Date = Convert.ToDateTime("05/01/1996") },
                    new Purchase() { Price = 350, Model = fM4, Car_Id = fM4.Id, Purchase_Date = Convert.ToDateTime("05/01/1996") },
                    new Purchase() { Price = 169, Model = fM4, Car_Id = fM4.Id, Purchase_Date = Convert.ToDateTime("05/01/1996") },
                }.AsQueryable();
            }

            public void Update(Purchase updated)
            {
                throw new NotImplementedException();
            }
        }
        ModelLogic ml;
        PurchaseLogic pl;
        public NUnit()
        {
            ml = new ModelLogic(new FakeModelRepository());
            pl = new PurchaseLogic(new FakePurchaseRepository());
        }
        //TODO: Test Non-CRUD methods
        [TestCase(null, false)]
        [TestCase("123456789012345678901234567890123456789012345678901234567890", false)]
        [TestCase("", true)]
        public void TestCreate(string modelName, bool result)
        {
            if (result)
            {
                Assert.That(() => ml.Create(new Model() { Model_Name = modelName, Brand_Id = 69 }), Throws.Nothing);
            }
            else
            {
                Assert.That(() => ml.Create(new Model() { Model_Name = modelName, Brand_Id = 69 }), Throws.Exception);
            }
        }



        [Test]
        public void TestBrandsByModels()
        {
            //ACT
            var result = ml.BrandsByModels();
            var expected = (new KeyValuePair<string, int>("Fiat", 3));
            //ASSERT
            Assert.That(result.First, Is.EqualTo(expected));
        }
        [Test]
        public void TestBasicBrand()
        {
            //ACT
            var result = ml.BasicBrand();
            var expected = (new KeyValuePair<string, int>("Slingshot", 1));
            //ASSERT
            Assert.That(result.First, Is.EqualTo(expected));
        }
        [Test]
        public void TestExpensiveCar()
        {
            //ACT
            var result = pl.ExpensiveCar();
            var expected = (new KeyValuePair<string, int>("Corsa", 690));
            //ASSERT
            Assert.That(result.First(), Is.EqualTo(expected));
        }
        [Test]
        public void TestPopularCar()
        {
            //ACT
            var result = pl.PopularCar();
            var expected = (new KeyValuePair<string, int>("Multipla", 3));
            //ASSERT
            Assert.That(result.First(), Is.EqualTo(expected));
        }
        [Test]
        public void TestRichBrand()
        {
            //ACT
            var result = pl.RichBrand();
            var expected = (new KeyValuePair<string, int>("Fiat", 1739));
            //ASSERT
            Assert.That(result.First(), Is.EqualTo(expected));
        }
        //TODO: Test Create Exception handling (e.g. null throws exception)
        //NOTE: 10 Unit tests are required
    }
}
