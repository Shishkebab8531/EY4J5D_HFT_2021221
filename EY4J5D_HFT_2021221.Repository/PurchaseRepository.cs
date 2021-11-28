using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using EY4J5D_HFT_2021221.Models;
using EY4J5D_HFT_2021221.Repository;
using EY4J5D_HFT_2021221.Data;

namespace EY4J5D_HFT_20211221.Repository
{
    public class PurchaseRepository : IRepository<Purchase>
    {
        CarDbContext ctx;
        public PurchaseRepository(CarDbContext ctx) 
        {
            this.ctx = ctx;
        }

        public void ChangePrice(int id, int newPrice)
        {
            Purchase purchase = Read(id);
            if (purchase == null)
            {
                throw new InvalidOperationException(
                    "Purchase not found"
                );
            }
            purchase.Price = newPrice;
            // Unit of Work pattern ???
            ctx.SaveChanges();
        }
        //CRUD
        public void Create(Purchase input)
        {
            ctx.Add(input);
            ctx.SaveChanges();
        }
        public Purchase Read(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }
        public IQueryable<Purchase> ReadAll()
        {
            return ctx.Purchases;
        }
        public void Update(Purchase updated)
        {
            var oldPurchase = Read(updated.Id);
            oldPurchase.Model_Id = updated.Model_Id;
            oldPurchase.Model = updated.Model;
            oldPurchase.Price = updated.Price;
            ctx.SaveChanges();
        }
        public void Delete(int id)
        {
            ctx.Remove(Read(id));
            ctx.SaveChanges();
        }  
    }
}
