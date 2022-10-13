using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESFactoryVO
{
    public class LineVO
    {
        public string LinID { get; set; }
        public string FacID { get; set; }
        public string FacNAME { get; set; } //직원 소속 공장 FK
        public string EmpID { get; set; }
        public string EmpNAME { get; set; } //사원 이름 FK
        public string LinNAME { get; set; }
        public int LinNUM { get; set; }
        public string LinUSE { get; set; }
        public DateTime FirstTIME { get; set; }
        public string FirstUSER { get; set; }
        public DateTime LastTIME { get; set; }
        public string LastUSER { get; set; }
        public string LinADD { get; set; }
    }
}
