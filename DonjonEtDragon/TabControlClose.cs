using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DonjonEtDragon
{
    public delegate bool PreRemoveTab(int indx);
    public class TabControlClose : TabControl
    {
        public TabControlClose()
            : base()
        {
            PreRemoveTabPage = null;
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
        }

        public PreRemoveTab PreRemoveTabPage;

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Rectangle r = e.Bounds;
            r = GetTabRect(e.Index);
            r.Offset(r.Width - 8, 2);
            r.Width = 5;
            r.Height = 5;
            Brush b = new SolidBrush(Color.Black);
            Pen p = new Pen(b);
            e.Graphics.DrawLine(p, r.X, r.Y, r.X + r.Width, r.Y + r.Height);
            e.Graphics.DrawLine(p, r.X + r.Width, r.Y, r.X, r.Y + r.Height);

            string titel = this.TabPages[e.Index].Text;
            Graphics g = this.CreateGraphics();
            Font f = this.Font;
            SizeF i = g.MeasureString(titel, f);
            g.Dispose();

            e.Graphics.DrawString(titel, f, b, new PointF(r.X - i.Width +2, r.Y));
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            Point p = e.Location;
            for (int i = 0; i < TabCount; i++)
            {
                Rectangle r = GetTabRect(i);
                r.Offset(r.Width - 8, 2);
                r.Width = 5;
                r.Height = 5;
                if (r.Contains(p))
                {
                    CloseTab(i);
                }
            }
        }

        private void CloseTab(int i)
        {
            if (PreRemoveTabPage != null)
            {
                bool closeIt = PreRemoveTabPage(i);
                if (!closeIt)
                    return;
            }
            TabPages.Remove(TabPages[i]);
        }
    }
}
