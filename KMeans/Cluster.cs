using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KMeans
{
    public class Cluster
    {
        public List<Point2D> oldOrigins = new List<Point2D>();
        public List<Point2D> members = new List<Point2D>();
        public Point2D origins;

        public Cluster(Random r, int width, int height, Color color)
        {
            origins = new Point2D((float) (width * r.NextDouble()), (float) (height * r.NextDouble())) {color = color};
            pen = new Pen(color);
        }

        private Pen pen;

        public void draw(Graphics g,bool final = false)
        {
            if (final)
            {   //önceki merkezleri göstereceksek ilk önce onları çizelim ki arkada kalsın
                for (int i = 0; i < oldOrigins.Count; i++)
                {
                    oldOrigins[i].draw(g,8f + 0.05f * i);
                }
            }

            // son merkezi çiz
            origins.draw(g, 10);

            // merkezden o kümenin elemanlarına bir çizgi çek.
            foreach (var p in members) { g.DrawLine(pen, origins.x, origins.y, p.x, p.y); }
        }

        public void add(Point2D p)
        {
            members.Add(p);
            p.color = origins.color;
        }


        //kMeans için merkez hesaplama
        public double CheckOrigin()
        {
            double x = 0, y = 0;
            foreach (var p in members)
            {       //aritmetik ortasını al
                x += p.x;
                y += p.y;
            }
            x /= members.Count;
            y /= members.Count;

            //yeni bir nokta oluştur
            Point2D no = new Point2D((float) x, (float) y) {color = origins.color};

            //eski merkezi (çizdirilmek üzere) listeye ekle
            oldOrigins.Add(origins);

            //iki merkez arası uzaklığı hata hesabı için kullan
            var err = no.dist(origins);

            //yeni merkezi origins ile değiştir.
            origins = no;
            return err;
        }

        //FCM için merkez hesabı
        public double calculateOrigin(int index,List<Point2D> points, double fuzzyFactor)
        {
            double x = 0, y = 0;
            double mem = 0;
            members.Clear();

            /*
                newCenterX = (w1 * p1.x + w2 * p2.x + ... + wn * pn.x) / (w1 + w2 + ... + wn)
                newCenterY = (w1 * p1.y + w2 * p2.y + ... + wn * pn.y) / (w1 + w2 + ... + wn)
            */

            foreach (Point2D point in points)
            {
                double tmp = point.MSV[index];  // bu kümenin nokta için ağırlığı ile
                mem += tmp;
                x += tmp * point.x;     // noktanın koordinatlarını çarp
                y += tmp * point.y;
                if(point.bestCluster == this) add(point);
            }
            x /= mem;
            y /= mem;   // ağırlık toplamına böl

            //bundan sonrası kmeans ile aynı
            oldOrigins.Add(origins);
            var n = new Point2D((float) x, (float) y) {color = origins.color};
            var result = n.dist(origins);
            origins = n;
            return result;
        }
    }
}
