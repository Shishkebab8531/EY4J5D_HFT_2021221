using System;
using System.Collections.Generic;
using EY4J5D_HFT_2021221.Models;

namespace EY4J5D_HFT_2021221.Logic
{
    interface IModelLogic
    {
        public void Create(Model newModel);
        public Model Read(int id);
        public IEnumerable<Model> ReadAll();
        public void Update(Model updated);
        public void Delete(int id);
    }
}
