using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ClientMed.Models
{
    public class MedCalendar
    {
        
        public int ID { get; set; }
        public int ClientID { get; set; }
        public int DaySchedID { get; set; }
        public int DayOfWkID { get; set; }
        public int SugarLvl { get; set; }
        public bool Done { get; set; }

        public Client Client { get; set; }
        public DaySched DaySched { get; set; }
        public DayOfWk DayOfWk { get; set; }
    }
}
