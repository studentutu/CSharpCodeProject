using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;
using System.Threading;

namespace MGS.Compress.Tests
{
    [TestClass()]
    public class CompressManagerTests
    {
        [TestMethod()]
        public void CompressAsyncTest()
        {
            var zipSource = string.Format("{0}/ZipSource/", Environment.CurrentDirectory);
            var zipFile = string.Format("{0}/ZipFile.zip", Environment.CurrentDirectory);

            var waiting = true;
            CompressManager.Instance.CompressAsync(new string[] { zipSource },
                zipFile, Encoding.UTF8, "CustomDir", true,
                progress =>
                {
                    Console.WriteLine("progress {0}", progress);
                },
                (isSucceed, info, error) =>
                {
                    waiting = false;
                    Console.WriteLine("isSucceed {0}, info {1}, error is {2}", isSucceed, info, error);
                    Assert.IsTrue(File.Exists(zipFile));
                });

            while (waiting)
            {
                Thread.Sleep(250);
            }
        }

        [TestMethod()]
        public void DecompressAsyncTest()
        {
            var zipFile = string.Format("{0}/ZipFile.zip", Environment.CurrentDirectory);
            var zipDir = string.Format("{0}/ZipDir/", Environment.CurrentDirectory);

            var waiting = true;
            CompressManager.Instance.DecompressAsync(zipFile, zipDir, true,
                progress =>
                {
                    Console.WriteLine("progress {0}", progress);
                },
                (isSucceed, info, error) =>
                {
                    waiting = false;
                    Console.WriteLine("isSucceed {0}, info {1}, error is {2}", isSucceed, info, error);
                    Assert.IsTrue(File.Exists(zipFile));
                });

            while (waiting)
            {
                Thread.Sleep(250);
            }
        }
    }
}