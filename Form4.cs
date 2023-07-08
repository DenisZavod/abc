using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apteka
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            db.dbConnection();
            db.InsertPrep(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox11.Text , textBox6.Text,
                textBox7.Text, textBox9.Text, textBox10.Text);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            DB db2 = new DB();
            db2.dbConnection();
            db2.LoadPrep(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DB db3 = new DB();
            db3.dbConnection();
            db3.UpdatePrep(Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value),
                Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value),
                Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value),
                Convert.ToString(dataGridView1.CurrentRow.Cells[7].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[8].Value),
                Convert.ToString(dataGridView1.CurrentRow.Cells[9].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            DB db4 = new DB();
            db4.dbConnection();
            db4.DeletePrep(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            DB db5 = new DB();
            db5.dbConnection();
            db5.PoiskPrep(dataGridView1, textBox8.Text);
        }
    }
}
