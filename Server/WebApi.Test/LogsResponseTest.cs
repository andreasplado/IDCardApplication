using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using NUnit.Framework;

namespace WebApi.Test
{
    [TestFixture]
    public class LogsResponseTest
    {
        private HttpClient _client;
        private HttpResponseMessage _response;

        [SetUp]
        public void SetUp()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(Constants.baseUrl);
            _response = _client.GetAsync("api/logs").Result;
        }

        [Test]
        public void GetLogsResponseIsSuccess()
         {
            Assert.AreEqual(HttpStatusCode.OK, _response.StatusCode);
        }

        [Test]
        public void GetLogsResponseIsJson()
        {
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Assert.AreEqual("application/json", _response.Content.Headers.ContentType.MediaType);
         }

    }
}
