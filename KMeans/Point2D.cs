using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeans
{
    public class Point2D
    {
        public float x, y;
        public Color color;
        Pen pen = new Pen(Color.Red);
        public double[] MSV;
        public double[] distList;
        public Point2D(float x, float y)
        {
            this.x = x;
            this.y = y;
            this.color = Color.Black;
        }

        public Point2D(float a)
        {
            x = y = a;
            color = Color.Black;
        }

        static Random r = new Random();
        public Point2D(int w,int h,int cc)
        {
            x = (float)r.NextDouble() * w;
            y = (float)r.NextDouble() * h;
            MSV = new double[cc];
            distList = new double[cc];
            color = Color.Black;
        }

        public void CalculateMSV(List<Cluster> cls, double m)
        {
            if (MSV == null || MSV.Length != cls.Count)
            {
                MSV = new double [cls.Count];
                distList = new double[cls.Count];
            }
            double fizzm = 2.0 / (m - 1.0);
            for (int i = 0; i < cls.Count; i++)
                distList[i] = Math.Sqrt(dist(cls[i].origins));
            double best = 0;
            for (int i = 0; i < cls.Count; i++)
            {
                double mm = 0;
                for (int j = 0; j < cls.Count; j++)
                {
                    double ratio = i!=j ? distList[i] / distList[j] : 1.0;
                    double val = Math.Pow(ratio, fizzm);
                    mm += val;
                }
                MSV[i] = Math.Pow(1.0 / mm, m);
                if (MSV[i] > best)
                {
                    best = MSV[i];
                    bestCluster = cls[i];
                }
            }
        }

        public Cluster bestCluster;

        public float dist(Point2D p)
        {
            float xx = p.x - x;
            float yy = p.y - y;
            return xx * xx + yy * yy;
        }

        internal void draw(Graphics g, float s = 2f)
        {
            pen.Color = color;
            g.FillEllipse(pen.Brush, x - s, y - s, 2*s, 2*s);
        }
    }
}
