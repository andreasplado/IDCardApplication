using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class IDApplication
    {
        [Key]
        public int IDApplicationId { get; set; }

        [MaxLength(128)]
        public string FirstName { get; set; }
        [MaxLength(128)]
        public string LastName { get; set; }

        [MaxLength(128)]
        public string Nationality { get; set; }

        [MaxLength(1)]
        public string Gender { get; set; }

        [MaxLength(128)]
        public string BirthDate { get; set; }


        [MaxLength(16)]
        public string IdNumber { get; set; }

        [MaxLength(128)]
        public string ImagePath { get; set; }


        [MaxLength(128)]
        public string Address { get; set; }

        [MaxLength(128)]
        public string County { get; set; }


        [MaxLength(128)]
        public string Country { get; set; }

        [MaxLength(16)]
        public string ZipCode { get; set; }

        [MaxLength(16)]
        public string DocumentNr { get; set; }

        [MaxLength(128)]
        public string IssuerFirstName { get; set; }

        [MaxLength(128)]
        public string IssuerLastName { get; set; }

        [MaxLength(128)]
        public string IdReceiptAddress { get; set; }

        public DateTime? Added { get; set; }

        public DateTime? Deleted { get; set; }

        public DateTime? Updated { get; set; }
    }

}
