using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MESFactoryDAC;
using MESFactoryVO;


namespace Win_MES_Factory.Services
{
    public class ItemService
    {
        ItemDAC dac = new ItemDAC();
        FacDAC facDac = new FacDAC();

        public DataTable GetAllItem()
        {
            return dac.GetAllItem();
        }

        public DataTable SearchName(ItemVO vo)
        {
            return dac.SearchName(vo);
        }

        public bool UseItemID(List<int> itemIDList, List<string> useList)
        {
            return dac.UseItemID(itemIDList, useList);
        }

        public bool SaveItem(ItemVO vo)
        {
            return dac.SaveItem(vo);
        }

        public bool DeleteItem(List<int> item_IDList)
        {
            return dac.DeleteItem(item_IDList);
        }


    }
}
