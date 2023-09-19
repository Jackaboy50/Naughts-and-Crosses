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
        public static void DrawNaught(Graphics formGraphics, int xPosition, int yPosition, Color color)
        {
            pen.Color = color;
            Rectangle shape = new Rectangle(xPosition + 50, yPosition + 50, 100, 100);
            formGraphics.DrawEllipse(pen, shape);
        }

        public static void DrawCross(Graphics formGraphics, int xPosition, int yPosition, Color color)
        {
            int lowerValX = 55 + xPosition;
            int upperValX = 145 + xPosition;

            int lowerValY = 55 + yPosition;
            int upperValY = 145 + yPosition;
            pen.Color = color;
            formGraphics.DrawLine(pen, lowerValX, lowerValY, upperValX, upperValY);
            formGraphics.DrawLine(pen, lowerValX, upperValY, upperValX, lowerValY);
        }

        public static void DrawLine(Graphics formGraphics, int startXPosition, int startYPosition, int endXPosition, int endYPosition, Color color)
        {
            pen.Color = color;
            formGraphics.DrawLine(pen, startXPosition, startYPosition, endXPosition, endYPosition);
        }
    }
}
