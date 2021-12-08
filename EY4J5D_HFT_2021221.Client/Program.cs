using CarDB.Client;
using ConsoleTools;
using EY4J5D_HFT_2021221.Models;
using System;
using System.Collections.Generic;

namespace EY4J5D_HFT_20211221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);
            RestService rest = new RestService("http://localhost:3445");
            Brand testBrand = new Brand()
            {
                Brand_Name = "Lada",
                Models = new List<Model>()
            };
            Model testModel = new Model()
            {
                Model_Name = "Niva",
                Purchases = new List<Purchase>(),
                Brand = testBrand,
                Brand_Id = testBrand.Id
            };
            Purchase testPurchase = new Purchase()
            {
                Purchase_Date = DateTime.Now,
                Price = 123,
                Model = testModel,
                Model_Id = testModel.Id
            };
            var model_crud = new ConsoleMenu(args, level: 1)
                .Add
                ("Create", () => { 
                    rest.Post<Model>(testModel, "model"); 
                    Console.WriteLine("Press any key to continue"); 
                    Console.ReadKey();
                })
                .Add
                ("Read", () => { 
                    Console.WriteLine("Specify the ID"); 
                    var temp = rest.Get<Model>(int.Parse(Console.ReadLine()), "model");
                    Console.WriteLine("ID: {0}, Model_Name: {1}, Brand_ID: {2}, Brand_Name: {3}", temp.Id, temp.Model_Name, temp.Brand_Id, temp.Brand.Brand_Name);
                    Console.WriteLine("Press any key to continue"); 
                    Console.ReadKey(); 
                })
                .Add
                ("ReadAll", () => { 
                    foreach (var item in rest.Get<Model>("model"))
                    {
                        Console.WriteLine("ID: {0}, Model_Name: {1}, Brand_ID: {2}, Brand_Name: {3}", item.Id, item.Model_Name, item.Brand_Id, item.Brand.Brand_Name);
                    }
                    Console.WriteLine("Press any key to continue"); 
                    Console.ReadKey(); 
                })
                .Add
                ("Update", () => { 
                    Console.WriteLine("Specify the ID"); 
                    testModel.Id = int.Parse(Console.ReadLine()); 
                    rest.Put<Model>(testModel, "model"); 
                    Console.WriteLine("Press any key to continue"); Console.ReadKey(); 
                })
                .Add
                ("Delete", () => { 
                    Console.WriteLine("Specify the ID"); 
                    rest.Delete(int.Parse(Console.ReadLine()), "model"); 
                    Console.WriteLine("Press any key to continue"); 
                    Console.ReadKey();
                })
                .Add("To main menu", ConsoleMenu.Close);
            var brand_crud = new ConsoleMenu(args, level: 1)
                                .Add
                ("Create", () => {
                    rest.Post<Brand>(testBrand, "brand");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                })
                .Add
                ("Read", () => {
                    Console.WriteLine("Specify the ID");
                    var temp = rest.Get<Brand>(int.Parse(Console.ReadLine()), "brand");
                    Console.WriteLine("ID: {0}, Brand_Name: {1}", temp.Id, temp.Brand_Name);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                })
                .Add
                ("ReadAll", () => {
                    foreach (var item in rest.Get<Brand>("brand"))
                    {
                        Console.WriteLine("ID: {0}, Brand_Name: {1}", item.Id, item.Brand_Name);
                    }
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                })
                .Add
                ("Update", () => {
                    Console.WriteLine("Specify the ID");
                    testBrand.Id = int.Parse(Console.ReadLine());
                    rest.Put<Brand>(testBrand, "brand");
                    Console.WriteLine("Press any key to continue"); Console.ReadKey();
                })
                .Add
                ("Delete", () => {
                    Console.WriteLine("Specify the ID");
                    rest.Delete(int.Parse(Console.ReadLine()), "brand");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                })
                .Add("To main menu", ConsoleMenu.Close);
            var purchase_crud = new ConsoleMenu(args, level: 1)
                                .Add
                ("Create", () => {
                    rest.Post<Purchase>(testPurchase, "purchase");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                })
                .Add
                ("Read", () => {
                    Console.WriteLine("Specify the ID");
                    var temp = rest.Get<Purchase>(int.Parse(Console.ReadLine()), "purchase");
                    Console.WriteLine("ID: {0}, Purchase_Date: {1}", temp.Id, temp.Purchase_Date);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                })
                .Add
                ("ReadAll", () => {
                    foreach (var item in rest.Get<Purchase>("purchase"))
                    {
                        Console.WriteLine("ID: {0}, Purchase_Date: {1}", item.Id, item.Purchase_Date);
                    }
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                })
                .Add
                ("Update", () => {
                    Console.WriteLine("Specify the ID");
                    testPurchase.Id = int.Parse(Console.ReadLine());
                    rest.Put<Purchase>(testPurchase, "purchase");
                    Console.WriteLine("Press any key to continue"); Console.ReadKey();
                })
                .Add
                ("Delete", () => {
                    Console.WriteLine("Specify the ID");
                    rest.Delete(int.Parse(Console.ReadLine()), "purchase");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                })
                .Add("To main menu", ConsoleMenu.Close);
            var non_crud = new ConsoleMenu(args, level: 1)
                .Add
                ("Brands with short names (less than 5 characters)", () =>{
                    foreach (var item in rest.Get<Brand>("stat/shortBrand"))
                    {
                        Console.WriteLine("ID: {0}, Brand_Name: {1}", item.Id, item.Brand_Name);
                    }
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                })
                .Add("Models purchased this year", () => {
                    foreach (var item in rest.Get<Purchase>("stat/purchasedThisYear"))
                    {
                        Console.WriteLine("ID: {0}, Model_Name: {1}, Purchase_Date: {2}", item.Id, item.Model.Model_Name, item.Purchase_Date);
                    }
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                })
                .Add("Average cost of each model", () => {
                    foreach (var item in rest.Get<KeyValuePair<string, double>>("stat/averageMoneyPerCar"))
                    {
                        Console.WriteLine("Car: " + item.Key + ", Average Cost" + item.Value);
                    }
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                })
                .Add("The most purchased car", () => {
                    foreach (var item in rest.Get<KeyValuePair<string, int>>("stat/popularCar"))
                    {
                        Console.WriteLine("Brand_Name: {0}, Times Purchased: {1}", item.Key, item.Value);
                    }
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                })
                .Add("The most expensive car", () => {
                    foreach (var item in rest.Get<KeyValuePair<string, int>>("stat/expensiveCar"))
                    {
                        Console.WriteLine("Model_Name: {0}, Price {1}", item.Key, item.Value);
                    }
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                })
                .Add("The highest income brand", () => {
                    foreach (var item in rest.Get<KeyValuePair<string, int>>("stat/richBrand"))
                    {
                        Console.WriteLine("Brand_Name: {0}, Money Gathered: {1}",item.Key, item.Value);
                    }
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                })
                //
                .Add("Brands in order of amount of models", () => {
                    foreach (var item in rest.Get<KeyValuePair<string, int>>("stat/brandsByModels"))
                    {
                        Console.WriteLine("Brand: {0}, Models: {1}",item.Key, item.Value);
                    }
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();

                })
                .Add("A brand with the minimum amount of models in this database", () => {
                    foreach (var item in rest.Get<KeyValuePair<string, int>>("stat/basicBrands"))
                    {
                        Console.WriteLine("Brand_Name: {0}, Models: {1}", item.Key, item.Value);
                    }
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                })
                .Add("To main menu", ConsoleMenu.Close);

            var oof = new ConsoleMenu(args, level: 0)
                .Add("Model CRUD", () => model_crud.Show())
                .Add("Brand CRUD", () => brand_crud.Show())
                .Add("Purchase CRUD", () => purchase_crud.Show())
                .Add("Non-CRUD", () => non_crud.Show())
                .Add("Close", ConsoleMenu.Close);
            oof.Show();
        }
    }
}
