using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MGS.Internation.Tests
{
    [TestClass()]
    public class InternationalizerTests
    {
        [TestMethod()]
        public void DeserializeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeserializeTest1()
        {
            var language = "zh_CN";
            var paragraphLines = new string[]
            {
                "Title=DeserializeTest1",
                "Date=05/01/2021"
            };
            var isSucceed = Internationalizer.Instance.Deserialize(language, paragraphLines);
            Assert.IsTrue(isSucceed);
        }

        [TestMethod()]
        public void GetLanguagesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetParagraphsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetParagraphTest()
        {
            DeserializeTest1();
            Internationalizer.Instance.Current = "zh_CN";

            var key = "Title";
            var paragraph = Internationalizer.Instance.GetParagraph(key);
            Assert.IsNotNull(paragraph);
            Console.WriteLine(paragraph);
        }

        [TestMethod()]
        public void GetParagraphTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ClearLanguageTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ClearLanguagesTest()
        {
            Assert.Fail();
        }
    }
}