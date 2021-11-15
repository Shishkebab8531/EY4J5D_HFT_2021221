using System;
using EY4J5D_HFT_2021221.Models;
using EY4J5D_HFT_2021221.Repository;
using System.Collections.Generic;

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
        public void Create(Brand newModel)
        {
            brandRepo.Create(newModel);
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
    }
}
