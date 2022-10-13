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
    public partial class BasicDataGridViewControl : DataGridView
    {
        public BasicDataGridViewControl()
        {                  
            InitializeComponent();

            DataGridViewContentAlignment centerAlign = DataGridViewContentAlignment.MiddleCenter;
            this.ColumnHeadersDefaultCellStyle.Alignment = centerAlign;
            
            this.DefaultCellStyle.ForeColor = Color.Black;
            //this.DefaultCellStyle.BackColor = Color.White;
            this.BackgroundColor = Color.White;

            // 테두리 설정
            this.BorderStyle = BorderStyle.None;

            this.AllowUserToAddRows = false;
            this.MultiSelect = false;
            this.AutoGenerateColumns = false;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
