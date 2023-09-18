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
        public static void DrawNaught(Graphics formGraphics, int xPosition, int yPosition)
        {
            pen.Color = Color.Green;
            Rectangle shape = new Rectangle(xPosition + 50, yPosition + 50, 100, 100);
            formGraphics.DrawEllipse(pen, shape);
        }

        public static void DrawCross(Graphics formGraphics, int xPosition, int yPosition)
        {
            int lowerValX = 60 + xPosition;
            int upperValX = 150 + xPosition;

            int lowerValY = 60 + yPosition;
            int upperValY = 150 + yPosition;
            pen.Color = Color.Red;
            formGraphics.DrawLine(pen, lowerValX, lowerValY, upperValX, upperValY);
            formGraphics.DrawLine(pen, lowerValX, upperValY, upperValX, lowerValY);
        }
    }
}
