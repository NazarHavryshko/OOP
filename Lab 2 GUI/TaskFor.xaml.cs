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
    /// Interaction logic for TaskFor.xaml
    /// </summary>
    public partial class TaskFor : Window
    {
        public TaskFor()
        {
            InitializeComponent();
        }

        private void Solution(object sender, RoutedEventArgs e)
        {
            double a, b, c;
            string str_a = num_a.Text;
            string str_b = num_b.Text;
            string str_c = num_c.Text;
            if (!double.TryParse(str_a, NumberStyles.Float, CultureInfo.InvariantCulture, out a))
            {
                MessageBox.Show("Ви ввели некоректне значення (a) спробуйте знову.", "Помилка введення", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }
            if (!double.TryParse(str_b, NumberStyles.Float, CultureInfo.InvariantCulture, out b))
            {
                MessageBox.Show("Ви ввели некоректне значення (b) спробуйте знову.", "Помилка введення", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }
            if (!double.TryParse(str_c, NumberStyles.Float, CultureInfo.InvariantCulture, out c))
            {
                MessageBox.Show("Ви ввели некоректне значення (c) спробуйте знову.", "Помилка введення", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            if (a == 0)
            {
                MessageBox.Show("Це не квадратне рівняння спробуйте ще раз спочатку.", "Помилка логіки", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                double d = Math.Pow(b, 2) - (4 * a * c);
                if (d < 0)
                {
                    text_x.Content = "Рівняння немає коренів.";
                    num_x1.Content = "";
                    num_x2.Content = "";
                }
                else if (d == 0)
                {
                    double x = ((-1 * b) / (2 * a));
                    text_x.Content = "Рівняння має один корінь";
                    num_x1.Content = $"х = {Math.Round(x, 4)}";
                    num_x2.Content = "";
                }
                else
                {
                    double x1 = (((-1 * b) - Math.Pow(d, 0.5)) / (2 * a));
                    double x2 = (((-1 * b) + Math.Pow(d, 0.5)) / (2 * a));
                    text_x.Content = "Рівняння має два корінея";
                    num_x1.Content = $"х1 = {Math.Round(x1, 4)}";
                    num_x2.Content = $"х2 = {Math.Round(x2, 4)}";
                }
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
