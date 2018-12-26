using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watson.Graphical
{
    public class Circle
    {
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
            float angle = 10;
            double b, c;// 边长，b是高（Y轴），C是长（X轴）
            float B, C;// 角度，设定B是向量-变化
            for (int i = 0; i < 36; i++)
            {
                float angleCenter = angle * i;
                if (angleCenter <= 180)
                {
                    B = angleCenter;
                    C = 90 - B;
                }
                else
                {
                    B = angleCenter - 360;
                    C = 90 - B;
                }
                b = radius * Math.Sin(Math.PI * B / 180);
                c = radius * Math.Sin(Math.PI * C / 180);

                // 1.同一纬线上经度差一度,实际距离差多少
                // 111km*cosφ （φ为当地纬度）
                // 2.同一经线上纬度差一度,实际距离差多少
                // 111km
                b = b / (111000 * Math.Cos(center.lon)) + center.lon;
                c = c / 111000 + center.lat;
                points.Add(new Point(b, c));
            }
        }
    }
}
