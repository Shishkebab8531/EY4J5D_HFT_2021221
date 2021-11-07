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

        public abstract T Create();
        public abstract T Delete(int id);
        public abstract T Update(int id);
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

        public override Purchase Create()
        {
            throw new NotImplementedException();
        }

        public override Purchase Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Purchase ReadOne(int id)
        {
            throw new NotImplementedException();
        }

        public override Purchase Update(int id)
        {
            throw new NotImplementedException();
        }
    }
    public class ModelRepository : Repository<Model>, IRepository<Model>
    {
        public ModelRepository(DbContext ctx) : base(ctx) { }
        public override Model Create()
        {
            throw new NotImplementedException();
        }

        public override Model Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Model ReadOne(int id)
        {
            throw new NotImplementedException();
        }

        public override Model Update(int id)
        {
            throw new NotImplementedException();
        }
    }
    public class BrandRepository : Repository<Brand>, IRepository<Brand>
    {
        public BrandRepository(DbContext ctx) : base(ctx) { }

        public override Brand Create()
        {
            throw new NotImplementedException();
        }

        public override Brand Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Brand ReadOne(int id)
        {
            throw new NotImplementedException();
        }

        public override Brand Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
