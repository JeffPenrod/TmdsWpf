using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tmds
{
    public class Utility
    {

        public static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            double dX = x2 - x1;
            double dY = y2 - y1;

            return Math.Sqrt(Math.Pow(dX, 2) + Math.Pow(dY, 2));
        }

    }
}
