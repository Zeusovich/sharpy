using System;
using System.Runtime.Intrinsics.X86;
using System.Windows.Forms;

namespace sharpy
{
    public partial class Create : Form
    {
        private FightersController _controller;
        public Create()
        {
            _controller = new FightersController();
            InitializeComponent();
        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.AddNewFighter(new Fighter(textBox1.Text,textBox2.Text,numericUpDown1.Value,numericUpDown2.Value));
        }
    }
}