using EY4J5D_HFT_2021221.Logic;
using EY4J5D_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EY4J5D_HFT_2021221.Endpoint.Controllers
{
    [Route("stat")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IModelLogic ml;
        IBrandLogic bl;
        IPurchaseLogic pl;
        public StatController(IModelLogic ml, IBrandLogic bl, IPurchaseLogic pl)
        {
            this.ml = ml;this.bl = bl;this.pl = pl;
        }
        //GET /stat/shortBrand
        [HttpGet("shortBrand")]
        public IEnumerable<Brand> ShortBrand()
        {
            return bl.ShortBrand();
        }
        //GET /stat/purchasedThisYear
        [HttpGet("purchasedThisYear")]
        public IEnumerable<Purchase> PurchasedThisYear()
        {
            return pl.PurchasedThisYear();
        }
        //GET /stat/averageMoneyPerCarPerBrand
        [HttpGet("averageMoneyPerCar")]
        public IEnumerable<KeyValuePair<string, double>> AverageMoneyPerCar()
        {
            return pl.AverageMoneyPerCar();
        }
        //GET /stat/popularCar
        [HttpGet("popularCar")]
        public IEnumerable<KeyValuePair<string, int>> PopularCar()
        {
            return pl.PopularCar();
        }
        //GET /stat/expensiveCar
        [HttpGet("expensiveCar")]
        public IEnumerable<KeyValuePair<string, int>> ExpensiveCar()
        {
            return pl.ExpensiveCar();
        }
        //GET /stat/richBrand
        [HttpGet("richBrand")]
        public IEnumerable<KeyValuePair<string, int>> RichBrand()
        {
            return pl.RichBrand();
        }
        //GET /stat/brandsByModels
        [HttpGet("brandsByModels")]
        public IEnumerable<KeyValuePair<string, int>> BrandsByModels()
        {
            return ml.BrandsByModels();
        }
        //GET /stat/basicBrand
        [HttpGet("basicBrands")]
        public IEnumerable<KeyValuePair<string, int>> BasicBrands()
        {
            return ml.BasicBrands();
        }
    }
}
