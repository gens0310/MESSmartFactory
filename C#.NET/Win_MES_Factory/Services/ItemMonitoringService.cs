using MESFactoryDAC;
using MESFactoryVO;
using System.Collections.Generic;
using System.Data;
namespace Win_MES_Factory.Services
{
    public class ItemMonitoringService
    {
        public DataTable GetItemMonitoringCode()
        {
            using (ItemMonitoringDAC dac = new ItemMonitoringDAC())
            {
                return dac.GetItemMonitoring();
            }
        }
        //public DataTable GetAllEmpCode()
        //{
        //    using (EmpDAC empdac = new EmpDAC())
        //    {
        //        return empdac.GetAllEmployees();
        //    }
        //}
        //public DataTable SearchName(EmpVO vo)
        //{
        //    using (EmpDAC dac = new EmpDAC())
        //    {
        //        return dac.SearchName(vo);
        //    }
        //}
        //public bool UseEmpID(List<int> cklist, List<string> uselist)
        //{
        //    using (EmpDAC dac = new EmpDAC())
        //    {
        //        return dac.UseEmpID(cklist, uselist);
        //    }
        //}
        //public bool EmpDelete(List<int> cklist)
        //{
        //    using (EmpDAC dac = new EmpDAC())
        //    {
        //        return dac.EmpDelete(cklist);
        //    }
        //}
        //public EmpVO GetLoginEmployee(string employee_id, string employee_pwd)
        //{
        //    using (EmpDAC employeeDAC = new EmpDAC())
        //    {
        //        return employeeDAC.GetLoginEmployee(employee_id, employee_pwd);
        //    }
        //}
    }
}