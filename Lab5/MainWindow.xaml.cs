using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Lab5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string AUTHORIZATION = "543g1%23vby";
        FileStatus fileStatus = new FileStatus();
        string file_name;
        DataBase[] clients;
        bool newFileBool = false;
        bool saveSatus = true;
        bool selectedFile = false;

        public MainWindow()
        {
            InitializeComponent();
            typeClient.ItemsSource = Enum.GetValues(typeof(ClientType)).Cast<ClientType>();
            currency.ItemsSource = Enum.GetValues(typeof(Currency)).Cast<Currency>();


        }

        private void GetData()
        {
            SaveData saveData = new SaveData();
            try
            {
                using (var file = File.OpenRead(this.file_name))
                {
                    var reader = new BinaryFormatter();
                    saveData = (SaveData)reader.Deserialize(file);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Помилка при відкритті файлу: {ex.Message}",
                        "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        
            this.fileStatus = saveData.fileStatus;
            this.clients = saveData.clients;
        }

        private void ShowClients(DataBase[] clientsArray)
        {
            dataGridClients.ItemsSource = clientsArray;
        }

        private void SelecFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Binary files (*.bin)|*.bin";

            if (openFileDialog.ShowDialog() == true)
            {
                this.file_name = openFileDialog.FileName;                
            }

            GetData();
            if (fileStatus.authorization == AUTHORIZATION)
            {
                ShowClients(this.clients);
            } else {
                MessageBox.Show("Вибраний вами файл не був створений цією програмою.", "Помилка файлу", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            this.selectedFile = true;
            this.newFileBool = false;
        }

        private void NewFile(object sender, RoutedEventArgs e)
        {
            if (saveSatus)
            {
                fileNameLabel.Visibility = Visibility.Visible;
                fileName.Visibility = Visibility.Visible;
                this.fileStatus.numberСustomers = 0;
                this.fileStatus.id = 10001;
                this.fileStatus.authorization = AUTHORIZATION;
                clients = new DataBase[0];
            } else
            {
                MessageBox.Show("Ви не зберегли файл з яким ви працюєте.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            this.selectedFile = false;
            this.newFileBool = true;
        }
        private void AddClient(object sender, RoutedEventArgs e)
        {            
            DateTime timeOpen;
            string bankName = bank.Text;
            string clientName = client.Text;
            string dividendP = dividend.Text;
            
            string maneyS = maney.Text;
            int maneyInt;
            byte dividendB;

                if (dateOpen.SelectedDate.HasValue &&
                dateOpen.SelectedDate.Value <= DateTime.Today &&
                DataBase.СheckСorrectBankName(bankName) &&
                DataBase.СheckСorrectClientName(clientName) &&
                DataBase.СheckСorrectDividendPercentage(dividendP, out dividendB) &&
                typeClient.SelectedItem != null &&
                currency.SelectedItem != null &&
                DataBase.СheckСorrectSumMoney(maneyS, out maneyInt))
            {
                DataBase tempData = new DataBase();
                tempData.bankName = bankName;
                tempData.clientName = clientName;
                tempData.timeOpen = dateOpen.SelectedDate.Value;
                tempData.sumMoney = maneyInt;
                tempData.dividendPercentage = dividendB;
                tempData.clientType = (ClientType)typeClient.SelectedItem;
                tempData.currency = (Currency)currency.SelectedItem;
                tempData.accountNumber = this.fileStatus.id;

                this.fileStatus.id++;
                this.fileStatus.numberСustomers++;

                DataBase[] tempClients = new DataBase[this.fileStatus.numberСustomers];

                for (int i = 0; i < this.fileStatus.numberСustomers - 1; i++)
                {
                    tempClients[i] = this.clients[i];
                }
                tempClients[this.fileStatus.numberСustomers - 1] = tempData;
                this.clients = tempClients;

                ShowClients(this.clients);

                bank.Text = "";
                client.Text = "";
                dividend.Text = "";
                maney.Text = "";
                dateOpen.SelectedDate = null;
                typeClient.SelectedItem = null;
                currency.SelectedItem = null;
            }
            else {
                MessageBox.Show("Ви вели некоректне значення.", "Помилка вводу.", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void SaveDataF(object sender, RoutedEventArgs e)
        {
            SaveData save = new SaveData();
            save.fileStatus = this.fileStatus;
            save.clients = this.clients;

            bool saveStatus = true;

            if (this.newFileBool)
            {
                if (Regex.IsMatch(fileName.Text, @"^[a-zA-Zа-яА-ЯїЇіІєЄґҐ1234567890']+$") && fileName.Text.Length > 3)
                {
                    this.file_name = fileName.Text + ".bin";
                }
                else
                {
                    saveStatus = false;
                }

            }


            if (saveStatus)
            {
                using (var file = File.Open(this.file_name, FileMode.Create))
                {
                    var writer = new BinaryFormatter();
                    writer.Serialize(file, save);
                }
            }
            else
            {
                MessageBox.Show("Ви вели некоректну назву файлу.", "Помилка вводу.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dataGridClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }


    }
}
