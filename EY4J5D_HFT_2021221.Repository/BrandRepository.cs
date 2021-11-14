using Microsoft.EntityFrameworkCore;
using System.Linq;
using EY4J5D_HFT_2021221.Models;
using EY4J5D_HFT_2021221.Repository;

namespace EY4J5D_HFT_20211221.Repository
{
    public class BrandRepository : Repository<Brand>, IRepository<Brand>
    {
        public BrandRepository(DbContext ctx) : base(ctx) { }
        //CRUD
        public override void Create(Brand input)
        {
            ctx.Add(input);
            ctx.SaveChanges();
        }
        public override Brand Read(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }

        public override void Update(Brand updated)
        {
           var oldBrand = Read(updated.Id);
            oldBrand.BrandName = updated.BrandName;
            oldBrand.Id = updated.Id;
            oldBrand.Models = updated.Models;
            ctx.SaveChanges();
        }

        public override void Delete(int id)
        {
            ctx.Remove(Read(id));
            ctx.SaveChanges();
        }
    }
}
