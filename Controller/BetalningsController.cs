using OOSU2_VT26_Grupp_07.Datalager;
using OOSU2_VT26_Grupp_07.Entiteter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_VT26_Grupp_07.Controller
{
    public class BetalningsController
    {
        private readonly UnitOfWork _uow;

        public BetalningsController(UnitOfWork uow)
        {
            _uow = uow;
        }

        public List<Betalning> HämtaBetalningarFörMedlem(int medlemId)
        {
            return _uow.BetalningRepository.Find(b => b.MedlemID == medlemId).ToList();
        }

        public void RegistreraBetalning(int betalningId)
        {
            var betalning = _uow.BetalningRepository.FirstOrDefault(b => b.BetalningID == betalningId);
            if (betalning != null)
            {
                betalning.Status = "Betald";
                betalning.BataldDatum = DateTime.Now;
                _uow.BetalningRepository.Update(betalning);

                // Uppdatera även medlemmens övergripande betalstatus
                var medlem = _uow.MedlemRepository.FirstOrDefault(m => m.MedlemID == betalning.MedlemID);
                if (medlem != null)
                {
                    medlem.Betalstatus = "Betald";
                    _uow.MedlemRepository.Update(medlem);
                }

                _uow.Save();
            }
        }

    }
}
