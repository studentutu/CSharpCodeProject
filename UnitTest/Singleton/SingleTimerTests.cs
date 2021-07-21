using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace MGS.DesignPattern.Tests
{
    [TestClass()]
    public class SingleTimerTests
    {
        [TestMethod()]
        public void SingleTimerTest()
        {
            //Compile error
            //var instance = new TestSingleTimer();

            Assert.IsNotNull(TestSingleUpdater.Instance);
            Console.WriteLine("TestSingleTimer.Instance is {0}", TestSingleUpdater.Instance);

            Thread.Sleep(1000);
            TestSingleUpdater.Instance.Enabled = false;
            Console.WriteLine("TestSingleTimer.Instance.Enabled = false");

            Thread.Sleep(1000);
            TestSingleUpdater.Instance.Enabled = true;
            Console.WriteLine("TestSingleTimer.Instance.Enabled = true");

            Thread.Sleep(1000);
        }

        public sealed class TestSingleUpdater : SingleUpdater<TestSingleUpdater>
        {
            private TestSingleUpdater() { }

            protected override void Update(DateTime signalTime)
            {
                Console.WriteLine("TestSingleTimer Tick");
            }
        }
    }
}