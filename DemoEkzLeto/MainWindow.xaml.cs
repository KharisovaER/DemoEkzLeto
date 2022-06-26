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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoEkzLeto
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int passwordcounter;
        public MainWindow()
        {
            InitializeComponent();
            passwordcounter = 0;
        }
        private void RedirectStaff(Staff staff)
        {
            string role = staff.Post;
            if (role == "Продавец")
            {
                Seller seller= new Seller(this);
                seller.Show();
            }
            if (role=="Администратор")
            {
                Admin admin = new Admin();
                admin.Show();
            }
            if (role=="Старший смены")
            {
                SeniorShift SS = new SeniorShift();
                SS.Show();
            }
            this.Hide();
        }
        private void StaffEnter(Staff staff, string type)
        {
            using (SkiResortEntities db= new SkiResortEntities())
            {
                db.Staff.Attach(staff);
                staff.Entry_type = type;
                staff.Last_entry = DateTime.Now;
                db.SaveChanges();
            }
        }
        private void bthEnter_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTB.Text;
            string password = PasswordTB.Text;
            using (SkiResortEntities SR= new SkiResortEntities())
            {
                foreach (var Staff in SR.Staff)
                {
                    if (login == Staff.Login && password != Staff.Password)
                        StaffEnter(Staff, "Неуспешно");
                    if (login == Staff.Login && password == Staff.Password)
                    {
                        StaffEnter(Staff, "Успешно");
                        RedirectStaff(Staff);
                        passwordcounter = 0;
                    }
                }
                foreach (var Client in SR.Clients)
                {
                    if (login==Client.Email && password==Client.Password)
                    {
                        passwordcounter = 0;
                        MainClient MN = new MainClient(Client);
                        MN.Show();
                        this.Close();
                    }
                }
                passwordcounter++;
                if (passwordcounter>2)
                {
                    passwordcounter = 0;
                    ReCaptcha reCaptcha = new ReCaptcha();
                    reCaptcha.ShowDialog();
                }
            }
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
