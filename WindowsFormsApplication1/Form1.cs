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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private IMathServiceLibrary channel = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var endPoint = new EndpointAddress("http://localhost:4444/MathService");

            channel = ChannelFactory<IMathServiceLibrary>.CreateChannel(new BasicHttpBinding(), endPoint);

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
