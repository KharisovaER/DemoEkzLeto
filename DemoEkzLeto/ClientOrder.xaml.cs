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
    /// Логика взаимодействия для ClientOrder.xaml
    /// </summary>
    public partial class ClientOrder : Window
    {
        List<Services> _services;
        Clients _client;
        public ClientOrder(List<Services> services, Clients clients)
        {
            InitializeComponent();
            _services = services;
            _client = clients;
            foreach (var i in services)
            {
                ServicesList.Text += i.Service_name;
            }
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int order_time = Convert.ToInt32(OrderTime.Text);
                DateTime nowDate = DateTime.Now;
                TimeSpan nowTime = nowDate - DateTime.Today;
                using (SkiResortEntities db = new SkiResortEntities())
                {
                    db.Orders.Add(new Orders
                    {
                        Rental_time = order_time,
                        Status = "Новая",
                        Client_code = _client.Client_code,
                        Create_date = nowDate,
                        Order_time = nowTime,
                        Order_code = _client.Client_code + "/" + nowDate.ToString()
                    });
                    db.SaveChanges();
                    string order_code = _client.Client_code + "/" + nowDate.ToString();
                    int order_id=db.Orders.Where(x=> x.Order_code==order_code).FirstOrDefault().ID;
                    foreach (var i in _services)
                    {
                        db.Orders_Services.Add(new Orders_Services
                        {
                            Order_ID = order_id,
                            Service_ID = i.ID
                        });
                    }
                    db.SaveChanges();
                    MainClient MC = new MainClient(_client);
                    MC.Show();
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Введите целочисленный тип данных в поле");
            }
        }
    }
}
