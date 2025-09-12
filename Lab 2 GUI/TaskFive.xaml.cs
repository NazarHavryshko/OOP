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
using System.Windows.Shapes;

namespace Lab_2_GUI
{
    /// <summary>
    /// Interaction logic for TaskFive.xaml
    /// </summary>
    public partial class TaskFive : Window
    {
        public TaskFive()
        {
            InitializeComponent();
        }
        void Sum1(int n, int k)
        {
            double sum = 0;
            for (int i = 1; i < k + 1; i++)
            {
                sum += Math.Pow(i, ((double)n / (double)i));
            }
            num_s.Content = $"Сума № 1 = {Math.Round(sum, 4)}";
        }

        void Sum2(int n, int k)
        {
            double sum = 0;
            for (int i = 1; i < n + 1; i++)
            {
                sum += Math.Pow(i, k);
            }
            num_s.Content = $"Сума № 2 = {sum}";
        }

        void Sum3(int n, int k)
        {
            double sum = 0;
            for (int i = 1; i < k + 1; i++)
            {
                sum += (double)i / Math.Pow(n, i);
            }
            num_s.Content = $"Сума № 3 = {Math.Round(sum, 4)}";
        }

        private void Solution(object sender, RoutedEventArgs e)
        {
            int k, n, num = 0;
            string str_k = num_k.Text;
            string str_n = num_n.Text;
            if (num_1.IsChecked == true)
            {
                num = 1;
            }
            else if (num_2.IsChecked == true)
            {
                num = 2;
            }
            else if (num_3.IsChecked == true)
            {
                num = 3;
            }
            else
            {
                MessageBox.Show("Ви не обрали яку суму рахувати.", "Помилка введення", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (!(int.TryParse(str_k, out k) && k > 0))
            {
                MessageBox.Show("Ви ввели некоректне значення (k) спробуйте знову.", "Помилка введення", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }
            if (!(int.TryParse(str_n, out n) && n > 0))
            {
                MessageBox.Show("Ви ввели некоректне значення (n) спробуйте знову.", "Помилка введення", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            switch (num)
            {
                case 1:
                    Sum1(n, k);
                    break;
                case 2:
                    Sum2(n, k);
                    break;
                case 3:
                    Sum3(n, k);
                    break;
            }


        }

        private void backClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            mainWindow.Show();

            this.Close();
        }
    }
}
