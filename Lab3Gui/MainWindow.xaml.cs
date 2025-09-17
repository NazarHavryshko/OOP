using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab3Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Solution(object sender, RoutedEventArgs e)
        {
            int n;
            string str_n = num_n.Text;
            if (!int.TryParse(str_n, out n) || n < 0)
            {
                MessageBox.Show("Ви ввели некоректне значення елементів спробуйте знову.", "Помилка введення", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }


            double min = -102.05, max = 5.13;

            double sumAddEl = 0;
            int first = -1, last = -1;


            double temp = 0;


            Random rnd = new Random();


            double[] array = new double[n];


            for (int i = 0; i < n; i++)
            {
                array[i] = Math.Round((rnd.NextDouble() * (max - min) + min), 2);
            }

            for (int i = 0; i < n; i++)
            {
                if (array[i] < 0 && first == -1)
                {
                    first = i;
                }
                if ((i + 1) % 2 == 0 && array[i] > 0)
                {
                    sumAddEl += array[i];
                }
            }

            for (int i = n - 1; i > 0; i--)
            {
                if (array[i] < 0)
                {
                    last = i;
                    break;
                }
            }


            double[] sortArray = new double[n];


            for (int i = 0; i < n; i++)
            {
                sortArray[i] = array[i];
            }
            for (int i = 0; i < last - first + 2; i++)
            {
                for (int j = first; j < last - i; j++)
                {
                    if (sortArray[j] > sortArray[j + 1])
                    {
                        temp = sortArray[j];
                        sortArray[j] = sortArray[j + 1];
                        sortArray[j + 1] = temp;
                    }
                }
            }
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{"Індекс"} \t {"Оригінал"} \t {"Відсортований"}");
            for (int i = 0; i < array.Length; i++)
            {
                sb.AppendLine($"{i} \t {array[i]}             \t {sortArray[i]}");
            }
            sb.AppendLine("   ");
            solution.Text = sb.ToString();
            sum_sol.Content = $"Сума дотатніх чисел які мають непарні індекси = {sumAddEl}";



        }
    }
}
