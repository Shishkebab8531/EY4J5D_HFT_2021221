using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using EY4J5D_HFT_2021221.Models;
using EY4J5D_HFT_2021221.Repository;

namespace EY4J5D_HFT_20211221.Repository
{
    public class PurchaseRepository : Repository<Purchase>, IRepository<Purchase>
    {
        public PurchaseRepository(DbContext ctx) : base(ctx) { }

        public void ChangePrice(int id, int newPrice)
        {
            Purchase purchase = ReadOne(id);
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
        public override void Create(Purchase input)
        {
            ctx.Add(input);
            ctx.SaveChanges();
        }
        public override Purchase ReadOne(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }
        public override void Update(Purchase updated)
        {
            var oldPurchase = ReadOne(updated.Id);
            oldPurchase.Car_Id = updated.Car_Id;
            oldPurchase.Model = updated.Model;
            oldPurchase.Price = updated.Price;
            ctx.SaveChanges();
        }
        public override void Delete(int id)
        {
            ctx.Remove(ReadOne(id));
            ctx.SaveChanges();
        }  
    }
}
