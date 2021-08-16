using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MGS.Algorithm.Tests
{
    [TestClass()]
    public class PalindromeCollectorTests
    {
        [TestMethod()]
        public void GetLongestPalindromeTest()
        {
            var str = "12321";
            var length = PalindromeCollector.GetLongestPalindrome(str);

            Assert.IsTrue(length == 5);
            Console.WriteLine("Max palindrome length of {0} is {1}", str, length);
        }

        [TestMethod()]
        public void GetLongestPalindrome0Test()
        {
            var str = "12321";
            var length = PalindromeCollector.GetLongestPalindrome0(str);

            Assert.IsTrue(length == 5);
            Console.WriteLine("Max palindrome length of {0} is {1}", str, length);
        }

        [TestMethod()]
        public void GetTheLongestPalindromeTest()
        {
            var str = "asd12321gfs7887";
            var pldm = PalindromeCollector.GetTheLongestPalindrome(str);

            Assert.IsTrue(pldm == "12321");
            Console.WriteLine("The longest palindrome of {0} is {1}", str, pldm);
        }

        [TestMethod()]
        public void CollectPalindromesTest()
        {
            var str = "asd12321gfs7887";
            var pldms = PalindromeCollector.CollectPalindromes(str);
            Assert.IsNotNull(pldms);

            foreach (var pldm in pldms)
            {
                Console.WriteLine("pldm {0}", pldm);
            }
        }
    }
}