using System;
using System.Collections.Generic;
using EY4J5D_HFT_2021221.Models;

namespace EY4J5D_HFT_2021221.Logic
{
    public interface IPurchaseLogic
    {
        public void Create(PurchaseLogic newModel);
        public PurchaseLogic Read(int id);
        public IEnumerable<PurchaseLogic> ReadAll();
        public void Update(PurchaseLogic updated);
        public void Delete(int id);
    }
}
