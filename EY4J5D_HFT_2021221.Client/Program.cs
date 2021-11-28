using CarDB.Client;
using EY4J5D_HFT_2021221.Models;
using System;

namespace EY4J5D_HFT_20211221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);
            RestService rest = new RestService("http://localhost:3445");
            var brands = rest.Get<Brand>("brand");
            var models = rest.Get<Model>("model");
            var purchases = rest.Get<Purchase>("purchase");

        }
    }
}
