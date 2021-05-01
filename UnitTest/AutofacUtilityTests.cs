using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Autofac.Tests
{
    [TestClass()]
    public class AutofacUtilityTests
    {
        [TestMethod()]
        public void RegisterTest()
        {
            // Register the mark types defined in assemblies of current app domain.
            AutofacUtility.Register();
        }

        [TestMethod()]
        public void RegisterTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RegisterTest2()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RegisterTest3()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ResolveTest()
        {
            RegisterTest();

            // The instance is Test.
            var test = AutofacUtility.Resolve<ITest>();
            Assert.IsNotNull(test);
            test.DoTest();
        }

        [TestMethod()]
        public void ResolveKeyedTest()
        {
            RegisterTest();

            // The instance is TestDebug.
            var testDebug = AutofacUtility.ResolveKeyed<ITest>("Debug");
            Assert.IsNotNull(testDebug);
            testDebug.DoTest();
        }
    }

    public interface ITest
    {
        void DoTest();
    }

    [AutofacRegister]
    internal class Test : ITest
    {
        public void DoTest()
        {
            Console.WriteLine("Test.DoTest()");
        }
    }

    // Use ServiceKey to mark type; you can resolve instance of this type by ServiceKey.
    [AutofacRegister(ServiceKey = "Debug", ServiceType = typeof(ITest))]
    internal class TestDebug : ITest
    {
        public void DoTest()
        {
            Console.WriteLine("TestDebug.DoTest()");
        }
    }
}