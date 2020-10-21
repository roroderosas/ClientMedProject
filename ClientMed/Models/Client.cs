using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientMed.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime Birthday { get; set; }
        public string MedicalHistory { get; set; }

        public ICollection<MedCalendar> MedCalendars { get; set; }
    }
}
