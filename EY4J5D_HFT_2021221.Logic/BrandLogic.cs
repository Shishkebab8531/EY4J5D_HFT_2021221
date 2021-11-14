using EY4J5D_HFT_20211221.Repository;
using EY4J5D_HFT_2021221.Models;
using EY4J5D_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EY4J5D_HFT_2021221.Logic
{
    class BrandLogic : IBrandLogic
    {
        //ADDED constructor
        IRepository<Brand> brandRepo;
        public BrandLogic(IRepository<Brand> brandRepo)
        {
            this.brandRepo = brandRepo;
        }
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
            return brandRepo.ReadOne(id);
        }

        public IEnumerable<Brand> ReadAll()
        {
            return brandRepo.ReadAll();
        }

        public void Update(Brand updated)
        {
            brandRepo.Update(updated);
        }
    }
}
