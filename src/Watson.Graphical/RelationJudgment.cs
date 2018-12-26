using Microsoft.SqlServer.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watson.Graphical
{
    public class RelationJudgment
    {
        /// <summary>
        /// 判断两条直线关系
        /// </summary>
        /// <param name="line1"></param>
        /// <param name="line2"></param>
        /// <returns></returns>
        public static bool LineToLine(Line line1, Line line2)
        {
            if (Math.Min(line1.point1.lon, line1.point2.lon) <= Math.Max(line2.point1.lon, line2.point2.lon) 
             && Math.Min(line2.point1.lat, line2.point2.lat) <= Math.Max(line1.point1.lat, line1.point2.lat) 
             && Math.Min(line2.point1.lon, line2.point2.lon) <= Math.Max(line1.point1.lon, line1.point2.lon) 
             && Math.Min(line1.point1.lat, line1.point2.lat) <= Math.Max(line2.point1.lat, line2.point2.lat))
                return true;
            return false;
        }
        /// <summary>
        /// 判断直线与多边形的关系
        /// </summary>
        /// <param name="line"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public static bool LineToPolygon(Line line, Polygon polygon)
        {
            if (polygon.points.Count > 1)
            {
                for (int i = 1; i < polygon.points.Count; i++)
                {
                    if (LineToLine(line, new Line(polygon.points[i - 1], polygon.points[i])))
                        return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 判断直线和圆的关系
        /// </summary>
        /// <param name="line"></param>
        /// <param name="circle"></param>
        /// <returns></returns>
        public static bool LineToCircle(Line line, Circle circle)
        {
            Polygon polygonCircle = new Polygon(circle.points);
            return LineToPolygon(line, polygonCircle);
        }
        /// <summary>
        /// 判断两个多边形的关系
        /// </summary>
        /// <param name="polygon1"></param>
        /// <param name="polygon2"></param>
        /// <returns></returns>
        public static bool PolygonToPolygon(Polygon polygon1, Polygon polygon2)
        {
            if (polygon1.points.Count > 1 && polygon2.points.Count > 1)
            {
                for (int i = 1; i < polygon1.points.Count; i++)
                {
                    for (int j = 1; j < polygon2.points.Count; j++)
                    {
                        if (LineToLine(new Line(polygon1.points[i - 1], polygon1.points[i]), new Line(polygon2.points[j - 1], polygon2.points[j])))
                            return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 判断多边形与圆的关系
        /// </summary>
        /// <param name="polygon"></param>
        /// <param name="circle"></param>
        /// <returns></returns>
        public static bool PolygonToCircle(Polygon polygon, Circle circle)
        {
            Polygon polygonCircle = new Polygon(circle.points);
            return PolygonToPolygon(polygon, polygon);
        }

        public static bool CircleToCircle(Circle circle1, Circle circle2)
        {
            //4236代表WGS84这种坐标参照系统。
            var _circle1 = SqlGeography.Point(circle1.center.lat, circle1.center.lon, 4326);
            var _circle2 = SqlGeography.Point(circle2.center.lat, circle2.center.lon, 4326);
            double distance = (double)_circle1.STDistance(_circle2);
            if (distance > circle1.radius + circle2.radius)
                return false;
            else
                return true;
        }
    }
}
