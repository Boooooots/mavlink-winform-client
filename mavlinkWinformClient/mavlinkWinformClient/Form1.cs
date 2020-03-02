using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using mavlinkWinformClient.MavClient;

namespace mavlinkWinformClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Console.WriteLine("Form1: " + Thread.CurrentThread.ManagedThreadId.ToString());

            Control.CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();

            mavclient = new Mavclient();

            /* ragister events */
            mavclient.commStatusEvent += commStatusHandler;
            mavclient.commDataEvent   += commDataHandler;
        }


        Mavclient mavclient;

        private void commStatusHandler(bool comm)
        {
            if (comm)
            {
                connect.Text = "Disconnect";
            }
            else
            {
                connect.Text = "Connect";
            }
        }

        private void commDataHandler(float dt)
        {
            richTextBox1.AppendText(dt.ToString() + "\r\n");
        }


        /* start work thread */
        private void connect_Click(object sender, EventArgs e)
        {
            if (connect.Text == "Connect")
            {
                mavclient.connect(serverIP.Text,int.Parse(serverPort.Text));

                if (mavclient.commStatus)
                {
                    Thread mavlinkRxThread = new Thread(mavclient.parseMavlink);
                    mavlinkRxThread.Start();
                    Console.WriteLine("mavlinkRxThread: " + mavlinkRxThread.ManagedThreadId.ToString());
                }              
            }
            else if(connect.Text == "Disconnect")
            {
                mavclient.close();
            }
        }

        private void Send_Click(object sender, EventArgs e)
        {
            mavclient.sendMavMsg(5,6,float.Parse(custom_mode.Text));
        }


    }
}
