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
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        TcpClient c = new TcpClient();
        NetworkStream str;
        BinaryFormatter fobj = new BinaryFormatter();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            c = new TcpClient();
            fobj = new BinaryFormatter();

            CheckForIllegalCrossThreadCalls = false;
            tb1.Text = "127.0.0.1";
            tb2.Text = "9267";
            tb1.Enabled = false;
            tb2.Enabled = false;
        }

        private void btnconnect_Click(object sender, EventArgs e)
        {
            c = new TcpClient();
            try
            {
                c.Connect(tb1.Text, int.Parse(tb2.Text));

                label4.Text = "Waiting For other Player";
                MessageBox.Show("We Are searching a Playr for you!");

                string Symbol = (String)fobj.Deserialize(c.GetStream());
                Form2 f = new Form2(c, Symbol);
                f.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
