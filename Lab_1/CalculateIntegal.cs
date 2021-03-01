using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab_1
{
    public static class CalculateIntegal
    {
        public static double RectLeft(Func<double, double> func, double dawn, double up, double step, Chart chart)
        {
            double integral = 0;

            for (double x = dawn + step; x <= up; x += step)
            {
                integral += (step * func(x));
                chart.Series[0].Points.AddXY(x, func(x));
            }

            return integral;
        }

        public static double RectRight(Func<double, double> func, double dawn, double up, double step, Chart chart)
        {
            double integral = 0;

            for (double x = dawn; x <= up - step; x += step)
            {
                integral += (step * func(x));
            }

            return integral;
        }

        public static double RectCenter(Func<double, double> func, double dawn, double up, double step, Chart chart)
        {
            double integral = 0;

            for (double x = dawn + (step / 2); x <= up - (step / 2); x += step)
            {
                integral += (step * func(x));
            }

            return integral;
        }
    }
}
