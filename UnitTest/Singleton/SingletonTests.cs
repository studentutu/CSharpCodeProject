using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MGS.DesignPattern.Tests
{
    [TestClass()]
    public class SingletonTests
    {
        [TestMethod()]
        public void SingletonTest()
        {
            //Compile error
            //var instance = new TestSingleton();

            Assert.IsNotNull(TestSingleton.Instance);
            Console.WriteLine("TestSingleton.Instance is {0}", TestSingleton.Instance);
            Console.WriteLine("TestSingleton.Instance.testField is {0}", TestSingleton.Instance.testField);
        }

        public sealed class TestSingleton : Singleton<TestSingleton>
        {
            public string testField = "Test Field";

            private TestSingleton() { }
        }
    }
}