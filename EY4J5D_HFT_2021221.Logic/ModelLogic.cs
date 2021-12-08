using System;
using System.Linq;
using EY4J5D_HFT_2021221.Models;
using EY4J5D_HFT_2021221.Repository;
using System.Collections.Generic;

namespace EY4J5D_HFT_2021221.Logic
{
    public class ModelLogic : IModelLogic
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
            if (newModel.Model_Name != null && newModel.Model_Name.Length <= 50 && newModel.Model_Name != "")
            {
                modelRepo.Create(newModel);
            }
            else
            {
                throw new ArgumentException();
            }
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
            /*var output = from x in modelRepo.ReadAll()
                         group x by x.Brand into g
                         select new KeyValuePair<string, int>
                         (g.Key.Brand_Name, g.Count());
            return output;*/
            return (from x in modelRepo.ReadAll() group x by x.Brand.Brand_Name into g orderby g.Count() select new KeyValuePair<string, int>(g.Key, g.Count()));

        }
        public IEnumerable<KeyValuePair<string, int>> BasicBrands()
        {
            return (from x in modelRepo.ReadAll() group x by x.Brand.Brand_Name into g orderby g.Count() select new KeyValuePair<string, int>(g.Key, g.Count())).Take(1);
        }
    }
}
