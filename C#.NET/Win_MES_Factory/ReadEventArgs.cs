using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win_MES_Factory
{
    public class ReadEventArgs : EventArgs
    {
        private string msg;

        public string ReadMsg
        {
            get { return msg; }
            set { msg = value; }
        }
    }
}
