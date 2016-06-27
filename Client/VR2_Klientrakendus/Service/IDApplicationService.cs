using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VR2_Klientrakendus.Models;
using VR2_Klientrakendus.Service.Interfaces;

namespace VR2_Klientrakendus.Service
{
    /// <summary>
    /// Asyncronous ID card application service methods that are used in client-side application.
    /// Asünkroonsed ID kaardi taotluse teenusmeetodid, mida kasutatakse klientipoolses rakenduses.
    /// </summary>
    public class IDApplicationService : BaseService, IIDApplicationService
    {

        public IDApplicationService() :base (ServiceConstants.IdApplicationServiceUrl)
        { 
        }
        
        public async Task<ObservableCollection<IDApplication>> GetAll()
        {
            return await base.GetData<ObservableCollection<IDApplication>>(ServiceConstants.IdApplicationServiceUrl);
        }
        public async Task<ObservableCollection<IDApplication>> GetByName (string name)
        {
            return await base.GetData<ObservableCollection<IDApplication>>(ServiceConstants.IdApplicationServiceUrl + "/" + name);
        }

        public async Task<IDApplication> GetById(int iDApplicationId)
        {
            return await base.GetData<IDApplication>(ServiceConstants.IdApplicationServiceUrl +"/" + iDApplicationId);
        }

        public async Task<IDApplication> Add(IDApplication idApplication)
        {
            return await base.PostData(idApplication);
        }

        public async Task<IDApplication> Update(IDApplication idApplication, int idApplicationId)
        {
            return await base.PutData(idApplication, idApplicationId);
        }

        public async Task<IDApplication> Delete(int idAppllicationId)
        {
            return await base.DeleteData<IDApplication>(idAppllicationId);
        }

        public async Task<ObservableCollection<IDApplication>> GetBySearchQuery(string searchQuery)
        {
            return await base.GetData<ObservableCollection<IDApplication>>(ServiceConstants.IdApplicationServiceUrl + "/" + searchQuery);
        }

    }
}
