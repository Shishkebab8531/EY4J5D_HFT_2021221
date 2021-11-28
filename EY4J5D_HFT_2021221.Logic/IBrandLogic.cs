using System;
using EY4J5D_HFT_2021221.Models;
using System.Collections.Generic;

namespace EY4J5D_HFT_2021221.Logic
{
    public interface IBrandLogic
    {
        public void Create(Brand newModel);
        public Brand Read(int id);
        public IEnumerable<Brand> ReadAll();
        public void Update(Brand updated);
        public void Delete(int id);
        public IEnumerable<Brand> ShortBrand();
    }
}
