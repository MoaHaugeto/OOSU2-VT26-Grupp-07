using OOSU2_VT26_Grupp_07.Entiteter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OOSU2_VT26_Grupp_07.Datalager
{
    public static class DbSeed
    {
        public static void Populate(OOPSU2DbContext _db)
        {
            if (_db.Medlemmar.Any() || _db.Personaler.Any() || _db.Resurser.Any() || _db.Bokningar.Any() || _db.Betalningar.Any() || _db.Utrustningar.Any())
                return;

            // PERSONAL
            _db.Personaler.Add(new Personal { Namn = "Sara Lindgren", Roll = "Administratör", Losenord = "Admin123!" });
            _db.Personaler.Add(new Personal { Namn = "Johan Karlsson", Roll = "Receptionist", Losenord = "Rec2024!" });
            _db.Personaler.Add(new Personal { Namn = "Elin Persson", Roll = "Instruktör", Losenord = "Traning#1" });
            _db.Personaler.Add(new Personal { Namn = "Markus Svensson", Roll = "Systemansvarig", Losenord = "Sys@456" });

            // MEDLEMMAR
            _db.Medlemmar.Add(new Medlem { Namn = "Anna Andersson", Telefonnummer = "0701234567", Email = "anna@email.se", MedlemskapsNivå = "Fast", Betalstatus = "Betald" });
            _db.Medlemmar.Add(new Medlem { Namn = "Erik Eriksson", Telefonnummer = "0739876543", Email = "erik@email.se", MedlemskapsNivå = "Flex", Betalstatus = "Obetald" });
            _db.Medlemmar.Add(new Medlem { Namn = "Lisa Svensson", Telefonnummer = "0725558899", Email = "lisa@email.se", MedlemskapsNivå = "Fast", Betalstatus = "Betald" });
            _db.Medlemmar.Add(new Medlem { Namn = "Oskar Nilsson", Telefonnummer = "0761122334", Email = "oskar@email.se", MedlemskapsNivå = "Företag", Betalstatus = "Betald" });

            // RESURSER
            _db.Resurser.Add(new Resurs { Namn = "A01", Typ = "Mötesrum", Kapacitet = 10, Status = "Tillgänglig" });
            _db.Resurser.Add(new Resurs { Namn = "B01", Typ = "Skrivbord", Kapacitet = 2, Status = "Tillgänglig" });
            _db.Resurser.Add(new Resurs { Namn = "C01", Typ = "Konferenssal", Kapacitet = 25, Status = "Ej tillgänglig" });

            // BOKNINGAR
            _db.Bokningar.Add(new Bokning { Datum = "2026-02-01", Starttid = "10:00", Sluttid = "11:00" });
            _db.Bokningar.Add(new Bokning { Datum = "2026-02-02", Starttid = "18:00", Sluttid = "19:00" });

            // BETALNINGAR
            _db.Betalningar.Add(new Betalning { Belopp = 250, Status = "Betald" });
            _db.Betalningar.Add(new Betalning { Belopp = 150, Status = "Obetald" });

            // UTRUSTNING
            _db.Utrustningar.Add(new Utrustning { ArtikelNamn = "Epson Projektor", Kategori = "Projektor", Skick = "Bra"});
            _db.Utrustningar.Add(new Utrustning { ArtikelNamn = "Samsung Skärm 55\"", Kategori = "Skärm", Skick = "Mycket bra" });
            _db.Utrustningar.Add(new Utrustning { ArtikelNamn = "Whiteboard Standard", Kategori = "Whiteboard", Skick = "Sliten" });
            _db.Utrustningar.Add(new Utrustning { ArtikelNamn = "LG Skärm 32\"", Kategori = "Skärm", Skick = "Bra" });

            _db.SaveChanges();

        }
    }
}
