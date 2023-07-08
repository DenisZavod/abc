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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            db.dbConnection();
            db.InsertProd(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text , textBox11.Text);
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            DB db2 = new DB();
            db2.dbConnection();
            db2.LoadProd(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DB db3 = new DB();
            db3.dbConnection();
            db3.UpdateProd(Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value),
                Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value),
                Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB db4 = new DB();
            db4.dbConnection();
            db4.DeleteProd(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));

            dataGridView1.Rows.Clear();
            db4.dbConnection();
            db4.LoadProd(dataGridView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            DB db5 = new DB();
            db5.dbConnection();
            db5.PoiskProd(dataGridView1, textBox8.Text);
        }
    }
}
