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
        public static double RectLeft(Func<double, double> func, double down, double up, double step, Chart chart)
        {
            double integral = 0;

            for (double x = down + step; x <= up; x += step)
            {
                integral += (step * func(x));
                chart.Series[0].Points.AddXY(x - (step / 2), func(x));
            }

            return integral;
        }

        public static double RectRight(Func<double, double> func, double down, double up, double step, Chart chart)
        {
            double integral = 0;

            for (double x = down; x <= up - step; x += step)
            {
                integral += (step * func(x));
                chart.Series[0].Points.AddXY(x + (step / 2), func(x));
            }

            return integral;
        }

        public static double RectCenter(Func<double, double> func, double down, double up, double step, Chart chart)
        {
            double integral = 0;

            for (double x = down + (step / 2); x <= up - (step / 2); x += step)
            {
                integral += (step * func(x));
                chart.Series[0].Points.AddXY(x, func(x));
            }

            return integral;
        }

        public static double Trapezoid(Func<double, double> func, double down, double up, double step, Chart chart)
        {
            double integral = 0;

            for (double x = down; x <= up - step; x += step)
            {
                double field = 0;

                double currentPoint = func(x);
                double nextPoint = func(x + step);
                if (currentPoint < nextPoint) {
                    field = (step * currentPoint);
                    double fieldTriangle = (step * nextPoint);
                    fieldTriangle -= field;
                    fieldTriangle /= 2;
                    field += fieldTriangle;
                    chart.Series[0].Points.AddXY(x + (step / 2), currentPoint);
                }
                else
                {
                    field = (step * nextPoint);
                    double fieldTriangle = (step * currentPoint);
                    fieldTriangle -= field;
                    fieldTriangle /= 2;
                    field += fieldTriangle;
                    chart.Series[0].Points.AddXY(x + (step / 2), nextPoint);
                }
                integral += field;
            }

            return integral;
        }
    }
}
