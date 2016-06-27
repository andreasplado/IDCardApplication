using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VR2_Klientrakendus.Service;

namespace VR2_Klientrakendus.Models
{
    /// <summary>
    /// Defines the ID card application model for an application.
    /// Defineerib ID kaardi taotluse mudeli rakenduses.
    /// </summary>
    public class IDApplication
    {
        public int  IdApplicationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public string Birthdate { get; set; }
        public string IdNumber { get; set; }
        public string ImagePath { get; set; }
        public string Address { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string IdReceiptAddress { get; set; }
        public string IssuerFirstName { get; set; }
        public string IssuerLastName { get; set; }
        public DateTime? Added { get; set; }
        public DateTime? Deleted { get; set; }
        public DateTime? Updated { get; set; }                                                                                                                                                                                
    }
}
