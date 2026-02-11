using OOSU2_VT26_Grupp_07.Entiteter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_VT26_Grupp_07.Datalager
{
    public static class DbSeed
    {
        public static void Seed(OOPSU2DbContext db)
        {
            if (db.Medlemmar.Any()) return;

            // PERSONAL
            db.Personaler.Add(new Personal { PersonID = 1, Namn = "Sara Lindgren", Roll = "Administratör", Losenord = "Admin123!" });
            db.Personaler.Add(new Personal { PersonID = 2, Namn = "Johan Karlsson", Roll = "Receptionist", Losenord = "Rec2024!" });
            db.Personaler.Add(new Personal { PersonID = 3, Namn = "Elin Persson", Roll = "Instruktör", Losenord = "Traning#1" });
            db.Personaler.Add(new Personal { PersonID = 4, Namn = "Markus Svensson", Roll = "Systemansvarig", Losenord = "Sys@456" });

            // MEDLEMMAR
            db.Medlemmar.Add(new Medlem { MedlemsID = "M001", Namn = "Anna Andersson", Telefonnummer = "0701234567", Email = "anna@email.se", MedlemskapsNivå = "Fast", Betalstatus = "Betald" });
            db.Medlemmar.Add(new Medlem { MedlemsID = "M002", Namn = "Erik Eriksson", Telefonnummer = "0739876543", Email = "erik@email.se", MedlemskapsNivå = "Flex", Betalstatus = "Obetald" });
            db.Medlemmar.Add(new Medlem { MedlemsID = "M003", Namn = "Lisa Svensson", Telefonnummer = "0725558899", Email = "lisa@email.se", MedlemskapsNivå = "Fast", Betalstatus = "Betald" });
            db.Medlemmar.Add(new Medlem { MedlemsID = "M004", Namn = "Oskar Nilsson", Telefonnummer = "0761122334", Email = "oskar@email.se", MedlemskapsNivå = "Företag", Betalstatus = "Betald" });

            // RESURSER
            db.Resurser.Add(new Resurs { ResursID = 1, Namn = "A01", Typ = "Mötesrum", Kapacitet = 10, Status = "Tillgänglig" });
            db.Resurser.Add(new Resurs { ResursID = 2, Namn = "B01", Typ = "Skrivbord", Kapacitet = 2, Status = "Tillgänglig" });
            db.Resurser.Add(new Resurs { ResursID = 3, Namn = "C01", Typ = "Konferenssal", Kapacitet = 25, Status = "Ej tillgänglig" });

            // BOKNINGAR
            db.Bokningar.Add(new Bokning { BokningsID = 1, MedlemsID = "M001", ResursID = 1, Datum = "2026-02-01", Starttid = "10:00", Sluttid = "11:00" });
            db.Bokningar.Add(new Bokning { BokningsID = 2, MedlemsID = "M002", ResursID = 2, Datum = "2026-02-02", Starttid = "18:00", Sluttid = "19:00" });

            // BETALNINGAR
            db.Betalningar.Add(new Betalning { BetalningsID = 1, MedlemsID = "M001", Belopp = 250, Status = "Betald" });
            db.Betalningar.Add(new Betalning { BetalningsID = 2, MedlemsID = "M002", Belopp = 150, Status = "Obetald" });

            // UTRUSTNING
            db.Utrustningar.Add(new Utrustning { InventarieNummer = "U001", ArtikelNamn = "Epson Projektor", Kategori = "Projektor", Skick = "Bra", ResursID = 1 });
            db.Utrustningar.Add(new Utrustning { InventarieNummer = "U002", ArtikelNamn = "Samsung Skärm 55\"", Kategori = "Skärm", Skick = "Mycket bra", ResursID = 1 });
            db.Utrustningar.Add(new Utrustning { InventarieNummer = "U003", ArtikelNamn = "Whiteboard Standard", Kategori = "Whiteboard", Skick = "Sliten", ResursID = 2 });
            db.Utrustningar.Add(new Utrustning { InventarieNummer = "U004", ArtikelNamn = "LG Skärm 32\"", Kategori = "Skärm", Skick = "Bra", ResursID = 3 });

            db.SaveChanges();

        }
    }
}
