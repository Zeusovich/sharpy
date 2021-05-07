using System;
using System.Windows.Forms;

namespace sharpy
{
    public partial class Search : Form
    {
        private FightersController _controller;
        public Search()
        {
            _controller = new FightersController();
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Fighter fighter = new Fighter(textBox1.Text, textBox2.Text, numericUpDown1.Value, numericUpDown2.Value);
            
            dataGridView1.DataSource = _controller.Search(fighter);
        }
    }
}