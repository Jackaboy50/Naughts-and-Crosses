using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naughts_and_Crosses
{
    internal static class TilePen
    {
        private static Pen pen = new Pen(Color.Transparent, 10);
        public static void DrawNaught(Form1 form1, int xPosition, int yPosition)
        {
            pen.Color = Color.Green;
            Graphics graphics = form1.CreateGraphics();
            Rectangle shape = new Rectangle(xPosition + 50, yPosition + 50, 100, 100);
            graphics.DrawEllipse(pen, shape);
        }

        public static void DrawCross(Form1 form1)
        {
            pen.Color = Color.Red;
        }
    }
}
