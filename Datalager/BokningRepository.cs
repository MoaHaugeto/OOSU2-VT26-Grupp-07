using OOSU2_VT26_Grupp_07.Entiteter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_VT26_Grupp_07.Datalager
{
    internal class BokningRepository
    {
        private readonly OOPSU2DbContext _db;

        public BokningRepository(OOPSU2DbContext db)
        {
            _db = db;
        }

        public List<Bokning> HämtaAllaBokningar()
        {
            return _db.Bokningar.ToList(); 
        }

        public void LäggTillBokning(Bokning bokning)
        {
            _db.Bokningar.Add(bokning);
        }

        public void UppdateraBokning(Bokning uppdateradBokning)
        {
            var bokning = _db.Bokningar
                .FirstOrDefault(b => b.BokningID == uppdateradBokning.BokningID);

            if (bokning == null) return;

            bokning.MedlemID = uppdateradBokning.MedlemID;
            bokning.ResursID = uppdateradBokning.ResursID;
            bokning.Datum = uppdateradBokning.Datum;
            bokning.Starttid = uppdateradBokning.Starttid;
            bokning.Sluttid = uppdateradBokning.Sluttid;

        }

        public void TaBortBokning(int bokningsID)
        {
            var bokning = _db.Bokningar
                .FirstOrDefault(b => b.BokningID == bokningsID);

            if (bokning == null) return;

            _db.Bokningar.Remove(bokning);

        }
    }
}
