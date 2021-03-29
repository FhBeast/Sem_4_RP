﻿using System;
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
        float lowerLimitOne;
        float upperLimitOne;
        float stepOne;
        float lowerLimitTwo;
        float upperLimitTwo;
        float stepTwo;

        private void Form1_Load(object sender, EventArgs e)
        {
            lowerLimitOne = Convert.ToSingle(textBox1.Text);
            upperLimitOne = Convert.ToSingle(textBox2.Text);
            stepOne = Convert.ToSingle(textBox3.Text);
            lowerLimitTwo = Convert.ToSingle(textBox6.Text);
            upperLimitTwo = Convert.ToSingle(textBox5.Text);
            stepTwo = Convert.ToSingle(textBox4.Text);

            integralOne = new Integral(lowerLimitOne, upperLimitOne, stepOne, new Func<double, double>(Function));
            integralTwo = new Integral(lowerLimitTwo, upperLimitTwo, stepTwo, new Func<double, double>(Function));
        }

        private void UpdateIntegrals()
        {
            integralOne.LowerLimit = Convert.ToSingle(textBox1.Text);
            integralOne.UpperLimit = Convert.ToSingle(textBox2.Text);
            integralOne.Step = Convert.ToSingle(textBox3.Text);
            integralTwo.LowerLimit = Convert.ToSingle(textBox6.Text);
            integralTwo.UpperLimit = Convert.ToSingle(textBox5.Text);
            integralTwo.Step = Convert.ToSingle(textBox4.Text);
        }

        private double Function(double x)
        {
            return Math.Sin(x / Math.Sqrt(x));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateIntegrals();
            chart1.Series[3].Points.Clear();
            chart1.Series[3].ChartType = SeriesChartType.Spline;
            for (double x = integralOne.LowerLimit; x <= integralOne.UpperLimit; x += integralOne.Step)
            {
                double u = Function(x);
                chart1.Series[3].Points.AddXY(x, u);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            UpdateIntegrals();
            chart1.Series[4].Points.Clear();
            chart1.Series[4].ChartType = SeriesChartType.Spline;
            for (double x = integralTwo.LowerLimit; x <= integralTwo.UpperLimit; x += integralTwo.Step)
            {
                double u = Function(x);
                chart1.Series[4].Points.AddXY(x, u);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            UpdateIntegrals();
            integralOne.Calculate(chart1.Series[0]);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            UpdateIntegrals();
            integralTwo.Calculate(chart1.Series[1]);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            UpdateIntegrals();
            float lowerLimitCommon;
            float upperLimitCommon;
            float stepCommon;

            if (integralOne.LowerLimit > integralTwo.LowerLimit)
            {
                lowerLimitCommon = integralOne.LowerLimit;
            }
            else
            {
                lowerLimitCommon = integralTwo.LowerLimit;
            }

            if (integralOne.UpperLimit < integralTwo.UpperLimit)
            {
                upperLimitCommon = integralOne.UpperLimit;
            }
            else
            {
                upperLimitCommon = integralTwo.UpperLimit;
            }

            if (lowerLimitCommon > upperLimitCommon)
            {
                return;
            }

            if (integralOne.Step < integralTwo.Step)
            {
                stepCommon = integralOne.Step;
            }
            else
            {
                stepCommon = integralTwo.Step;
            }

            //float result = 0;
            chart1.Series[2].Points.Clear();
            chart1.Series[2].ChartType = SeriesChartType.Column;
            for (double x = lowerLimitCommon + (stepCommon / 2); x < upperLimitCommon; x += stepCommon)
            {
                double u = Function(x);
                //result += (float)(u * step);
                chart1.Series[2].Points.AddXY(x, u);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = chart1.PaletteCustomColors[0];
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            chart1.PaletteCustomColors[0] = colorDialog1.Color;
        }
    }
}
