using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace test_data_gen
{
    class Program
    {
        static void Main(string[] args)
        {
            var prodGen = new Bogus.Faker<Product>()
                .RuleFor(p=>p.Name, f=>f.Commerce.ProductName())
                .RuleFor(p=>p.Slug, (f,p)=>p.Name.Replace(" ", "-").ToLower())
                .RuleFor(p=>p.Description, f=>f.Lorem.Paragraph());

            HttpClient c = new HttpClient();

            prodGen.Generate(3000).ForEach(p=>
            {
                var productJson = JsonConvert.SerializeObject(p);
                var res = c.PostAsync("http://localhost:5002/api/products", 
                                      new StringContent(productJson, Encoding.UTF8, "application/json")).Result;
                Console.WriteLine(res.StatusCode);
                Console.WriteLine($"{p.Slug} : {p.Name}");
            });

        }
    }
}
