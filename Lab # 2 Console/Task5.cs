using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab___2_Console
{
    internal class Task5
    {

        void ChooseSum(ref int num)
        {
            InputNumbers inputIN = new InputNumbers();
            Console.WriteLine("Виберіть яку суму обчислити: ");
            Console.WriteLine("  № 1: 1^n + 2^(n/2) + ... + k^(n/k)");
            Console.WriteLine("  № 2: 1^k + 2^k + ... + n^k");
            Console.WriteLine("  № 3: 1/n + 2/(n^2) + ... + k/(n^k)");
            
            inputIN.InputIntNumber(ref num);
        }

        void Sum1(int n, int k)
        {
            double sum = 0;
            for (int i = 1; i < k+1; i++)
            {
                sum += Math.Pow(i, ((double)n / (double)i));
            }
            Console.WriteLine($"Сума № 1 = {Math.Round(sum, 4)}");
        }

        void Sum2(int n, int k)
        {
            double sum = 0;
            for (int i = 1; i < n + 1; i++)
            {
                sum += Math.Pow(i, k);
            }
            Console.WriteLine($"Сума № 2 = {sum}");
        }

        void Sum3(int n, int k)
        {
            double sum = 0;
            for (int i = 1; i < k + 1; i++)
            {
                sum += (double)i / Math.Pow(n, i);
            }
            Console.WriteLine($"Сума № 3 = {Math.Round(sum, 4)}");
        }

        public void Start()
        {
            InputNumbers inputIN = new InputNumbers();
            int num = 0, n = 0, k = 0;
            bool status = true;
            ChooseSum(ref num);
            Console.WriteLine("Введіть ціле додатнє значення k ");
            inputIN.InputPosibleIntNumber(ref k);
            Console.WriteLine("Введіть ціле додатнє значення n ");
            inputIN.InputPosibleIntNumber(ref n);
            while (status)
            {
                switch (num) {
                    case 1:
                        Sum1(n, k);
                        status = false;
                        break;
                    case 2:
                        Sum2(n, k);
                        status = false;
                        break;
                    case 3:
                        Sum3(n, k);
                        status = false;
                        break;
                    default:
                        Console.WriteLine("Ви не вибрали існуючу суму спробуйте ще раз");
                        ChooseSum(ref num);
                        break;
                } 
            
            }


        }
    }
}
