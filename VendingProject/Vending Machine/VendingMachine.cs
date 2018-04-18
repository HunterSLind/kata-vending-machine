using System;

namespace Vending_Machine
{
    public class VendingMachine
    {
        /// <summary>
        /// Determines coin validity based on diameter and weight.
        /// </summary>
        /// <param name="diameter">Diameter of the coin</param>
        /// <param name="weight">Weight of the coin</param>
        /// <returns></returns>
        public bool CheckCoinToAccept(string diameter, string weight)
        {

        }

        /// <summary>
        /// Determines what's displayed on the screen
        /// </summary>
        /// <returns>A display message for the vending machine.</returns>
        public string ScreenDisplay()
        {

        }

        /// <summary>
        /// Gets the coin value based on diameter and weight of the coin
        /// </summary>
        /// <param name="diameter">Diameter of the coin.</param>
        /// <param name="weight">Weight of the coin.</param>
        /// <returns></returns>
        public int CheckCoinValue(string diameter, string weight)
        {

        }

        /// <summary>
        /// Gets the amount of change to return to customer.
        /// </summary>
        /// <returns>An amount of change to return.</returns>
        public int MakeChange()
        {

        }

        /// <summary>
        /// Determines whether product is selectable by checking whether it exists, and if it is in stock.
        /// </summary>
        /// <param name="ProductCode">Code for the product the customer has requested.</param>
        /// <returns>T/F for whether the product is valid.</returns>
        public bool SelectProduct(string ProductCode)
        {

        }
    }
}
