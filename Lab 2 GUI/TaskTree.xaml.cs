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
    /// Interaction logic for TaskTree.xaml
    /// </summary>
    public partial class TaskTree : Window
    {
        public TaskTree()
        {
            InitializeComponent();
        }

        private void Solution(object sender, RoutedEventArgs e)
        {
            double x, y, z;
            string str_x = num_x.Text;
            string str_y = num_y.Text;
            string str_z = num_z.Text;
            if (!double.TryParse(str_x, NumberStyles.Float, CultureInfo.InvariantCulture, out x))
            {
                MessageBox.Show("Ви ввели некоректне значення (х) спробуйте знову.", "Помилка введення", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }
            if (!double.TryParse(str_y, NumberStyles.Float, CultureInfo.InvariantCulture, out y))
            {
                MessageBox.Show("Ви ввели некоректне значення (y) спробуйте знову.", "Помилка введення", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }
            if (!double.TryParse(str_z, NumberStyles.Float, CultureInfo.InvariantCulture, out z))
            {
                MessageBox.Show("Ви ввели некоректне значення (z) спробуйте знову.", "Помилка введення", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }
            if ((Math.Pow(y, 2) - x) == 0 || (Math.Pow(x, 3) + Math.Log(x)) <= 0)
            {
                MessageBox.Show("При обчисленні виникли обчислення які в класичній математиці необчислюються.", "Помилка обчислення", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                double s = Math.Round((Math.Pow(Math.Cos(z), 2) + (y / (Math.Pow(y, 2) - x))) / (Math.Pow((Math.Pow(x, 3) + Math.Log(x)), 0.25)), 4);

                num_s.Content = $"S = {s}";
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
