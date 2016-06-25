using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BLL.Service;
using NUnit.Framework;
using WebApi.Controllers;


namespace WebApi.Test
{
    [TestFixture]
    public class IDApplicationsControllerTest
    {
        private IDApplicationService _service;
        private int _count;
        private int _idApplicationId;

        [SetUp]
        public void Setup()
        {

            _service = new IDApplicationService();
            _count = _service.GetAllApplications().Count;
            _idApplicationId = _service.GetIdApplicationById(1).IDApplicationId;
        }

        [Test]
        public void GetAllIdApplicantionsTest()
        {
            Assert.IsTrue(_count > 0);
        }
        [Test]
        public void GetApplicationTest()
        {
            Assert.IsTrue(_idApplicationId.Equals(1));
        }
    }
}
