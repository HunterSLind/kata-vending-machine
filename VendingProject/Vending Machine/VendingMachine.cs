﻿using System;
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


        /// <summary>
        /// Determines coin validity based on diameter and weight.
        /// </summary>
        /// <param name="diameter">Diameter of the coin, in Millimeters</param>
        /// <param name="weight">Weight of the coin, in Grams</param>
        /// <returns>T/F for whether the coin is acceptable.</returns>
        public bool CheckCoinToAccept(double diameter, double weight)
        {
            if (NICKEL.Item1 == diameter && NICKEL.Item2 == weight)
            {
                return true;
            }
            else if (DIME.Item1 == diameter && DIME.Item2 == weight)
            {
                return true;
            }
            else if (QUARTER.Item1 == diameter && QUARTER.Item2 == weight)
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

        ///// <summary>
        ///// Gets the coin value based on diameter and weight of the coin
        ///// </summary>
        ///// <param name="diameter">Diameter of the coin, in Millimeters</param>
        ///// <param name="weight">Weight of the coin, in Grams</param>
        ///// <returns>A coin value in cents</returns>
        //public int CheckCoinValue(double diameter, double weight)
        //{

        //}

        ///// <summary>
        ///// Gets the amount of change to return to customer.
        ///// </summary>
        ///// <returns>An amount of change to return.</returns>
        //public int MakeChange()
        //{

        //}

        ///// <summary>
        ///// Determines whether product is selectable by checking whether it exists, and if it is in stock.
        ///// </summary>
        ///// <param name="ProductCode">Code for the product the customer has requested.</param>
        ///// <returns>T/F for whether the product is valid.</returns>
        //public bool SelectProduct(string ProductCode)
        //{

        //}
    }
}
