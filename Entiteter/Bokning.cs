using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_VT26_Grupp_07.Entiteter
{
    public class Bokning
    {
        public int BokningID { get; set; }
        public DateTime Datum { get; set; }
        public int MedlemID { get; set; }
        public int ResursID { get; set; }
        public TimeSpan Starttid { get; set; }
        public TimeSpan Sluttid { get; set; }
    }
}
