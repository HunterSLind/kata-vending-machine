using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine
{
    public class Product
    {
        public Product(string productName, int price, int id, int stock)
        {
            ProductName = productName;
            Price = price;
            ID = id;
            Stock = stock;
        }

        public string ProductName { get; private set; }
        public int Price { get; private set; }
        public int ID { get; private set; }
        public int Stock { get; private set; }

        public bool DispenseItem()
        {
            if(Stock > 0)
            {
                Stock = Stock - 1;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
