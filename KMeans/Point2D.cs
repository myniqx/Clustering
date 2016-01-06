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
        public Point2D(int w,int h)
        {
            x = (float)r.NextDouble() * w;
            y = (float)r.NextDouble() * h;
            color = Color.Black;
        }

        public void CalculateMSV(List<Cluster> cls, double m)
        {
            // kmean algoritmasında MSV ve distList e gerek yok.
            // dolayısı ile bu fonksiyon çağırıldığında ihtiyaç halinde arraylar oluşturulacak

            if (MSV == null || MSV.Length != cls.Count)
            {
                MSV = new double [cls.Count];
                distList = new double[cls.Count];
            }

            /*
                m -> fuzzy factor
                dist(p,o) -> ağırlığı hesaplanan kümenin merkezinin p noktasına uzaklığı
                dist(p,o(i)) -> i. küme merkezinin p noktasına uzaklığı
                C -> küme

                ağırlık = 
                { 1 / <TOPLAM ( 1 den küme sayısına ) [ dist(p,o) / dist(p,o(i)) ] ^ [ 2 - (m-1) ]> }  
                
                MSV = ağırlık ^ m   

                formülleri ile hesaplanıyor.
            */

            double fizzm = 2.0 / (m - 1.0);  //üst hep sabit olacağı için defalarca hesaplatmadım
            for (int i = 0; i < cls.Count; i++)
                distList[i] = Math.Sqrt(dist(cls[i].origins));  //önce bir defa uzaklıkları bulduk
            double best = 0;
            for (int i = 0; i < cls.Count; i++)
            {
                double mm = 0;
                for (int j = 0; j < cls.Count; j++)
                {
                    double ratio = i!=j ? distList[i] / distList[j] : 1.0;
                    double val = Math.Pow(ratio, fizzm);  // uzaklıkları oranı ^ fizzm
                    mm += val;  //hepsini topla
                }
                MSV[i] = Math.Pow(1.0 / mm, m);     //MSV değerini bul.
                if (MSV[i] > best)
                {
                    best = MSV[i];
                    bestCluster = cls[i];           // en yüksek ağırlık hangi kümenin ise bu noktayı ona ait miş gibi boya
                }  // unutmadan FCM'de bir noktanın bir kümeye <ağırlık> dereceden aidiyeti söz konusu
                   // burada yaptığım sadece boyama için. yoksa her nokta her kümeye <ağırlık> derecesinden ait.
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
