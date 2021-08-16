using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MGS.Algorithm.Tests
{
    [TestClass()]
    public class WaterCollectorTests
    {
        [TestMethod()]
        public void CollectWaterTest()
        {
            var ps = new int[] { 1, 2, 3, 1, 1, 3, 2, 1 };
            var w = WaterCollector.CollectWater(ps);
            Assert.IsTrue(w == 4);
            Console.WriteLine("water {0}", w);
        }

        [TestMethod()]
        public void CollectWatersTest()
        {
            var ps = new int[] { 1, 2, 3, 1, 1, 3, 2, 1 };
            var ws = WaterCollector.CollectWaters(ps);
            Assert.IsNotNull(ws);
            Assert.IsTrue(ws.Count == 2);

            foreach (var w in ws)
            {
                Console.WriteLine("index {0} water {1}", w.Key, w.Value);
            }
        }
    }
}