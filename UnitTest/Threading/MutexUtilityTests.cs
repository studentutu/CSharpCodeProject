using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MGS.Common.Threading.Tests
{
    [TestClass()]
    public class MutexUtilityTests
    {
        [TestMethod()]
        public void GetMutexNameTest()
        {
            var name = "TEST_MUTEX";
            var globalMutexName = MutexUtility.GetMutexName(name);
            Console.WriteLine("globalMutexName is {0}", globalMutexName);
            Assert.IsNotNull(globalMutexName);

            var localMutexName = MutexUtility.GetMutexName(name, false);
            Console.WriteLine("localMutexName is {0}", localMutexName);
            Assert.IsNotNull(localMutexName);
        }

        [TestMethod()]
        public void GetMutexNameForPathTest()
        {
            var path = Environment.CurrentDirectory;
            var globalMutexName = MutexUtility.GetMutexNameForPath(path);
            Console.WriteLine("globalMutexName is {0} for path {1}", globalMutexName, path);
            Assert.IsNotNull(globalMutexName);

            var localMutexName = MutexUtility.GetMutexName(path, false);
            Console.WriteLine("localMutexName is {0} for path {1}", globalMutexName, path);
            Assert.IsNotNull(localMutexName);
        }

        [TestMethod()]
        public void WaitMutexTest()
        {
            var path = Environment.CurrentDirectory;
            var globalMutexName = MutexUtility.GetMutexNameForPath(path);

            Console.WriteLine("Start wait mutex for path {0}", path);
            var mutex = MutexUtility.WaitMutex(globalMutexName);
            Console.WriteLine("End wait mutex {0} for path {1}", mutex, path);
            Assert.IsNotNull(mutex);
            mutex.ReleaseMutex();
        }

        [TestMethod()]
        public void WaitMutexTest1()
        {
            var path = Environment.CurrentDirectory;
            var globalMutexName = MutexUtility.GetMutexNameForPath(path);

            Console.WriteLine("Start wait mutex to do work base path {0}", path);
            var isSucceed = MutexUtility.WaitMutex(globalMutexName, () =>
            {
                Console.WriteLine("end wait mutex to do work base path {0}", path);
            });
            Console.WriteLine("Wait mutex to do work result is {0} base path {1}", isSucceed, path);
        }
    }
}