using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naughts_and_Crosses
{
    internal static class TilePencil
    {
        public static void DrawNaught()
        {

        }

        public static void DrawCircle(this Graphics graphics, Pen pen, float centerX, float centerY, float radius)
        {
            g.DrawEllipse(pen, centerX - radius, centerY - radius, radius + radius, radius + radius);
        }


        public static void DrawCross()
        {

        }
    }
}
