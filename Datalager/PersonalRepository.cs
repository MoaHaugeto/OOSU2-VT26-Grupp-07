using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_VT26_Grupp_07.Datalager
{
    internal class PersonalRepository
    {

        private readonly OOPSU2DbContext _db;

        public PersonalRepository(OOPSU2DbContext db)
        {
            _db = db;
        }


    }
}
