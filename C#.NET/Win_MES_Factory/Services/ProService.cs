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
    public class ProService
    {
        ProDAC dac = new ProDAC();
        FacDAC facDac = new FacDAC();

        public DataTable GetAllPro()
        {
            return dac.GetAllPro();
        }

        public DataTable SearchName(ProVO vo)
        {
            return dac.SearchName(vo);
        }


        public List<FactoryVO> ComboFacGet()
        {
            return facDac.ComboFacGet();
        }

        public bool UseProID(List<int> empIDList, List<string> useList)
        {
            return dac.UseProID(empIDList, useList);
        }
        public bool SavePro(ProVO vo)
        {
            return dac.SavePro(vo);
        }
        public bool DeletePro(List<int> pro_IDList)
        {
            return dac.DeletePro(pro_IDList);
        }
        public List<ProVO> FactoryLinCombo(string facID)
        {
            return dac.FactoryLinCombo(facID);
        }

        public List<ProVO> ComboFacGetPro()  // 수정함  팩토리 dac에 있는 ComboFacGet 을 새로 만든 것으로 수정
        {
            return dac.ComboFacGetPro();
        }
    }
}
