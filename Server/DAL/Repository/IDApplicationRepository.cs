using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;
using Domain.Aggregate;

namespace DAL.Repositories
{
    public class IDApplicationRepository : EFRepository<IDApplication>, IUserRepository
    {
        public IDApplicationRepository(IDbContext dbContext) : base(dbContext)
        {
        }
        public List<ApplicantWithContactCount> GetUsersWithContactCount()
        {
            return null;
        }

    }
}
