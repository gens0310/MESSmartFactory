using MESFactoryDAC;
using MESFactoryVO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win_MES_Factory.Services
{
    public class EmpService
    {
        public DataTable GetAllEmpCode()
        {
            using(EmpDAC empdac = new EmpDAC())
            {
                return empdac.GetAllEmployees();
            }
        }

        public DataTable SearchName(EmpVO vo)
        { 
            using(EmpDAC dac = new EmpDAC())
            {
                return dac.SearchName(vo);
            }
        }

        public bool UseEmpID(List<int> cklist, List<string> uselist)
        { 
            using(EmpDAC dac = new EmpDAC())
            {
                return dac.UseEmpID(cklist, uselist);
            }
        }

        public bool EmpDelete(List<int> cklist)
        {
            using (EmpDAC dac = new EmpDAC())
            {
                return dac.EmpDelete(cklist);
            }
        }
        public EmpVO GetLoginEmployee(string employee_id, string employee_pwd)
        {
            using (EmpDAC employeeDAC = new EmpDAC())
            {
                return employeeDAC.GetLoginEmployee(employee_id, employee_pwd);
            }
        }

        public List<FactoryVO> ComboFacGet()
        {
            using (FacDAC facDAC = new FacDAC())
            {
                return facDAC.ComboFacGet();
            }
        }

        public List<RankVO> ComboRankGet()
        {
            using (EmpDAC employeeDAC = new EmpDAC())
            {
                return employeeDAC.ComboRankGet();
            }
        }

        public bool SaveEmp(EmpVO vo)
        {
            using (EmpDAC employeeDAC = new EmpDAC())
            {
                return employeeDAC.SaveEmp(vo);
            }
        }
    }
}
