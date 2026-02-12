using OOSU2_VT26_Grupp_07.Entiteter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_VT26_Grupp_07.Datalager
{
    public class BokningRepository
    {
        private readonly OOPSU2DbContext db = new OOPSU2DbContext();

        public List<Bokning> HämtaAllaBokningar()
        {
            return db.Bokningar.ToList(); 
        }

        public void LäggTillBokning(Bokning bokning)
        {
            db.Bokningar.Add(bokning);
            db.SaveChanges();
        }

        public void UppdateraBokning(Bokning uppdateradBokning)
        {
            var bokning = db.Bokningar
                .FirstOrDefault(b => b.BokningsID == uppdateradBokning.BokningsID);

            if (bokning == null) return;

            bokning.MedlemsID = uppdateradBokning.MedlemsID;
            bokning.ResursID = uppdateradBokning.ResursID;
            bokning.Datum = uppdateradBokning.Datum;
            bokning.Starttid = uppdateradBokning.Starttid;
            bokning.Sluttid = uppdateradBokning.Sluttid;

            db.SaveChanges();
        }

        public void TaBortBokning(int bokningsID)
        {
            var bokning = db.Bokningar
                .FirstOrDefault(b => b.BokningsID == bokningsID);

            if (bokning == null) return;

            db.Bokningar.Remove(bokning);
            db.SaveChanges();



        }
    }
}
