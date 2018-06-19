using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TTT_PCL_TEST
{
    [TestClass]
    public class CGame_TEST
    {
        [TestMethod]
        public void CheckWinner_TEST()
        {
            Data_TEST.SubscribeTo_onEnd();

            Assert.AreEqual(Data_TEST.Game.CheckWinner(),Data_TEST.PlayerX);
        }
    }
}
