using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using DAL.Interfaces;
using DAL.Repositories;
using Domain;

namespace DAL.Repository
{
    /// <summary>
    /// Make database queries that are not associated with business logic.
    /// Tee andmebaasi päringuid, mis ei ole seotud äriloogikaga.
    /// </summary>
    public class LogRepository : EFRepository<Log>, ILogRepository
    {
        public LogRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
