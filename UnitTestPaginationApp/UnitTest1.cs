using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaginationApp;

namespace UnitTestPaginationApp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodValoresSaoZero()
        {

            int currentPage = 0;
            int totalPages = 0;
            int boundaries = 0;
            int around = 0;

            string metodo = Program.Paginaçao(currentPage, totalPages, boundaries, around);

            string resultadoEsperadoEsperado = "Dados inseridos não podem ser usados.";

            Assert.AreEqual(resultadoEsperadoEsperado, metodo);
        }

        [TestMethod]
        public void TestMethodValoresBoundariesAroundMaiorQueTotalPages()
        {

            int currentPage = 1;
            int totalPages = 1;
            int boundaries = 2;
            int around = 2;

            string metodo = Program.Paginaçao(currentPage, totalPages, boundaries, around);

            string resultadoEsperadoEsperado = "1";

            Assert.AreEqual(resultadoEsperadoEsperado, metodo);
        }

        [TestMethod]
        public void TestMethodValoresAroundZero()
        {

            int currentPage = 5;
            int totalPages = 10;
            int boundaries = 3;
            int around = 0;

            string metodo = Program.Paginaçao(currentPage, totalPages, boundaries, around);

            string resultadoEsperadoEsperado = "1 2 3 ... 5 ... 8 9 10";

            Assert.AreEqual(resultadoEsperadoEsperado, metodo);
        }

        [TestMethod]
        public void TestMethodValoresCurrentPageMaiorQueTotalPages()
        {

            int currentPage = 10;
            int totalPages = 1;
            int boundaries = 0;
            int around = 0;

            string metodo = Program.Paginaçao(currentPage, totalPages, boundaries, around);

            string resultadoEsperadoEsperado = "Dados inseridos não podem ser usados.";

            Assert.AreEqual(resultadoEsperadoEsperado, metodo);
        }

        [TestMethod]
        public void TestMethodValoresBoundariesAroundMaioresQueTotalPages()
        {
            int currentPage = 5;
            int totalPages = 10;
            int boundaries = 20;
            int around = 20;

            string metodo = Program.Paginaçao(currentPage, totalPages, boundaries, around);

            string resultadoEsperadoEsperado = "1 2 3 4 5 6 7 8 9 10";

            Assert.AreEqual(resultadoEsperadoEsperado, metodo);
        }

        [TestMethod]
        public void TestMethodValoresCurrentPageIgualTotalPages()
        {

            int currentPage = 10;
            int totalPages = 10;
            int boundaries = 3;
            int around = 2;

            string metodo = Program.Paginaçao(currentPage, totalPages, boundaries, around);

            string resultadoEsperadoEsperado = "1 2 3 ... 8 9 10";

            Assert.AreEqual(resultadoEsperadoEsperado, metodo);
        }

        [TestMethod]
        public void TestMethodValoresCurrentPageIgualTotalPagesComZeroBoundaries()
        {

            int currentPage = 10;
            int totalPages = 10;
            int boundaries = 0;
            int around = 0;

            string metodo = Program.Paginaçao(currentPage, totalPages, boundaries, around);

            string resultadoEsperadoEsperado = "... 10";

            Assert.AreEqual(resultadoEsperadoEsperado, metodo);
        }

        [TestMethod]
        public void TestMethodValoresCurrentPageIgualTotalPagesComAroundMasSemBoundaries()
        {

            int currentPage = 10;
            int totalPages = 10;
            int boundaries = 0;
            int around = 4;

            string metodo = Program.Paginaçao(currentPage, totalPages, boundaries, around);

            string resultadoEsperadoEsperado = "... 6 7 8 9 10";

            Assert.AreEqual(resultadoEsperadoEsperado, metodo);
        }

        [TestMethod]
        public void TestMethodValoresCurrentPageIgualTotalPagesComAroundMasSemBoundaries2()
        {

            int currentPage = 1;
            int totalPages = 10;
            int boundaries = 0;
            int around = 4;

            string metodo = Program.Paginaçao(currentPage, totalPages, boundaries, around);

            string resultadoEsperadoEsperado = "1 2 3 4 5 ...";

            Assert.AreEqual(resultadoEsperadoEsperado, metodo);
        }

        [TestMethod]
        public void TestMethodValoresBoundariesCincoAroundZero()
        {

            int currentPage = 8;
            int totalPages = 20;
            int boundaries = 5;
            int around = 0;

            string metodo = Program.Paginaçao(currentPage, totalPages, boundaries, around);

            string resultadoEsperadoEsperado = "1 2 3 4 5 ... 8 ... 16 17 18 19 20";

            Assert.AreEqual(resultadoEsperadoEsperado, metodo);
        }

        [TestMethod]
        public void TestMethodValoresBoundariesEAroundZeroCurrentPageCincoETotalPagesVinte()
        {

            int currentPage = 5;
            int totalPages = 20;
            int boundaries = 0;
            int around = 0;

            string metodo = Program.Paginaçao(currentPage, totalPages, boundaries, around);

            string resultadoEsperado = "... 5 ...";

            Assert.AreEqual(resultadoEsperado, metodo);
        }

        [TestMethod]
        public void TestMethodValoresGrandesBoundariesAroundDez()
        {

            int currentPage = 10000;
            int totalPages = 40000;
            int boundaries = 10;
            int around = 10;

            string metodo = Program.Paginaçao(currentPage, totalPages, boundaries, around);

            string resultadoEsperado = "1 2 3 4 5 6 7 8 9 10 ... 9990 9991 9992 9993 9994 9995 9996 9997 9998 9999 10000 10001 10002" +
                " 10003 10004 10005 10006 10007 10008 10009 10010 ... 39991 39992 39993 39994 39995 39996 39997 39998 39999 40000";

            Assert.AreEqual(resultadoEsperado, metodo);
        }

        [TestMethod]
        public void TestMethodValoresCurrentPageMaxValue()
        {

            int currentPage = 100000;
            int totalPages = int.MaxValue;
            int boundaries = 1;
            int around = 0;

            string metodo = Program.Paginaçao(currentPage, totalPages, boundaries, around);

            string resultadoEsperado = "1 ... 100000 ... 2147483647";

            Assert.AreEqual(resultadoEsperado, metodo);
        }

        [TestMethod]
        public void TestMethodValoresBoundariesAroundNegativos()
        {

            int currentPage = 8;
            int totalPages = 20;
            int boundaries = -1;
            int around = -2;

            string metodo = Program.Paginaçao(currentPage, totalPages, boundaries, around);

            string resultadoEsperado = "Dados inseridos não podem ser usados.";

            Assert.AreEqual(resultadoEsperado, metodo);
        }

        [TestMethod]
        public void TestMethodValoresTotalPagesNegativo()
        {

            int currentPage = 4;
            int totalPages = -2;
            int boundaries = 3;
            int around = 3;

            string metodo = Program.Paginaçao(currentPage, totalPages, boundaries, around);

            string resultadoEsperadoEsperadoEsperadoo = "Dados inseridos não podem ser usados.";

            Assert.AreEqual(resultadoEsperadoEsperadoEsperadoo, metodo);
        }
    }
}
