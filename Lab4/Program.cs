using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Program
    {
        //Введення додатніх чисел
        public static void InputPosibleIntNumber(out int x)
        {
            x = -1;
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
                    x = x.Replace('.', ',');
                    y = y.Replace('.', ',');
                    this.x = Math.Round(double.Parse(x), 2);
                    this.y = Math.Round(double.Parse(y), 2);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ви ввели невірні значення х або y спробуйти знову.");
                    throw;
                }
            }

            public override string ToString() {
                return $"X = {this.x}     \t Y = {this.y}";
            }

            public double LengthToBegDordogne()
            {
                return Math.Round(Math.Pow((Math.Pow(this.x, 2) + Math.Pow(this.y, 2)), 0.5), 2);
            }

            public double X()
            {
                return this.x;
            }
            public double Y()
            {
                return this.y;
            }
            public void changeX(string x)
            {
                try
                {
                    x = x.Replace('.', ',');
                    this.x = Math.Round(double.Parse(x), 2);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ви ввели невірні значення х спробуйти знову.");
                    throw;
                }
            }
            public void changeY(string y)
            {
                try
                {
                    y = y.Replace('.', ',');
                    this.y = Math.Round(double.Parse(y), 2);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ви ввели невірні значення y спробуйти знову.");
                    throw;
                }
            }

            public bool theSamePoint(double x, double y)
            {
                return this.x == x && this.y == y;
            }

            public double[] ToPolar()
            {
                double[] Polar = { LengthToBegDordogne(), Math.Atan2(this.y, this.x) };
                return Polar;
            }
        }

        //Ввести точки з клавіатури
        public static Point[] createPointsArray(int n)
        {
            Point[] points = new Point[n];
            Point p;
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
                        p = new Point(x, y);
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

        //Створити Рандомні точки
        public static Point[] createRandomPointsArray(int n)
        {
            Point[] points = new Point[n];

            Random rand = new Random();
            double min = -10, max = 10;

            for (int i = 0; i < n; i++)
            {
                bool status = true;
                while (status)
                {
                    try
                    {
                        string x = Convert.ToString(Math.Round((rand.NextDouble() * (max - min) + min), 2));
                        string y = Convert.ToString(Math.Round((rand.NextDouble() * (max - min) + min), 2));
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

        //Вивести масив на екран
        public static void showPointsArray(Point[] points)
        {
            for (int i = 0; i < points.Length; i++)
            {
                Console.WriteLine($"Точка № {i + 1} має кординати {points[i].ToString()}                     \t відстань до початку кординат {points[i].LengthToBegDordogne()}.");
            }
        }

        // Вести кількість елементів з якими потрібно створити масив
        public static int enterNumEl() {
            int n;
            Console.WriteLine("Введіть скільки точок потрібно створити.");
            InputPosibleIntNumber(out n);
            return n;
        }

        // Сортування масиву за вибраним критерієм
        public static void sortArray(Point[] points)
        {
            bool status = true;
            int Num = -1;
            Console.WriteLine("За чим ви хочете сортувати масив:");
            Console.WriteLine("1. За Х.");
            Console.WriteLine("2. За Y.");
            Console.WriteLine("3. За відстаню від початку кординат.");
            while (status)
            {
                InputPosibleIntNumber(out Num);

                if (Num == 1 || Num == 2 || Num == 3)
                {
                    status = false;
                }
                else
                {
                    Console.WriteLine("Ви не вибрали існуючих пунктів спробуйте ще раз.");
                }
            }

            bool moreThen = false;
            Point temp = new Point();
            for (int i = 0; i < points.Length - 1; i++)
            {
                for (int j = 0; j < points.Length - 1 - i; j++)
                {
                    switch (Num)
                    {
                        case 1:
                            if (points[j].X() > points[j+1].X())
                            {
                                moreThen = true;
                            }
                            break;
                        case 2:
                            if (points[j].Y() > points[j + 1].Y())
                            {
                                moreThen = true;
                            }
                            break;
                        case 3:
                            if (points[j].LengthToBegDordogne() > points[j + 1].LengthToBegDordogne())
                            {
                                moreThen = true;
                            }
                            break;
                    }
                    if (moreThen)
                    {
                        temp = points[j];
                        points[j] = points[j + 1];
                        points[j + 1] = temp;
                        moreThen = false;
                    }
                }
            }
        }

        // Змінити вибраний елемент
        public static void changePoint(ref Point point)
        {
            Console.WriteLine("Що ви хочете змінити x (1), y (2)");

            bool status = true;
            int Num = -1;

            while (status)
            {
                InputPosibleIntNumber(out Num);

                if (Num == 1 || Num == 2)
                {
                    status = false;
                }
                else
                {
                    Console.WriteLine("Ви не вибрали існуючих пунктів спробуйте ще раз.");
                }
            }

            status = true;

            while (status)
            {
                try
                {
                    switch (Num)
                    {
                        case 1:
                            Console.WriteLine($"Ведеіть значення х");
                            string x = Console.ReadLine();
                            point.changeX(x);
                            status = false;
                            break;
                        case 2:
                            Console.WriteLine($"Ведеіть значення y");
                            string y = Console.ReadLine();
                            point.changeY(y);
                            status = false;
                            break;
                    }                    
                }
                catch (FormatException)
                {

                }
            }
        }

        // Зміна масиву
        public static void changeArray(Point[] points)
        {
            Console.WriteLine("Виберіть який елемент ви хочете змінити");
            showPointsArray(points);

            bool status = true;
            int Num = - 1;

            while (status)
            {
                InputPosibleIntNumber(out Num);

                if (Num > 0 && points.Length + 1 > Num)
                {
                    status = false;
                }
                else
                {
                    Console.WriteLine("Ви не вибрали існуючих пунктів спробуйте ще раз.");
                }
            }
            Num--;
            changePoint(ref points[Num]);
        }

        public static void MinMaxDistanseOut(Point[] points, out double min, out double max)
        {
            min = points[0].LengthToBegDordogne();
            max = points[0].LengthToBegDordogne();

            for (int i = 1; i < points.Length; i++) {
                if (points[i].LengthToBegDordogne() < min)
                {
                    min = points[i].LengthToBegDordogne();
                }

                if (points[i].LengthToBegDordogne() > max)
                {
                    max = points[i].LengthToBegDordogne();
                }
            }
        }

        // пошук найбільшої і найменшої відстані від початку кординат
        public static void MinMaxDistanse(Point[] points)
        {
            double min, max;
            MinMaxDistanseOut(points, out min, out max);
            Console.WriteLine($"Відстань до початку координат найближча {min}, найдальша {max}");
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool statusPorgram = true;
            int n = 0;
            n = enterNumEl();
            Point[] points = new Point[n];

            while (statusPorgram)
            {
                Console.WriteLine("Виберіть що ви хочити зробити:");
                Console.WriteLine("1. Створити n-кількість точок і ввести їх кординати.");
                Console.WriteLine("2. Створити n-кількість точок рандомно задати їх кординати.");

                int swN = -1;

                InputPosibleIntNumber(out swN);

                switch (swN)
                {
                    case 1:
                        points = createPointsArray(n);
                        statusPorgram = false;
                        break;

                    case 2:
                        points = createRandomPointsArray(n);
                        statusPorgram = false;
                        break;
                    default:
                        Console.WriteLine("Ви вибрали неіснуючий пунк спробуйте ще раз.");
                        break;
                }
            }

            statusPorgram = true;

            while (statusPorgram) {
                Console.WriteLine("Виберіть що ви хочити зробити:");
                Console.WriteLine("1. Показати кординати точок");
                Console.WriteLine("2. Сортувати точки.");
                Console.WriteLine("3. Змінити кординати вибраної точки.");
                Console.WriteLine("4. Максимальна і мінімальна відстань до початку кординат.");

                Console.WriteLine("9. Закінчити програму.");

                int swN;
                

                InputPosibleIntNumber(out swN);

                switch (swN)
                {
                    case 9:
                        statusPorgram = false;
                        break;

                    case 1:
                        showPointsArray(points);
                        break;
                    case 2:
                        sortArray(points);
                        break;
                    case 3:
                        changeArray(points);
                        break;
                    case 4:
                        MinMaxDistanse(points);
                        break;
                    default:
                        Console.WriteLine("Ви вибрали неіснуючий пунк спробуйте ще раз.");
                        break;
                }
            }
            //double[] Polar = points[0].ToPolar();
            //Console.WriteLine($"r = {Polar[0]}, f = {Math.Round(Polar[1])} радіан");
        }
        
    }
}
