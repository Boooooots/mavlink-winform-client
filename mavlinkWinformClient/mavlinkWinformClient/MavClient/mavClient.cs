using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using MavLink;
using System.Threading;

namespace mavlinkWinformClient.MavClient
{
    public class Mavclient
    {
        public Mavclient()
        {
            this.commStatus = false;

            this._mav = new Mavlink();
            this._mavPack = new MavlinkPacket();
            this._tcpClient = new TcpClient();
            this._mht = new Msg_heartbeat();

            this._mav.PacketReceived += recvMavMsg;
        }

        ~Mavclient()
        {

        }


        private TcpClient _tcpClient;
        private NetworkStream _stream;
        private Mavlink _mav;
        private MavlinkPacket _mavPack;
        private Msg_heartbeat _mht;

        /*  */
        public uint mode;
        public float pos1;
        public float pos2;
        public float pos3;

        public bool commStatus;

        public event commStatusDelegate commStatusEvent;
        public delegate void commStatusDelegate(bool comm);

        public event commDataDelegate commDataEvent;
        public delegate void commDataDelegate(float dt);

        public void parseMavlink()
        {
            try
            {
                while (_tcpClient.Connected)
                {
                    Byte[] data;

                    _stream = _tcpClient.GetStream();

                    data = new Byte[256];

                    //Read the first batch of the TcpServer response bytes.
                    if (_tcpClient.Connected)
                    {
                        Int32 bytes = _stream.Read(data, 0, data.Length);
                        if (bytes > 0)
                        {
                            //parse mavlink
                            _mav.ParseBytes(data);
                            Console.WriteLine("ParseBytes: " + Thread.CurrentThread.ManagedThreadId.ToString());
                        }
                    }
                }

                _stream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public void connect(string serverIP, int serverPort)
        {
            try
            {
                _tcpClient.Connect(serverIP, serverPort);
                commStatus = true;
                commStatusEvent(commStatus);
            }
            catch (Exception tcp_con)
            {
                Console.WriteLine(tcp_con.Message);
                commStatus = false;
                commStatusEvent(commStatus);
            }
            
        }

        public void close()
        {
            try
            {
                _tcpClient.Close();
                commStatus = false;
                commStatusEvent(commStatus);
            }
            catch (Exception tcp_con)
            {
                Console.WriteLine(tcp_con.Message);
            }
        }

        public void recvMavMsg(object sender, MavlinkPacket e)
        {
            Console.WriteLine("recvMavMsg: " + Thread.CurrentThread.ManagedThreadId.ToString());

            string str = e.Message.ToString();

            if (str == "MavLink.Msg_heartbeat")
            {
                /* convert */
                Msg_heartbeat ht = (Msg_heartbeat)e.Message;

                /* save the incoming msg */
                mode = ht.custom_mode;

                /* publish */
                commDataEvent(mode);
            }
            else if (e.Message.ToString() == "Mavlink.Msg_attitude")
            {
                Msg_attitude at = (Msg_attitude)e.Message;
            }
        }


        public void sendMavMsg(byte cmd,byte addr,float pos)
        {
            try
            {
                /* mavlink encode */
                _mht.mavlink_version = cmd;
                _mht.custom_mode = (uint)pos;
                _mht.base_mode = addr;

                _mht.system_status = 4;

                _mavPack.ComponentId = 1;
                _mavPack.SystemId = 1;
                _mavPack.SequenceNumber = 0;
                _mavPack.TimeStamp = DateTime.Now;
                _mavPack.Message = _mht;

                byte[] buffer = _mav.Send(_mavPack);

                _stream.Write(buffer, 0, buffer.Length);
                Console.WriteLine("Write: " + Thread.CurrentThread.ManagedThreadId.ToString());
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
        }


    }
}
