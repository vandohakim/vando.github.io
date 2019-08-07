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

using System.Net;
using System.Net.Sockets;
using System.IO;
using System.ComponentModel;
using System.Threading;

namespace ServerCSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string recieve;
        public String TextToSend;

        BackgroundWorker backgroundWorker1 = new BackgroundWorker();
        BackgroundWorker backgroundWorker2 = new BackgroundWorker();
        //private static BackgroundWorker backgroundWorker1;
        //private static BackgroundWorker backgroundWorker2;
        public MainWindow()
        {
            InitializeComponent();
            /*
                        backgroundWorker1 = new BackgroundWorker
                        {
                            WorkerReportsProgress = true,
                            WorkerSupportsCancellation = true
                        };

                        backgroundWorker2 = new BackgroundWorker
                        {
                            WorkerReportsProgress = true,
                            WorkerSupportsCancellation = true
                        };*/
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker2.DoWork += backgroundWorker2_DoWork;

            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    ServerIPtextBox.Text = address.ToString();
                }
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, int.Parse(ServerPorttextBox.Text));
            listener.Start();
            client = listener.AcceptTcpClient();
            STR = new StreamReader(client.GetStream());
            STW = new StreamWriter(client.GetStream());
            STW.AutoFlush = true;
            ChatScreentextBox.AppendText("Client is Connect!!" + "\n\n");

            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.WorkerSupportsCancellation = true;
        }

        /*private void ConnectButton_Click(object sender, EventArgs e)
        {
            client = new TcpClient();
            IPEndPoint IpEnd = new IPEndPoint(IPAddress.Parse(ClientIPtextBox.Text), int.Parse(ClientPorttextBox.Text));

            try
            {
                client.Connect(IpEnd);

                if (client.Connected)
                {
                    ChatScreentextBox.AppendText("Connected to server" + "\n");
                    STW = new StreamWriter(client.GetStream());
                    STR = new StreamReader(client.GetStream());
                    STW.AutoFlush = true;
                    backgroundWorker1.RunWorkerAsync();
                    backgroundWorker2.WorkerSupportsCancellation = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        */
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (client.Connected)
            {
                try
                {
                    recieve = STR.ReadLine();
                    this.ChatScreentextBox.Dispatcher.Invoke(new Action(delegate ()
                    {
                        ChatScreentextBox.AppendText("Android: " + recieve + "\n");
                    }));
                    recieve = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (client.Connected)
            {
                STW.WriteLine(TextToSend);
                this.ChatScreentextBox.Dispatcher.Invoke(new Action(delegate ()
                {
                    ChatScreentextBox.AppendText("C#: " + TextToSend + "\n");
                }));
            }
            else
            {
                MessageBox.Show("Sending failed");
            }
            backgroundWorker2.CancelAsync();
        }
        private void SendButton_Click(object sender, EventArgs e)
        {
            if (MessagetextBox.Text != "")
            {
                TextToSend = MessagetextBox.Text;
                backgroundWorker2.RunWorkerAsync();
            }
            MessagetextBox.Text = "";
        }
    }
}