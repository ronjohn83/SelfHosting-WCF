using Exercise_2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_3
{
    public partial class Form1 : Form
    {
        private IMathServiceLibrary channell = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var endpoint = new EndpointAddress("net.tcp://localhost:6666/MathService");
            channell = ChannelFactory<IMathServiceLibrary>.CreateChannel(new NetTcpBinding(), endpoint);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MathServiceLibrary client = new MathServiceLibrary();
            int result = client.Add(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));

            textBox3.Text = result.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MathServiceLibrary client = new MathServiceLibrary();
            int result = client.Substract(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));

            textBox3.Text = result.ToString();
        }

     
    }
}
