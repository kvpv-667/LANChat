using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Chat
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NameUser.Text == "Admin")
            {
                if (IP.Text.Length <= 16 && IP.Text.Length != 0)
                {
                    Server server = new Server(NameUser.Text);
                    server.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Enter the IP");
                }
            }
            else if (NameUser.Text == "Chmoshnik")
            {
                if (IP.Text.Length <= 16 && IP.Text.Length != 0)
                {
                    User client = new User(NameUser.Text, IP.Text);
                    client.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Enter the IP");
                }
            }
            else
            {
                MessageBox.Show("Enter the Nickname");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (NameUser.Text == "Admin" || NameUser.Text == "Chmoshnik")
            {
                Server serv = new Server(NameUser.Text);
                serv.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Enter the Nickname");
            }
        }
        private void IP_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private static readonly Regex onlyNumbers = new Regex("[^0-9.-]+");
        private static bool IsTextAllowed(string text)
        {
            return !onlyNumbers.IsMatch(text);
        }
    }
}
