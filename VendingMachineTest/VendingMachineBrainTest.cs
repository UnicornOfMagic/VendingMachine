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
    }
}
