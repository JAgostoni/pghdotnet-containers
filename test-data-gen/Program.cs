using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace test_data_gen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generating data, please wait...");
            var prodGen = new Bogus.Faker<Product>()
                .RuleFor(p=>p.Name, f=>f.Commerce.ProductName())
                .RuleFor(p=>p.Slug, (f,p)=>p.Name.Replace(" ", "-").ToLower())
                .RuleFor(p=>p.Description, f=>f.Lorem.Paragraph());

            HttpClient c = new HttpClient();

            Parallel.ForEach(prodGen.Generate(3000), p=>
            {
                var productJson = JsonConvert.SerializeObject(p);
                var res = c.PostAsync("http://localhost:5002/api/products", 
                                      new StringContent(productJson, Encoding.UTF8, "application/json")).Result;
            });
            
            Console.WriteLine("Done.");
        }
    }
}
