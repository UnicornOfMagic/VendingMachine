using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine;

namespace VendingMachineTest
{
    [TestClass]
    public class VendingMachineBrainTest
    {
        VendingMachineBrain brain;

        [TestInitialize]
        public void SetUp()
        {
            brain = new VendingMachineBrain();
        }

        [TestMethod]
        public void VendingMachineBrainReturnsInsertCoinWhenDisplayIsChecked()
        {
            Assert.AreEqual("INSERT COIN", brain.CheckDisplay());
        }

        [TestMethod]
        public void VendingMachineAcceptsQuarters()
        {
            Coin quarter = new Coin(0.955);
            Assert.IsTrue(brain.AcceptCoin(quarter));
        }
    }
}
