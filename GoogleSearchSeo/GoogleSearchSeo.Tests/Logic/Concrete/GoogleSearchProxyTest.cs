using GoogleSearchSeo.Core.Logic.Conctract;
using GoogleSearchSeo.Logic.Concrete;
using GoogleSearchSeo.Logic.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace GoogleSearchSeo.Tests.Logic.Concrete
{
    [TestClass]
    public class GoogleSearchProxyTest
    {
        [TestMethod]
        [TestCategory("Unit")]
        public void Test_Unit_GoogleSearchProxy_GetGoogleSearchResults_HtmlDocumentFound()
        {
            Mock<ILogger> logger = new Mock<ILogger>();
            logger.Setup(s => s.Error(It.IsAny<Exception>(), It.IsAny<string>()));

            IGoogleSearchProxy sut = new GoogleSearchProxy(logger.Object);
            string htmlDocument = sut.GetGoogleSearchHtml("battery are awesome", 100);
            Assert.IsTrue(!string.IsNullOrEmpty(htmlDocument));
        }
    }
}
