using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EY4J5D_HFT_2021221.Data;
using EY4J5D_HFT_2021221.Logic;
using EY4J5D_HFT_2021221.Models;
using EY4J5D_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;

namespace EY4J5D_HFT_2021221.Test
{
    [TestFixture]
    class TestWithMock
    {

        ModelLogic ml;
        BrandLogic bl;
        PurchaseLogic pl;
        public TestWithMock()
        {
            Mock<IRepository<Model>> mr = new();
            Mock<IRepository<Purchase>> pr = new();
            Mock<IRepository<Brand>> br = new();
            var brands = new List<Brand>()
            {
                new Brand(){Brand_Name = "Opel", Id = 1},
                new Brand(){Brand_Name = "Fiatt", Id = 2},
                new Brand(){Brand_Name = "Polaris", Id = 3}
            }.AsQueryable();
            var models = new List<Model>()
            {
                //Opel
                new Model(){Model_Name = "Astra", Id = 1,Brand_Id = brands.ElementAt(0).Id, Brand = brands.ElementAt(0)},
                new Model(){Model_Name = "Corsa", Id = 2,Brand_Id = brands.ElementAt(0).Id, Brand = brands.ElementAt(0)},
                //Fiatt
                new Model(){Model_Name = "Bravo", Id = 3, Brand_Id = brands.ElementAt(1).Id, Brand = brands.ElementAt(1)},
                new Model(){Model_Name = "Multipla", Id = 4,Brand_Id = brands.ElementAt(1).Id, Brand = brands.ElementAt(1)},
                new Model(){Model_Name = "Punto", Id = 5,Brand_Id = brands.ElementAt(1).Id, Brand = brands.ElementAt(1)},
                //Slingshot
                new Model(){Model_Name = "Slingshot", Id = 6, Brand_Id = brands.ElementAt(2).Id, Brand = brands.ElementAt(2)}
            }.AsQueryable();

            var purchases = new List<Purchase>()
            {
                //Astra
                new Purchase() { Price = 1000, Model = models.ElementAt(0), Model_Id = models.ElementAt(0).Id, Purchase_Date = Convert.ToDateTime("05/01/1996"), Id =  1},
                //Corsa
                new Purchase() { Price = 1000, Model = models.ElementAt(1), Model_Id = models.ElementAt(1).Id, Purchase_Date = Convert.ToDateTime("05/01/1996"), Id =  2},
                //Bravo
                new Purchase() { Price = 1000, Model = models.ElementAt(2), Model_Id = models.ElementAt(2).Id, Purchase_Date = Convert.ToDateTime("05/01/1996"), Id =  3},
                //Multipla
                new Purchase() { Price = 1500, Model = models.ElementAt(3), Model_Id = models.ElementAt(3).Id, Purchase_Date = DateTime.Today, Id = 4},
                new Purchase() { Price = 1000, Model = models.ElementAt(3), Model_Id = models.ElementAt(3).Id, Purchase_Date = Convert.ToDateTime("05/01/1996"), Id =  5},
                //Punto
                new Purchase() { Price = 1000, Model = models.ElementAt(4), Model_Id = models.ElementAt(4).Id, Purchase_Date = Convert.ToDateTime("05/01/1996"), Id =  6},
                //Slingshot
                new Purchase() { Price = 1000, Model = models.ElementAt(5), Model_Id = models.ElementAt(5).Id, Purchase_Date = Convert.ToDateTime("05/01/1996"), Id =  7}
            }.AsQueryable();

            br.Setup(t => t.Create(It.IsAny<Brand>())); 
            mr.Setup(t => t.Create(It.IsAny<Model>()));
            pr.Setup(t => t.Create(It.IsAny<Purchase>()));

            br.Setup(t => t.ReadAll()).Returns(brands);
            mr.Setup(t => t.ReadAll()).Returns(models);
            pr.Setup(t => t.ReadAll()).Returns(purchases);

            ml = new ModelLogic(mr.Object);
            bl = new BrandLogic(br.Object);
            pl = new PurchaseLogic(pr.Object);
        }


        //Create Tests
        [TestCase(null, false)]
        [TestCase("123456789012345678901234567890123456789012345678901234567890", false)]
        [TestCase("", false)]
        [TestCase("Yes", true)]
        public void TestCreateModel(string modelName, bool result)
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



        [TestCase(null, false)]
        [TestCase("123456789012345678901234567890123456789012345678901234567890", false)]
        [TestCase("", false)]
        [TestCase("Yes", true)]
        public void TestCreateBrand(string BrandName, bool result)
        {
            if (result)
            {
                Assert.That(() => bl.Create(new Brand() { Brand_Name = BrandName }), Throws.Nothing);
            }
            else
            {
                Assert.That(() => bl.Create(new Brand() { Brand_Name = BrandName }), Throws.Exception);
            }
        }



        [TestCase(-1, false)]
        [TestCase(69, true)]
        public void TestCreatePurchase(int priceIn, bool result)
        {
            if (result)
            {
                Assert.That(() => pl.Create(new Purchase() { Price = priceIn }), Throws.Nothing);
            }
            else
            {
                Assert.That(() => pl.Create(new Purchase() { Price = priceIn }), Throws.Exception);
            }
        }



        [Test]
        public void TestBrandsByModels()
        {
            //ACT
            var result = ml.BrandsByModels();
            var expected = (new KeyValuePair<string, int>("Polaris", 1));
            //ASSERT
            Assert.That(result.First, Is.EqualTo(expected));
        }



        [Test]
        public void TestBasicBrand()
        {
            //ACT
            var result = ml.BasicBrands();
            var expected = (new KeyValuePair<string, int>("Polaris", 1));
            //ASSERT
            Assert.That(result.ElementAt(0), Is.EqualTo(expected));
        }



        [Test]
        public void TestExpensiveCar()
        {
            //ACT
            var result = pl.ExpensiveCar();
            var expected = (new KeyValuePair<string, int>("Multipla", 1500));
            //ASSERT
            Assert.That(result.First(), Is.EqualTo(expected));
        }



        [Test]
        public void TestPopularCar()
        {
            //ACT
            var result = pl.PopularCar();
            var expected = (new KeyValuePair<string, int>("Multipla", 2));
            //ASSERT
            Assert.That(result.First(), Is.EqualTo(expected));
        }



        [Test]
        public void TestRichBrand()
        {
            //ACT
            var result = pl.RichBrand();
            var expected = (new KeyValuePair<string, int>("Fiatt", 4500));
            //ASSERT
            Assert.That(result.First(), Is.EqualTo(expected));
        }



        [Test]
        public void TestThisYear()
        {
            //ACT
            var result = pl.PurchasedThisYear();
            var expected = pl.ReadAll().ElementAt(3);
            //ASSERT
            Assert.That(result.First().Id, Is.EqualTo(expected.Id));
        }



        [Test]
        public void TestShortBrand()
        {
            //ACT
            var result = bl.ShortBrand();
            var expected = "Opel";
            //ASSERT
            Assert.That(result.First().Brand_Name, Is.EqualTo(expected));
        }
        //TODO: Test Create Exception handling (e.g. null throws exception)
        //NOTE: 10 Unit tests are required
    }
}
