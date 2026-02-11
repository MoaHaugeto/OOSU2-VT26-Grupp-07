using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_VT26_Grupp_07.Entiteter
{
    public class Personal
    {
        public int PersonID { get; set; }
        public string Namn { get; set; }
        public string Roll { get; set; }
        public string Losenord { get; set; }

        public Medlem Medlem { get; set; }
    }
}
