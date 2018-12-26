using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watson.Graphical
{
    public class Polygon
    {
        public List<Point> points { get; set; }
        public Polygon(List<Point> points)
        {
            this.points = points;
        }
    }
}
