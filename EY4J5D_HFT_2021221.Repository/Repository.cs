using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
}
