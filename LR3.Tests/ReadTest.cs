using NUnit.Framework;
using System;
using System.IO;

namespace LR3.Tests
{
    class ReadTest
    {
        public class ReadingTests
        {
            private Read read;

            [SetUp]
            public void Setup()
            {
                read = new Read();
            }

            [Test]
            public void GetNextLineTest()
            {
                string fileName = "Input.txt";
                string path = Path.Combine(Environment.CurrentDirectory, @"Data\", fileName);
                var line = read.GetNextLine(path);
                Assert.AreEqual(line[0], "a = 2;");
                Assert.AreEqual(line[1], "b = 5;");
                Assert.AreEqual(line[2], "f = 10;");
                Assert.AreEqual(line[3], "b * f + a / 4 * 3 - b;");
                Assert.AreEqual(line[4], "a + b - f / f * 5;");
            }
        }
    }
}
