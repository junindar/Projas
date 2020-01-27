using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projas
{
   public class CircularPanel:Panel
    {
        public CircularPanel()
        {
            this.BackColor = Color.AliceBlue;  // set an image.
            this.Size = new Size(50, 50);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath pnlPath = new GraphicsPath();
            pnlPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(pnlPath);
          
            base.OnPaint(e);
        }
    }
}
