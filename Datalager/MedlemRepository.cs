using OOSU2_VT26_Grupp_07.Entiteter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_VT26_Grupp_07.Datalager
{
    public class MedlemRepository
    {
        private readonly OOPSU2DbContext db = new OOPSU2DbContext();

        public List<Medlem> HämtaAllaMedlemmar()
        {
            return db.Medlemmar.ToList();
        }

        public void LäggTillMedlem(Medlem medlem)
        {
            db.Medlemmar.Add(medlem);
            db.SaveChanges();
        }

        //public void UppdateraMedlem();


    }
}
