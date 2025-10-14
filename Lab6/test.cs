using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class test
    {
        static public List<Student> testStudent()
        {
            List<Student> students = new List<Student>();

            Student student1 = new Student("Дмитренко Олександр Іванович", "КН-22", "2", "3");
            Result[] results1 = new Result[]
            {
                new Result("Математика", "Іванов І.І.", "1", "95"), // Екзамен, 95 балів
                new Result("Фізика", "Петрова О.С.", "1", "88"), // Екзамен, 88 балів
                new Result("Програмування", "Сидоренко В.В.", "2", "98") // Залік, 98 балів
            };

            student1.AddResults(results1);
            students.Add(student1);

            Student student2 = new Student("Ковальчук Анна Вікторівна", "КН-22", "2", "3");
            Result[] results2 = new Result[]
            {
                new Result("Математика", "Іванов І.І.", "1", "72"),
                new Result("Фізика", "Петрова О.С.", "1", "65"),
                new Result("Хімія", "Коваленко Л.П.", "2", "80")
            };

            student2.AddResults(results2);
            students.Add(student2);

            Student student3 = new Student("Мельник Сергій Петрович", "ЕК-23", "1", "3");
            Result[] results3 = new Result[]
            {
                new Result("Історія України", "Шевчук Р.Д.", "2", "90"),
                new Result("Філософія", "Олійник М.А.", "2", "85"),
                new Result("Правознавство", "Ткаченко І.О.", "1", "78")
            };

            student3.AddResults(results3);
            students.Add(student3);

            Student student4 = new Student("Олійник Катерина Олегівна", "КН-22", "2", "3");
            Result[] results4 = new Result[]
            {
                new Result("Програмування", "Сидоренко В.В.", "2", "60"),
                new Result("Бази даних", "Григоренко С.Г.", "1", "55"),
                new Result("Менеджмент", "Павленко О.В.", "2", "75")
            };

            student4.AddResults(results4);
            students.Add(student4);

            Student student5 = new Student("Ткач Максим Андрійович", "ЮП-21", "3", "3");
            Result[] results5 = new Result[]
            {
                new Result("Англійська мова", "Захарова Т.П.", "2", "100"),
                new Result("Фізкультура", "Рибак А.К.", "2", "92"),
                new Result("Економіка", "Савчук Г.Ю.", "1", "81")
            };

            student5.AddResults(results5);
            students.Add(student5);

            return students;
        }
    }

    
    
}
