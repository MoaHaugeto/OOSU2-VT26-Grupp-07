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



        
        //Unit of work läser från DBContext och sedan skickar till databasen för att sparas


    }
}
