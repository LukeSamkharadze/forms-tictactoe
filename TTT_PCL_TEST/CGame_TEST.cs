using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TTT_PCL_TEST
{
    [TestClass]
    public class CGame_TEST
    {
        [TestMethod]
        public void CheckWinner_TEST()
        {
            Assert.AreEqual(Data_TEST.Game.CheckWinner(),Data_TEST.PlayerX);
        }
    }
}
