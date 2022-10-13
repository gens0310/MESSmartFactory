using MESFactoryDAC;
using MESFactoryVO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win_MES_Factory.Services
{
    public class FacService
    {
        public DataTable GetAllFacCode()
        {
            using (FacDAC facdac = new FacDAC())
            {
                return facdac.GetAllFactorys();
            }
        }

        public DataTable SearchName(FactoryVO vo)
        {
            using (FacDAC dac = new FacDAC())
            {
                return dac.SearchName(vo);
            }
        }


        public bool UseFacID(List<int> cklist, List<string> uselist)
        {
            using (FacDAC dac = new FacDAC())
            {
                return dac.UseFacID(cklist, uselist);
            }
        }

        public bool FacDelete(List<int> cklist)
        {
            using (FacDAC dac = new FacDAC())
            {
                return dac.FacDelete(cklist);
            }
        }

        public bool InsertFac(FactoryVO vo)
        {
            using (FacDAC dac = new FacDAC())
            {
                return dac.InsertFac(vo);
            }
        }

        public bool UpdateFac(FactoryVO vo)
        {
            using (FacDAC dac = new FacDAC())
            {
                return dac.UpdateFac(vo);
            }

        }
    }
}
