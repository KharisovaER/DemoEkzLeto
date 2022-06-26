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
    /// Логика взаимодействия для Seller.xaml
    /// </summary>
    public partial class Seller : Window
    {
        Window _window;
        public Seller(Window window)
        {
            InitializeComponent();
            RefreashGrid();
            _window = window;
        }

        private void RefreashGrid()
        {
            using (SkiResortEntities db = new SkiResortEntities())
            {
                OrdersGrid.ItemsSource = db.Orders.ToList();
            }
        }
        private void QRBtn_Click(object sender, RoutedEventArgs e)
        {
            QrCode qr = new QrCode((sender as Button).DataContext as Orders, _window);
            qr.Show();
            this.Close();
        }

        private void StatusBtn_Click(object sender, RoutedEventArgs e)
        {
            Orders order = (sender as Button).DataContext as Orders;
            OrderStatusChange OSC = new OrderStatusChange(order, _window);
            OSC.Show();
            this.Close();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _window.Show();
            this.Close();
        }
    }
}
