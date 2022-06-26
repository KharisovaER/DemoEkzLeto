using System;
using System.Collections.Generic;
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

namespace DemoEkzLeto
{
    /// <summary>
    /// Логика взаимодействия для MainClient.xaml
    /// </summary>
    public partial class MainClient : Window
    {
        Clients _client;
        public MainClient(Clients clients)
        {
            InitializeComponent();
            _client = clients;
            ListServices();
        }
        private void ListServices()
        {
            using (SkiResortEntities skiResortEntities = new SkiResortEntities())
            {
                Goods.ItemsSource = skiResortEntities.Services.ToList();
            }
        }

        private void ReserveBTN_Click(object sender, RoutedEventArgs e)
        {
            if (ReservedServices.Count > 0)
            {
                ClientOrder CO = new ClientOrder(ReservedServices, _client);
                CO.Show();
                this.Close();
            }
            else
                MessageBox.Show("Выберите услугу");
        }
        List<Services> ReservedServices= new List<Services>();

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow MW= new MainWindow();
            MW.Show();
            this.Close();
        }

        private void BronBtn_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Content.ToString()=="Забронировать")
            {
                (sender as Button).Content = "В списке";
                Services service = (sender as Button).DataContext as Services;
                using (SkiResortEntities skiResortEntities = new SkiResortEntities())
                {
                    ReservedServices.Add(service);
                }
            }
            else
            {
                (sender as Button).Content = "Забронировать";
                Services service = (sender as Button).DataContext as Services;
                using (SkiResortEntities skiResortEntities = new SkiResortEntities())
                {
                    ReservedServices.Remove(service);
                }
            }
        }
    }
}
