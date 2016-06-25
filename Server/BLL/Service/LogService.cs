using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.ObjectFactory;
using DAL;
using DAL.Interface;
using DAL.Repositories;
using DAL.Repository;
using Domain;

namespace BLL.Service
{
    public class LogService
    {
        
        private readonly ILogRepository _repo;
        private readonly LogDTOFactory _logDtoFactory;
        public LogRepository LogRepository;

        public LogService()
        {
            this._repo = new LogRepository(new IDApplicationDbContext());
            this._logDtoFactory = new LogDTOFactory();
            this.LogRepository = new LogRepository(new IDApplicationDbContext());
        }


        public List<LogDTO> GetAllLogs()
        {
            return _repo.All.ToList().Select(x => _logDtoFactory.CreateBasicDTO(x)).ToList();
        }

        public LogDTO GetLogById(int logId)
        {
            Log log = _repo.GetById(logId);
            return _logDtoFactory.CreateBasicDTO(log);
        }

        public void AddLog(Log newLog)
        {
            _repo.Add(newLog);
            _repo.SaveChanges();
        }

        public void UpdateLog(Log newLog)
        {
            _repo.Update(newLog);
            _repo.SaveChanges();
        }

        public void DeleteLog(int logId)
        {
            _repo.Delete(logId);
            _repo.SaveChanges();
        }

        public void Dispose()
        {
            _repo.Dispose();
        }
    }
}
