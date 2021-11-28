using Microsoft.EntityFrameworkCore;
using System.Linq;
using EY4J5D_HFT_2021221.Models;
using EY4J5D_HFT_2021221.Repository;
using EY4J5D_HFT_2021221.Data;

namespace EY4J5D_HFT_20211221.Repository
{
    public class BrandRepository : IRepository<Brand>
    {
        CarDbContext ctx;
        public BrandRepository(CarDbContext ctx)
        {
            this.ctx = ctx;
        }
        //CRUD
        public void Create(Brand input)
        {
            ctx.Add(input);
            ctx.SaveChanges();
        }
        public Brand Read(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }
        public IQueryable<Brand> ReadAll()
        {
            return ctx.Brands;
        }

        public void Update(Brand updated)
        {
           var oldBrand = Read(updated.Id);
            oldBrand.Brand_Name = updated.Brand_Name;
            oldBrand.Id = updated.Id;
            oldBrand.Models = updated.Models;
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            ctx.Remove(Read(id));
            ctx.SaveChanges();
        }
    }
}
