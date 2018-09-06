using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace portal_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ConnectionMultiplexer _REDIS;

        public ProductController()
        {
            var redisHost = Environment.GetEnvironmentVariable("REDIS_HOST") ?? "localhost";
            Console.WriteLine($"Redis Host: {redisHost}");

            _REDIS = ConnectionMultiplexer.Connect(redisHost);

        }
        
        // GET api/values/5
        [HttpGet("{slug}")]
        public async Task<string> Get(string slug)
        {
            IDatabase redisDB = _REDIS.GetDatabase();
            return (await redisDB.StringGetAsync(slug)).ToString();
        }

        
        [HttpGet("find/{search}")]
        public IEnumerable<Product> Find(string search)
        {
            var server = _REDIS.GetServer(_REDIS.GetEndPoints()[0]);
            IDatabase redisDB = _REDIS.GetDatabase();
            return server.Keys(pattern:$"*{search}*")
                        .Select(k=>redisDB.StringGet(k).ToString())
                        .Select(pjson => JsonConvert.DeserializeObject<Product>(pjson));
        }
    }
}
