using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noughts_and_Crosses
{
    /// <summary>
    /// Represents the Pen used for drawing
    /// </summary>
    internal static class TilePen
    {
        private static Pen pen = new Pen(Color.Transparent, 10);
        /// <summary>
        /// Draws a nought on the given graphics
        /// </summary>
        /// <param name="formGraphics">Specifies where to draw the nought</param>
        /// <param name="xPosition">Specfies the X coordinate of the center of the nought</param>
        /// <param name="yPosition">Specfies the Y coordinate of the center of the nought</param>
        /// <param name="color">Specifies the colour of the nought</param>
        public static void DrawNought(Graphics formGraphics, int xPosition, int yPosition, Color color)
        {
            pen.Color = color;
            Rectangle shape = new Rectangle(xPosition + 50, yPosition + 50, 100, 100);
            formGraphics.DrawEllipse(pen, shape);
        }
        /// <summary>
        /// Draws a cross on the given graphics
        /// </summary>
        /// <param name="formGraphics">Specifies where to draw the cross</param>
        /// <param name="xPosition">Specfies the X coordinate of the center of the cross</param>
        /// <param name="yPosition">Specfies the Y coordinate of the center of the cross</param>
        /// <param name="color">Specifies the colour of the cross</param>
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
        /// <summary>
        /// Drwas a line on the given graphics
        /// </summary>
        /// <param name="formGraphics">Specifies where to draw the line</param>
        /// <param name="startXPosition">Specifies the start X position</param>
        /// <param name="startYPosition">Specifies the start Y position</param>
        /// <param name="endXPosition">Specifies the end X position</param>
        /// <param name="endYPosition">Specifies the end Y position</param>
        /// <param name="color">Specifies the colour of the line</param>
        public static void DrawLine(Graphics formGraphics, int startXPosition, int startYPosition, int endXPosition, int endYPosition, Color color)
        {
            pen.Color = color;
            formGraphics.DrawLine(pen, startXPosition, startYPosition, endXPosition, endYPosition);
        }
    }
}
