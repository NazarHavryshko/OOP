using SimpleClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    internal class FractionWork
    {

        static internal void FractionArea()
        {
            int n, m;
            Fraction A, B;

            Console.WriteLine("Ведіть чисельник першого дробу:");
            InputValue.InputIntNumber(out n);
            Console.WriteLine("Ведіть знаменник першого дробу:");
            InputValue.InputIntNumber(out m);
            A = new Fraction(n, m);

            Console.WriteLine("Ведіть чисельник другого дробу:");
            InputValue.InputIntNumber(out n);
            Console.WriteLine("Ведіть знаменник другого дробу:");
            InputValue.InputIntNumber(out m);
            B = new Fraction(n, m);


            Console.WriteLine($"Перший дріб (A) {A}; Другий дріб (B) {B}");
            A.FractionReduction();
            B.FractionReduction();
            Console.WriteLine($"Скорочення першого дробу {A}; Скорочення другого дробу {B}");
            Console.WriteLine($"A + B = {A + B}");
            Console.WriteLine($"A - B = {A - B}");
            Console.WriteLine($"A * B = {A * B}");
            Console.WriteLine($"A / B = {A / B}");
            Console.WriteLine($"A == B = {A == B}");
            Console.WriteLine($"A != B = {A != B}");
            Console.WriteLine($"A > B = {A > B}");
            Console.WriteLine($"A < B = {A < B}");
            Console.WriteLine($"A >= B = {A >= B}");
            Console.WriteLine($"A <= B = {A <= B}");



        }
    }
}
