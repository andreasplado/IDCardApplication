using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VR2_Klientrakendus.Models;

namespace VR2_Klientrakendus.Service.Interfaces
{
    public interface IIDApplicationService
    {
        Task<ObservableCollection<IDApplication>> GetAll();
        Task<ObservableCollection<IDApplication>> GetByName(string searchquery);
        Task<IDApplication> GetById(int idApplicationId);
        Task<IDApplication> Add(IDApplication idApplication);
        Task<IDApplication> Update(IDApplication idApplication, int idApplicationId);
        Task<IDApplication> Delete(int idAppllicationId);
        Task<ObservableCollection<IDApplication>> GetBySearchQuery(string searchQuery);
    }
}
