using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.WebMVC.Command
{
    public class DailyTimeRecordEditCommand
    {

        public DateTime Date { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }
    }
}
