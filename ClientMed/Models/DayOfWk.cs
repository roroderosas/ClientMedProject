using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientMed.Models
{
    public class DayOfWk
    {
        public int DayOfWkID { get; set; }
        public string DayOfWkName { get; set; }

        public ICollection<MedCalendar> MedCalendars { get; set; }
    }
}
