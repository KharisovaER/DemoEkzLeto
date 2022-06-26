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
    /// Логика взаимодействия для SeniorShift.xaml
    /// </summary>
    public partial class SeniorShift : Window
    {
        public SeniorShift()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            Seller seller = new Seller(this);
            this.Hide();
            seller.Show();
        }

        private void ClientsButotn_Click(object sender, RoutedEventArgs e)
        {
            AddClientPage addClientPage = new AddClientPage();
            addClientPage.Show();
            this.Close();
        }
    }
}
