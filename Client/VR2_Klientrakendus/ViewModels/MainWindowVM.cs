using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using VR2_Klientrakendus.Models;
using VR2_Klientrakendus.Service;
using VR2_Klientrakendus.Service.Interfaces;

namespace VR2_Klientrakendus.ViewModels
{
    /// <summary>
    /// ViewModel for Mainwindow.xaml.cs.
    /// Vaatemudel MainWindow.xaml.cs-i jaoks.
    /// </summary>
    public class MainWindowVM :INotifyPropertyChanged
    {
        private readonly IIDApplicationService _idApplicationService;
        private readonly ILogService _logService;
        private ObservableCollection<IDApplication> _idApplications;
        public string _imagePath;
        private ObservableCollection<Log> _logs;
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowVM()
        {
            this._idApplications = new ObservableCollection<IDApplication>();
            this._logs = new ObservableCollection<Log>();
            this._idApplicationService = new IDApplicationService();
            this._logService = new LogService();
        }

        #region Load data
        public async void LoadApplicationsByFirstName(string firstname)
        {
            this.IdApplications.Clear();
            this.IdApplications = await this._idApplicationService.GetByName(firstname);

        }

        public async void LoadApplications()
        {
            this.IdApplications = await this._idApplicationService.GetAll();
        }

        public async void LoadLogs()
        {
            this.Logs = await this._logService.GetAll();
        }
        #endregion
        #region Add data
        public async void AddApplication(IDApplication user)
        {
            this.IdApplications.Add(await this._idApplicationService.Add(user));
        }

        public async void AddLog(Log newLog)
        {
            this.Logs.Add(await this._logService.Add(newLog));
        }
        public async void AddImage(string imagePath)
        {
           new WebClient().UploadFile("http://localhost:21855/api/idapplication/image", "POST", imagePath);
        }
        #endregion
        #region Update data
        //        public async void UpdateGroup(Group newGroup, int groupId, int listboxPosition)
        //        {
        //            this.Groups.RemoveAt(listboxPosition);
        //            Groups.Add(await this._groupService.Update(newGroup, groupId));
        //
        //        }
        #endregion
        #region Delete data
        public async void DeleteUser(int userId)
        {
            this.IdApplications.Remove(await this._idApplicationService.Delete(userId));
        }

        public async void DeleteLog(int logId)
        {
            this.Logs.Remove(await this._logService.Delete(logId));
        }
        #endregion



        #region Properties

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public ObservableCollection<IDApplication> IdApplications
        {
            get { return this._idApplications; }
            private set
            {
                _idApplications = value;
                NotifyPropertyChanged("IdApplications");
            }
        }

        public ObservableCollection<Log> Logs
        {
            get { return _logs; }
            private set
            {
                _logs = value;
                NotifyPropertyChanged("Logs");
            }
        }
        public string TheImage
        {
            get { return _imagePath; }
        }
        #endregion
    }
}
