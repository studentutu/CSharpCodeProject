using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MGS.WinCommon.Utility.Tests
{
    [TestClass()]
    public class ExplorerUtilityTests
    {
        [TestMethod()]
        public void ShowTest()
        {
            var path = @"C:\Program Files\";
            ExplorerUtility.Show(path, true, true);
        }
    }
}