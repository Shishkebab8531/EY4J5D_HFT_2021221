using System;
using System.Collections.Generic;
using EY4J5D_HFT_2021221.Models;

namespace EY4J5D_HFT_2021221.Logic
{
    interface ICarLogic
    {
        Purchase GetOnePurchase(int id);

        void ChangeCarPrice(int id, int newPrice);

        IList<Purchase> GetPurchases();

        IList<AveragesResult> GetBrandAverages();
        
    }
}
