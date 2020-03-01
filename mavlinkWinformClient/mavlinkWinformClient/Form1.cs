using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using MavLink;

namespace mavlinkWinformClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Console.WriteLine("Form1: " + Thread.CurrentThread.ManagedThreadId.ToString());

            Control.CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();

            /* ragister events */
            pub.OnChange     += sub.recvMsg;
            m.PacketReceived += sub.recvMavMsg;
            m.PacketReceived += recvMavMsg;
        }

        TcpClient mavTcpClient;
        NetworkStream stream;

        MavLink.Mavlink m = new MavLink.Mavlink();
        MavLink.MavlinkPacket p = new MavLink.MavlinkPacket();

        Publisher  pub = new Publisher("boots");
        Subscriber sub = new Subscriber("haha");

        public delegate double MathDelegate(double value1, double value2);
        public static double Add(double value1, double value2)
        {
            Console.WriteLine("Add...");
            return value1 + value2;
        }
        public static double Subtract(double value1, double value2)
        {
            Console.WriteLine("Subtract...");
            return value1 - value2;
        }

        /* process msgs */
        public void recvMavMsg(object sender, MavlinkPacket e)
        {
            Console.WriteLine("recvMavMsg: " + Thread.CurrentThread.ManagedThreadId.ToString());

            string str = e.Message.ToString();

            if (str == "MavLink.Msg_heartbeat")
            {
                /* convert */
                MavLink.Msg_heartbeat ht = (MavLink.Msg_heartbeat)e.Message;
                /* display the incoming msg */
                richTextBox1.AppendText(ht.custom_mode.ToString() + "\n");
            }
            else if(e.Message.ToString() == "Mavlink.Msg_attitude")
            {
                MavLink.Msg_attitude at = (MavLink.Msg_attitude)e.Message;
            }
         
        }

       
        /* connect TCP server and parse mavlink */
        void mavlinkRxThreadFunc()
        {
            string ip = serverIP.Text;
            int port  = int.Parse(serverPort.Text);

            try
            {
                mavTcpClient = new TcpClient();
                mavTcpClient.Connect(ip, port);

                while (mavTcpClient.Connected)
                {
                    connect.Text = "Disconnect";

                    Byte[] data;

                    stream = mavTcpClient.GetStream();

                    data = new Byte[256];

                    // String to store the response ASCII representation.
                    String responseData = String.Empty;

                    //Read the first batch of the TcpServer response bytes.
                    if (mavTcpClient.Connected)
                    {
                        Int32 bytes = stream.Read(data, 0, data.Length);
                        if (bytes > 0)
                        {
                            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);

                            //parse mavlink
                            m.ParseBytes(data);
                            Console.WriteLine("ParseBytes: " + Thread.CurrentThread.ManagedThreadId.ToString());
                        }
                    }

                }

                stream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            connect.Text = "Connect";
        }

        private void connect_Click(object sender, EventArgs e)
        {
            if (connect.Text == "Connect")
            {
                Thread mavlinkRxThread = new Thread(mavlinkRxThreadFunc);
                mavlinkRxThread.Start();
                Console.WriteLine("mavlinkRxThread: " + mavlinkRxThread.ManagedThreadId.ToString());
            }
            else if(connect.Text == "Disconnect")
            {
                mavTcpClient.Close();
            }

        }


        private void Send_Click(object sender, EventArgs e)
        {
            /* multicast delegate test*/
            MathDelegate s = new MathDelegate(Subtract);
            MathDelegate a = new MathDelegate(Add);
            MathDelegate sa = s + a;
            double ret = sa(5,4);
            Console.WriteLine(ret);
            pub.Raise();

            try
            {
                /* mavlink encode */
                var tmp = new MavLink.Msg_heartbeat();
                tmp.mavlink_version = 1;
                tmp.custom_mode = uint.Parse(custom_mode.Text);
                tmp.base_mode = 3;
                tmp.system_status = 4;

                p.ComponentId = 1;
                p.SystemId = 1;
                p.SequenceNumber = 0;
                p.TimeStamp = DateTime.Now;
                p.Message = tmp;

                byte[] buffer = m.Send(p);

                stream.Write(buffer, 0, buffer.Length);
                Console.WriteLine("Write: " + Thread.CurrentThread.ManagedThreadId.ToString());
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }


    }
}
