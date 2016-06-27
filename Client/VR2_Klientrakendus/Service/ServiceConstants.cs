using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VR2_Klientrakendus.Service
{
    /// <summary>
    /// This class gets the service endpoints that are described in App.config file.
    /// See klass saab teenuse endpoindid, mis on ära kirjeldatud App.config failis.
    /// </summary>
    public static class ServiceConstants
    {
        public static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static string IdApplicationServiceUrl
        {
            get { return GetValue("IdApplicationServiceUrl");}
        }

        public static string LogServiceUrl
        {
            get { return GetValue("LogServiceUrl"); }
        }
    }
}
