using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESFactoryVO
{
    public class ItemVO
    {
        public string ItemID { get; set; }
        public string ItemNAME { get; set; }
        public int ItemNUM { get; set; }
        public string ItemUSE { get; set; }
        public DateTime FirstTIME { get; set; }
        public string FirstUSER { get; set; }
        public DateTime LastTIME { get; set; }
        public string LastUSER { get; set; }
        public string ItemADD { get; set; }
        public string EmpNAME { get; set; }
        public string EmpID { get; set; }
    }
}
