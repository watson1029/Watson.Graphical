using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watson.Graphical
{
    public class Point
    {
        public double lon { get; set; }
        public double lat { get; set; }
        public Point(double lon, double lat)
        {
            this.lon = lon;
            this.lat = lat;
        }
    }
}
