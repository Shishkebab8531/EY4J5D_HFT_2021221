using System;
using EY4J5D_HFT_2021221.Models;
using System.Collections.Generic;

namespace EY4J5D_HFT_2021221.Logic
{
    public interface IModelLogic
    {
        public void Create(Model newModel);
        public Model Read(int id);
        public IEnumerable<Model> ReadAll();
        public void Update(Model updated);
        public void Delete(int id);
        public IEnumerable<KeyValuePair<string, int>> BrandsByModels();
        public IEnumerable<KeyValuePair<string, int>> BasicBrands();

    }
}
