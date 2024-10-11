using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace veritabani_project1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection b = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=kutuphane_p.mdb");

        private void button1_Click(object sender, EventArgs e)
        {
            b.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * From kitaplar", b);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


            b.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ekle = "INSERT INTO kitaplar (kitapAdi,kitapYazari,kitapSayfasi,kitapTuru,kitapKonumu)" +
                          "VALUES ('" + textBox1.Text + "','" + textBox2.Text + "'," + textBox3.Text + ",'" + textBox4.Text + "','" + textBox5.Text + "')";

            b.Open();
            OleDbCommand cmd = new OleDbCommand(ekle, b);
            cmd.ExecuteNonQuery();
            b.Close();
        }
    }
}
