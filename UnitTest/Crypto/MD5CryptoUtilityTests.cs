using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MGS.Common.Crypto.Tests
{
    [TestClass()]
    public class MD5CryptoUtilityTests
    {
        [TestMethod()]
        public void ComputeHashTest()
        {
            var buffer = new byte[] { 0, 1, 2 };
            var hash = MD5CryptoUtility.ComputeHash(buffer);
            Assert.IsNotNull(hash);
            Console.WriteLine(hash);
        }

        [TestMethod()]
        public void ComputeHashTest1()
        {
            var source = "ComputeHashTest1";
            var hash = MD5CryptoUtility.ComputeHash(source);
            Assert.IsNotNull(hash);
            Console.WriteLine(hash);
        }

        [TestMethod()]
        public void ComputeFileHashTest()
        {
            var filePath = string.Format("{0}/MGS.Common.xml", Environment.CurrentDirectory);
            var hash = MD5CryptoUtility.ComputeFileHash(filePath);
            Assert.IsNotNull(hash);
            Console.WriteLine(hash);
        }
    }
}