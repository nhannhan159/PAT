using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PAT.GUI.SVModule
{
    public partial class RandomForm : Form
    {
        public event EventHandler ButtonGetNumSenLinkClicked;
        public RandomForm()
        {
            InitializeComponent();            
        }

        //public void getsenlink(ref int sensor, ref int link)
        //{
        //    sensor = int.Parse(textBox1.Text);
        //    link = int.Parse(textBox2.Text);
        //    Console.WriteLine(sensor);
        //    Console.WriteLine(link);
        //}

        public void button1_Click(object sender, EventArgs e)
        {
            if (ButtonGetNumSenLinkClicked != null)
                ButtonGetNumSenLinkClicked(sender, e);
        }
    }
}
