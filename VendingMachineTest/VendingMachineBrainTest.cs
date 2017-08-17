using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine;

namespace VendingMachineTest
{
    [TestClass]
    public class VendingMachineBrainTest
    {
        [TestMethod]
        public void VendingMachineBrainReturnsInsertCoinWhenDisplayIsChecked()
        {
            VendingMachineBrain brain = new VendingMachine.VendingMachineBrain();
            Assert.AreEqual("INSERT COIN", brain.CheckDisplay());
        }

        [TestMethod]
        public void VendingMachineAcceptsQuarters()
        {
            VendingMachineBrain brain = new VendingMachine.VendingMachineBrain();
            Coin quarter = new Coin(0.955);
            Assert.IsTrue(brain.AcceptCoin(quarter));
        }
    }
}
