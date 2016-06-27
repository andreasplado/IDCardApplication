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
    public class IDApplicationsResponseTest
    {
        private HttpClient client;
        private HttpResponseMessage response;

        [SetUp]
        public void SetUp()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(Constants.baseUrl);
            response = client.GetAsync("api/idapplications").Result;
        }

        [Test]
        public void GetResponseIsSuccess()
         {
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void GetIDApplicationsResponseIsJson()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Assert.AreEqual("application/json", response.Content.Headers.ContentType.MediaType);
         }
    }
}
