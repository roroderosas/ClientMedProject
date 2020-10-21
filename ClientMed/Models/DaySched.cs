using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientMed.Models
{
    public class DaySched
    {
        public int DaySchedID { get; set; }
        public string DaySchedName { get; set; }

        public ICollection<MedCalendar> MedCalendars { get; set; }
    }
}
