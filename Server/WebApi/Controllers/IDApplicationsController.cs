using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using BLL.DTO;
using BLL.Service;
using DAL;
using Domain;

namespace WebApi.Controllers
{
    public class IDApplicationsController : ApiController
    {
        private readonly IDApplicationService _applicationService;

        public IDApplicationsController()
        {
            _applicationService = new IDApplicationService();
        }

        // GET: api/Users
        public IHttpActionResult GetIdApplicantions()
        {
            List<IDApplicationDTO> applications = _applicationService.GetAllApplications();
            if (applications == null)
            {
                return NotFound();
            }
            return Ok(applications);
        }

        // GET: api/Users/5
        [ResponseType(typeof(IDApplication))]
        public IHttpActionResult GetIdApplication(int id)
        {
            IDApplicationDTO application = _applicationService.GetIdApplicationById(id);
            if (application == null)
            {
                return NotFound();
            }

            return Ok(application);
        }
        // GET: api/Users/5
        [Route("api/idapplications/{searchquery}")]
        public IHttpActionResult GetIdApplicationByName(string searchquery)
        {
            List<IDApplicationDTO> applications = _applicationService.GetApplicationsByQuery(searchquery);
            if (applications == null)
            {
                return NotFound();
            }

            return Ok(applications);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIdApplication(int id, IDApplication application)
        {
            if (ModelState.IsValid)
            {
                _applicationService.UpdateApplication(application);
            }

            if (id != application.IDApplicationId)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(IDApplication))]
        public IHttpActionResult PostIdApplication(IDApplication applicant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _applicationService.AddApplication(applicant);

            return CreatedAtRoute("DefaultApi", new { id = applicant.IDApplicationId }, applicant);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(IDApplication))]
        public IHttpActionResult DeleteIdApplication(int id)
        {
            IDApplicationDTO application = _applicationService.GetIdApplicationById(id);
            if (application == null)
            {
                return NotFound();
            }
            _applicationService.DeleteApplication(id);

            return Ok(application);
        }

        [Route("api/idapplication/image")]
        public HttpResponseMessage PostIdApplication()
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
                    postedFile.SaveAs(filePath);
                    docfiles.Add(filePath);
                }
                result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }

    protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _applicationService.IdApplicationRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}