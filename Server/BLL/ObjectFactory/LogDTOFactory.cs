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
        /// <summary>
        /// Creates document transfer objerct.
        /// Loob andmeedastus objekti.
        /// </summary>
        /// <param name="idapplication">Object that is taken from domain model. Domeenimudelist võetud objekt Log.</param>
        /// <returns>The object that will be translated according to business advantage. Objekt, mis tõlgitakse ära vastavalt ärivajadustele(Log). </returns>
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
