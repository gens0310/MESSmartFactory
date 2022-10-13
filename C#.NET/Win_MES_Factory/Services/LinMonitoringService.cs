using MESFactoryDAC;
using System.Collections.Generic;
using System.Data;
namespace Win_MES_Factory.Services
{
    public class LinMonitoringService
    {
        public DataTable GetLinMonitoringCode()
        {
            using (LinMonitoringDAC dac = new LinMonitoringDAC())
            {
                return dac.GetLinMonitoring();
            }
        }

        public bool UseLinID(List<int> empIDList, List<string> useList)
        {
            using (LinMonitoringDAC dac = new LinMonitoringDAC())
            {
                return dac.UseLinID(empIDList, useList);
            }
        }
    }
}