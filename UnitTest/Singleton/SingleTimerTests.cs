using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Timers;

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

            Assert.IsNotNull(TestSingleTimer.Instance);
            Console.WriteLine("TestSingleTimer.Instance is {0}", TestSingleTimer.Instance);

            Thread.Sleep(1000);
            TestSingleTimer.Instance.Enabled = false;
            Console.WriteLine("TestSingleTimer.Instance.Enabled = false");

            Thread.Sleep(1000);
            TestSingleTimer.Instance.Enabled = true;
            Console.WriteLine("TestSingleTimer.Instance.Enabled = true");

            Thread.Sleep(1000);
        }

        public sealed class TestSingleTimer : SingleTimer<TestSingleTimer>
        {
            private TestSingleTimer() { }

            protected override void TickUpdate(object sender, ElapsedEventArgs e)
            {
                Console.WriteLine("TestSingleTimer TickUpdate");
            }
        }
    }
}