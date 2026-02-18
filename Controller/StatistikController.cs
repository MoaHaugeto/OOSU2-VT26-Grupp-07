using OOSU2_VT26_Grupp_07.Datalager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_VT26_Grupp_07.Controller
{
    public class StatistikController
    {
        private readonly UnitOfWork _uow;

        public StatistikController(UnitOfWork uow)
        {
            _uow = uow;
        }

        public int TotaltAntalMedlemmar()
        {
            return _uow.MedlemRepository.Count();
        }

        public int AntalAktivaBokningar()
        {
            return _uow.BokningRepository.Count();
        }

        public decimal TotalIntäkt()
        {
            return _uow.BetalningRepository.Find(b => b.Status == "Betald").Sum(b => b.Belopp);
        }

    }
}
