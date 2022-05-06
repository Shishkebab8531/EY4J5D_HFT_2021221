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
    [Route("brand")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        IBrandLogic bl;
        IHubContext<SignalRHub> hub;
        public BrandController(IBrandLogic bl, IHubContext<SignalRHub> hub)
        {
            this.bl = bl;
            this.hub = hub;
        }
        // GET: /brand
        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            return bl.ReadAll();
        }

        // GET /brand/2
        [HttpGet("{id}")]
        public Brand Get(int id)
        {
            return bl.Read(id);
        }

        // POST /brand
        [HttpPost]
        public void Post([FromBody] Brand value)
        {
            bl.Create(value);
            this.hub.Clients.All.SendAsync("BrandCreated", value);
        }

        // PUT /brand/4
        [HttpPut]
        public void Put([FromBody] Brand value)
        {
            bl.Update(value);
            this.hub.Clients.All.SendAsync("BrandUpdated", value);
        }

        // DELETE /brand/2
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var value = bl.Read(id);
            bl.Delete(id);
            this.hub.Clients.All.SendAsync("BrandDeleted", value);

        }
    }
}
