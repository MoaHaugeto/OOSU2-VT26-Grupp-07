using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_VT26_Grupp_07.Entiteter
{
    public class Bokning
    {
        public int BokningsID { get; set; }
        public string Datum { get; set; }
        public string MedlemsID { get; set; }
        public int ResursID { get; set; }
        public string Starttid { get; set; }
        public string Sluttid { get; set; }
    }
}
