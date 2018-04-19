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

        public static Product COLA = new Product("Cola", 100, 1, 5);
        public static Product CHIPS = new Product("Chips", 50, 2, 10);
        public static Product CANDY = new Product("Candy", 65, 3, 1);

        public static Dictionary<int, Product> PRODUCTDICTIONARY = new Dictionary<int, Product>()
        {
            {COLA.ID, COLA },
            {CHIPS.ID, CHIPS },
            {CANDY.ID, CANDY }
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
                return COINDICTIONARY[new Tuple<double, double>(diameter, weight)];
            }
            else
            {
                return 0;
            }
        }

        ///// <summary>
        ///// Gets the amount of change to return to customer.
        ///// </summary>
        ///// <returns>An amount of change to return.</returns>
        //public int MakeChange()
        //{

        //}

        /// <summary>
        /// Determines whether product is selectable by checking whether it exists, and if it is in stock.
        /// </summary>
        /// <param name="ProductCode">Code for the product the customer has requested.</param>
        /// <returns>T/F for whether the product is valid.</returns>
        public bool SelectProduct(int productid)
        {
            if (PRODUCTDICTIONARY.ContainsKey(productid))
            {
                // add valid change checks
                return PRODUCTDICTIONARY[productid].DispenseItem();
            }
            else
            {
                // Set an invalid product message here.
                return false;
            }
        }
    }
}
