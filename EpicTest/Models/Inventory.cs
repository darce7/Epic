using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace EpicTest.Models
{
    [XmlRoot]
    public class Inventory
    {
        public List<Product> Products { get; set; }

        public Inventory()
        {
            Products = new List<Product>();
        }
    }
}
