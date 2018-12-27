using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watson.Graphical
{
    public class Circle
    {
        public const double Ea = 6378137;//赤道半径
        public const double Eb = 6356725;//极半径
        public Point center { get; set; }
        public double radius { get; set; }
        public List<Point> points { get; set; }
        public Circle(Point center, double radius)
        {
            this.center = center;
            this.radius = radius;
            PointCalculation();
        }
        public Circle(double lon, double lat, double radius)
        {
            this.center = new Point(lon, lat);
            this.radius = radius;
            PointCalculation();
        }
        /// <summary>
        /// 圆形绘制点计算
        /// </summary>
        private void PointCalculation()
        {
            points = new List<Point>();
            double angle = 10;
            for (int i = 0; i < 36; i++)
            {
                double dx = radius * Math.Sin(angle * i * Math.PI / 180.0);
                double dy = radius * Math.Cos(angle * i * Math.PI / 180.0);
                //double ec = 6356725 + 21412 * (90.0 - GLAT) / 90.0;
                //21412是赤道半径与极半径的差
                double ec = Eb + (Ea - Eb) * (90.0 - center.lat) / 90.0;
                double ed = ec * Math.Cos(center.lat * Math.PI / 180);
                double BJD = (dx / ed + center.lon * Math.PI / 180.0) * 180.0 / Math.PI;
                double BWD = (dy / ec + center.lat * Math.PI / 180.0) * 180.0 / Math.PI;
                points.Add(new Point(BJD, BWD));
            }
        }
    }
}
