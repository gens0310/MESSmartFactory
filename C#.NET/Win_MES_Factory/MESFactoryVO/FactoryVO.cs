using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESFactoryVO
{
    public class FactoryVO
    {
        //대문자로 등록

        public string FacID { get; set; }
        public string FacNAME { get; set; }
        public int FacNUM { get; set; }
        public string FacUSE { get; set; }
        public DateTime FirstTIME { get; set; }
        public string FirstUSER { get; set; }
        public DateTime LastTIME { get; set; }
        public string LastUSER { get; set; }
        public string FacADD { get; set; }

    }
}
