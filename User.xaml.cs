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
using static System.Net.Mime.MediaTypeNames;

namespace Chat
{
    public partial class User : Window
    {
        private TcpClient client;
        public User(string login, string ip)
        {
            InitializeComponent();
            client = new TcpClient(login, msg, ip);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void send_Click(object sender, RoutedEventArgs e)
        {
            string exitCommand = "/disconnect";
            if (tbx.Text == exitCommand)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            else
            {
                client.SendMessage(tbx.Text);
            }
        }
        private void tbx_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            tbx.Text = "";
        }
    }
}
