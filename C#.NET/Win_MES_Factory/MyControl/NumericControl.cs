using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinMSFactory
{
    public partial class NumericControl : NumericUpDown
    {
        public NumericControl()
        {                  
            InitializeComponent();
            this.Minimum = 0;
            this.Maximum = 100000;
            this.Size = new Size(63, 21);
            this.BackColor = Color.White;
            this.TextAlign = HorizontalAlignment.Center;
            this.UpDownAlign = LeftRightAlignment.Right;
            this.Increment = 10;

        }

        

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
