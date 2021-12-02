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
        public IEnumerable<KeyValuePair<string, int>> PopularCar();
        public IEnumerable<KeyValuePair<string, int>> ExpensiveCar();
        public IEnumerable<KeyValuePair<string, int>> RichBrand();
        public IEnumerable<KeyValuePair<string, double>> AverageMoneyPerCar();
        public IEnumerable<Purchase> PurchasedThisYear();
    }
}
