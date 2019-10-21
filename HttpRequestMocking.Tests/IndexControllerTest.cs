using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HttpRequestMocking;
using System.Web;
using System.Collections.Specialized;

namespace HttpRequestMocking.Tests
{
    [TestClass]
    public class IndexControllerTest
    {
        [TestMethod]
        public void createCookieNormalCase()
        {
            // Arrange
            var requestMock = new HttpRequestMock(new NameValueCollection() { { "hoge", "12345" } });
            var responseMock = new HttpResponseMock();
            var sut = new indexController();

            // Act
            sut.createCookie(requestMock, responseMock);

            // Assert
            Assert.AreEqual("hoge12345", responseMock.Cookies["hoge"].Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void createCookieQueryIsEmptyCase()
        {
            // Arrange
            var requestMock = new HttpRequestMock(null);
            var responseMock = new HttpResponseMock();
            var sut = new indexController();

            // Act
            sut.createCookie(requestMock, responseMock);
        }

        public class HttpRequestMock : HttpRequestBase
        {
            private readonly NameValueCollection _queryString;
            public HttpRequestMock(NameValueCollection queryString)
            {
                _queryString = queryString;
            }

            public override NameValueCollection QueryString => _queryString;
        }

        public class HttpResponseMock : HttpResponseBase
        {
            private readonly HttpCookieCollection _cookies = new HttpCookieCollection();
            public override HttpCookieCollection Cookies => _cookies;
        }

    }
}
