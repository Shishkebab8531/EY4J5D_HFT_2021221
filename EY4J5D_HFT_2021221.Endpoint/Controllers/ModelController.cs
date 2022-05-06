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
    [Route("model")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        IModelLogic ml;
        IHubContext<SignalRHub> hub;
        public ModelController(IModelLogic ml, IHubContext<SignalRHub> hub)
        {
            this.ml = ml;
            this.hub = hub;
        }
        // GET: /model
        [HttpGet]
        public IEnumerable<Model> Get()
        {
            return ml.ReadAll();
        }

        // GET /model/2
        [HttpGet("{id}")]
        public Model Get(int id)
        {
            return ml.Read(id);
        }

        // POST /model/
        [HttpPost]
        public void Post([FromBody] Model value)
        {
            ml.Create(value);
            this.hub.Clients.All.SendAsync("ModelCreated", value);

        }

        // PUT /model
        [HttpPut]
        public void Put([FromBody] Model value)
        {
            ml.Update(value);
            this.hub.Clients.All.SendAsync("ModelUpdated", value);

        }

        // DELETE /model/2
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Model value = ml.Read(id);
            ml.Delete(id);
            this.hub.Clients.All.SendAsync("ModelDeleted", value);

        }
    }
}
