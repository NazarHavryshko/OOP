using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Program
    {
        public static void InputPosibleIntNumber(ref int x)
        {
            string input_text;
            input_text = Console.ReadLine();
            bool status = true;



            while (status)
            {
                if (int.TryParse(input_text, out x) && x > 0)
                {
                    status = false;
                }
                else
                {
                    Console.WriteLine("    Ви ввели некоректне значення спробуйте знову. ");
                    input_text = Console.ReadLine();
                }
            }

        }

        public struct Point
        {
            double x;
            double y;
            public Point(string x, string y)
            {
                try
                {
                    this.x = double.Parse(x);
                    this.y = double.Parse(y);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ви ввели невірні значення х або y спробуйти знову.");
                    throw;
                }
            }

            public override string ToString() {
                return $"X = {this.x}, Y = {this.y}";
            }

            public double LengthToBegDordogne()
            {
                return Math.Pow((Math.Pow(this.x, 2) + Math.Pow(this.y, 2)), 0.5);
            }
            //public void changeX(string x)
            //{
            //    this.x = x;
            //}
            //public void changeY(string y)
            //{
            //    this.y = y;
            //}
        }

        public static Point[] createPointsArray(int n)
        {
            Point[] points = new Point[n];

            for (int i = 0; i < n; i++)
            {
                bool status = true;
                while (status)
                {
                    try
                    {
                        Console.WriteLine($"Ведеіть значення х точки № {i + 1}");
                        string x = Console.ReadLine();
                        Console.WriteLine($"Ведеіть значення y точки № {i + 1}");
                        string y = Console.ReadLine();
                        Point p = new Point(x, y);
                        points[i] = p;
                        status = false;
                    }
                    catch (FormatException)
                    {

                    }
                }
            }

            return points;
        }

        public static void showPointsArray(Point[] points)
        {
            for (int i = 0; i < points.Length; i++)
            {
                Console.WriteLine($"Точка № {i + 1} має кординати {points[i].ToString()}.");
            }
        }

       

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int n = 0;
            Console.WriteLine("Введіть скільки кількість точок.");
            InputPosibleIntNumber(ref n);
            Point[] points = new Point[n];
            points = createPointsArray(n);
            showPointsArray(points);

        }
    }
}
