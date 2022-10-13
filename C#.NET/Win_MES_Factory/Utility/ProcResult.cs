using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win_MES_Factory.Utility
{
    public enum ProcResultID { SUCCESS, FAIL }
    public class ProcResult
    {
        public ProcResultID ResultID { get; set; }

        public string ErrorMsg { get; set; }
 
    }
}
