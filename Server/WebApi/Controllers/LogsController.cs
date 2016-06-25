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

        // GET: api/Logs
        public IHttpActionResult GetLogs()
        {
            List<LogDTO> logs = _logService.GetAllLogs();
            if (logs == null)
            {
                return NotFound();
            }
            return Ok(logs);
        }

        // GET: api/Logs/5
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

        // PUT: api/Logs/5
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

        // POST: api/Logs
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

        // DELETE: api/Logs/5
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