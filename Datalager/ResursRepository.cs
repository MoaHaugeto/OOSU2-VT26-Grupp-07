using OOSU2_VT26_Grupp_07.Entiteter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_VT26_Grupp_07.Datalager
{
    public class ResursRepository
    {
        private readonly OOPSU2DbContext _db;

        public ResursRepository(OOPSU2DbContext db)
        {
            _db = db;
        }
        public List<Resurs> HämtaAllaResurser()
        {
            return _db.Resurser.ToList();
        }

        public void LäggTillResurs(Resurs resurs)
        {
            _db.Resurser.Add(resurs);
        }

        public void UppdateraResurs(Resurs uppdateradResurs)
        {
            var resurs = _db.Resurser
                .FirstOrDefault(r => r.ResursID == uppdateradResurs.ResursID);

            if (resurs == null) return;

            resurs.Namn = uppdateradResurs.Namn;
            resurs.Typ = uppdateradResurs.Typ;
            resurs.Kapacitet = uppdateradResurs.Kapacitet;
            resurs.Status = uppdateradResurs.Status;

        }
        public void TaBortResurs(int resursID)
        {
            var resurs = _db.Resurser
                .FirstOrDefault(r => r.ResursID == resursID);

            if (resurs == null) return;

            _db.Resurser.Remove(resurs);
        }
    }
}
