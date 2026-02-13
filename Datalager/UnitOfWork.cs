using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OOSU2_VT26_Grupp_07.Entiteter;


namespace OOSU2_VT26_Grupp_07.Datalager
{
    public class UnitOfWork : IDisposable
    {
        private readonly OOPSU2DbContext _db;


        public BetalningRepository BetalningRepository { get; }
        public BokningRepository BokningRepository { get; }
        public MedlemRepository MedlemRepository { get;}

        public PersonalRepository PersonalRepository { get; } 
        public ResursRepository ResursRepository { get; }
        public UtrustningRepository UtrustningRepository { get; } 


        public UnitOfWork()
        {
            _db = new OOPSU2DbContext();
            _db.Database.EnsureCreated();
            DbSeed.Populate(_db);

            MedlemRepository = new MedlemRepository(_db);
            BetalningRepository = new BetalningRepository(_db);
            BokningRepository = new BokningRepository(_db);
            PersonalRepository = new PersonalRepository(_db);
            ResursRepository = new ResursRepository(_db);
            UtrustningRepository = new UtrustningRepository(_db);

        }

        

        public int Save() => _db.SaveChanges();
        public void Dispose() => _db.Dispose();

        // Tror att vi behöver ta bort dessa "private readonly OOPSU2DbContext db = new OOPSU2DbContext();" från alla repositorys för det går typ emot principerna för unitofwork som vi måste ha med
        // jag tror också att alla dina metoder du gjort som tex "LäggTillMedlem" kommer att ändras sen när vi gjort alla fönstren och knapptryck som kommer påverka


        //Unit of work läser från DBContext och sedan skickar till databasen för att sparas


    }
}
