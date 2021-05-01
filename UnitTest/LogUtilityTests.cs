using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace MGS.Logger.Tests
{
    [TestClass()]
    public class LogUtilityTests
    {
        [TestMethod()]
        public void RegisterTest()
        {
            var logDir = string.Format("{0}/Log/", Environment.CurrentDirectory);
            LogUtility.Register(new FileLogger(logDir));
            Assert.IsTrue(Directory.Exists(logDir));
        }

        [TestMethod()]
        public void UnregisterTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ClearTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LogTest()
        {
            RegisterTest();
            LogUtility.Log("Log info is {0}", "LogTest");
        }

        [TestMethod()]
        public void LogErrorTest()
        {
            RegisterTest();
            LogUtility.LogError("Log error is {0}", "LogErrorTest");
        }

        [TestMethod()]
        public void LogWarningTest()
        {
            RegisterTest();
            LogUtility.LogWarning("Log warning is {0}", "LogWarningTest");
        }
    }
}