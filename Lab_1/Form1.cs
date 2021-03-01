using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = label3.Text = label4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double lowerLimit = Convert.ToDouble(textBox1.Text);
            double upperLimit = Convert.ToDouble(textBox2.Text);
            double step = Convert.ToDouble(textBox3.Text);

            double border = 2;

            double xStart = lowerLimit - border;
            double xEnd = upperLimit + border;
            double xDelta = step;

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            for (double x = xStart; x <= xEnd; x += xDelta)
            {
                double u = Function(x);
                chart1.Series[1].Points.AddXY(x, u);
            }

            label2.Text = lowerLimit.ToString();
            label3.Text = upperLimit.ToString();

            if (radioButton1.Checked)
            {
                label4.Text = CalculateIntegal.RectLeft(new Func<double, double>(Function), lowerLimit, upperLimit, step, chart1).ToString();
            }
            else if (radioButton2.Checked)
            {
                label4.Text = CalculateIntegal.RectRight(new Func<double, double>(Function), lowerLimit, upperLimit, step, chart1).ToString();
            }
            else if (radioButton3.Checked)
            {
                label4.Text = CalculateIntegal.RectCenter(new Func<double, double>(Function), lowerLimit, upperLimit, step, chart1).ToString();
            }
            else if (radioButton4.Checked)
            {
                label4.Text = CalculateIntegal.Trapezoid(new Func<double, double>(Function), lowerLimit, upperLimit, step, chart1).ToString();
            }
        }

        private double Function(double x)
        {
            return Math.Sin(x / Math.Sqrt(x));
        }
    }
}
