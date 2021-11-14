﻿using System;
using System.Linq;
using EY4J5D_HFT_2021221.Models;
using EY4J5D_HFT_2021221.Repository;
using System.Collections.Generic;

namespace EY4J5D_HFT_2021221.Logic
{
    class PurchaseLogic : IPurchaseLogic
    {
        IRepository<Purchase> purchaseRepo;
        //ctor
        public PurchaseLogic(IRepository<Purchase> purchaseRepo)
        {
            this.purchaseRepo = purchaseRepo;
        }
        //CRUD
        public void Create(Purchase newModel)
        {
            purchaseRepo.Create(newModel);
        }

        public void Delete(int id)
        {
            purchaseRepo.Delete(id);
        }

        public Purchase Read(int id)
        {
            return purchaseRepo.Read(id);
        }

        public IEnumerable<Purchase> ReadAll()
        {
            return purchaseRepo.ReadAll();
        }

        public void Update(Purchase updated)
        {
            purchaseRepo.Update(updated);
        }
        //Non-CRUD
        public IEnumerable<KeyValuePair<string, int>> PopularCar()
        {

            return (from x in purchaseRepo.ReadAll()
                    group x by x.Model.Model_Name into g
                    orderby g.Count() descending
                    select new KeyValuePair<string, int>
                    (g.Key, g.Count())).Take(1);
        }
        public IEnumerable<KeyValuePair<string, int>> ExpensiveCar()
        {
            return (from x in purchaseRepo.ReadAll()
                    orderby x.Price descending
                    select new KeyValuePair<string, int>
                    (x.Model.Model_Name, x.Price)).Take(1);
        }
        public IEnumerable<KeyValuePair<string, int>> RichBrand()
        {
            return (from x in purchaseRepo.ReadAll() 
                    group x by x.Model.Brand.BrandName into g 
                    orderby g.Sum(x => x.Price) descending 
                    select new KeyValuePair<string, int>
                    (g.Key, g.Sum(x => x.Price))).Take(1);
        }
    }
}
