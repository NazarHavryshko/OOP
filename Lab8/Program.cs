using SimpleClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Lab8
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool statusPorgram = true;

            while (statusPorgram)
            {
                Console.WriteLine("Виберіть що ви хочити зробити:");
                Console.WriteLine("1. Працювати з фігурами.");
                Console.WriteLine("2. Працювати з дробами.");


                Console.WriteLine("9. Закінчити програму.");

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
                        ShapesWork.ShapeArea();
                        break;
                    case 2:
                        FractionWork.FractionArea();
                        break;

                    default:
                        Console.WriteLine("Ви вибрали неіснуючий пунк спробуйте ще раз.");
                        break;
                }
            }
        }
    }
}
