using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Integral
    {
        private float lowerLimit;
        private float upperLimit;
        private float step;
        private Func<float, float> function;
        public float LowerLimit { get => lowerLimit; set => lowerLimit = value; }
        public float UpperLimit { get => upperLimit; set => upperLimit = value; }
        public float Step { get => step; set
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

        public Func<float, float> Function { get => function; set => function = value; }

        public Integral()
        {

        }

        public Integral(float lowerLimit, float upperLimit, float step)
        {
            this.lowerLimit = lowerLimit;
            this.upperLimit = upperLimit;
            this.step = step;
        }

        public float Calculate()
        {
            float result = 0;

            return result;
        }
    }
}
