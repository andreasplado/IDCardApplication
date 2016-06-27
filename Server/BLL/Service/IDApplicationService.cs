using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.ObjectFactory;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Domain;

namespace BLL.Service
{
    public class IDApplicationService
    {

        private readonly IUserRepository _repo;
        private readonly IDApplicationDTOFactory _idApplicationDtoFactory;
        public IDApplicationRepository IdApplicationRepository;

        public IDApplicationService()
        {
            this._repo = new IDApplicationRepository(new IDApplicationDbContext());
            this._idApplicationDtoFactory = new IDApplicationDTOFactory();
            this.IdApplicationRepository = new IDApplicationRepository(new IDApplicationDbContext());
        }

        public List<IDApplicationDTO> GetApplicationsByQuery(string query)
        {
            return _repo.All.Where(x => x.FirstName.ToUpper().Contains(query)
            || x.LastName.ToUpper().Contains(query)
            || x.FirstName.ToLower().Contains(query)
            || x.LastName.ToLower().Contains(query)).Select(x => _idApplicationDtoFactory.CreateBasicDTO(x)).Distinct().ToList();
        }

        public List<IDApplicationDTO> GetApplicationsByLastName(string lastname)
        {
            return _repo.All.Where(x => x.LastName == lastname)
                .ToList().Select(x => _idApplicationDtoFactory.CreateBasicDTO(x)).ToList();
        }

        public List<IDApplicationDTO> GetAllApplications()
        {
            return _repo.All.ToList().Select(x => _idApplicationDtoFactory.CreateBasicDTO(x)).ToList();
        }

        public IDApplicationDTO GetIdApplicationById(int applicationId)
        {
            IDApplication idApplication = _repo.GetById(applicationId);
            return _idApplicationDtoFactory.CreateBasicDTO(idApplication);
        }

        public void AddApplication(IDApplication newuser)
        {
            _repo.Add(newuser);
            _repo.SaveChanges();
        }

        public void UpdateApplication(IDApplication newIdApplication)
        {
            _repo.Update(newIdApplication);
            _repo.SaveChanges();
        }

        public void DeleteApplication(int applicationId)
        {
            _repo.Delete(applicationId);
            _repo.SaveChanges();
        }

        public void Dispose()
        {
            _repo.Dispose();
        }
    }
}
