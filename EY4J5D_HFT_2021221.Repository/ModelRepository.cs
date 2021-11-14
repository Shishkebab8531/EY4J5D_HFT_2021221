using Microsoft.EntityFrameworkCore;
using System.Linq;
using EY4J5D_HFT_2021221.Models;
using EY4J5D_HFT_2021221.Repository;
using EY4J5D_HFT_2021221.Data;
using System.Collections.Generic;

namespace EY4J5D_HFT_20211221.Repository
{
    public class ModelRepository : IRepository<Model>
    {
        CarDbContext ctx;
        public ModelRepository(CarDbContext ctx) 
        {
            this.ctx = ctx;
        }
        //CRUD
        public void Create(Model input)
        {
            ctx.Add(input);
            ctx.SaveChanges();
        }
        public Model Read(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }
        public IQueryable<Model> ReadAll()
        {
            return ctx.Models;
        }
        public void Update(Model updated)
        {
            var oldModel = Read(updated.Id);
            oldModel.Brand = updated.Brand;
            oldModel.Brand_Id = updated.Brand_Id;
            oldModel.Model_Name = updated.Model_Name;
            oldModel.Purchases = updated.Purchases;
            ctx.SaveChanges();
        }
        public void Delete(int id)
        {
            ctx.Remove(Read(id));
            ctx.SaveChanges();
        }
        //Non-CRUD
        
    }
}
