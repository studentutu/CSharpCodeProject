using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MGS.Common.Threading.Tests
{
    [TestClass()]
    public class ThreadBridgeTests
    {
        [TestMethod()]
        public void EnqueueTest()
        {
            ThreadBridge.Enqueue(() =>
            {
                Console.WriteLine("EnqueueTest");
            });
        }

        [TestMethod()]
        public void DequeueTest()
        {
            EnqueueTest();
            ThreadBridge.Dequeue();
        }

        [TestMethod()]
        public void DequeueTest1()
        {
            ThreadBridge.Enqueue(() =>
            {
                Console.WriteLine("EnqueueTest1");
            });

            ThreadBridge.Enqueue(() =>
            {
                Console.WriteLine("EnqueueTest2");
            });

            //Dequeue all.
            //ThreadBridge.Dequeue();

            //Dequeue one.
            ThreadBridge.Dequeue(1);
        }
    }
}