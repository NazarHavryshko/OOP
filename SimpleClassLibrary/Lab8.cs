using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
        protected string Name;
        protected double Area;
        protected Point ReferencePoint;

        public Shape()
        {
            this.Name = "Невідомо";
            this.Area = 0.0;
            this.ReferencePoint = new Point(0.0, 0.0);
        }

        public bool СheckСorrectSText(string text)
        {
            return Regex.IsMatch(text, @"^[a-zA-Zа-яА-Я0-9їЇіІєЄґҐ\-'\s\.]+$") && text.Length >= 3;
        }

        public bool СheckСorrectDouble(string text, out double test)
        {
            test = 0;
            return text.Length > 0 && double.TryParse(text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out test);
        }



        public Shape(string area, string x, string y)
        {
            double areaD, xD, yD;

            if (СheckСorrectDouble(area, out areaD)
                && СheckСorrectDouble(x, out xD) && СheckСorrectDouble(y, out yD))
            {
                this.Area = areaD;
                this.ReferencePoint = new Point(xD, yD);
            }
            else
            {
                throw new ArgumentException("Один або більше параметрів для створення Result є некоректними.");
            }

        }

        public Shape(string name, string area, string x, string y) : this(area, x, y)
        {
            if (СheckСorrectSText(name)) {

                this.Name = name;
            }
            else
            {
                throw new ArgumentException("Один або більше параметрів для створення Result є некоректними.");
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
            else
            {
                throw new ArgumentException("Один або більше параметрів для створення трикутника є некоректними.");
            }
        }

        public void ChangeName(string name)
        {
            if (СheckСorrectSText(name))
            {
                this.Name = name;
            }
            else
            {
                throw new ArgumentException("Один або більше параметрів для створення трикутника є некоректними.");
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
        public Triangle() : base()
        {
            this.Type = TriangleType.MultiSided;
        }

        public Triangle(string name, string area, string x, string y, TriangleType type) : base(name, area, x, y) {
            this.Type = type;
        }

        public Triangle(string area, string x, string y, TriangleType type) : base(area, x, y)
        {
            this.Type = type;
        }

        public Triangle(Triangle other) : base(other)
        {
            this.Type = other.Type;
        }

        public void ChangeType(TriangleType type)
        {
            this.Type = type;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, тип трикутника - {this.Type}";
        }

        public bool ComparisonObjects(Triangle other)
        {

            return other.Type == this.Type && base.ComparisonObjects(other);
        }
    }

    public class Circle : Shape
    {
        private double Radius;
        public Circle() : base()
        {
            this.Radius = 0.0;
        }

        public Circle(string name, string x, string y, string radius)
        {
            double xD, yD, r;
            if (СheckСorrectSText(name) && СheckСorrectDouble(radius, out r)
                && СheckСorrectDouble(x, out xD) && СheckСorrectDouble(y, out yD))
            {
                this.Area = Math.Round((Math.Pow(r, 2) * Math.PI), 4);
                this.ReferencePoint = new Point(xD, yD);
                this.Name = name;

                this.Radius = r;
            }
            else
            {
                throw new ArgumentException("Один або більше параметрів для створення кола є некоректними.");
            }
        }

        public Circle(string x, string y, string radius)
        {
            double xD, yD, r;
            if (СheckСorrectDouble(radius, out r)
                && СheckСorrectDouble(x, out xD) && СheckСorrectDouble(y, out yD))
            {
                this.Area = Math.Round((Math.Pow(r, 2) * Math.PI), 4);
                this.ReferencePoint = new Point(xD, yD);


                this.Radius = r;
            }
            else
            {
                throw new ArgumentException("Один або більше параметрів для створення кола є некоректними.");
            }
        }

        public Circle(Circle other) : base(other)
        {
            this.Radius = other.Radius;
        }

        public void ChangeRadius(string radius)
        {
            double r;
            if (СheckСorrectDouble(radius, out r))
            {
                this.Radius = r;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}, радіус кола - {this.Radius}";
        }

        public bool ComparisonObjects(Circle other)
        {

            return other.Radius == this.Radius && base.ComparisonObjects(other);
        }
    }

    public class Fraction
    {
        private int Numerator; // чисельник
        private int Denominator;  // знаменник
        public Fraction()
        {
            this.Numerator = 1;
            this.Denominator = 2;
        }

        public Fraction(Fraction other)
        {
            this.Numerator = other.Numerator;
            this.Denominator = other.Denominator;
        }

        public void FractionReduction()
        {
            int a = Math.Abs(this.Numerator), b = Math.Abs(this.Denominator);

            // Алгоритм Евкліда
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            this.Numerator /= a;
            this.Denominator /= a;
        }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new DivideByZeroException("Знаменник не може бути нулем.");
            }

            this.Numerator = numerator;
            this.Denominator = denominator;

            if (this.Denominator < 0)
            {
                this.Numerator *= -1;
                this.Denominator *= -1;
            }
        }

        public override string ToString()
        {
            return $"{this.Numerator}/{this.Denominator}";
        }

        public static Fraction operator +(Fraction a)
        {
            return new Fraction(a.Numerator, a.Denominator);
        }

        public static Fraction operator -(Fraction a)
        {
            return new Fraction(a.Numerator * -1, a.Denominator);
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            int newNumerator, newDenominator;
            if (b.Denominator == a.Denominator)
            {
                newNumerator = a.Numerator + b.Numerator;
                newDenominator = a.Denominator;
            }
            else
            {
                newNumerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
                newDenominator = b.Denominator * a.Denominator;
            }
            Fraction frac = new Fraction(newNumerator, newDenominator);
            frac.FractionReduction();
            return frac;
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            int newNumerator, newDenominator;
            if (b.Denominator == a.Denominator)
            {
                newNumerator = a.Numerator - b.Numerator;
                newDenominator = a.Denominator;
            }
            else
            {
                newNumerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
                newDenominator = b.Denominator * a.Denominator;
            }

            Fraction frac = new Fraction(newNumerator, newDenominator);
            frac.FractionReduction();
            return frac;
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            int newNumerator = a.Numerator * b.Numerator;
            int newDenominator = b.Denominator * a.Denominator;

            Fraction frac = new Fraction(newNumerator, newDenominator);
            frac.FractionReduction();
            return frac;
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.Numerator == 0)
            {
                throw new DivideByZeroException("Не можна ділити на нульовий дріб.");
            }

            int newNumerator = a.Numerator * b.Denominator;
            int newDenominator = a.Denominator * b.Numerator;

            Fraction frac = new Fraction(newNumerator, newDenominator);
            frac.FractionReduction();
            return frac;
        }

        public static bool operator ==(Fraction a, Fraction b)
        {

            return (long)a.Numerator * b.Denominator == (long)b.Numerator * a.Denominator;
        }

        public static bool operator !=(Fraction a, Fraction b)
        {
            return !(a == b);
        }

        public static bool operator >(Fraction a, Fraction b)
        {
            return (long)a.Numerator * b.Denominator > (long)b.Numerator * a.Denominator;
        }

        public static bool operator <(Fraction a, Fraction b)
        {
            return (long)a.Numerator * b.Denominator < (long)b.Numerator * a.Denominator;
        }

        public static bool operator >=(Fraction a, Fraction b)
        {
            return (a > b) || (a == b);
        }

        public static bool operator <=(Fraction a, Fraction b)
        {
            return (a < b) || (a == b);
        }

        public static implicit operator double(Fraction f)
        {

            return (double)f.Numerator / f.Denominator;
        }

        public override bool Equals(object obj)
        {
            if (obj is Fraction other)
            {
                return this == other;
            }

            return false;
        }

        public override int GetHashCode()
        {

            Fraction temp = new Fraction(this.Numerator, this.Denominator);

            temp.FractionReduction();

            return temp.Numerator.GetHashCode();
        }
    }
}
