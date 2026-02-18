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
        //public BetalningRepository BetalningRepository { get; }
        //public BokningRepository BokningRepository { get; }
        //public MedlemRepository MedlemRepository { get;}

        //public PersonalRepository PersonalRepository { get; } 
        //public ResursRepository ResursRepository { get; }
        //public UtrustningRepository UtrustningRepository { get; } 


        public UnitOfWork(OOPSU2DbContext context)
        {
            _db = new OOPSU2DbContext();
            _db.Database.EnsureCreated();
            DbSeed.Populate(_db);

            BetalningRepository = new GenericRepository<Betalning>(context.Betalningar);
            BokningRepository = new GenericRepository<Bokning>(context.Bokningar);
            MedlemRepository = new GenericRepository<Medlem>(context.Medlemmar);
            PersonalRepository = new GenericRepository<Personal>(context.Personaler);
            ResursRepository = new GenericRepository<Resurs>(context.Resurser);
            UtrustningRepository = new GenericRepository<Utrustning>(context.Utrustningar);



            //MedlemRepository = new MedlemRepository(_db);
            //BetalningRepository = new BetalningRepository(_db);
            //BokningRepository = new BokningRepository(_db);
            //PersonalRepository = new PersonalRepository(_db);
            //ResursRepository = new ResursRepository(_db);
            //UtrustningRepository = new UtrustningRepository(_db);

        }

        

        public int Save() => _db.SaveChanges();
        public void Dispose() => _db.Dispose();

        // Tror att vi behöver ta bort dessa "private readonly OOPSU2DbContext db = new OOPSU2DbContext();" från alla repositorys för det går typ emot principerna för unitofwork som vi måste ha med
        // jag tror också att alla dina metoder du gjort som tex "LäggTillMedlem" kommer att ändras sen när vi gjort alla fönstren och knapptryck som kommer påverka


        //Unit of work läser från DBContext och sedan skickar till databasen för att sparas


    }
}
