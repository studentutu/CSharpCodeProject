using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MGS.WinUtility.Tests
{
    [TestClass()]
    public class NetworkUtilityTests
    {
        [TestMethod()]
        public void GetNetworkConnectStateTest()
        {
            var state = NetworkUtility.GetNetworkConnectState();
            Console.WriteLine("State is {0}", state);
        }

        [TestMethod()]
        public void GetMacAddressTest()
        {
            var address = NetworkUtility.GetMacAddress();
            Assert.IsNotNull(address);
            Assert.IsTrue(address.Count > 0);

            foreach (var item in address)
            {
                Console.WriteLine("addres is {0}", item);
            }
        }
    }
}