using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Threading;

namespace MGS.Common.Collection.Tests
{
    [TestClass()]
    public class EnumeratorUtilityTests
    {
        [TestMethod()]
        public void CollectTest()
        {
            var testEnum = EnumeratorUtility.Collect(DoTest_0(),
                state =>
                {
                    if (state == null)
                    {
                        return;
                    }
                    Console.WriteLine(state);
                },
                () =>
                {
                    Console.WriteLine("Conplete");
                });

            Assert.IsNotNull(testEnum);
            while (testEnum.MoveNext()) { }
        }

        [TestMethod()]
        public void CollectTest1()
        {
            var testEnum = EnumeratorUtility.Collect(
                new IEnumerator[] { DoTest_0(), DoTest_1() },
                state =>
                {
                    if (state == null)
                    {
                        return;
                    }
                    Console.WriteLine(state);
                },
                () =>
                {
                    Console.WriteLine("Conplete");
                });

            Assert.IsNotNull(testEnum);
            while (testEnum.MoveNext()) { }
        }

        [TestMethod()]
        public void QueueAsyncTest()
        {
            var testAsync = EnumeratorUtility.QueueAsync(DoTest_2());
            Assert.IsNotNull(testAsync);

            var testEnum = EnumeratorUtility.Collect(testAsync,
                state =>
                {
                    if (state == null)
                    {
                        return;
                    }
                    Console.WriteLine(state);
                },
                () =>
                {
                    Console.WriteLine("Conplete");
                });

            Assert.IsNotNull(testEnum);
            while (testEnum.MoveNext()) { }
        }

        IEnumerator DoTest_0()
        {
            yield return 0;
            yield return "1";
        }

        IEnumerator DoTest_1()
        {
            yield return new object();
            yield return this;
        }

        IEnumerator DoTest_2()
        {
            Thread.Sleep(2);
            yield return "Run in thread 25%";

            Thread.Sleep(2);
            yield return "Run in thread 50%";

            Thread.Sleep(2);
            yield return "Run in thread 75%";

            Thread.Sleep(2);
            yield return "Run in thread 100%";
        }
    }
}