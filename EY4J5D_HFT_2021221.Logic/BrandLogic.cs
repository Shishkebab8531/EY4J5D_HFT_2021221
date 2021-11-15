using System;
using EY4J5D_HFT_2021221.Models;
using EY4J5D_HFT_2021221.Repository;
using System.Collections.Generic;
using System.Linq;

namespace EY4J5D_HFT_2021221.Logic
{
    public class BrandLogic : IBrandLogic
    {
        IRepository<Brand> brandRepo;
        //ctor
        public BrandLogic(IRepository<Brand> brandRepo)
        {
            this.brandRepo = brandRepo;
        }
        //CRUD
        public void Create(Brand newBrand)
        {
            if (newBrand.BrandName != null && newBrand.BrandName.Length <= 50 && newBrand.BrandName != "")
            {
                brandRepo.Create(newBrand);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void Delete(int id)
        {
            brandRepo.Delete(id);
        }

        public Brand Read(int id)
        {
            return brandRepo.Read(id);
        }

        public IEnumerable<Brand> ReadAll()
        {
            return brandRepo.ReadAll();
        }

        public void Update(Brand updated)
        {
            brandRepo.Update(updated);
        }
        //Non-CRUD
        public IEnumerable<Brand> ShortBrand()
        {
            return (from x in brandRepo.ReadAll() where x.BrandName.Length < 4 select x);
        }
    }
}
