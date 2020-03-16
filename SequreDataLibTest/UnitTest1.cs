using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureDataLib;
using System.Net;

namespace SequreDataLibTest
{
    [TestClass]
    public class ResultCreaterTests
    {
        [TestMethod]
        public void CreateHttpResultFromGetUri()
        {
            HttpResult httpResult = new HttpResult { Url = "http://test.com?user=max&pass=123456" };
            httpResult = ResultCreater.CreateHttpResult(httpResult);
            Assert.AreEqual(httpResult.Url, "http://test.com?user=XXX&pass=XXXXXX");
        }
        [TestMethod]
        public void CreateHttpResultFromRestUri()
        {
            HttpResult httpResult = new HttpResult { Url = "http://test.com/users/max/info?pass=123456" };
            httpResult = ResultCreater.CreateHttpResult(httpResult);
            Assert.AreEqual(httpResult.Url, "http://test.com/users/XXX/info?pass=XXXXXX");
        }

        [TestMethod]
        public void CreateHttpResultFromJson() {
              var bookingcomHttpResult = new HttpResult
                   {
                       Url = "http://test.com/users/max/info?pass=123456",
                       RequestBody = "http://test.com?user=max&pass=123456",
                       ResponseBody = "http://test.com?user=max&pass=123456",
                   };
            bookingcomHttpResult = ResultCreater.CreateHttpResult(bookingcomHttpResult);
            Assert.AreEqual(bookingcomHttpResult.Url, "http://test.com/users/XXX/info?pass=XXXXXX");
            Assert.AreEqual(bookingcomHttpResult.RequestBody, "http://test.com?user=XXX&pass=XXXXXX");
            Assert.AreEqual(bookingcomHttpResult.ResponseBody, "http://test.com?user=XXX&pass=XXXXXX");
        }
    }
}
