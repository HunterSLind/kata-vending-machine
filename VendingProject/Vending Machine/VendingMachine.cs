using System;
using System.Collections.Generic;
using System.Linq;

namespace Vending_Machine
{
    public class VendingMachine
    {
        /// <summary>
        /// The following Tuple values are the diameter (cm) and weight (g) of known coins, stored respectively.
        /// </summary>
        public static readonly Tuple<double, double> PENNY = new Tuple<double, double>(19, 2.5);
        public static readonly Tuple<double, double> NICKEL = new Tuple<double, double>(21.2, 5);
        public static readonly Tuple<double, double> DIME = new Tuple<double, double>(17.9, 2.3);
        public static readonly Tuple<double, double> QUARTER = new Tuple<double, double>(24.3, 5.7);
        public static readonly Dictionary<Tuple<double, double>, int> COINDICTIONARY = new Dictionary<Tuple<double, double>, int>()
        {
            {NICKEL, 5 },
            {DIME, 10 },
            {QUARTER, 25 }
        };
        public static readonly string THANKYOUMESSAGE = "THANK YOU";
        public static readonly string INSERTCOINMESSAGE = "INSERT COIN";
        public static readonly string SOLDOUTMESSAGE = "SOLD OUT";
        public static readonly string EXACTCHANGEONLYMESSAGE = "EXACT CHANGE ONLY";

        private Dictionary<int, Product> productDictionary = new Dictionary<int, Product>();

        /// <summary>
        /// Tracks the stock of a given item.
        /// </summary>
        private Dictionary<int, int> productStock = new Dictionary<int, int>();

        /// <summary>
        /// Coin storage counts. Key is the value of the coin, Value is the number of coins in the machine.
        /// </summary>
        public Dictionary<int, int> CoinCollection = new Dictionary<int, int>()
        {
            {5, 0 }, //NICKEL
            {10, 0 }, //DIME
            {25, 0 } // QUARTER
        };

        public Dictionary<int, int> changeDictionary = new Dictionary<int, int>()
        {
            {25, 0 },
            {10, 0 },
            {5, 0 }
        };

        public int InsertedAmount = 0;
        private string screenMessage;

        public VendingMachine(Dictionary<int, Product> newProductDictionary, Dictionary<int, int> newProductStockDictionary)
        {
            productDictionary = newProductDictionary;

            if (newProductStockDictionary == null || newProductStockDictionary.Count == 0)
            {
                productStock = new Dictionary<int, int>();
                foreach (var product in productDictionary)
                {
                    productStock.Add(product.Key, 0);
                }
            }
            else
            {
                productStock = newProductStockDictionary;
            }
        }

        /// <summary>
        /// Determines coin validity based on diameter and weight.
        /// </summary>
        /// <param name="diameter">Diameter of the coin, in Millimeters</param>
        /// <param name="weight">Weight of the coin, in Grams</param>
        /// <returns>T/F for whether the coin is acceptable.</returns>
        public bool CheckCoinToAccept(double diameter, double weight)
        {
            return COINDICTIONARY.ContainsKey(new Tuple<double, double>(diameter, weight));
        }

        ///// <summary>
        ///// Determines what's displayed on the screen
        ///// </summary>
        ///// <returns>A display message for the vending machine.</returns>
        public string ScreenDisplay()
        {
            return screenMessage;
        }

        /// <summary>
        /// Gets the coin value based on diameter and weight of the coin
        /// </summary>
        /// <param name="diameter">Diameter of the coin, in Millimeters</param>
        /// <param name="weight">Weight of the coin, in Grams</param>
        /// <returns>A coin value in cents</returns>
        public int CheckCoinValue(double diameter, double weight)
        {
            if (COINDICTIONARY.ContainsKey(new Tuple<double, double>(diameter, weight)))
            {
                int coinValue = COINDICTIONARY[new Tuple<double, double>(diameter, weight)];
                depositCoin(coinValue);
                return coinValue;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Deposits a coin into the Coin Collection item.
        /// </summary>
        /// <param name="Value"></param>
        private void depositCoin(int Value)
        {
            if (CoinCollection.ContainsKey(Value))
            {
                CoinCollection[Value]++;
                InsertedAmount = InsertedAmount + Value;
            }
        }

        /// <summary>
        /// Determines whether product is selectable by checking whether it exists, and if it is in stock.
        /// </summary>
        /// <param name="ProductCode">Code for the product the customer has requested.</param>
        /// <returns>T/F for whether the product is valid.</returns>
        public bool SelectProduct(int productid)
        {
            if (productStock[productid] > 0)
            {
                Product thisProduct = productDictionary[productid];

                // Check if enough money has been inserted for item.
                if (thisProduct.Price > InsertedAmount)
                {
                    screenMessage = INSERTCOINMESSAGE;
                    return false;
                }

                // Set change amount
                int change = InsertedAmount - thisProduct.Price;
                // Check if vending machine has the coins to make change.
                if (!ableToMakeChange(change))
                {
                    screenMessage = EXACTCHANGEONLYMESSAGE;
                    return false;
                }

                // Before returning true, subtract from the inventory level of the product.
                productStock[productid]--;
                screenMessage = THANKYOUMESSAGE;
                return true;
            }
            else
            {
                screenMessage = SOLDOUTMESSAGE;
                return false;
            }
        }

        public void EmptyChangeDictionary()
        {
            changeDictionary = new Dictionary<int, int>()
            {
                {25, 0 },
                {10, 0 },
                {5, 0 }
            };
        }

        private bool ableToMakeChange(int change)
        {

            // Start with largest coin, and find out how many of those to dispense, then move to smaller and smaller coins.
            // Item:
            // Key: Value of the coin 
            // Value: Number of coins
            foreach (var item in CoinCollection.OrderByDescending(a => a.Key))
            {
                while (change >= item.Key && changeDictionary[item.Key] < CoinCollection[item.Key])
                {
                    changeDictionary[item.Key] = changeDictionary[item.Key] + 1;
                    change = change - item.Key;
                }
            }

            if (change > 0)
            {
                // TODO Dispense Change
                return false;
            }
            return true;
        }
    }
}
