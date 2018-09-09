using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace chaos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChaosController : ControllerBase
    {
        PodClient _K;

        public ChaosController()
        {
            _K = new PodClient();
        }

        // GET api/values
        [HttpGet]
        public Task Get()
        {
            return _K.KillRandomPod();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
