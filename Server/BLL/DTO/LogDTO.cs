using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class LogDTO
    {
        /// <summary>
        /// Data transfer objects.
        /// The main reason is to transfer data objects here is to show data that is needed in program business logic.
        /// At the moment we need every piece of data, so we copy the fields from Domain without code-first annotations.
        /// 
        /// Andmeedastus objektid.
        /// Peamine eesmärk miks kasutada andmeedastus objekte siin, on näidata andmeid, mida programmi äriloogikas vaja läheb.
        /// Praegusel juhul me vajame kõiki andmeid, seega me kopeerime väljad domeeni mudelist ilma code-first annotatsioonideta.
        /// </summary>
        public int LogId { get; set; }
        public string LogText { get; set; }
        public DateTime? Added { get; set; }
        public DateTime? Deleted { get; set; }
        public DateTime? Updated { get; set; }
    }
}
