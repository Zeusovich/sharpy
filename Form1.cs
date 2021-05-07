using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sharpy
{
    public partial class Form1 : Form
    {
        private FightersController _controller;
        public Form1()
        {
            _controller = new FightersController();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.CreateFile();
            _controller.GetAllFighters();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Create create = new Create();
            create.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            FightersController fightersController = new FightersController();
            
        }


        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _controller.GetAllFighters();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //Search
            Search search = new Search();
            search.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Edit
            Edit edit = new Edit();
            edit.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Delete delete = new Delete();
            delete.Show();
        }

        /*private void button6_Click(object sender, EventArgs e)
        {
            _controller.CreateFile();
        }*/
    }
}