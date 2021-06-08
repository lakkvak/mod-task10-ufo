using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ufo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Invalidate();
            Width = 1000;
            Height = 1000;
        }
       
       


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        int Fact(int x)
        {
            if (x == 0)
                return 1;
            else
                return x * Fact(x - 1);
        }

        double Sin(int n, double x)
        {
            double sin = 0.0;
            for (int i = 1; i < n + 1; i++)
                sin += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / Fact(2 * i - 1);

            return sin;
        }

        double Cos(int n, double x)
        {
            double cos = 0.0;
            for (int i = 1; i < n + 1; i++)
                cos += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 2) / Fact(2 * i - 2);

            return cos;
        }
        double Arctan(double x, int degree)
        {
            double res = 0;
            if (-1 <= x && x <= 1)
            {
                for (int i = 1; i < degree + 1; i++)
                {
                    res += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / (2 * i - 1);
                }
            }
            else
            {
                if (x >= 1)
                {
                    res += Math.PI / 2;
                    for (int i = 0; i < degree; i++)
                    {
                        res -= Math.Pow(-1, i) / ((2 * i + 1) * Math.Pow(x, 2 * i + 1));
                    }
                }
                else
                {
                    res -= Math.PI / 2;
                    for (int i = 0; i < degree; i++)
                    {
                        res -= Math.Pow(-1, i) / ((2 * i + 1) * Math.Pow(x, 2 * i + 1));
                    }
                }
            }
            return res;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen line = new Pen(Color.Green, 2);
            Pen dot = new Pen(Color.Black, 3);

            double x1 = 10;
            double y1 = 900;
            double x2 = 800;
            double y2 = 20;
            double step = 1;
            int TSeries = 14;

            g.DrawEllipse(dot, (int)x1, (int)y1, 2, 2);
            g.DrawEllipse(dot, (int)x2, (int)y2, 2, 2);

            double a = Math.Abs(x1 - x2);
            double b = Math.Abs(y1 - y2);
            double value = a + b;           
            double distance = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            double angle = Arctan(b / a, TSeries);

            while (distance <= value)
            {
                y1 -= step * Sin(TSeries, angle);
                x1 += step * Cos(TSeries, angle);
                g.DrawEllipse(line, (int)x1, (int)y1, 1, 1);
                a = Math.Abs(x1 - x2);
                b = Math.Abs(y1 - y2);
                distance = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
                if (distance < value)
                    value = distance;
            }

            g.DrawString("Погрешность: " + value.ToString("0.000"), new Font("Arial", 17), Brushes.Black, new PointF(Width - Width / 3, 300));
            List<double> l = new List<double>();
            
            

            for (int i = 1; i < 15; i++)
            {
                 x1 = 10;
                 y1 = 900;
                 x2 = 800;
                 y2 = 20;
                 step = 1;
                a = Math.Abs(x1 - x2);
                 b = Math.Abs(y1 - y2);
                value = a + b;
                 distance = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
                angle = Arctan(b / a, i);

                while (distance <= value)
                {
                    y1 -= step * Sin(i, angle);
                    x1 += step * Cos(i, angle);
                    a = Math.Abs(x1 - x2);
                    b = Math.Abs(y1 - y2);
                    distance = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
                    if (distance < value)
                        value = distance;
                }
                l.Add(value);
               
                
            }
            Form2 f2 = new Form2(l);
            f2.Show();
        }

        
    }
}
