using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MGS.WinUtility.Tests
{
    [TestClass()]
    public class ComdlgUtilityTests
    {
        [TestMethod()]
        public void OpenFileDialogTest()
        {
            var title = "OpenFileDialogTest";
            var dir = @"C:\Program Files\";
            var filter = "*.txt";
            ComdlgUtility.OpenFileDialog(title, dir, filter);
        }

        [TestMethod()]
        public void SaveFileDialogTest()
        {
            var title = "SaveFileDialogTest";
            var dir = @"C:\Program Files\";
            var defaultName = "Default File Name";
            var filter = "*.txt";
            ComdlgUtility.SaveFileDialog(title, dir, defaultName, filter);
        }

        [TestMethod()]
        public void OpenFolderDialogTest()
        {
            var title = "OpenFolderDialogTest";
            ComdlgUtility.OpenFolderDialog(title);
        }
    }
}