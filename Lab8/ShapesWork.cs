using SimpleClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    internal class ShapesWork
    {

        static private void AddTriangle(List<Shape> shapes)
        {
            while (true)
            {
                Console.WriteLine("Ведіть назву фігури:");
                string name = Console.ReadLine();
                Console.WriteLine("Ведіть площу фігури:");
                string area = Console.ReadLine();
                Console.WriteLine("Ведіть кординату відліку (x):");
                string x = Console.ReadLine();
                Console.WriteLine("Ведіть кординату відліку (y):");
                string y = Console.ReadLine();
                Console.WriteLine("Виберіть вид трикутник рівнобедренний (1) рівносторонній (2) прямокутний (3):");
                int num;

                while (true)
                {
                    InputValue.InputPosibleIntNumber(out num);
                    if (num < 1 && num > 3)
                    {
                        Console.WriteLine("Ви вибрали неіснуючий пунк спробуйте ще раз.");
                    }
                    else
                    {
                        break;
                    }
                }


                try
                {
                    Triangle triangle = new Triangle(name, area, x, y, (TriangleType)(num - 1));
                    shapes.Add(triangle);                   
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static private void AddCircle(List<Shape> shapes)
        {
            while (true)
            {
                Console.WriteLine("Ведіть назву фігури:");
                string name = Console.ReadLine();
                Console.WriteLine("Ведіть кординату центру (x):");
                string x = Console.ReadLine();
                Console.WriteLine("Ведіть кординату центру (y):");
                string y = Console.ReadLine();
                Console.WriteLine("Ведіть радіус кола:");
                string radius = Console.ReadLine();


                try
                {
                    Circle circle = new Circle(name, x, y, radius);
                    shapes.Add(circle);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static private void ShowInfo(List<Shape> shapes)
        {
            foreach (Shape item in shapes)
            {
                Console.WriteLine(item.ToString());
            }
        }

        static internal void ShapeArea()
        {
            bool statusPorgram = true;
            List<Triangle> triangles = new List<Triangle>();
            List<Circle> circles = new List<Circle>();
            List<Shape> shapes = new List<Shape>();

            while (statusPorgram)
            {
                Console.WriteLine("Виберіть що ви хочити зробити:");
                Console.WriteLine("1. Добавити трикутник.");
                Console.WriteLine("2. Добавити коло.");
                Console.WriteLine("3. Показати всі фігури.");
                //Console.WriteLine("4. Показати середнє арифметичне серед всіх оцінок обраного студента.");
                //Console.WriteLine("5. Показати назву предмета, по якому студент отримав найнижчий бал.");
                //Console.WriteLine("6. Показати ціну за навчання обраного студента.");

                Console.WriteLine("9. Повернутися до попереднього меню (усі дані видаляться).");

                int swN;


                InputValue.InputPosibleIntNumber(out swN);

                switch (swN)
                {
                    case 9:
                        statusPorgram = false;
                        break;
                    //case 8:
                    //    Students = Test.testStudent();
                    //    break;

                    case 1:
                        AddTriangle(shapes);
                        break;
                    case 2:
                        AddCircle(shapes);
                        break;
                    case 3:
                        ShowInfo(shapes);
                        break;

                    default:
                        Console.WriteLine("Ви вибрали неіснуючий пунк спробуйте ще раз.");
                        break;
                }
            }
        }
    }
}
