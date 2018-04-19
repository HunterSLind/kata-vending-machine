using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine
{
    public class Product
    {
        public Product(string productName, int price, int id)
        {
            ProductName = productName;
            Price = price;
            ID = id;
        }

        public string ProductName { get; private set; }
        public int Price { get; private set; }
        public int ID { get; private set; }
        
    }
}
