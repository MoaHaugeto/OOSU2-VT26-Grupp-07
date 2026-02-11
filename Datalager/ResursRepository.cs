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
        private readonly OOPSU2DbContext db = new OOPSU2DbContext();

        public List<Resurs> HämtaAllaResurser()
        {
            return db.Resurser.ToList();
        }

        public void LäggTillResurs(Resurs resurs)
        {
            db.Resurser.Add(resurs);
            db.SaveChanges();
        }

        public void UppdateraResurs(Resurs uppdateradResurs)
        {
            var resurs = db.Resurser
                .FirstOrDefault(r => r.ResursID == uppdateradResurs.ResursID);

            if (resurs == null) return;

            resurs.Namn = uppdateradResurs.Namn;
            resurs.Typ = uppdateradResurs.Typ;
            resurs.Kapacitet = uppdateradResurs.Kapacitet;
            resurs.Status = uppdateradResurs.Status;

            db.SaveChanges();
        }

        public void TaBortResurs(int resursID)
        {
            var resurs = db.Resurser
                .FirstOrDefault(r => r.ResursID == resursID);

            if (resurs == null) return;

            db.Resurser.Remove(resurs);
            db.SaveChanges();
        }
    }
}
