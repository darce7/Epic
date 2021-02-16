using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EpicTest.Models;
using System.Xml.Linq;


namespace EpicTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string sortOrder)
        {
            var sortBy = String.IsNullOrEmpty(sortOrder) ? "name" : sortOrder;
            
            Inventory inventory = new Inventory();

            XElement xml = XElement.Load("./Data/inventory.xml");

            var products = from product in xml.Descendants("products").Elements()
                        select product;

            foreach(var p in products)
            {
                inventory.Products.Add(new Product()
                {
                    Name = p.Attribute("name").Value,
                    Price = float.Parse(p.Attribute("price").Value),
                    Quantity = int.Parse(p.Attribute("qty").Value)
                });
            }

            switch (sortBy)
            {
                case "name":
                    inventory.Products = inventory.Products.OrderBy(x => x.Name).ToList();
                    break;
                case "price":
                    inventory.Products = inventory.Products.OrderBy(x => x.Price).ToList();
                    break;
                case "qty":
                    inventory.Products = inventory.Products.OrderBy(x => x.Quantity).ToList();
                    break;
            }
               


            return View(inventory.Products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
