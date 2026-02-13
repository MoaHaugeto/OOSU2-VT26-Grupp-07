using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_VT26_Grupp_07.Entiteter
{
    public class Betalning
    {
        public int BetalningID { get; set; }
        public string MedlemID { get; set; }
        public string Köpdatum { get; set; }
        public decimal Belopp { get; set; }
        public string Forfallodatum { get; set; }
        public string BataldDatum { get; set; }
        public string Status { get; set; }
    }
}
