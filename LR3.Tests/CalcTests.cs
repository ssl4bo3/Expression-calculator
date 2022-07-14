using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LR3.Tests
{
    public class CalcTests
    {
        private Calc calc;
        private Converter converter;
        private List<string> plug;
        private List<string> plug1;

        [SetUp]
        public void Setup()
        {
            calc = new Calc();
            converter = new Converter();
            plug = new List<string>()
            {
                "a = 2",
                "b = 5",
                "f = 10",
                "b * f + a / 4 * 3 - b",
                "a + b - f / f * 5",
            };
            plug1 = new List<string>()
            {
                "5 * 10 + 2 / 4 * 3 - 5",
            };
        }

        [Test]
        public void ConvertToDictionary()
        {
            var dic = converter.ConvertToDictionary(plug);
            Assert.AreEqual(dic["a"], 2);
            Assert.AreEqual(dic["b"], 5);
            Assert.AreEqual(dic["f"], 10);
            Assert.Throws<ArgumentNullException>(() => converter.ConvertToDictionary(null));
        }

        [Test]
        public void ReplaceLine()
        {
            var dic = converter.ConvertToDictionary(plug);
            var expression = converter.ReplaceLine(plug[3], dic);

            Assert.AreEqual(expression, "5 * 10 + 2 / 4 * 3 - 5");
            Assert.Throws<ArgumentNullException>(() => converter.ReplaceLine(null, dic));
            Assert.Throws<ArgumentNullException>(() => converter.ReplaceLine(plug[3], null));
        }


        [Test]
        public void GetOperands()
        {
            var dic = converter.ConvertToDictionary(plug);
            var list = converter.GetOperands(plug[4]);
            Assert.AreEqual(list[0], "a ");
            Assert.AreEqual(list[1], "+");
            Assert.AreEqual(list[2], " b ");
            Assert.AreEqual(list[3], "-");
            Assert.AreEqual(list[4], " f ");
            Assert.AreEqual(list[5], "/");
            Assert.AreEqual(list[6], " f ");
            Assert.AreEqual(list[7], "*");
            Assert.AreEqual(list[8], " 5");
            Assert.Throws<ArgumentNullException>(() => converter.GetOperands(null));
        }

        [Test]
         public void GetExpressionTest()
        {
            var expression = converter.GetExpression(plug1);
            Assert.AreEqual(expression[0], '5');
            Assert.AreEqual(expression[1], ' ');
            Assert.AreEqual(expression[2], '1');
            Assert.AreEqual(expression[3], '0');
            Assert.AreEqual(expression[4], ' ');
            Assert.AreEqual(expression[5], '*');
            Assert.AreEqual(expression[6], ' ');
            Assert.AreEqual(expression[7], '2');
            Assert.AreEqual(expression[8], ' ');
            Assert.AreEqual(expression[9], '4');
            Assert.AreEqual(expression[10], ' ');
            Assert.AreEqual(expression[11], '/');
            Assert.AreEqual(expression[12], ' ');
            Assert.AreEqual(expression[13], '3');
            Assert.AreEqual(expression[14], ' ');
            Assert.AreEqual(expression[15], '*');
            Assert.AreEqual(expression[16], ' ');
            Assert.AreEqual(expression[17], '5');
            Assert.AreEqual(expression[18], '-');
            Assert.AreEqual(expression[19], ' ');
            Assert.AreEqual(expression[20], '+');
            Assert.Throws<ArgumentNullException>(() => converter.GetExpression(null));
        }

        [Test]
        public void ÑalcTest()
        {
            var dic = converter.ConvertToDictionary(plug);
            var expression = converter.ReplaceLine(plug[4], dic);
            var result = calc.Calculate(expression);
            Assert.AreEqual(result, 2);
            Assert.Throws<ArgumentNullException>(() => calc.Calculate(null));
        } 
    }
}