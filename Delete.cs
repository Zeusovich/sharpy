using System;
using System.Windows.Forms;

namespace sharpy
{
    public partial class Delete : Form
    {
        private FightersController _controller;
        public Delete()
        {
            _controller = new FightersController();
            InitializeComponent();
        }

        private void Delete_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = _controller.GetNamesList();
        }
        public void Update()
        {
            listBox1.DataSource = _controller.GetNamesList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var fighter = _controller.GetFighterByName(listBox1.SelectedItem.ToString());
            _controller.DeleteFighter(fighter);
            Update();
        }
        
        
    }
}