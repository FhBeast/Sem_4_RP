using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Integral integralOne;
        Integral integralTwo;

        private void Form1_Load(object sender, EventArgs e)
        {
            float lowerLimitOne = Convert.ToSingle(textBox1.Text);
            float upperLimitOne = Convert.ToSingle(textBox2.Text);
            float stepOne = Convert.ToSingle(textBox3.Text);
            float lowerLimitTwo = Convert.ToSingle(textBox6.Text);
            float upperLimitTwo = Convert.ToSingle(textBox5.Text);
            float stepTwo = Convert.ToSingle(textBox4.Text);

            integralOne = new Integral(lowerLimitOne, upperLimitOne, stepOne);
            integralTwo = new Integral(lowerLimitTwo, upperLimitTwo, stepTwo);
        }

        private double Function(double x)
        {
            return Math.Sin(x / Math.Sqrt(x));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[0].ChartType = SeriesChartType.Spline;
            for (double x = integralOne.LowerLimit; x <= integralOne.UpperLimit; x += integralOne.Step)
            {
                double u = Function(x);
                chart1.Series[0].Points.AddXY(x, u);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            chart1.Series[1].Points.Clear();
            chart1.Series[1].ChartType = SeriesChartType.Spline;
            for (double x = integralTwo.LowerLimit; x <= integralTwo.UpperLimit; x += integralTwo.Step)
            {
                double u = Function(x);
                chart1.Series[1].Points.AddXY(x, u);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
    }
}
