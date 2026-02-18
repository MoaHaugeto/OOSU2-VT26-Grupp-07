using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OOSU2_VT26_Grupp_07.Entiteter;
using OOSU2_VT26_Grupp_07.Controller;



namespace OOSU2_VT26_Grupp_07.Datalager
{
    public class UnitOfWork : IDisposable
    {
        private readonly OOPSU2DbContext _db;

        public GenericRepository<Betalning> BetalningRepository { get; private set; }
        public GenericRepository<Bokning> BokningRepository { get; private set; }
        public GenericRepository<Medlem> MedlemRepository { get; private set; }
        public GenericRepository<Personal> PersonalRepository { get; private set; }
        public GenericRepository<Resurs> ResursRepository { get; private set; }
        public GenericRepository<Utrustning> UtrustningRepository { get; private set; }       

        public UnitOfWork()
        {
            _db = new OOPSU2DbContext();
            _db.Database.EnsureCreated();
            DbSeed.Populate(_db);

            BetalningRepository = new GenericRepository<Betalning>(_db.Betalningar);
            BokningRepository = new GenericRepository<Bokning>(_db.Bokningar);
            MedlemRepository = new GenericRepository<Medlem>(_db.Medlemmar);
            PersonalRepository = new GenericRepository<Personal>(_db.Personaler);
            ResursRepository = new GenericRepository<Resurs>(_db.Resurser);
            UtrustningRepository = new GenericRepository<Utrustning>(_db.Utrustningar);

        }

        public int Save() => _db.SaveChanges();
        public void Dispose() => _db.Dispose();

        // Tror att vi behöver ta bort dessa "private readonly OOPSU2DbContext db = new OOPSU2DbContext();" från alla repositorys för det går typ emot principerna för unitofwork som vi måste ha med
        // jag tror också att alla dina metoder du gjort som tex "LäggTillMedlem" kommer att ändras sen när vi gjort alla fönstren och knapptryck som kommer påverka


        //Unit of work läser från DBContext och sedan skickar till databasen för att sparas


    }
}
