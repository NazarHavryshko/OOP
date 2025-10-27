using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using SimpleClassLibrary;

namespace Lab7
{
    internal class Program
    {
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

        static int InputPrice()
        {
            bool statusPorgram = true;

            int priceT = 0;

            while (statusPorgram)
            {
                Console.WriteLine("Оберіть, як ви хочете ввести вартість навчання:");
                Console.WriteLine("1. Ввести вартість за місяць.");
                Console.WriteLine("2. Ввести вартість за рік.");
                Console.WriteLine("3. Ввести вартість за весь період.");

                InputPosibleIntNumber(out priceT);

                if (priceT > 0 && priceT < 4)
                {
                    statusPorgram = false;
                }
                else
                {
                    Console.WriteLine("Ви вибрали неіснуючий пунк спробуйте ще раз.");
                }

            }
            string[] typeP = { "місяць", "рік", "весь період" };
            Console.WriteLine($"Введіть вартість за {typeP[priceT - 1]}:");
            int price;

            InputPosibleIntNumber(out price);
            switch (priceT)
            {
                case 1:
                    break;
                case 2:
                    price /= 10;
                    break;
                case 3:
                    price /= 40;
                    break;
            }

            return price;
        }

        static void AddNewStudent(List<Student> Students)
        {

            while (true)
            {
                Console.WriteLine("Ведіть ім'я студента:");
                string name = Console.ReadLine();
                Console.WriteLine("Ведіть код групи:");
                string code = Console.ReadLine();
                Console.WriteLine("Ведіть номер курсу:");
                string course = Console.ReadLine();
                Console.WriteLine("Ведіть кількість предметів:");
                string num = Console.ReadLine();

                int price = InputPrice();
                


                try
                {
                    Student student = new Student(name, code, course, num, price);
                    int numx = 0;
                    Result[] results = new Result[Convert.ToInt32(num)];

                    while (Convert.ToString(numx) != num)
                    {
                        Console.WriteLine("Ведіть назву придмету:");
                        string nameSub = Console.ReadLine();
                        Console.WriteLine("Ведіть ім'я вчителя:");
                        string nameT = Console.ReadLine();
                        Console.WriteLine("Виберіть це екзамен (1) чи залік (2):");
                        string ex = Console.ReadLine();
                        Console.WriteLine("Ведіть бал від 1 до 100:");
                        string point = Console.ReadLine();

                        try
                        {
                            Result result = new Result(nameSub, nameT, ex, point);
                            results[numx] = result;
                            numx++;
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Ви ввели невірне значення предмету.");
                        }

                    }
                    student.AddResults(results);
                    Students.Add(student);
                    break;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Ви ввели невірне значення ");
                }
            }

        }

        static void ShowStudents(List<Student> Students)
        {
            for (int i = 0; i < Students.Count; i++)
            {
                Console.WriteLine($"№ {i + 1} – {Students[i].ToString()}");
            }
        }

        static void ShowStudentResults(List<Student> Students)
        {
            ShowStudents(Students);

            Console.WriteLine("Виберіть одного з студентів:");
            int num;
            while (true)
            {


                InputPosibleIntNumber(out num);

                if (num > 0 && num <= Students.LongCount())
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Вибераного вами студента неіснує спробуйте знову:");
                }
            }


            Console.WriteLine(Students[num - 1].ToString());
            for (int i = 0; i < Students[num - 1].Results.Length; i++)
            {
                Console.WriteLine($"\t{Students[num - 1].Results[i].ToString()}");
            }
        }

        static void ShowArithmeticMean(List<Student> Students)
        {
            ShowStudents(Students);

            Console.WriteLine("Виберіть одного з студентів:");
            int num;
            while (true)
            {


                InputPosibleIntNumber(out num);

                if (num > 0 && num <= Students.LongCount())
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Вибераного вами студента неіснує спробуйте знову:");
                }
            }
            num--;
            Console.WriteLine($"Cереднє арифметичне серед всіх оцінок обраного студента {Students[num].FullName} – {Students[num].GetAveragePoint()}");

        }


        static void LowestScore(List<Student> Students)
        {
            ShowStudents(Students);

            Console.WriteLine("Виберіть одного з студентів:");
            int num;
            while (true)
            {


                InputPosibleIntNumber(out num);

                if (num > 0 && num <= Students.LongCount())
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Вибераного вами студента неіснує спробуйте знову:");
                }
            }
            num--;

            Console.WriteLine($"Найнижчий бал {Students[num].FullName} – з предмету {Students[num].GetWorstSubject()}");

        }

        static void ShowTuitionFee(List<Student> Students)
        {
            ShowStudents(Students);

            Console.WriteLine("Виберіть одного з студентів:");
            int numSt;
            while (true)
            {


                InputPosibleIntNumber(out numSt);

                if (numSt > 0 && numSt <= Students.LongCount())
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Вибераного вами студента неіснує спробуйте знову:");
                }
            }
            numSt--;
            Console.WriteLine("Оберіть, як ви хочете побачите вартість навчання:");
            Console.WriteLine("1. Вартість за місяць.");
            Console.WriteLine("2. Вартість за рік.");
            Console.WriteLine("3. Вартість за весь період.");
            int num=0; 
            while (true)
            {


                InputPosibleIntNumber(out num);

                if (num > 0 && num < 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ви вибрали неіснуючий пунк спробуйте ще раз.");
                }
            }
            num--;
            int[] price = {1, 10, 40};
            string[] str = { "місяць", "рік", "весь період"};

            Console.WriteLine($"Вартісьт навчання студента {Students[numSt].FullName} за {str[num]} {Students[numSt].TuitionFee * price[num]}");

        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<Student> Students = new List<Student>();

            bool statusPorgram = true;

            while (statusPorgram)
            {
                Console.WriteLine("Виберіть що ви хочити зробити:");
                Console.WriteLine("1. Добавити нового студента.");
                Console.WriteLine("2. Показати всіх студентів.");
                Console.WriteLine("3. Показати придмети обраного студента.");
                Console.WriteLine("4. Показати середнє арифметичне серед всіх оцінок обраного студента.");
                Console.WriteLine("5. Показати назву предмета, по якому студент отримав найнижчий бал.");
                Console.WriteLine("6. Показати ціну за навчання обраного студента.");

                Console.WriteLine("9. Закінчити програму.");

                int swN;


                InputPosibleIntNumber(out swN);

                switch (swN)
                {
                    case 9:
                        statusPorgram = false;
                        break;
                    case 8:
                        Students = Test.testStudent();
                        break;

                    case 1:
                        AddNewStudent(Students);
                        break;
                    case 2:
                        ShowStudents(Students);
                        break;
                    case 3:
                        ShowStudentResults(Students);
                        break;

                    case 4:
                        ShowArithmeticMean(Students);
                        break;
                    case 5:
                        LowestScore(Students);
                        break;
                    case 6:
                        ShowTuitionFee(Students);
                        break;
                    default:
                        Console.WriteLine("Ви вибрали неіснуючий пунк спробуйте ще раз.");
                        break;
                }
            }

        }
    }
}
