using System;
using System.Windows.Forms;

namespace sharpy
{
    public partial class Edit : Form
    {
        private FightersController _controller;
        public Edit()
        {
            _controller = new FightersController();
            InitializeComponent();
        }
        
       

        private void button1_Click_1(object sender, EventArgs e)
        {
            var selectedName = listBox1.SelectedValue.ToString();

            var selectedFighter = _controller.GetFighterByName(selectedName);
            Fighter newFighter = new Fighter
            {
                FirstName = textBox1.Text,
                Surname = textBox2.Text,
                Rating = numericUpDown1.Value,
                Weight = (int) numericUpDown2.Value,
            };
            /*textBox1.Text = fighter.FirstName;
            textBox2.Text = fighter.Surname;
            numericUpDown1.Value = fighter.Rating;
            numericUpDown2.Value = fighter.Weight;*/
            

            _controller.EditFighter(selectedFighter, newFighter);

            Reset();
            
            listBox1.DataSource = _controller.GetNamesList();
        }
        
        private void Reset()
        {
            textBox2.Text = "";
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;

        }

        private void Edit_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = _controller.GetNamesList();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedName = listBox1.SelectedItem.ToString();

            var selectedAnimal = _controller.GetFighterByName(selectedName);

            textBox1.Text = selectedAnimal.FirstName;
            textBox2.Text = selectedAnimal.Surname;
            numericUpDown1.Value = selectedAnimal.Rating;
            numericUpDown2.Value = selectedAnimal.Weight;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
            /*textBox1.Text = fighter.FirstName;
            textBox2.Text = fighter.Surname;
            numericUpDown1.Value = fighter.Rating;
            numericUpDown2.Value = fighter.Weight;*/
            //_controller.DeleteFighter(fighter);
}