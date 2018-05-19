using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CowTipping.Messages
{
    public class TimeToTipACow
    {
        public string NameOfCow { get; set; }
        public DateTime EventTime { get;set; }

        public TimeToTipACow(string nameOfCow, DateTime eventTime)
        {
            NameOfCow = nameOfCow;
            EventTime = eventTime;
        }
    }
}
