using OOSU2_VT26_Grupp_07.Entiteter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_VT26_Grupp_07.Datalager
{
    public class UtrustningRepository

    {
        private readonly OOPSU2DbContext _db;

        public UtrustningRepository(OOPSU2DbContext db)
        {
            _db = db;
        }
        public List<Utrustning> HämtaAllUtrustning()
        {
            return _db.Utrustningar.ToList(); //hämtar data om Utrustning från databas
        }

        public void UppdateraResurs( Resurs uppdateradResurs) 
        {
            var resurs = _db.Resurser
               .FirstOrDefault(r => r.ResursID == uppdateradResurs.ResursID); // Matchar mot ResursID

            if (resurs == null) 
            
                resurs.ResursID = uppdateradResurs.ResursID;
                resurs.Namn = uppdateradResurs.Namn;
                resurs.Typ = uppdateradResurs.Typ;
                resurs.Kapacitet = uppdateradResurs.Kapacitet;
                resurs.Utrustning = uppdateradResurs.Utrustning;
                resurs.Status = uppdateradResurs.Status;

                //db.SaveChanges(); //sparar ny data om resurs i databbasen
           
        }
    }
}
