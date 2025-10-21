using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimpleClassLibrary
{
    public enum TriangleType
    {
        Isosceles, // рівнобедрений 
        MultiSided,  // різносторонній 
        Rectangular // прямокутний
    }
    public struct Point
    {
        double x;
        double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return $"x = {this.x}, y =  {this.y}";
        }
    }
    public class Shape
    {
        private string Name;
        private double Area;
        private Point ReferencePoint;

        public Shape()
        {
            this.Name = "Невідомо";
            this.Area = 0.0;
            this.ReferencePoint = new Point(0.0, 0.0);
        }

        private bool СheckСorrectSText(string text)
        {
            return Regex.IsMatch(text, @"^[a-zA-Zа-яА-ЯїЇіІєЄґҐ\-'\s\.]+$") && text.Length >= 3;
        }

        static public bool СheckСorrectDouble(string text, out double test)
        {
            test = 0;
            return text.Length > 0 && double.TryParse(text, out test);
        }



        public Shape(string name,  string x, string y)
        {
            double  xD, yD;

            if (СheckСorrectSText(name) 
                && СheckСorrectDouble(x, out xD) && СheckСorrectDouble(y, out yD))
            {
                this.Name = name;
                this.ReferencePoint = new Point(xD, yD);
            }

        }

        public Shape(string name, string area, string x, string y) : this(name, x, y)
        {
            double areaD;

            if (СheckСorrectDouble(area, out areaD)) {
                this.Area = areaD;
            }

        }

        public Shape(Shape other)
        {
            this.Name = other.Name;
            this.Area = other.Area;
            this.ReferencePoint = other.ReferencePoint;
        }

        public override string ToString()
        {
            return $"Фігура: {this.Name}, площа = {this.Area}, точка відліку {this.ReferencePoint.ToString()}";
        }

        public void ChangePoint(string x, string y)
        {
            double xD, yD;

            if (СheckСorrectDouble(x, out xD) && СheckСorrectDouble(y, out yD))
            {
                this.ReferencePoint = new Point(xD, yD);
            }
        }

        public void ChangeName(string name)
        {
            if (СheckСorrectSText(name))
            {
                this.Name = name;
            }
        }

        public bool ComparisonObjects(Shape other)
        {
            return other.Area == this.Area;
        }
    }

    public class Triangle : Shape
    {
        private TriangleType Type;

        public Triangle(string name, string area, string x, string y, TriangleType type) : base(name, area, x, y) { 
            this.Type = type;
        }

        public Triangle(string name, string x, string y, TriangleType type) : base(name, x, y)
        {
            this.Type = type;
        }

        public void ChangeType(TriangleType type)
        {
            this.Type = type;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, тип трикутника - {this.Type}";
        }
    } 

}
