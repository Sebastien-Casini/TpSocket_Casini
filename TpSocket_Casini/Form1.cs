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
using System.Runtime.InteropServices;
namespace TpSocket_Casini
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void MessageSaisit_TextChanged(object sender, EventArgs e)
        {

        }

        private void MessageR_TextChanged(object sender, EventArgs e)
        {

        }

        private void Envoyer_Click(object sender, EventArgs e)
        {
            try
            {
                var message = Encoding.ASCII.GetBytes(this.MessageSaisit.Text);
                SSocketUDP.SendTo(message, Destination);
            }
            catch (SocketException SExcept)
            {
                this.MessageR.Text = SExcept.ToString();
            }
        }

        private void Fermer_Click(object sender, EventArgs e)
        {
            try
            {
                SSocketUDP.Close();
            }
            catch (SocketException SExcept)
            {
                this.MessageR.Text = SExcept.ToString();
            }
        }

        private void Creer_Click(object sender, EventArgs e)
        {
            try
            {
              
                SSocketUDP = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                SSocketUDP.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 5000);
                Destination = new IPEndPoint(IPAddress.Parse(this.IPDestination.Text), int.Parse(this.PortRCP.Text));
                Reception = new IPEndPoint(IPAddress.Parse(this.IPReception.Text), int.Parse(this.PortDestinataire.Text));

                SSocketUDP.Bind(Reception);
            }

            catch (SocketException SExcept)
            {
                this.MessageR.Text = SExcept.ToString();
            }
        }

        private void IPDestination_TextChanged(object sender, EventArgs e)
        {

        }


        private void Rcp_Click(object sender, EventArgs e)
        {
            Task.Run(() => CheckUp());
        }

        private bool ReceptionT()
        {
            try
            {
                var buffer = new byte[1024];
                SSocketUDP.ReceiveFrom(buffer, ref Reception);
                this.MessageR.Text = Encoding.ASCII.GetString(buffer);
                return SSocketUDP.Available == 0;
            }
            catch (SocketException SExcept)
            {
                this.MessageR.Text = SExcept.ToString();
            }
            return false;


        }

        private async void CheckUp()
        {
            Timer.Start();
            while (Timer.ElapsedMilliseconds < 1500) ;
            Timer.Stop();

            if (!ReceptionT())
            {
                CheckUp();
            }
        }
    }


}