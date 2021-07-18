using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MGS.WinUtility.Tests
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