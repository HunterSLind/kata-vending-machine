using System;
using System.Collections.Generic;

namespace Vending_Machine
{
    public class VendingMachine
    {
        /// <summary>
        /// The following Tuple values are the diameter and weight of known coins, stored respectively.
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

        public static Product COLA = new Product("Cola", 100, 1);
        public static Product CHIPS = new Product("Chips", 50, 2);
        public static Product CANDY = new Product("Candy", 65, 3);

        public static Dictionary<int, Product> ProductDictionary = new Dictionary<int, Product>()
        {
            {1,  new Product("Cola", 100, 1) },
            {2, new Product("Chips", 50, 2) },
            {3, new Product("Candy", 65, 3) }
        };


        /// <summary>
        /// Tracks the stock of a given item.
        /// </summary>
        public static Dictionary<int, int> PRODUCTSTOCK = new Dictionary<int, int>()
        {
            {1, 10 },
            {2, 10 },
            {3, 10 }
        };


        public int InsertedAmount = 0;

        /// <summary>
        /// Coin storage counts. Key is the value of the coin, Value is the number of coins in the machine.
        /// </summary>
        public Dictionary<int, int> CoinCollection = new Dictionary<int, int>()
        {
            {5, 0 }, //NICKEL
            {10, 0 }, //DIME
            {25, 0 } // QUARTER
        };


        /// <summary>
        /// Determines coin validity based on diameter and weight.
        /// </summary>
        /// <param name="diameter">Diameter of the coin, in Millimeters</param>
        /// <param name="weight">Weight of the coin, in Grams</param>
        /// <returns>T/F for whether the coin is acceptable.</returns>
        public bool CheckCoinToAccept(double diameter, double weight)
        {
            if (COINDICTIONARY.ContainsKey(new Tuple<double, double>(diameter, weight)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        ///// <summary>
        ///// Determines what's displayed on the screen
        ///// </summary>
        ///// <returns>A display message for the vending machine.</returns>
        //public string ScreenDisplay()
        //{

        //}

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
        /// Gets the amount of change to return to customer.
        /// </summary>
        /// <returns>An amount of change to return.</returns>
        public int MakeChange()
        {
            return 0;
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
            if (PRODUCTSTOCK.ContainsKey(productid))
            {
                if (PRODUCTSTOCK[productid] > 0)
                {
                    // TODO add NotEnoughMoney check.
                    Product thisProduct = ProductDictionary[productid];

                    if (thisProduct.Price > InsertedAmount)
                    {
                        // Set a not enough money message here.
                        return false;
                    }

                    // TODO add UnableToMakeChange check.
                    // find how many quarters
                    // find how many dimes
                    // find how many nickels
                    int numQuarters = 0;
                    int numDimes = 0;
                    int numNickels = 0;

                    int change = InsertedAmount - thisProduct.Price;

                    while(change > 25)
                    {
                        numQuarters = numQuarters + 1;
                        change = change - 25;
                    }
                    while (change > 10)
                    {
                        numDimes = numDimes + 1;
                        change = change - 10;
                    }
                    while (change > 5)
                    {
                        numNickels = numNickels + 1;
                        change = change - 5;
                    }

                    if(numQuarters > CoinCollection[25] || numDimes > CoinCollection[10] || numNickels > CoinCollection[5])
                    {
                        // TODO Unable to make change message
                        return false;
                    }
                    
                    // Before returning true, subtract from the inventory level of the product.
                    PRODUCTSTOCK[productid]--;

                    return true;
                }
                else
                {
                    // TODO Set out of stock message here.
                    return false;
                }
            }
            else
            {
                // TODO Set invalid product message here.
                return false;
            }
        }
    }
}
