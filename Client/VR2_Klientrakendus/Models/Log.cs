using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VR2_Klientrakendus.Models
{
    public class Log
    {
        public int LogId { get; set; }
        public string LogText { get; set; }
        public DateTime? Added { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? Deleted { get; set; }

    }
}
