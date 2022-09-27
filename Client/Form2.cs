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
using System.Media;

namespace WindowsFormsApp6
{
    public partial class Form2 : Form
    {
        bool flag = false;
        TcpClient client;
        string sym,msg, osym;
        int count=0;
        BinaryFormatter fobj = new BinaryFormatter();
        NetworkStream str;
        private SoundPlayer player;

        public Form2(TcpClient cl, string symbol)
        {
            this.client = cl;
            sym = symbol;
            if (sym == "1")
            {
                osym = "0";
            }
            else
            {
                osym = "1";
            }
            InitializeComponent();
            player = new SoundPlayer("C:\\mywavfile.wav");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            
            CheckForIllegalCrossThreadCalls = false;
            if (sym == "0")
            {
                label1.Text = "Name : Player1";
                label2.Text = "Symbol : 0";
                MessageBox.Show("Ready to Play!");
            }
            if (sym == "1")
            {
                label1.Text = "Name : Player2";
                label2.Text = "Symbol : 1";
                MessageBox.Show("Ready to Play!");
            }

            if (sym == "0")
            {
                setcontrol(false);
                new Thread(() => Read()).Start();
            }

        }
        private void setcontrol(bool f)
        {
            count = count + 1;
            if (flag == true)
            {
                f = false;
                MessageBox.Show(msg);
                this.Close();
            }
            if (flag == false)
            {
                
                btn1.Enabled = btn2.Enabled = f;
                btn3.Enabled = btn4.Enabled = f;
                btn5.Enabled = btn6.Enabled = f;
                btn7.Enabled = btn8.Enabled = f;
                btn9.Enabled = f;
            }
            if (btn1.Text == "0" && btn2.Text == "0" && btn3.Text == "0")
            {
                player.Play();
                flag = true;
                msg = "Player 1 Won the Match";
                MessageBox.Show(msg);
                this.Close();
            }
            if (btn4.Text == "0" && btn5.Text == "0" && btn6.Text == "0")
            {
                player.Play();
                flag = true;
                msg = "Player 1 Won the Match";
                MessageBox.Show(msg);
                this.Close();
            }
            if (btn7.Text == "0" && btn8.Text == "0" && btn9.Text == "0")
            {
                player.Play();
                flag = true;
                msg = "Player 1 Won the Match";
                MessageBox.Show(msg);
                this.Close();
            }
            if (btn1.Text == "0" && btn4.Text == "0" && btn7.Text == "0")
            {
                player.Play();
                flag = true;
                msg = "Player 1 Won the Match";
                MessageBox.Show(msg);
                this.Close();
            }
            if (btn2.Text == "0" && btn5.Text == "0" && btn8.Text == "0")
            {
                player.Play();
                flag = true;
                msg = "Player 1 Won the Match";
                MessageBox.Show(msg);
                this.Close();
            }
            if (btn3.Text == "0" && btn6.Text == "0" && btn9.Text == "0")
            {
                player.Play();
                flag = true;
                msg = "Player 1 Won the Match";
                MessageBox.Show(msg);
                this.Close();
            }
            if (btn1.Text == "0" && btn5.Text == "0" && btn9.Text == "0")
            {
                player.Play();
                flag = true;
                msg = "Player 1 Won the Match";
                MessageBox.Show(msg);
                this.Close();
            }
            if (btn3.Text == "0" && btn5.Text == "0" && btn7.Text == "0")
            {
                player.Play();
                flag = true;
                msg = "Player 1 Won the Match";
                MessageBox.Show(msg);
                this.Close();
            }
            if (btn1.Text == "1" && btn2.Text == "1" && btn3.Text == "1")
            {
                player.Play();
                flag = true;
                msg = "Player 2 Won the Match";
                MessageBox.Show(msg);
                this.Close();
            }
            if (btn4.Text == "1" && btn5.Text == "1" && btn6.Text == "1")
            {
                player.Play();
                flag = true;
                msg = "Player 2 Won the Match";
                MessageBox.Show(msg);
                this.Close();
            }
            if (btn7.Text == "1" && btn8.Text == "1" && btn9.Text == "1")
            {
                player.Play();
                flag = true;
                msg = "Player 2 Won the Match";
                MessageBox.Show(msg);
                this.Close();
            }
            if (btn1.Text == "1" && btn4.Text == "1" && btn7.Text == "1")
            {
                player.Play();
                flag = true;
                msg = "Player 2 Won the Match";
                MessageBox.Show(msg);
                this.Close();
            }
            if (btn2.Text == "1" && btn5.Text == "1" && btn8.Text == "1")
            {
                player.Play();
                flag = true;
                msg = "Player 2 Won the Match";
                MessageBox.Show(msg);
                this.Close();
            }
            if (btn3.Text == "1" && btn6.Text == "1" && btn9.Text == "1")
            {
                player.Play();
                flag = true;
                msg = "Player 2 Won the Match";
                MessageBox.Show(msg);
                this.Close();
            }
            if (btn1.Text == "1" && btn5.Text == "1" && btn9.Text == "1")
            {
                player.Play();
                flag = true;
                msg = "Player 2 Won the Match";
                MessageBox.Show(msg);
                this.Close();
            }
            if (btn3.Text == "1" && btn5.Text == "1" && btn7.Text == "1")
            {
                player.Play();
                flag = true;
                msg = "Player 2 Won the Match";
                MessageBox.Show(msg);
                this.Close();
            }
           



        }
        private void Read()
        {
            try
            {
                string m = (string)fobj.Deserialize(client.GetStream());
                //string m = "0,0";
                string[] md = m.Split(',');
                int r = int.Parse(md[0]);
                int c = int.Parse(md[1]);
                marksymbol(r, c);
                if (count == 9)
                {
                    flag = true;
                    msg = "Match Draw!";
                    MessageBox.Show(msg);
                    this.Close();
                }
                setcontrol(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (btn1.Text == string.Empty)
            {
                
                btn1.Text = sym;
                string msg = "0,0";
                fobj.Serialize(client.GetStream(), msg);
                setcontrol(false);
                
                new Thread(() => Read()).Start();

            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (btn2.Text == string.Empty)
            {
                
                btn2.Text = sym;
                string msg = "0,1";
                fobj.Serialize(client.GetStream(), msg);
                setcontrol(false);
                new Thread(() => Read()).Start();

            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (btn3.Text == string.Empty)
            {
                btn3.Text = sym;
                string msg = "0,2";
                fobj.Serialize(client.GetStream(), msg);
                setcontrol(false);
                
                new Thread(() => Read()).Start();

            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (btn4.Text == string.Empty)
            {
                btn4.Text = sym;
                string msg = "1,0";
                fobj.Serialize(client.GetStream(), msg);
                setcontrol(false);
                
                new Thread(() => Read()).Start();

            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (btn5.Text == string.Empty)
            {
                btn5.Text = sym;
                string msg = "1,1";
                fobj.Serialize(client.GetStream(), msg);
                setcontrol(false);
                
                new Thread(() => Read()).Start();

            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (btn6.Text == string.Empty)
            {
                btn6.Text = sym;
                string msg = "1,2";
                fobj.Serialize(client.GetStream(), msg);
                setcontrol(false);
                
                new Thread(() => Read()).Start();

            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (btn7.Text == string.Empty)
            {
                btn7.Text = sym;
                string msg = "2,0";
                fobj.Serialize(client.GetStream(), msg);
                setcontrol(false);
                
                new Thread(() => Read()).Start();

            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (btn8.Text == string.Empty)
            {
                btn8.Text = sym;
                string msg = "2,1";
                fobj.Serialize(client.GetStream(), msg);
                setcontrol(false);
                
                new Thread(() => Read()).Start();

            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (btn9.Text == string.Empty)
            {
                btn9.Text = sym;
                string msg = "2,2";
                fobj.Serialize(client.GetStream(), msg);
                setcontrol(false);
                new Thread(() => Read()).Start();

            }
        }

        private void marksymbol(int r, int c)
        {
            if (r == 0 && c == 0)
                btn1.Text = osym;
            if (r == 0 && c == 1)
                btn2.Text = osym;
            if (r == 0 && c == 2)
                btn3.Text = osym;
            if (r == 1 && c == 0)
                btn4.Text = osym;
            if (r == 1 && c == 1)
                btn5.Text = osym;
            if (r == 1 && c == 2)
                btn6.Text = osym;
            if (r == 2 && c == 0)
                btn7.Text = osym;
            if (r == 2 && c == 1)
                btn8.Text = osym;
            if (r == 2 && c == 2)
                btn9.Text = osym;

        }
    }
}
