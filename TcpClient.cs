using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chat
{
    class TcpClient
    {
        private Socket socket;
        private ListBox listbox;

        public TcpClient(string login, ListBox listBox, string ip)
        {
            listbox = listBox;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.ConnectAsync(ip, 8888);
            SendMessage("/Пользователь " + login + " подключился");
            ReciveMessage(login);

        }

        public async Task SendMessage(string message)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            await socket.SendAsync(bytes, SocketFlags.None);
        }

        private async Task ReciveMessage(string login)
        {
            while (true)
            {
                byte[] bytes = new byte[1024];
                await socket.ReceiveAsync(bytes, SocketFlags.None);
                string message = Encoding.UTF8.GetString(bytes);
                listbox.Items.Add($"[{DateTime.Now}] {message}");
            }
        }
    }
}
