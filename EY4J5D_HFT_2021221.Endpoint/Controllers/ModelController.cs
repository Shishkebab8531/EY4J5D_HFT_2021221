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
    [Route("model")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        IModelLogic ml;
        public ModelController(IModelLogic ml)
        {
            this.ml = ml;
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
        }

        // PUT /model
        [HttpPut("{id}")]
        public void Put([FromBody] Model value)
        {
            ml.Update(value);
        }

        // DELETE /model/2
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ml.Delete(id);
        }
    }
}
