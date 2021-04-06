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
        private float step;
        public float LowerLimit { get; set; }
        public float UpperLimit { get; set; }
        public float Step
        {
            get
            {
                return step;
            }
            set
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

        public Func<double, double> Function { get; set; }

        public Integral()
        {

        }

        public Integral(float lowerLimit, float upperLimit, float step, Func<double, double> function)
        {
            this.LowerLimit = lowerLimit;
            this.UpperLimit = upperLimit;
            this.step = step;
            this.Function = function;
        }

        public float Calculate(Series series)
        {
            series.Points.Clear();
            series.ChartType = SeriesChartType.Column;
            float result = 0;
            for (double x = LowerLimit + (step / 2); x < UpperLimit; x += step)
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
            for (double x = LowerLimit + (step / 2); x < UpperLimit; x += step)
            {
                double u = Function(x);
                result += (float)(u * step);
            }
            return result;
        }
    }
}
