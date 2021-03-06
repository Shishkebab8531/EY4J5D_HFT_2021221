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
            if (newBrand.Brand_Name != null && newBrand.Brand_Name.Length <= 50 && newBrand.Brand_Name != "")
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
            //var output = (from x in brandRepo.ReadAll() where x.Brand_Name.Length <= 4 select x);
            var output = brandRepo.ReadAll().Where(x => x.Brand_Name.Length <= 4).ToList();
            return output.AsEnumerable();
        }
    }
}
