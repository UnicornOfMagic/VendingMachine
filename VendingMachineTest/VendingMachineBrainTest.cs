using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VendingMachine;

namespace VendingMachineTest
{
    [TestClass]
    public class VendingMachineBrainTest
    {
        VendingMachineBrain brain;
        Coin quarter;
        Coin nickel;
        Coin dime;
        Coin penny;

        [TestInitialize]
        public void SetUp()
        {
            brain = new VendingMachineBrain();
            quarter = new Coin(0.955);
            nickel = new Coin(0.835);
            dime = new Coin(0.705);
            penny = new Coin(0.750);
        }

        [TestCleanup]
        public void TearDown()
        {
            brain.Balance = 0;
            brain.Message = "";
            brain.CoinReturn = new List<Coin>();
            brain.Dispenser = new List<Product>();
        }

        [TestMethod]
        public void CoinReturnButtonShouldReturnEntireBalanceAndReturnsCoins()
        {
            brain.Balance = 0.90;
            brain.ReturnCoins();
            Assert.AreEqual(0, brain.Balance);
            Assert.IsTrue(brain.CoinReturn.Count > 0);
        }

        [TestMethod]
        public void AfterPressingCoinReturnTheDisplayShouldShowInsertCoin()
        {
            brain.Balance = 1;
            brain.ReturnCoins();
            Assert.AreEqual("INSERT COIN", brain.CheckDisplay());
        }

        #region VendingMachineBrain.SelectProduct() Tests

        [TestMethod]
        public void SelectingAProductWithInsufficientBalanceDisplaysThePriceOfTheProduct()
        {
            brain.SelectProduct(Product.Cola);
            Assert.AreEqual("1", brain.CheckDisplay());
            brain.SelectProduct(Product.Chips);
            Assert.AreEqual("0.5", brain.CheckDisplay());
            brain.SelectProduct(Product.Candy);
            Assert.AreEqual("0.65", brain.CheckDisplay());
        }

        [TestMethod]
        public void SelectingAProductWithSufficientBalanceDispensesProduct()
        {
            brain.Balance = 1;
            brain.SelectProduct(Product.Cola);
            Assert.IsTrue(brain.Dispenser.Contains(Product.Cola));
        }

        [TestMethod]
        public void SelectingAProductWithSufficientBalanceShouldNotDisplayProductPrice()
        {
            brain.Balance = 1;
            brain.SelectProduct(Product.Cola);
            Assert.AreEqual("INSERT COIN", brain.CheckDisplay());
        }

        [TestMethod]
        public void SelectingAProductWithInsufficientBalanceShouldNotDispenseTheProduct()
        {
            brain.SelectProduct(Product.Cola);
            Assert.IsFalse(brain.Dispenser.Contains(Product.Cola));
        }

        [TestMethod]
        public void SelectingAProductWithInsufficientBalanceAndThenWithASufficientBalanceShouldDisplayInsertCoin()
        {
            brain.SelectProduct(Product.Cola);
            Assert.AreEqual("1", brain.CheckDisplay());
            brain.Balance = 1;
            brain.SelectProduct(Product.Cola);
            Assert.AreEqual("INSERT COIN", brain.CheckDisplay());
        }

        [TestMethod]
        public void SelectingAProductWithExcessBalanceShouldResultInChangeBack()
        {
            brain.Balance = 1.25;
            brain.SelectProduct(Product.Cola);
            Assert.IsTrue(brain.CoinReturn.Contains(quarter));
        }

        #endregion

        #region VendingMachineBrain.CheckDisplay() Tests

        [TestMethod]
        public void VendingMachineBrainReturnsInsertCoinWhenDisplayIsChecked()
        {
            Assert.AreEqual("INSERT COIN", brain.CheckDisplay());
        }

        [TestMethod]
        public void VendingMachineBrainReturnsAmountInsertedWhenDisplayIsCheckedAfterAcceptingValidCoins()
        {
            brain.AcceptCoin(quarter);
            brain.AcceptCoin(nickel);
            brain.AcceptCoin(dime);

            Assert.AreEqual("0.4", brain.CheckDisplay());
        }

        [TestMethod]
        public void VendingMachineBrainReturnsInsertCoinIfInvalidCoinsAreInserted()
        {
            Coin invalidCoin = new Coin(0.111);
            Coin otherInvalidCoin = new Coin(0.999);

            brain.AcceptCoin(penny);
            brain.AcceptCoin(invalidCoin);
            brain.AcceptCoin(otherInvalidCoin);

            Assert.AreEqual("INSERT COIN", brain.CheckDisplay());
        }

        #endregion

        #region VendingMachineBrain.AcceptCoin() Tests

        [TestMethod]
        public void VendingMachineAcceptsQuarters()
        {
            Assert.IsTrue(brain.AcceptCoin(quarter));
        }

        [TestMethod]
        public void VendingMachineAcceptsNickels()
        {
            Assert.IsTrue(brain.AcceptCoin(nickel));
        }

        [TestMethod]
        public void VendingMachineAcceptsDimes()
        {
            Assert.IsTrue(brain.AcceptCoin(dime));
        }

        [TestMethod]
        public void VendingMachineDeclinesPennies()
        {
            Assert.IsFalse(brain.AcceptCoin(penny));
        }

        [TestMethod]
        public void VendingMachineDeclinesOddCoins()
        {
            Coin oddCoin1 = new Coin(0.123);
            Coin oddCoin2 = new Coin(0.456);
            Coin oddCoin3 = new Coin(0.789);
            Coin oddCoin4 = new Coin(0.111);
            Coin oddCoin5 = new Coin(10.20);
            Assert.IsFalse(brain.AcceptCoin(oddCoin1));
            Assert.IsFalse(brain.AcceptCoin(oddCoin2));
            Assert.IsFalse(brain.AcceptCoin(oddCoin3));
            Assert.IsFalse(brain.AcceptCoin(oddCoin4));
            Assert.IsFalse(brain.AcceptCoin(oddCoin5));
        }

        [TestMethod]
        public void DeclinedCoinsGoToTheCoinReturn()
        {
            brain.AcceptCoin(penny);
            Assert.IsTrue(brain.CoinReturn.Contains(penny));
        }

        #endregion
    }
}
