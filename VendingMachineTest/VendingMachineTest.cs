using System;
using System.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vending_Machine;


namespace VendingMachineTest
{
    [TestClass]
    public class VendingMachineTest
    {
        VendingMachine thisMachine;



        [TestInitialize]
        public void testInit()
        {
            thisMachine = new VendingMachine();
        }

        [TestMethod]
        public void CheckCoinToAccept_Penny()
        {
            bool IsValidCoin = thisMachine.CheckCoinToAccept(VendingMachine.PENNY.Item1, VendingMachine.PENNY.Item2);
            Assert.AreEqual(IsValidCoin, false);
        }

        [TestMethod]
        public void CheckCoinToAccept_Nickel()
        {
            bool IsValidCoin = thisMachine.CheckCoinToAccept(VendingMachine.NICKEL.Item1, VendingMachine.NICKEL.Item2);
            Assert.AreEqual(IsValidCoin, true);
        }

        [TestMethod]
        public void CheckCoinToAccept_Dime()
        {
            bool IsValidCoin = thisMachine.CheckCoinToAccept(VendingMachine.DIME.Item1, VendingMachine.DIME.Item2);
            Assert.AreEqual(IsValidCoin, true);
        }

        [TestMethod]
        public void CheckCoinToAccept_Quarter()
        {
            bool IsValidCoin = thisMachine.CheckCoinToAccept(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            Assert.AreEqual(IsValidCoin, true);
        }

        [TestMethod]
        public void CheckCoinToAccept_InvalidCoin()
        {
            bool IsValidCoin = thisMachine.CheckCoinToAccept(25, 0);
            Assert.AreEqual(IsValidCoin, false);
        }


        [TestMethod]
        public void CheckCoinValue_Penny()
        {
            int CoinValue = thisMachine.CheckCoinValue(VendingMachine.PENNY.Item1, VendingMachine.PENNY.Item2);
            Assert.AreEqual(0, CoinValue);
        }

        [TestMethod]
        public void CheckCoinValue_Nickel()
        {
            int CoinValue = thisMachine.CheckCoinValue(VendingMachine.NICKEL.Item1, VendingMachine.NICKEL.Item2);
            Assert.AreEqual(5, CoinValue);
        }

        [TestMethod]
        public void CheckCoinValue_Dime()
        {
            int CoinValue = thisMachine.CheckCoinValue(VendingMachine.DIME.Item1, VendingMachine.DIME.Item2);
            Assert.AreEqual(10, CoinValue);
        }

        [TestMethod]
        public void CheckCoinValue_Quarter()
        {
            int CoinValue = thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            Assert.AreEqual(25, CoinValue);
        }

        [TestMethod]
        public void CheckCoinValue_InvalidCoin()
        {
            int CoinValue = thisMachine.CheckCoinValue(25, 0);
            Assert.AreEqual(0, CoinValue);
        }

        [TestMethod]
        public void SelectProduct_Cola_ExactAmount()
        {
            // Cola is a dollar
            thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            bool ValidProduct = thisMachine.SelectProduct(VendingMachine.COLA.ID);
            Assert.AreEqual(true, ValidProduct);
        }

        [TestMethod]
        public void SelectProduct_Chips_ExactAmount()
        {
            // Chips price is 50 cents
            thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            bool ValidProduct = thisMachine.SelectProduct(VendingMachine.CHIPS.ID);
            Assert.AreEqual(true, ValidProduct);
        }
        [TestMethod]
        public void SelectProduct_Candy_ExactAmount()
        {
            // Candy Price is 65 cents
            thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            thisMachine.CheckCoinValue(VendingMachine.DIME.Item1, VendingMachine.DIME.Item2);
            thisMachine.CheckCoinValue(VendingMachine.NICKEL.Item1, VendingMachine.NICKEL.Item2);
            bool ValidProduct = thisMachine.SelectProduct(VendingMachine.CANDY.ID);
            Assert.AreEqual(true, ValidProduct);
        }

        [TestMethod]
        public void SelectProduct_Cola_NotEnoughChange()
        {
            // Cola is a dollar
            thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            bool ValidProduct = thisMachine.SelectProduct(VendingMachine.COLA.ID);
            Assert.AreEqual(false, ValidProduct);
        }

        [TestMethod]
        public void SelectProduct_Chips_NotEnoughChange()
        {
            // Chips price is 50 cents
            thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            bool ValidProduct = thisMachine.SelectProduct(VendingMachine.CHIPS.ID);
            Assert.AreEqual(false, ValidProduct);
        }
        [TestMethod]
        public void SelectProduct_Candy_NotEnoughChange()
        {
            // Candy Price is 65 cents
            thisMachine.CheckCoinValue(VendingMachine.NICKEL.Item1, VendingMachine.NICKEL.Item2);
            bool ValidProduct = thisMachine.SelectProduct(VendingMachine.CANDY.ID);
            Assert.AreEqual(false, ValidProduct);
        }


        [TestMethod]
        public void SelectProduct_Cola_ChangeWithNoQuarters()
        {
            // Cola is a dollar
            for (int i = 0; i < 20; i++)
            {
                thisMachine.CheckCoinValue(VendingMachine.DIME.Item1, VendingMachine.DIME.Item2);
            }
            bool ValidProduct = thisMachine.SelectProduct(VendingMachine.COLA.ID);
            Assert.AreEqual(true, ValidProduct);
        }

        [TestMethod]
        public void SelectProduct_Chips_ChangeWithNoQuarters()
        {
            // Chips price is 50 cents
            for (int i = 0; i < 20; i++)
            {
                thisMachine.CheckCoinValue(VendingMachine.DIME.Item1, VendingMachine.DIME.Item2);
            }
            bool ValidProduct = thisMachine.SelectProduct(VendingMachine.CHIPS.ID);
            Assert.AreEqual(true, ValidProduct);
        }
        [TestMethod]
        public void SelectProduct_Candy_ChangeWithNoQuarters()
        {
            // Candy Price is 65 cents
            for (int i = 0; i < 50; i++)
            {
                thisMachine.CheckCoinValue(VendingMachine.NICKEL.Item1, VendingMachine.NICKEL.Item2);
            }
            bool ValidProduct = thisMachine.SelectProduct(VendingMachine.CANDY.ID);
            Assert.AreEqual(true, ValidProduct);
        }

        [TestMethod]
        public void SelectProduct_SoldOut()
        {
            bool ValidProduct = true;
            while (ValidProduct == true)
            {
                ValidProduct = thisMachine.SelectProduct(VendingMachine.COLA.ID);
            }
            Assert.AreEqual(false, ValidProduct);
        }

        [TestMethod]
        public void SelectProduct_NotEnoughMoney()
        {
            bool ValidProduct = thisMachine.SelectProduct(VendingMachine.CANDY.ID);
            Assert.AreEqual(false, ValidProduct);
        }
        [TestMethod]
        public void SelectProduct_UnableToMakeChange()
        {
            bool ValidProduct = thisMachine.SelectProduct(VendingMachine.CANDY.ID);
            Assert.AreEqual(false, ValidProduct);
        }

        [TestMethod]
        public void CollectCoin_Nickel()
        {
            int CoinValue = thisMachine.CheckCoinValue(VendingMachine.NICKEL.Item1, VendingMachine.NICKEL.Item2);
            Assert.AreEqual(thisMachine.CoinCollection[5], 1);
        }
        [TestMethod]
        public void CollectCoin_Dime()
        {
            int CoinValue = thisMachine.CheckCoinValue(VendingMachine.DIME.Item1, VendingMachine.DIME.Item2);
            Assert.AreEqual(thisMachine.CoinCollection[10], 1);
        }
        [TestMethod]
        public void CollectCoin_Quarter()
        {
            int CoinValue = thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            Assert.AreEqual(thisMachine.CoinCollection[25], 1);
        }

        [TestMethod]
        public void UpdateInsertedAmount_Nickel()
        {
            int CoinValue = thisMachine.CheckCoinValue(VendingMachine.NICKEL.Item1, VendingMachine.NICKEL.Item2);
            Assert.AreEqual(thisMachine.InsertedAmount, 5);
        }
        [TestMethod]
        public void UpdateInsertedAmount_Dime()
        {
            int CoinValue = thisMachine.CheckCoinValue(VendingMachine.DIME.Item1, VendingMachine.DIME.Item2);
            Assert.AreEqual(thisMachine.InsertedAmount, 10);
        }
        [TestMethod]
        public void UpdateInsertedAmount_Quarter()
        {
            int CoinValue = thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            Assert.AreEqual(thisMachine.InsertedAmount, 25);
        }

    }
}
