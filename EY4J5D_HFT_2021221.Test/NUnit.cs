using System;
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
                return ReadAll().First(x =>x.Id == id);
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
        class FakeBrandRepository : IRepository<Brand>
        {
            public void Create(Brand input)
            {

            }

            public void Delete(int id)
            {

            }

            public Brand Read(int id)
            {
                return ReadAll().First(x => x.Id == id);
            }

            public IQueryable<Brand> ReadAll()
            {
                return null;
            }

            public void Update(Brand updated)
            {
                
            }
        }
        class FakePurchaseRepository
        {

        }
        ModelLogic ml;
        public NUnit()
        {
            ml = new ModelLogic(new FakeModelRepository());
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
            var result = ml.BrandsByModels();
            var expected = (new KeyValuePair<string, int>("Fiat", 3));
            Assert.That(result.First, Is.EqualTo(expected));
        }
        public void TestBasicBrand()
        {
            var result = ml.BasicBrand();
            var expected = (new KeyValuePair<string, int>("Slingshot", 1));
            Assert.That(result.First, Is.EqualTo(expected));
        }
        //TODO: Test Create Exception handling (e.g. "" throws exception)
        //NOTE: 10 Unit tests are required
    }
}
