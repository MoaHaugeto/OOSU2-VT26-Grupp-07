using OOSU2_VT26_Grupp_07.Entiteter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_VT26_Grupp_07.Datalager
{
    internal class MedlemRepository
    {
        private readonly OOPSU2DbContext _db;

        public MedlemRepository(OOPSU2DbContext db)
        {
            _db = db;
        }
        public List<Medlem> HämtaAllaMedlemmar()
        {
            return _db.Medlemmar.ToList();
        }

        public void LäggTillMedlem(Medlem medlem)
        {
            _db.Medlemmar.Add(medlem);
        }

        public bool FinnsEmail(string email)
        {
            return _db.Medlemmar.Any(m => m.Email == email);    
        }

        //public void UppdateraMedlem();


    }
}
