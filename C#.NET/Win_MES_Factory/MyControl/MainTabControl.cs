using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinMSFactory
{
    public partial class MainTabControl : TabControl
    {
        private Point _imageLocation = new Point(18, 2);

        public MainTabControl()
        {
            InitializeComponent();

            this.DrawMode = TabDrawMode.OwnerDrawFixed;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);

            try
            {
                Image img;

                Font f = this.Font;

                Rectangle r = e.Bounds;
                Brush titleBrush = new SolidBrush(Color.Black);
                string title = this.TabPages[e.Index].Text;

                r = this.GetTabRect(e.Index);
                r.Offset(2, 2);

                // SelectedTab의 Background Color 는 White으로 처리
                if (this.SelectedIndex == e.Index)
                    e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);

                // 각 Tab별로 close button 에 대한 image값 
                if (this.SelectedTab == this.TabPages[e.Index])
                    img = Win_MES_Factory.Properties.Resources.Delete_now;
                else
                    img = null;

                // TabPage Text
                e.Graphics.DrawString(title, f, titleBrush, new PointF(r.X, r.Y));

                // TabPage 의 닫기 버튼
                e.Graphics.DrawImage(img, new Point(r.X + this.GetTabRect(e.Index).Width - _imageLocation.X, _imageLocation.Y));

                img.Dispose();
                img = null;
            }
            catch (Exception)
            {
            }
        }
    }
}
