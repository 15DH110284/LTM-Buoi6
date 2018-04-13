using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
    public partial class Form1 : Form
    {
        Socket client;
        IPEndPoint ipServer;
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[1024];
            data = Encoding.ASCII.GetBytes(textBox2.Text);
            listBox1.Items.Add("Client " + textBox2.Text);
            textBox2.Text = "";
            client.Send(data);
            data = new byte[1024];
            client.Receive(data);
            string text = Encoding.ASCII.GetString(data);
            listBox1.Items.Add("Server: " + text);
        }

        private void btncn_Click(object sender, EventArgs e)
        {
            ipServer = new IPEndPoint(IPAddress.Parse("192.168.1.110"), 1234);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(ipServer);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button4.PerformClick();
        }


    }
}
