using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TBAppAcier.Dessins
{
    public class Dessin
    {

        #region Basic drawing methods (points, lines)

        /// <summary>
        /// Get the path for a point
        /// The color and the diameter is chosen in the other method or class
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Path GetPathPoint(double x, double y, double φcircle, Brush color)
        {

            Point pts = new Point(x, y);
            EllipseGeometry circleGeo = new EllipseGeometry(pts, φcircle, φcircle);

            Path myPath = new Path();
            myPath.Stroke = color;
            myPath.Fill = Brushes.Brown;
            myPath.Data = circleGeo;
            return myPath;
        }


        /// <summary>
        /// Method used to draw a line in different color
        /// </summary>
        /// <param name="startPoint"></param>
        /// <param name="endPoint"></param>
        /// <returns></returns>
        public Path GetPathLine(Point startPoint, Point endPoint, Brush color, double thickness)
        {

            LineGeometry lineGeo = new LineGeometry(startPoint, endPoint);

            Path myPath = new Path();
            myPath.Stroke = color;
            myPath.Data = lineGeo;
            return myPath;

        }




        /// <summary>
        /// Get the path for a point
        /// The color and the diameter is chosen in the other method or class
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public ArcSegment GetArcSegment(double x, double y, Size size, double rotationAngle, Brush color)
        {

            

            Point pts = new Point(x, y);
            
            ArcSegment arcseg = new ArcSegment(pts, size , rotationAngle, true, SweepDirection.Clockwise,true);

                     


           
            return arcseg;
        }




        public PathFigure GetPathFigure(double X, double Y)
        {

            PathFigure pthFigure = new PathFigure();
            pthFigure.StartPoint = new Point(X, Y);

            return pthFigure;

        }

        #endregion



        #region Scale

        public double GetScaleX(double dimensionEnfant, double dimensionParent)
        {
            double s;
            if (dimensionEnfant > dimensionParent)
            {
                s = dimensionParent / dimensionEnfant;
            }            
            else
                s = 1;


            return s;
        }


        public double GetScaleNormal(double dimensionEnfant, double dimensionParent)
        {
            double s;
            if (dimensionEnfant > dimensionParent && dimensionEnfant < 1.5 * dimensionParent)
            {
                s = 0.6;
            }
            else if (dimensionEnfant > 1.5 * dimensionParent && dimensionEnfant < 5 * dimensionParent)
            {

                s = 0.2;
            
            }
            else if (dimensionEnfant > 5 * dimensionParent && dimensionEnfant < 20 * dimensionParent)
            {

                s = 0.05;


            }
            else if (dimensionEnfant > 20 * dimensionParent)
            {

                s = 0.01;


            }
            else
                s = 1;
           

            return s;
        }


        #endregion


    }
}
