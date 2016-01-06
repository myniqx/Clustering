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
            origins = new Point2D((float) (width * r.NextDouble()), (float) (height * r.NextDouble()));
            origins.color = color;
            pen = new Pen(color);
        }

        private Pen pen;

        public void draw(Graphics g,bool final = false)
        {
            if (final)
            {
                for (int i = 0; i < oldOrigins.Count; i++)
                {
                    oldOrigins[i].draw(g,8f + 0.05f * i);
                }
            }
            origins.draw(g, 10);
            foreach (var p in members) { g.DrawLine(pen, origins.x, origins.y, p.x, p.y); }
        }

        public void add(Point2D p)
        {
            members.Add(p);
            p.color = origins.color;
        }

        public double CheckOrigin()
        {
            double x = 0, y = 0;
            foreach (var p in members)
            {
                x += p.x;
                y += p.y;
            }
            x /= members.Count;
            y /= members.Count;
            Point2D no = new Point2D((float) x, (float) y) {color = origins.color};
            oldOrigins.Add(origins);
            var err = no.dist(origins);
            origins = no;
            return err;
        }

        public double calculateOrigin(int index,List<Point2D> points, double fuzzyFactor)
        {
            double x = 0, y = 0;
            double mem = 0;
            members.Clear();
            foreach (Point2D point in points)
            {
                double tmp = point.MSV[index];
                mem += tmp;
                x += tmp * point.x;
                y += tmp * point.y;
                if(point.bestCluster == this) add(point);
            }
            x /= mem;
            y /= mem;
            oldOrigins.Add(origins);
            var n = new Point2D((float) x, (float) y) {color = origins.color};
            var result = n.dist(origins);
            origins = n;
            return result;
        }
    }
}
