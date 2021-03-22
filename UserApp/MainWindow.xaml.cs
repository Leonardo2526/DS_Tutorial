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
using System.Windows.Media.Animation;

namespace UserApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = 450;
            doubleAnimation.Duration = TimeSpan.FromSeconds(3);
            regButton.BeginAnimation(Button.WidthProperty, doubleAnimation);
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass1 = PassBox1.Password.Trim();
            string pass2 = PassBox2.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Wrong input";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if (pass1.Length <5)
            {
                Clean();
                PassBox1.ToolTip = "Wrong input";
                PassBox1.Background = Brushes.DarkRed;
            }
            else if (pass2 != pass1)
            {
                Clean();
                PassBox2.ToolTip = "Wrong input";
                PassBox2.Background = Brushes.DarkRed;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                Clean();
                textBoxEmail.ToolTip = "Wrong input";
                textBoxEmail.Background = Brushes.DarkRed;
            }
            else
            {
                Clean();
                MessageBox.Show("Registration complete!");
            }
        }

        private void Clean()
        {
            textBoxLogin.ToolTip = "";
            textBoxLogin.Background = Brushes.Transparent;
            PassBox1.ToolTip = "";
            PassBox1.Background = Brushes.Transparent;
            PassBox2.ToolTip = "";
            PassBox2.Background = Brushes.Transparent;
            textBoxEmail.ToolTip = "";
            textBoxEmail.Background = Brushes.Transparent;
        }

        private void Button_Enter_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
            this.Hide();
        }
    }
}
