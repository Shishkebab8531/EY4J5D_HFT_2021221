using Microsoft.EntityFrameworkCore;
using System.Linq;
using EY4J5D_HFT_2021221.Models;
using EY4J5D_HFT_2021221.Repository;

namespace EY4J5D_HFT_20211221.Repository
{
    public class ModelRepository : Repository<Model>, IRepository<Model>
    {
        public ModelRepository(DbContext ctx) : base(ctx) { }
        //CRUD
        public override void Create(Model input)
        {
            ctx.Add(input);
            ctx.SaveChanges();
        }
        public override Model Read(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }
        public override void Update(Model updated)
        {
            var oldModel = Read(updated.Id);
            oldModel.Brand = updated.Brand;
            oldModel.Brand_Id = updated.Brand_Id;
            oldModel.Model_Name = updated.Model_Name;
            oldModel.Purchases = updated.Purchases;
            ctx.SaveChanges();
        }
        public override void Delete(int id)
        {
            ctx.Remove(Read(id));
            ctx.SaveChanges();
        }
    }
}
