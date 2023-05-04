using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

namespace Chat
{
    public partial class Server : Window
    {
        private TcpClient client;
        private TcpServer serv;
        public Server(string login)
        {
            InitializeComponent();
            serv = new TcpServer(this, usrs);
            client = new TcpClient(login, msg, "127.0.0.1");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void BtnLogs_Click(object sender, RoutedEventArgs e)
        {
            Logs logs = new Logs();
            logs.Show();
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

        private void tbx_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            tbx.Text = "";
        }
    }
}
