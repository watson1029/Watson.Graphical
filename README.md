地图-图形判断
=====
### 概述
* Base on DotNetFramwork4.5.2
* Base on System.SqlServer.Types
### 更新日志
[TODO.md](TODO.md)
### 安装
Install-Package Watson.Graphical -Version 1.1.0
### 方法列表
* LineToLine(line, line) 两条直线关系判断
* LineToPolygon(line, polygon) 直线与多边形关系判断
* LineToCircle(line, circle) 直线与圆形关系判断
* PolygonToPolygon(polygon, polygon) 两个多边形关系判断
* PolygonToCircle(polygon, circle) 多边形与圆形关系判断
* CircleToCircle(circle, circle) 两个圆形关系判断
### 其他方法
* BMapLib.GeoUtils.isPointInPolygon(point, polygon) 点与多边形关系判断
* BMapLib.GeoUtils.isPointInCircle(point, circle) 点与圆形关系判断
