using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregate
{
    public class ApplicantWithContactCount
    {
        //Need klassid esinevad väiksemaid infokilde.
        //These classes represent smaller pieces of data. 
        public IDApplication Application { get; set; }

        public int ContactCount { get; set; }

    }
}
