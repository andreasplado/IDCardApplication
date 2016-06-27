using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
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
    public class IDApplicationDTO
    {
        public int IDApplicationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public string IdNumber { get; set; }
        public string ImagePath { get; set; }
        public string Address { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string IssuerFirstName { get; set; }
        public string IssuerLastName { get; set; }
        public string IdReceiptAddress { get; set; }
        public DateTime? Added { get; set; }
        public DateTime? Deleted { get; set; }
        public DateTime? Updated { get; set; }
    }
}
