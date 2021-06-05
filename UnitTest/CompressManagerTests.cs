﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
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
            CompressManager.Instance.CompressAsync(new string[] { zipSource }, zipFile, true,
                progress =>
                {
                    Console.WriteLine("progress {0}", progress);
                },
                (isSucceed, info) =>
                {
                    waiting = false;
                    Console.WriteLine("isSucceed {0}, info {1}", isSucceed, info);
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
                (isSucceed, info) =>
                {
                    waiting = false;
                    Console.WriteLine("isSucceed {0}, info {1}", isSucceed, info);
                    Assert.IsTrue(File.Exists(zipFile));
                });

            while (waiting)
            {
                Thread.Sleep(250);
            }
        }
    }
}