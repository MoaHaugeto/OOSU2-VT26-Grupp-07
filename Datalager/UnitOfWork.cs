using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OOSU2_VT26_Grupp_07.Entiteter;


namespace OOSU2_VT26_Grupp_07.Datalager
{
    public class UnitOfWork
    {
        private readonly OOPSU2DbContext db = new OOPSU2DbContext();

        public BetalningRepository BetalningRepository { get; set; } = new BetalningRepository();
        public BokningRepository BokningRepository { get; set; } =new BokningRepository();
        public MedlemRepository MedlemRepository { get; set; } = new MedlemRepository();

        public PersonalRepository PersonalRepository { get; set; } = new PersonalRepository();
        public ResursRepository ResursRepository { get; set; } = new ResursRepository();
        public UtrustningRepository UtrustningRepository { get; set; } = new UtrustningRepository();


        public UnitOfWork()
        {
            db.Database.EnsureCreated();
            BokningRepository = new BokningRepository();

        }

        // Tror att vi behöver ta bort dessa "private readonly OOPSU2DbContext db = new OOPSU2DbContext();" från alla repositorys för det går typ emot principerna för unitofwork som vi måste ha med
        // jag tror också att alla dina metoder du gjort som tex "LäggTillMedlem" kommer att ändras sen när vi gjort alla fönstren och knapptryck som kommer påverka


        //Unit of work läser från DBContext och sedan skickar till databasen för att sparas


    }
}
