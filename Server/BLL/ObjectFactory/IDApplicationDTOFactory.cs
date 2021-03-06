﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.Interfaces;
using Domain;

namespace BLL.ObjectFactory
{
    public class IDApplicationDTOFactory
    {
        public IDApplicationDTOFactory()
        {
            
        }
        /// <summary>
        /// Creates document transfer objerct.
        /// Loob andmeedastus objekti.
        /// </summary>
        /// <param name="idapplication">Object that is taken from domain model. Domeenimudelist võetud objekt IDApplication.</param>
        /// <returns>The object that will be translated according to business advantage. Objekt, mis tõlgitakse ära vastavalt ärivajadustele(Log). </returns>
        public IDApplicationDTO CreateBasicDTO(IDApplication idapplication)
        {
            return new IDApplicationDTO
            {
                Added = idapplication.Added,
                Address = idapplication.Address,
                Country = idapplication.County,
                County = idapplication.Country,
                Deleted = idapplication.Deleted,
                FirstName = idapplication.FirstName,
                Gender = idapplication.Gender,
                ImagePath = idapplication.ImagePath,
                LastName = idapplication.LastName,
                Nationality = idapplication.Nationality,
                Updated = idapplication.Updated,
                IDApplicationId = idapplication.IDApplicationId,
                ZipCode = idapplication.ZipCode,
                BirthDate = idapplication.BirthDate,
                IdNumber = idapplication.IdNumber,
                IdReceiptAddress = idapplication.IdReceiptAddress,
                IssuerFirstName = idapplication.IssuerFirstName,
                IssuerLastName = idapplication.IssuerLastName
            };
        }
    }
}
