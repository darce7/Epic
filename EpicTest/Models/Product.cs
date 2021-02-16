using System;
using System.Xml.Serialization;
namespace EpicTest.Models
{
    
    public class Product
    {
        public string Name { get; set; }

        public float Price { get; set; }

        public int Quantity { get; set; }

        public string Class {
            get {
                if (Quantity > 3)
                {
                    return "greaterThanThree";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

    }
}
