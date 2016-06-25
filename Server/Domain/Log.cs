using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Log
    {
        [Key]
        public int LogId { get; set; }


        [MinLength(3)]
        [MaxLength(160)]
        public string LogText { get; set; }

        public DateTime? Added { get; set; }

        public DateTime? Deleted { get; set; }

        public DateTime? Updated { get; set; }
    }
}
