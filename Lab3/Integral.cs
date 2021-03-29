using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab3
{
    class Integral
    {
        private float lowerLimit;
        private float upperLimit;
        private float step;
        private Func<double, double> function;
        public float LowerLimit { get => lowerLimit; set => lowerLimit = value; }
        public float UpperLimit { get => upperLimit; set => upperLimit = value; }
        public float Step
        {
            get => step; set
            {
                if (value <= 0)
                {
                    step = 1;
                }
                else
                {
                    step = value;
                }
            }
        }

        public Func<double, double> Function { get => function; set => function = value; }

        public Integral()
        {

        }

        public Integral(float lowerLimit, float upperLimit, float step, Func<double, double> function)
        {
            this.lowerLimit = lowerLimit;
            this.upperLimit = upperLimit;
            this.step = step;
            this.function = function;
        }

        public float Calculate(Series series)
        {
            series.Points.Clear();
            series.ChartType = SeriesChartType.Column;
            float result = 0;
            for (double x = lowerLimit + (step / 2); x < upperLimit; x += step)
            {
                double u = Function(x);
                result += (float)(u * step);
                series.Points.AddXY(x, u);
            }
            return result;
        }

        public float Calculate()
        {
            float result = 0;
            for (double x = lowerLimit + (step / 2); x < upperLimit; x += step)
            {
                double u = Function(x);
                result += (float)(u * step);
            }
            return result;
        }
    }
}
