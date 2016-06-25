using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Domain;

namespace BLL.ObjectFactory
{
    public class LogDTOFactory
    {
        public LogDTOFactory()
        {

        }

        public LogDTO CreateBasicDTO(Log log)
        {
            return new LogDTO()
            {
                Added = log.Added,
                Deleted = log.Deleted,
                LogId = log.LogId,
                LogText = log.LogText,
                Updated = log.Updated
            };
        }
    }
}
