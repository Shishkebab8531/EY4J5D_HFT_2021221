using System;
using System.Collections.Generic;
using EY4J5D_HFT_2021221.Models;

namespace EY4J5D_HFT_2021221.Logic
{
    public interface IPurchaseLogic
    {
        public void Create(Purchase newModel);
        public Purchase Read(int id);
        public IEnumerable<Purchase> ReadAll();
        public void Update(Purchase updated);
        public void Delete(int id);
    }
}
