using System;
using System.Collections.Generic;
using System.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vending_Machine;


namespace VendingMachineTest
{
    [TestClass]
    public class VendingMachineTest
    {
        VendingMachine thisMachine;

        public static Product COLA = new Product("Cola", 100, 1);
        public static Product CHIPS = new Product("Chips", 50, 2);
        public static Product CANDY = new Product("Candy", 65, 3);

        [TestInitialize]
        public void testInit()
        {
            Dictionary<int, Product> testProdDictionary = new Dictionary<int, Product>()
            {
                {1,  new Product("Cola", 100, 1) },
                {2, new Product("Chips", 50, 2) },
                {3, new Product("Candy", 65, 3) }
             };

            Dictionary<int, int> testProdStockDictionary = new Dictionary<int, int>()
            {
                {1, 10 },
                {2, 10 },
                {3, 10 }
            };

            thisMachine = new VendingMachine(testProdDictionary, testProdStockDictionary);
        }

        ///////////////////////////////////////////
        //     Check If Coins Are Acceptable     //
        ///////////////////////////////////////////
        [TestMethod]
        public void CheckCoinToAccept_Penny()
        {
            bool IsValidCoin = thisMachine.CheckCoinToAccept(VendingMachine.PENNY.Item1, VendingMachine.PENNY.Item2);
            Assert.IsFalse(IsValidCoin);
        }
        [TestMethod]
        public void CheckCoinToAccept_Nickel()
        {
            bool IsValidCoin = thisMachine.CheckCoinToAccept(VendingMachine.NICKEL.Item1, VendingMachine.NICKEL.Item2);
            Assert.IsTrue(IsValidCoin);
        }
        [TestMethod]
        public void CheckCoinToAccept_Dime()
        {
            bool IsValidCoin = thisMachine.CheckCoinToAccept(VendingMachine.DIME.Item1, VendingMachine.DIME.Item2);
            Assert.IsTrue(IsValidCoin);
        }
        [TestMethod]
        public void CheckCoinToAccept_Quarter()
        {
            bool IsValidCoin = thisMachine.CheckCoinToAccept(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            Assert.IsTrue(IsValidCoin);
        }
        [TestMethod]
        public void CheckCoinToAccept_InvalidCoin()
        {
            bool IsValidCoin = thisMachine.CheckCoinToAccept(25, 0);
            Assert.IsFalse(IsValidCoin);
        }

        //////////////////////////////////
        //     Check Value of Coins     //
        //////////////////////////////////
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

        /////////////////////////////////////////////////
        //     Make sure coins are being collected     //
        /////////////////////////////////////////////////
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

        ///////////////////////////////////////////////////////
        //     Make sure Inserted amount is being updated    //
        ///////////////////////////////////////////////////////
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

        ///////////////////////////////////////////
        //        Check Product Selection        //
        ///////////////////////////////////////////
        [TestMethod]
        public void SelectProduct_Cola_ExactAmount()
        {
            // Cola is a dollar
            thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            bool ValidProduct = thisMachine.SelectProduct(COLA.ID);
            Assert.IsTrue(ValidProduct);
        }
        [TestMethod]
        public void SelectProduct_Chips_ExactAmount()
        {
            // Chips price is 50 cents
            thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            bool ValidProduct = thisMachine.SelectProduct(CHIPS.ID);
            Assert.IsTrue(ValidProduct);
        }
        [TestMethod]
        public void SelectProduct_Candy_ExactAmount()
        {
            // Candy Price is 65 cents
            thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            thisMachine.CheckCoinValue(VendingMachine.DIME.Item1, VendingMachine.DIME.Item2);
            thisMachine.CheckCoinValue(VendingMachine.NICKEL.Item1, VendingMachine.NICKEL.Item2);
            bool ValidProduct = thisMachine.SelectProduct(CANDY.ID);
            Assert.IsTrue(ValidProduct);
        }
        [TestMethod]
        public void SelectProduct_Cola_NotEnoughChange()
        {
            // Cola is a dollar
            thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            bool ValidProduct = thisMachine.SelectProduct(COLA.ID);
            Assert.IsFalse(ValidProduct);
        }
        [TestMethod]
        public void SelectProduct_Chips_NotEnoughChange()
        {
            // Chips price is 50 cents
            thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            bool ValidProduct = thisMachine.SelectProduct(CHIPS.ID);
            Assert.IsFalse(ValidProduct);
        }
        [TestMethod]
        public void SelectProduct_Candy_NotEnoughChange()
        {
            // Candy Price is 65 cents
            thisMachine.CheckCoinValue(VendingMachine.NICKEL.Item1, VendingMachine.NICKEL.Item2);
            bool ValidProduct = thisMachine.SelectProduct(CANDY.ID);
            Assert.IsFalse(ValidProduct);
        }
        [TestMethod]
        public void SelectProduct_Cola_ChangeWithNoQuarters()
        {
            // Cola is a dollar
            for (int i = 0; i < 20; i++)
            {
                thisMachine.CheckCoinValue(VendingMachine.DIME.Item1, VendingMachine.DIME.Item2);
            }
            bool ValidProduct = thisMachine.SelectProduct(COLA.ID);
            Assert.IsTrue(ValidProduct);
        }
        [TestMethod]
        public void SelectProduct_Chips_ChangeWithNoQuarters()
        {
            // Chips price is 50 cents
            for (int i = 0; i < 20; i++)
            {
                thisMachine.CheckCoinValue(VendingMachine.DIME.Item1, VendingMachine.DIME.Item2);
            }
            bool ValidProduct = thisMachine.SelectProduct(CHIPS.ID);
            Assert.IsTrue(ValidProduct);
        }
        [TestMethod]
        public void SelectProduct_Candy_ChangeWithNoQuarters()
        {
            // Candy Price is 65 cents
            for (int i = 0; i < 50; i++)
            {
                thisMachine.CheckCoinValue(VendingMachine.NICKEL.Item1, VendingMachine.NICKEL.Item2);
            }
            bool ValidProduct = thisMachine.SelectProduct(CANDY.ID);
            Assert.IsTrue(ValidProduct);
        }
        [TestMethod]
        public void SelectProduct_SoldOut()
        {
            bool ValidProduct = true;
            while (ValidProduct == true)
            {
                for (int i = 0; i <= 4; i++)
                {
                    thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
                }
                ValidProduct = thisMachine.SelectProduct(COLA.ID);
            }
            Assert.IsFalse(ValidProduct);
        }
        [TestMethod]
        public void SelectProduct_NotEnoughMoney()
        {
            bool ValidProduct = thisMachine.SelectProduct(CANDY.ID);
            Assert.IsFalse(ValidProduct);
        }
        [TestMethod]
        public void SelectProduct_UnableToMakeChange()
        {
            bool ValidProduct = thisMachine.SelectProduct(CANDY.ID);
            Assert.IsFalse(ValidProduct);
        }


        //////////////////////////////////
        //        Check Messages        //
        //////////////////////////////////
        [TestMethod]
        public void SelectProduct_Cola_ExactAmount_CheckMessage()
        {
            // Cola is a dollar
            thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            bool ValidProduct = thisMachine.SelectProduct(COLA.ID);
            Assert.AreEqual(thisMachine.ScreenDisplay(), VendingMachine.THANKYOUMESSAGE);
        }
        [TestMethod]
        public void SelectProduct_Chips_ExactAmount_CheckMessage()
        {
            // Chips price is 50 cents
            thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            bool ValidProduct = thisMachine.SelectProduct(CHIPS.ID);
            Assert.AreEqual(thisMachine.ScreenDisplay(), VendingMachine.THANKYOUMESSAGE);
        }
        [TestMethod]
        public void SelectProduct_Candy_ExactAmount_CheckMessage()
        {
            // Candy Price is 65 cents
            thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            thisMachine.CheckCoinValue(VendingMachine.DIME.Item1, VendingMachine.DIME.Item2);
            thisMachine.CheckCoinValue(VendingMachine.NICKEL.Item1, VendingMachine.NICKEL.Item2);
            bool ValidProduct = thisMachine.SelectProduct(CANDY.ID);
            Assert.AreEqual(thisMachine.ScreenDisplay(), VendingMachine.THANKYOUMESSAGE);
        }
        [TestMethod]
        public void SelectProduct_Cola_NotEnoughChange_CheckMessage()
        {
            // Cola is a dollar
            thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            bool ValidProduct = thisMachine.SelectProduct(COLA.ID);
            Assert.AreEqual(thisMachine.ScreenDisplay(), VendingMachine.INSERTCOINMESSAGE);
        }
        [TestMethod]
        public void SelectProduct_Chips_NotEnoughChange_CheckMessage()
        {
            // Chips price is 50 cents
            thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            bool ValidProduct = thisMachine.SelectProduct(CHIPS.ID);
            Assert.AreEqual(thisMachine.ScreenDisplay(), VendingMachine.INSERTCOINMESSAGE);
        }
        [TestMethod]
        public void SelectProduct_Candy_NotEnoughChange_CheckMessage()
        {
            // Candy Price is 65 cents
            thisMachine.CheckCoinValue(VendingMachine.NICKEL.Item1, VendingMachine.NICKEL.Item2);
            bool ValidProduct = thisMachine.SelectProduct(CANDY.ID);
            Assert.AreEqual(thisMachine.ScreenDisplay(), VendingMachine.INSERTCOINMESSAGE);
        }
        [TestMethod]
        public void SelectProduct_Cola_ChangeWithNoQuarters_CheckMessage()
        {
            // Cola is a dollar
            for (int i = 0; i < 20; i++)
            {
                thisMachine.CheckCoinValue(VendingMachine.DIME.Item1, VendingMachine.DIME.Item2);
            }
            bool ValidProduct = thisMachine.SelectProduct(COLA.ID);
            Assert.AreEqual(thisMachine.ScreenDisplay(), VendingMachine.THANKYOUMESSAGE);
        }
        [TestMethod]
        public void SelectProduct_Chips_ChangeWithNoQuarters_CheckMessage()
        {
            // Chips price is 50 cents
            for (int i = 0; i < 20; i++)
            {
                thisMachine.CheckCoinValue(VendingMachine.DIME.Item1, VendingMachine.DIME.Item2);
            }
            bool ValidProduct = thisMachine.SelectProduct(CHIPS.ID);
            Assert.AreEqual(thisMachine.ScreenDisplay(), VendingMachine.THANKYOUMESSAGE);
        }
        [TestMethod]
        public void SelectProduct_Candy_ChangeWithNoQuarters_CheckMessage()
        {
            // Candy Price is 65 cents
            for (int i = 0; i < 50; i++)
            {
                thisMachine.CheckCoinValue(VendingMachine.NICKEL.Item1, VendingMachine.NICKEL.Item2);
            }
            bool ValidProduct = thisMachine.SelectProduct(CANDY.ID);
            Assert.AreEqual(thisMachine.ScreenDisplay(), VendingMachine.THANKYOUMESSAGE);
        }
        [TestMethod]
        public void SelectProduct_SoldOut_CheckMessage()
        {
            bool ValidProduct = true;
            while (ValidProduct == true)
            {
                for(int i = 0; i < 4; i++)
                {
                    thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
                }
                ValidProduct = thisMachine.SelectProduct(COLA.ID);
            }
            Assert.AreEqual(thisMachine.ScreenDisplay(), VendingMachine.SOLDOUTMESSAGE);
        }
        [TestMethod]
        public void SelectProduct_NotEnoughMoney_CheckMessage()
        {
            bool ValidProduct = thisMachine.SelectProduct(CANDY.ID);
            Assert.AreEqual(thisMachine.ScreenDisplay(), VendingMachine.INSERTCOINMESSAGE);
        }
        [TestMethod]
        public void SelectProduct_UnableToMakeChange_CheckMessage()
        {
            for (int i = 0; i <= 4; i++)
            {
                thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            }
            bool ValidProduct = thisMachine.SelectProduct(CANDY.ID);
            Assert.AreEqual(thisMachine.ScreenDisplay(), VendingMachine.EXACTCHANGEONLYMESSAGE);
        }
        
        [TestMethod]
        public void DispenseChange_NoPurchase()
        {
            for (int i = 0; i <= 4; i++)
            {
                thisMachine.CheckCoinValue(VendingMachine.QUARTER.Item1, VendingMachine.QUARTER.Item2);
            }
            var machineChangeDictionary = thisMachine.DispenseChange();
            var compareDictionary = new Dictionary<int, int>()
            {
                {25, 4 },
                {10, 0 },
                {5, 0 }
            };
            foreach(var key in machineChangeDictionary.Keys)
            {
                Assert.AreEqual(compareDictionary[key], machineChangeDictionary[key]);
            }
        }

        [TestMethod]
        public void DispenseChange_Zero()
        {

        }

        [TestMethod]
        public void DispenseChange_Purchase()
        {

        }


    }
}
