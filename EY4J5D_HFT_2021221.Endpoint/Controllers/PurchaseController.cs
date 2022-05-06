using EY4J5D_HFT_2021221.Endpoint.Services;
using EY4J5D_HFT_2021221.Logic;
using EY4J5D_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        IHubContext<SignalRHub> hub;
        public PurchaseController(IPurchaseLogic pl, IHubContext<SignalRHub> hub)
        {
            this.pl = pl;
            this.hub = hub;

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
            this.hub.Clients.All.SendAsync("PurchaseCreated", value);

        }

        // PUT /purchase/1
        [HttpPut]
        public void Put([FromBody] Purchase value)
        {
            pl.Update(value);
            this.hub.Clients.All.SendAsync("PurchaseUpdated", value);

        }

        // DELETE /purchase/3
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Purchase value = pl.Read(id);
            pl.Delete(id);
            this.hub.Clients.All.SendAsync("PurchaseDeleted", value);
        }
    }
}
