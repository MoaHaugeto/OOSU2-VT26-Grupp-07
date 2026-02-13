using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_VT26_Grupp_07.Entiteter
{
    public class Medlem
    {
        public int MedlemID { get; set; }
        public string Namn { get; set; }
        public string Telefonnummer { get; set; }
        public string Email { get; set; }
        public string MedlemskapsNivå { get; set; }
        public string Betalstatus { get; set; }


        public ICollection<Bokning> Bokningar { get; set; }
        public ICollection<Betalning> Betalningar {  get; set; }

        //public List<Bokning> Bokningar { get; set; } = new List<Bokning>();
        //public List<Betalning> Betalningar { get; set; } = new List<Betalning>();

        Personal personer = new Personal();

    }
}
