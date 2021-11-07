using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EY4J5D_HFT_2021221.Models;
using EY4J5D_HFT_2021221.Repository;

namespace EY4J5D_HFT_20211221.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {

        protected DbContext ctx;

        public Repository(DbContext ctx)
        {
            this.ctx = ctx;
        }

        public abstract void Create(T input);
        public abstract void Delete(int id);
        public abstract void Update(T updated);
        public abstract T ReadOne(int id);
        public IQueryable<T> ReadAll()
        {
            return ctx.Set<T>();
        }
    }

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
    public class ModelRepository : Repository<Model>, IRepository<Model>
    {
        public ModelRepository(DbContext ctx) : base(ctx) { }
        //CRUD
        public override void Create(Model input)
        {
            ctx.Add(input);
            ctx.SaveChanges();
        }
        public override Model ReadOne(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }
        public override void Update(Model updated)
        {
            var oldPurchase = ReadOne(updated.Id);
            oldPurchase.Brand = updated.Brand;
            oldPurchase.Brand_Id = updated.Brand_Id;
            oldPurchase.Model_Name = updated.Model_Name;
            oldPurchase.Purchases = updated.Purchases;
            ctx.SaveChanges();
        }
        public override void Delete(int id)
        {
            ctx.Remove(ReadOne(id));
            ctx.SaveChanges();
        }
    }
    public class BrandRepository : Repository<Brand>, IRepository<Brand>
    {
        public BrandRepository(DbContext ctx) : base(ctx) { }
        //CRUD
        public override void Create(Brand input)
        {
            ctx.Add(input);
            ctx.SaveChanges();
        }
        public override Brand ReadOne(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }

        public override void Update(Brand updated)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
