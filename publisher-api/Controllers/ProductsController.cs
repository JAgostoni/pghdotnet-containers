using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace publisher_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpPost]
        public void Post([FromBody] Product value)
        {
            var client = new NewProductQueue();
            client.SendProduct(value);
        }

    }
}
