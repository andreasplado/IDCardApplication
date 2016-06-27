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
    /// Asyncronous ID card application log service methods that are used in client-side application.
    /// Asünkroonsed ID kaardi taotluse logi teenusmeetodid, mida kasutatakse klientipoolses rakenduses.
    /// </summary>
    public class LogService : BaseService, ILogService
    {

        public LogService():base(ServiceConstants.LogServiceUrl)
        {
        }

        public async Task<ObservableCollection<Log>> GetAll()
        {
            return await base.GetData<ObservableCollection<Log>>(ServiceConstants.LogServiceUrl);
        }

        public async Task<Log> GetById(int groupId)
        {
            return await base.GetData<Log>(ServiceConstants.LogServiceUrl + "/" + groupId);
        }

        public async Task<Log> Add(Log log)
        {
            return await base.PostData(log);
        }

        public async Task<Log> Update(Log log, int logId)
        {
            return await base.PutData(log, logId);
        }

        public async Task<Log> Delete(int logId)
        {
            return await base.DeleteData<Log>(logId);
        }
    }
}
