using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BLL.DTO;
using BLL.Service;
using DAL;
using Domain;

namespace WebApi.Controllers
{
    public class LogsController : ApiController
    {
        private readonly LogService _logService;

        public LogsController()
        {
            _logService = new LogService();
        }

        /// <summary>
        /// Gets all ID card application logs trough url : api/logs
        /// Saab ID kaardi taotluse logi läbi urli: api/idApplications
        /// </summary>
        /// <returns>All applied ID card applications in JSON format. Kõik ID kaardi taotlused JSON formaadis.</returns>
        public IHttpActionResult GetLogs()
        {
            List<LogDTO> logs = _logService.GetAllLogs();
            if (logs == null)
            {
                return NotFound();
            }
            return Ok(logs);
        }

        /// <summary>
        /// Gets log by id trough url : api/logs/{id}
        /// Saab logi id järgi läbi urli: api/logs/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code. Staatuskood</returns>
        [ResponseType(typeof(Log))]
        public IHttpActionResult GetLog(int id)
        {
            LogDTO log = _logService.GetLogById(id);
            if (log == null)
            {
                return NotFound();
            }

            return Ok(log);
        }

        /// <summary>
        /// Updates one ID card application log through url: api/logs/{id}
        /// Uuendab ühe ID kaardi taotluse logi läbi urli: api/logs/{id}
        /// </summary>
        /// <param name="id">Log id. Logi id</param>
        /// <param name="log">Log object. Logi objekt.</param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLog(int id, Log log)
        {
            if (ModelState.IsValid)
            {
                _logService.UpdateLog(log);
            }

            if (id != log.LogId)
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
        [ResponseType(typeof(Log))]
        public IHttpActionResult PostLog(Log log)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _logService.AddLog(log);

            return CreatedAtRoute("DefaultApi", new { id = log.LogId }, log);
        }

        /// <summary>
        /// Deletes ID card application log through url: api/logs/{id}
        /// Kustutab ID kaardi taotluse logi läbi URL-i: api/logs/{id}
        /// </summary>
        /// <param name="id">ID card application id. ID kaardi taotluse id</param>
        /// <returns>Status code. Staatuskood</returns>
        [ResponseType(typeof(Log))]
        public IHttpActionResult DeleteLog(int id)
        {
            LogDTO log = _logService.GetLogById(id);
            if (log == null)
            {
                return NotFound();
            }
            _logService.DeleteLog(id);

            return Ok(log);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _logService.LogRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}