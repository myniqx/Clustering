using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KMeans
{
    public partial class Kmeans : Form
    {
        public Kmeans()
        {
            InitializeComponent();
        }

        // data olarak kullanılan nokta listesi
        List<Point2D> points = new List<Point2D>();

        // kümeler ile ilgili verileri tutan Cluster class'ının listesi
        List<Cluster> clusters = new List<Cluster>();


        Random random = new Random();
        private int IterationCount = 1000;
        private double ErrorThreshold = 0.5;
        private int ItemCount = 200;
        private int ClusterCount = 4;
        private double FuzzyFactor = 1.8;


        //UI üzerindeki verileri toplayıp sınırlar arasına alan fonksiyon
        // Cluster sayısı [2 10] arasında olmalı -> kaç küme olsun
        // IterationCount [10 10000] arası gibi  -> en fazla kaç iterasyon olsun
        // ItemCount -> random oluştur dendiğinde kaç tane oluştursun
        // ErrorThreshold -> merkez yerdeğiştirmesi bu değerin altına inince iterasyonu durdur
        // FuzzyFactor -> FCM'de formul içinde kullanılan bulanık sabit değeri
        void collectData()
        {
            if (int.TryParse(t_cluster.Text, out ClusterCount) == false) ClusterCount = 4;
            if (int.TryParse(t_iteration.Text, out IterationCount) == false) IterationCount = 1000;
            if (int.TryParse(t_item.Text, out ItemCount) == false) ItemCount = 200;
            if (double.TryParse(t_err.Text, out ErrorThreshold) == false) ErrorThreshold = 0.5;
            if (double.TryParse(t_fuzzy.Text, out FuzzyFactor) == false) FuzzyFactor = 1.8;

            ClusterCount = Math.Max(2, Math.Min(10, ClusterCount));
            IterationCount = Math.Max(10, Math.Min(10000, IterationCount));
            ItemCount = Math.Max(20, Math.Min(1000, ItemCount));
            ErrorThreshold = Math.Max(0.1, Math.Min(2, ErrorThreshold));
            FuzzyFactor = Math.Max(1.01, Math.Min(Double.MaxValue, FuzzyFactor));
        }

        void resetData() => points.Clear();

        //her ihtiyaç olduğunda pencerenin içinin yeniden çizilmesi için
        private void ReDraw() => pictureBox.Invalidate();

        void randomData()
        {
            if (int.TryParse(t_item.Text, out ItemCount) == false) ItemCount = 200;
            ItemCount = Math.Max(20, Math.Min(1000, ItemCount));
            resetData();
            for (int i = 0; i < ItemCount; i++)
            {   //pencere eni ve boyu içinde rastgele sayılar üretecek.
                points.Add(new Point2D(pictureBox.Width, pictureBox.Height));
            }
            ReDraw();
        }

        void addData(int x, int y)
        {
            //tıklandığı alan içinde merkezden 'radius' uzaklık arasında 'count' tane nokta üretecek
            float radius = Math.Max(pictureBox.Width,pictureBox.Height) / 15f;
            int count = ItemCount / 60;

            for (int i = 0; i < count; i++)
            {
                double r = random.NextDouble() * radius;
                double ang = random.NextDouble() * Math.PI;
                float _x = (float) (r * Math.Cos(ang)) + x;
                float _y = (float) (r * Math.Sin(ang)) + y;
                if (0 > _x || _x > pictureBox.Width) continue;
                if (0 > _y || _y > pictureBox.Height) continue;  // oluşan nokta pencere içinde değilse listeye ekleme
                points.Add(new Point2D(_x, _y));
            }
            ReDraw();
        }


        // yeniden gruplama için çağırılır
        // kümeler yeniden oluşturulup kümeleme algoritmalarından biri çağırılır
        private void resetall()
        {
            collectData();
            clusters.Clear();       

            //eğer önceden elle nokta girilmedi ise rastgele noktalar üret
            if(points.Count == 0) randomData();


            //en fazla 10 kümeye izin verdik, 10 tane renk seçtik.
            //eğer daha fazla küme sayısına çıkmak isterseniz renkleride arttırın.
            var colours = new[]
            {
                Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Violet, Color.Chocolate, Color.DarkOrchid,
                Color.YellowGreen, Color.Teal, Color.Purple
            };

            for(int i=0;i<ClusterCount;i++)
            { // kümeleri yine pencere içinde rastgele şeçilen merkez noktaları ile yeniden oluştur
                clusters.Add(new Cluster(random,pictureBox.Width, pictureBox.Height, colours[i%colours.Length]));
            }


            ReDraw();
            AnimTimer.Enabled = animatecheck.Checked;
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //arka planı temizle
            g.FillRectangle(Brushes.White, 0, 0, pictureBox.Width, pictureBox.Height);

            //noktaların hepsini çiz
            foreach (var p in points) p.draw(g);


            //finalscene eğer true olursa ekrana kümelerin bulunan tüm merkezlerinin
            //çizdirir, böylece değişimi görmüş oluruz.

            bool finalscene = AnimTimer.Enabled == false;
            finalscene = finalscene || animatecheck.Checked == false;
            finalscene = finalscene && show_olds.Checked;

            //kümelerin hepsini çiz
            foreach (var c in clusters) c.draw(g, finalscene);
        }

        double iterasyonFCM()
        {
            //tüm noktaların tüm küme merkezlerine göre üyeliklerini hesaplar
            foreach (var point in points) { point.CalculateMSV(clusters, FuzzyFactor); }
            //tüm kümelerin noktaların üyeliklerine göre yeni merkezini hesaplar
            double err = clusters.Select((t, i) => t.calculateOrigin(i, points, FuzzyFactor)).Sum();
            //eğer yer değiştirme azaldı ise iterasyon biter.
            if (err < ErrorThreshold) AnimTimer.Enabled = false;
            return err;
        }

        double iterasyonKMEAN()
        {
            //tüm kümelere ait üyeleri temizle
            clusters.ForEach(c => c.members.Clear());

            //tüm noktaların tüm küme merkezlerine uzaklıklarını hesapla
            //kümenin merkezine en yakın olan noktayı o kümeye ekle
            foreach(var p in points)
            {
                float m = float.MaxValue;
                Cluster c = clusters[0];
                foreach(var cl in clusters)
                {
                    float dist = cl.origins.dist(p);
                    if (dist > m) continue;
                    m = dist;
                    c = cl;
                }
                c.add(p);
            }

            //tüm kümelerin kendi üyelerinin koordinatlarının aritmetik ortasını o kümenin yeni merkezi yap
            double err = clusters.Sum(c => c.CheckOrigin());
            //yer değiştirme hata payının altında ise iterasyonu bitir.
            AnimTimer.Enabled = err > ErrorThreshold;
            return err;
        }

        private bool kmeans = true;
        private int iterCount = 0;
        private void AnimTimer_Tick(object sender, EventArgs e)
        {
            double err = kmeans ? iterasyonKMEAN() : iterasyonFCM();
            if (++iterCount > IterationCount)
                AnimTimer.Enabled = false;
            Text = $@"Iterasyon : {iterCount} Error : {err:E2}";
            ReDraw();
        }

        private void Animate_CheckedChanged(object sender, EventArgs e)
        {
            AnimTimer.Enabled = animatecheck.Checked;
        }

        private void start_Click(object sender, EventArgs e)
        {
            kmeans = true;
            resetall();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kmeans = false;
            resetall();
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (AnimTimer.Enabled) return;
            addData(e.X, e.Y);
        }

        private void random_data_Click(object sender, EventArgs e)
        {
            randomData();
        }

        private void clear_data_Click(object sender, EventArgs e)
        {
            resetData();
            clusters.Clear();
            pictureBox.Invalidate();
        }
    }
}
