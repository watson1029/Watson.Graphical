using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watson.Graphical
{
    public class Line
    {
        public Point point1 { get; set; }
        public Point point2 { get; set; }
        public Line(Point point1, Point point2)
        {
            this.point1 = point1;
            this.point2 = point2;
        }
        public Line(double lon1, double lat1, double lon2, double lat2)
        {
            this.point1 = new Point(lon1, lat1);
            this.point2 = new Point(lon2, lat2);
        }
    }
}
