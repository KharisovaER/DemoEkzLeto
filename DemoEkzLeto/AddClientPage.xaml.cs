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
    /// Логика взаимодействия для AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Window
    {
        public AddClientPage()
        {
            InitializeComponent();
            Clients client = new Clients();
        }

        private void SignUpClient_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(surname.Text))
                errors.AppendLine("Введите фамилию");
            else
            {
                
            }
            if (string.IsNullOrWhiteSpace(name.Text))
            {
                errors.AppendLine("Введите имя");
            }
            if (string.IsNullOrWhiteSpace(patronomic.Text))
            {
                errors.AppendLine("Введите отчество");
            }
            if (passportSerie.Text.Length != 4)
            {
                errors.AppendLine("Введите корректную серию паспорта!");
            }
            if (passportNum.Text.Length != 6)
            {
                errors.AppendLine("Введите корректный номер паспорта!");
            }
            if (string.IsNullOrWhiteSpace(address.Text))
            {
                errors.AppendLine("Введите адрес");
            }
            if (string.IsNullOrWhiteSpace(email.Text))
            {
                errors.AppendLine("Введите почту!");
            }
            if (password.Text.Length < 8)
            {
                errors.AppendLine("Пароль должен быть не менее 8 символов");
            }
            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            Clients clients = new Clients();
            clients.Name = name.Text;
            clients.Email = email.Text;
            clients.Surname = surname.Text;
            clients.Patronymic = patronomic.Text;
            clients.Passport_series = int.Parse(passportSerie.Text);
            clients.Passport_number = int.Parse(passportNum.Text);
            clients.Birthday_date = birthday.DisplayDate;
            clients.Address = address.Text;
            clients.Password = password.Text;
            SkiResortEntities.GetContext().Clients.Add(clients);
            try
            {
                SkiResortEntities.GetContext().SaveChanges();
                MessageBox.Show("Клиент зарегистрирован");
                SeniorShift SS = new SeniorShift();
                SS.Show();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SeniorShift SS = new SeniorShift();
            SS.Show();
            this.Close();
        }
    }
}
