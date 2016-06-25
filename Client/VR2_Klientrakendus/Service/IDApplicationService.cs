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

        public async Task<IDApplication> Add(IDApplication user)
        {
            return await base.PostData(user);
        }

        public async Task<IDApplication> Update(IDApplication user, int userId)
        {
            return await base.PutData(user, userId);
        }

        public async Task<IDApplication> Delete(int userId)
        {
            return await base.DeleteData<IDApplication>(userId);
        }

        public async Task<ObservableCollection<IDApplication>> GetBySearchQuery(string searchQuery)
        {
            return await base.GetData<ObservableCollection<IDApplication>>(ServiceConstants.IdApplicationServiceUrl + "/" + searchQuery);
        }

    }
}
