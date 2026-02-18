using OOSU2_VT26_Grupp_07.Datalager;
using OOSU2_VT26_Grupp_07.Entiteter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_VT26_Grupp_07.Controller
{
    public class ResursController
    {
        private readonly UnitOfWork _uow;

        public ResursController(UnitOfWork uow)
        {
            _uow = uow;
        }

        public List<Resurs> HämtaAllaResurser()
        {
            return _uow.ResursRepository.GetAll().ToList();
        }

        public List<Resurs> HämtaTillgängligaResurser()
        {
            return _uow.ResursRepository.Find(r => r.Status == "Tillgänglig").ToList();
        }

        public void UppdateraResursStatus(int resursId, string nyStatus)
        {
            var resurs = _uow.ResursRepository.FirstOrDefault(r => r.ResursID == resursId);
            if (resurs != null)
            {
                resurs.Status = nyStatus;
                _uow.ResursRepository.Update(resurs);
                _uow.Save();
            }
        }

    }
}
