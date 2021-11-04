using CreditSuisse;
using NUnit.Framework;
using System;

namespace NUnitTestProject
{
    public class Tests
    {
        readonly DateTime refe = new DateTime(2020, 12, 11);

        [SetUp]
        public void Setup()
        {
            //2000000 Private 12 / 29 / 2025
            //400000 Public 07 / 01 / 2020
            //5000000 Public 01 / 02 / 2024
            //3000000 Public 10 / 26 / 2023
            
        }

        [Test]
        public void Test1()
        {
            Trade trade = new Trade(2000000, "Private", new DateTime(2025,12,29));
            var result = trade.GetCategory(refe);
            Assert.Pass(result,"HIGHRISK");
        }

        [Test]
        public void Test2()
        {
            Trade trade = new Trade(400000, "Public", new DateTime(2020, 07, 01));
            var result = trade.GetCategory(refe);
            Assert.Pass(result, "EXPIRED");
        }

        [Test]
        public void Test3()
        {
            Trade trade = new Trade(5000000, "Public", new DateTime(2024, 01, 02));
            var result = trade.GetCategory(refe);
            Assert.Pass(result, "MEDIUMRISK");
        }

        [Test]
        public void Test4()
        {
            Trade trade = new Trade(3000000, "Public", new DateTime(2023, 10, 26));
            var result = trade.GetCategory(refe);
            Assert.Pass(result, "MEDIUMRISK");
        }
    }
}