using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_VT26_Grupp_07.Entiteter
{
    public class Resurs
    {
        public int ResursID { get; set; }
        public string Namn { get; set; }
        public string Typ { get; set; }
        public int Kapacitet { get; set; }
        public int Utrustning { get; set; }
        public string Status { get; set; }

        public ICollection<Utrustning> Utrustningar { get; set; }
        public ICollection<Bokning> Bokningar { get; set;}

        //Utrustning utrustningar = new Utrustning();
        //Bokning bokningar = new Bokning();
    }
}
