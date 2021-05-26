using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop_Api;

namespace ShopApi.Test
{
    [TestClass]
    public class CustomerTests
    {
        private HttpClient _client;

        public CustomerTests()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [TestMethod]
        public void CustomerGetAllTest()
        {
            var request = new HttpRequestMessage(new HttpMethod("Get"), "/Api/Customers");

            var response = _client.SendAsync(request).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        [DataRow(1)]
        public void CustomerGetOneTest(int id)
        {
            var request = new HttpRequestMessage(new HttpMethod("Get"), $"/Api/Customers/{id}");

            var response = _client.SendAsync(request).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void CustomerPostTest()
        {
            var request = new HttpRequestMessage(new HttpMethod("POST"), $"/Api/Customers");

            var response = _client.SendAsync(request).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}

