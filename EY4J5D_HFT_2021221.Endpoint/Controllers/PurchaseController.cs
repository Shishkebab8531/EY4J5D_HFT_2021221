﻿using EY4J5D_HFT_2021221.Logic;
using EY4J5D_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EY4J5D_HFT_2021221.Endpoint.Controllers
{
    [Route("purchase")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        IPurchaseLogic pl;
        public PurchaseController(IPurchaseLogic pl)
        {
            this.pl = pl;
        }
        // GET: /purchase
        [HttpGet]
        public IEnumerable<Purchase> Get()
        {
            return pl.ReadAll();
        }

        // GET /purchase/1
        [HttpGet("{id}")]
        public Purchase Get(int id)
        {
            return pl.Read(id);
        }

        // POST /purchase
        [HttpPost]
        public void Post([FromBody] Purchase value)
        {
            pl.Create(value);
        }

        // PUT /purchase/1
        [HttpPut("{id}")]
        public void Put([FromBody] Purchase value)
        {
            pl.Update(value);
        }

        // DELETE /purchase/3
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            pl.Delete(id);
        }
    }
}