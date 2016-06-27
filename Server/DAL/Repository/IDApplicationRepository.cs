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
    /// <summary>
    /// Make database queries that are not associated with business logic.
    /// Tee andmebaasi päringuid, mis ei ole seotud äriloogikaga.
    /// </summary>
    public class IDApplicationRepository : EFRepository<IDApplication>, IIDApplicationRepository
    {
        public IDApplicationRepository(IDbContext dbContext) : base(dbContext)
        {
        }

    }
}
