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
using CalcServiceLibrary;

namespace Client_1
{
    public partial class Form1 : Form
    {
        private IMathServiceLibrary channel = null;
        private ICalcService channel2 = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var endpoint = new EndpointAddress("http://localhost:5555/MathService");
            channel = ChannelFactory<IMathServiceLibrary>.CreateChannel(new BasicHttpBinding(), endpoint);

            var endpoint2 = new EndpointAddress("http://localhost:8081/CalcService");
            channel2 = ChannelFactory<ICalcService>.CreateChannel(new BasicHttpBinding(), endpoint2);

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

        private void button3_Click(object sender, EventArgs e)
        {
            CalcService1 calc = new CalcService1();
            int result = calc.Multiply(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));

            textBox3.Text = result.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CalcService1 calc = new CalcService1();
            int result = calc.Divide(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));

            textBox3.Text = result.ToString();
        }
    }
}
