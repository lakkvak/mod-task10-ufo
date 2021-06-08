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

namespace Ufo
{
    public partial class Form2 : Form
    {
        List<double> l;
        public Form2(List<double> ls)
        {
            InitializeComponent();
            l = ls;
            
            
            Axis ax = new Axis();
            ax.Title = "Погрешность";
            chart1.ChartAreas[0].AxisX = ax;
            Axis ay = new Axis();
            ay.Title = "Кол-во членов ряда";
            chart1.ChartAreas[0].AxisY = ay;
            chart1.Series[0].Color = Color.Red;
            chart1.Series[0].ChartType = SeriesChartType.Line;

            for (int i = 1; i < l.Count; i++)
                chart1.Series[0].Points.AddXY(Math.Round( l[i-1],3), i);

        }
       
        
    }
}
