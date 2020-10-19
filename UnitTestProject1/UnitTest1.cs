using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeomFigure;
using MyLib;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Trapeciya_Perimetr()
        {
            string[] param = { "-1" ,"10", "1", "10", "16", "2", "-7", "2" };
            double expected = 52;
            Trapeciya trap = new Trapeciya(param);
            double per = trap.perimetr;

            Assert.AreEqual(expected, per);
        }

        [TestMethod]
        public void Test_Trapeciya_Ploshad()
        {
            string[] param = { "-2", "2", "2", "2", "6", "0", "-6", "0" };
            double expected = 22.6274169979695;
            Trapeciya trap = new Trapeciya(param);
            double per = trap.ploshad;

            Assert.AreEqual(expected, per, 0.001, "Account not debited correctly");
            
        }

        [TestMethod]
        public void Test_Kvadrat_Ploshad()
        {
            string[] param = { "1","1", "2", "1", "2", "0", "1", "0" };
            double expected = 1;
            Kvadrat kvadrat = new Kvadrat(param);
            double per = kvadrat.ploshad;

            Assert.AreEqual(expected, per);
            
        }
        [TestMethod]
        public void Test_Kvadrat_Perimetr()
        {
            string[] param = { "1", "1", "2", "1", "2", "0", "1", "0" };
            double expected = 4;
            Kvadrat kvadrat = new Kvadrat(param);
            double per = kvadrat.perimetr;

            Assert.AreEqual(expected, per);

        }

        [TestMethod]
        public void Test_Okruzhnost_Perimetr()
        {
            string[] param = { "1", "3", "2"};
            double expected = 12.5663706143592;
            Okruzhnost okruzhnost = new Okruzhnost(param);
            double per = okruzhnost.perimetr;

            Assert.AreEqual(expected, per, 0.001, "Account not debited correctly");

        }


        [TestMethod]
        public void Test_Okruzhnost_Ploshad()
        {
            string[] param = { "1", "3", "2" };
            double expected = 12.5663706143592;
            Okruzhnost okruzhnost = new Okruzhnost(param);
            double per = okruzhnost.perimetr;

            Assert.AreEqual(expected, per, 0.001, "Account not debited correctly");

        }
    }
}
