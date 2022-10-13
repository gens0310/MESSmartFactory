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
    public class LineService
    {
        LineDAC dac = new LineDAC();
        FacDAC facDac = new FacDAC();
        public DataTable GetAllLine()
        {
            return dac.GetAllLine();
        }
        public List<FactoryVO> ComboFacGet()
        {
            return facDac.ComboFacGet();
        }
        public DataTable SearchName(LineVO vo)
        {
            return dac.SearchName(vo);
        }
        public bool UseLinID(List<int> empIDList, List<string> useList)
        {
            return dac.UseLinID(empIDList, useList);
        }
        public bool SaveLine(LineVO vo)
        {
            return dac.SaveLine(vo);
        }
        public bool DeleteLine(List<int> line_IDList)
        {
            return dac.DeleteLine(line_IDList);
        }
        public List<LineVO> FactoryEMPCombo(string facID)
        {
            return dac.FactoryEMPCombo(facID);
        }

    }
}
