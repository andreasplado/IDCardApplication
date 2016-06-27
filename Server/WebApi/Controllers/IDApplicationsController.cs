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

        /// <summary>
        /// Gets all applied ID card applications trough url : api/idApplications
        /// Saab kõik ID kaardi taotlused läbi urli: api/idApplications
        /// </summary>
        /// <returns>All applied ID card applications in JSON format. Kõik ID kaardi taotlused JSON formaadis.</returns>
        public IHttpActionResult GetIdApplicantions()
        {
            List<IDApplicationDTO> applications = _applicationService.GetAllApplications();
            if (applications == null)
            {
                return NotFound();
            }
            return Ok(applications);
        }

        /// <summary>
        /// Gets applied ID card application by id trough url : api/idApplications/{id}
        /// Saab ühe ID kaardi taotluse id järgi läbi urli: api/idApplications/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Single applied ID card application in JSON format.Ühe ID Kaardi taotluse JSON formaadis.</returns>
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
        /// <summary>
        /// Searches ID application by search query through url: api/idapplications/{searchquery}
        /// Otsib ID kaardi taotlust läbi urli: api/idapplications/{searchquery}
        /// </summary>
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

        /// <summary>
        /// Updates one ID card application through url: api/idapplications/{id}
        /// Uuendab ühte ID kaardi taotlust läbi urli: api/idapplications/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <param name="application">ID Card application object. ID kaardi taotluse objekt.</param>
        /// <returns>Status code. Staatuskood</returns>
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

        /// <summary>
        /// Adds ID card application through url : api/idapplication
        /// Lisab ID kaardi taotluse läbi url-i : api/idapplication
        /// </summary>
        /// <param name="applicant"></param>
        /// <returns>Status code. Staatuskood</returns>
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

        /// <summary>
        /// Deletes ID card application through url: api/idapplication/{id}
        /// Kustutab ID kaardi taotluse läbi URL-i: api/idapplication/{id}
        /// </summary>
        /// <param name="id">ID card application id. ID kaardi taotluse id</param>
        /// <returns>Status code. Staatuskood</returns>
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

        /// <summary>
        /// Uploads pictrue of application through url: api/idapplication/image
        /// Laeb ülesse ID kaardi taotluse pildi läbi url-i: api/idapplication/image
        /// </summary>
        /// <returns>Status code. Staatuskood</returns>
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