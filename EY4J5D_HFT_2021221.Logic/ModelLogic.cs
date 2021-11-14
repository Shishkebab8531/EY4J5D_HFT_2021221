using System;
using System.Linq;
using EY4J5D_HFT_2021221.Models;
using EY4J5D_HFT_2021221.Repository;
using System.Collections.Generic;

namespace EY4J5D_HFT_2021221.Logic
{
    class ModelLogic : IModelLogic
    {
        IRepository<Model> modelRepo;
        //ctor
        public ModelLogic(IRepository<Model> modelRepo)
        {
            this.modelRepo = modelRepo;
        }
        //CRUD
        public void Create(Model newModel)
        {
            modelRepo.Create(newModel);
        }

        public void Delete(int id)
        {
            modelRepo.Delete(id);
        }

        public Model Read(int id)
        {
            return modelRepo.Read(id);
        }

        public IEnumerable<Model> ReadAll()
        {
            return modelRepo.ReadAll();
        }

        public void Update(Model updated)
        {
            modelRepo.Update(updated);
        }
        //Non-CRUD
        public IEnumerable<KeyValuePair<string, int>> BrandsByModels()
        {
            return from x in modelRepo.ReadAll()
                   group x by x.Brand.BrandName into g
                   select new KeyValuePair<string, int>
                   (g.Key, g.Count());
        }
        public IEnumerable<KeyValuePair<string, int>> BasicBrand()
        {
            return (from x in modelRepo.ReadAll() group x by x.Brand.BrandName into g orderby g.Count(*) select new KeyValuePair<string, int>(g.Key, g.Count())).Take(1);
        }
    }
}
