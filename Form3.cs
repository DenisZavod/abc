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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            db.dbConnection();
            db.InsertSotr(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text);

            db.dbConnection();
            db.LoadSortr(dataGridView1);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DB db2 = new DB();
            db2.dbConnection();
            db2.LoadSortr(dataGridView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            DB db3 = new DB();
            db3.dbConnection();
            db3.PoiskSotr(dataGridView1, textBox8.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DB db4 = new DB();
            db4.dbConnection();
            db4.UpdateSotr(Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value),
                Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value),
                Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value),
                Convert.ToString(dataGridView1.CurrentRow.Cells[7].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB db5 = new DB();
            db5.dbConnection();
            db5.DeleteSotr(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));

            db5.dbConnection();
            db5.LoadSortr(dataGridView1);
        }
    }
}
