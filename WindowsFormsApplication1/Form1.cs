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
using HslCommunication;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {        
        Socket socket;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //tc = new TcpClient(textBox1.Text, int.Parse(textBox2.Text));
                //ns = tc.GetStream();
                IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("192.168.0.45"), 9004);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ipe);
                label2.Text = "online";
            }
            catch (Exception)
            {
                MessageBox.Show("connect fail");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //0x4C, 0x4F, 0x46, 0x46, 0x0D
                //0x4C, 0x4F, 0x4E, 0x0D
                //76, 79, 78, 13
                byte[] by = new byte[] { 0x4C, 0x4F, 0x46, 0x46, 0x0D };
                //byte[] b = new byte[3];
                //byte[] c = Encoding.ASCII.GetBytes("LON");
                //for (int i = 0; i < 3; i++)
                //{

                //    b[i] = c[i];
                //}
                
                //b[3] = 0x0D;
                ////string str = BitConverter.ToString(b, 0);
                ////textBox1.Text = str;
                ////for (int i = 0; i < b.Length; i++)
                ////{
                ////    label1.Text += b[i];
                ////}
                //ns.Write(by, 0, by.Length);
                //ns.Close(1000);
                //tc.Close();

                socket.Send(by, 0, by.Length, SocketFlags.None);
            }
            catch (Exception)
            {
                MessageBox.Show("send fail");
            }
        }
    }
}
