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
    /// Логика взаимодействия для ReCaptcha.xaml
    /// </summary>
    public partial class ReCaptcha : Window
    {
        public ReCaptcha()
        {
            InitializeComponent();
            GenerateCaptcha();
        }
        bool canclose = false;
        private void GenerateCaptcha()
        {
            String allowchar = "";
            allowchar += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
            allowchar += "1,2,3,4,5,6,7,8,9,0";
            String[] ar = allowchar.Split(',');
            Random r = new Random();
            string captchatext = "";
            int arrayLength = ar.Length;
            for (int i = 0; i < 7; i++)
            {
                int j = r.Next(arrayLength - 1);
                captchatext += ar[j];
            }
            CaptchaLabel.Content = captchatext;
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            if (EnteredCaptcha.Text == CaptchaLabel.Content.ToString())
            {
                canclose = true;
                this.Close();
            }
            if (EnteredCaptcha.Text != CaptchaLabel.Content.ToString())
            {
                GenerateCaptcha();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!canclose) e.Cancel = true;
        }
    }
}
