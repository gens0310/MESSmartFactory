using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MESFactoryDAC;
using MESFactoryVO;
using System.Data;
using System.Windows.Forms;

namespace Win_MES_Factory.Services
{
    public class OrderService
    {
        public DataTable GetAllOrderCode()
        {
            using (OrderDAC empdac = new OrderDAC())
            {
                return empdac.GetAllOrders();
            }
        }

        public DataTable GetExcelOrders()
        {
            using (OrderDAC empdac = new OrderDAC())
            {
                return empdac.GetExcelOrders();
            }
        }
        
        public OrderVO GetWorkOrder(string OrdID)
        {
            using (OrderDAC orderDAC = new OrderDAC())
            {
                return orderDAC.GetWorkOrder(OrdID);
            }
        }

        public DataTable GetToDoes() // 팝업창의 그리드뷰 가져올 때 사용
        {
            using (OrderDAC orderDAC = new OrderDAC())
            {
                return orderDAC.GetToDoes();
            }
        }

        
        public DataTable SearchOrderItem(OrderVO vo)
        {
            using (OrderDAC dac = new OrderDAC())
            {
                return dac.SearchOrderItem(vo);
            }
        }
        public DataTable SearchNameOrder(OrderVO vo)
        {
            using (OrderDAC dac = new OrderDAC())
            {
                return dac.SearchName(vo);
            }
        }

        public bool OrderDelete(List<int> cklist)
        {
            using (OrderDAC dac = new OrderDAC())
            {
                return dac.OrderDelete(cklist);
            }
        }

        public bool SaveOrder(List<OrderVO> vo)
        {
            using (OrderDAC dac = new OrderDAC())
            {
                return dac.SaveOrder(vo);
            }
        }

        public List<FactoryVO> ComboFacGet()
        {
            using (OrderDAC dac = new OrderDAC())
            {
                return dac.ComboFacGet();
            }
        }

        public List<EmpVO> ComboEmpGet()
        {
            using (OrderDAC dac = new OrderDAC())
            {
                return dac.ComboEmpGet();
            }
        }

        public List<OrderVO> GetChart(string from, string to, string facID, string itemID)
        {
            using (OrderDAC dac = new OrderDAC())
            {
                return dac.GetSellsChart(from, to, facID, itemID);
            }
        }

        
        public List<LineVO> ComboLineGet()
        {
            using (OrderDAC dac = new OrderDAC())
            {
                return dac.ComboLineGet();
            }
        }

        public List<ProVO> ComboProGet()
        {
            using (OrderDAC dac = new OrderDAC())
            {
                return dac.ComboProGet();
            }
        }

        public List<ItemVO> ComboItemGet()
        {
            using (OrderDAC dac = new OrderDAC())
            {
                return dac.ComboItemGet();
            }
        }

        public List<ProVO> FactoryLinCombo(string facID)
        {
            using (ProDAC dac = new ProDAC())
            {
                return dac.FactoryLinCombo(facID);
            }
        }


        public List<ProVO> LineProcessCombo(string linID)
        {
            using (OrderDAC dac = new OrderDAC())
            {
                return dac.LineProcessCombo(linID);
            }
        }

        public List<LineVO> LineEmpCombo(string facID)
          {
              using (OrderDAC dac = new OrderDAC())
              {
                  return dac.LineEmpCombo(facID);
              }
          }

        public DataTable GetOrderListByDate(string fromDate, string toDate, string facID, string linID, string proID, string itemID)
        {
            using (OrderDAC dac = new OrderDAC())
            {
                return dac.GetOrderListByDate(fromDate, toDate, facID, linID, proID, itemID);
            }
        }

        public List<OrderVO> SearchOrderItem2(OrderVO vo)
        {
            using (OrderDAC dac = new OrderDAC())
            {
                return dac.SearchOrderItem2(vo);
            }
        }
    }
}
