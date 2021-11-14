﻿using System;
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
    }
}
