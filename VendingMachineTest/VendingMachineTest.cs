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
    }
}
