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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            db.dbConnection();
            db.InsertPost(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox6.Text, textBox7.Text);
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            DB db2 = new DB();
            db2.dbConnection();
            db2.LoadPost(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DB db3 = new DB();
            db3.dbConnection();
            db3.UpdatePost(Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value),
                Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value),
                Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value),
                Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB db4 = new DB();
            db4.dbConnection();
            db4.DeletePost(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));

            db4.dbConnection();
            db4.LoadPost(dataGridView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            DB db5 = new DB();
            db5.dbConnection();
            db5.PoiskPost(dataGridView1, textBox8.Text);
        }
    }
}
