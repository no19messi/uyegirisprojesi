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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace sporsalonu
{
    public partial class uyeyonetimi : Form
    {
        public uyeyonetimi()
        {
            InitializeComponent();
        }
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=sporsalonu.mdb");  
        void vg() 
        {
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM uyeyonetimi",conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        void ue()
        {
            string sql = "INSERT INTO uyeyonetimi (isim, soyisim, dogumTarihi, cinsiyet, telno, eposta, uyelikPlani, uyelikBaslangicTarihi, acilDurumIletisimBilgileri) " +
              "VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + dateTimePicker1.Value.ToString() + "', '" + comboBox1.Text + "', '" + maskedTextBox1.Text + "', '" + textBox3.Text + "', " +
              "'" + comboBox2.Text + "', '" + dateTimePicker2.Value.ToString() + "', '" + maskedTextBox2.Text + "')";


            conn.Open(); 
            OleDbCommand cmd = new OleDbCommand(sql,conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        void dgvclick()
        {
            textBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker3.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[3].Value);
            comboBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            maskedTextBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            comboBox4.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            dateTimePicker4.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[8].Value);
            maskedTextBox4.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();

            textBox9.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker5.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[3].Value);
            comboBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            maskedTextBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            comboBox6.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            dateTimePicker6.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[8].Value);
            maskedTextBox6.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();




        }
        void ua()
        {
            string arananIsim = textBox7.Text.Trim();
            string arananSoyisim = textBox8.Text.Trim();

            // SQL sorgusu
            string sorgu = "SELECT * FROM uyeyonetimi WHERE isim LIKE '%" + arananIsim + "%' AND soyisim LIKE '%" + arananSoyisim + "%'";

            OleDbCommand sql_search = new OleDbCommand(sorgu, conn);

            // DataAdapter kullanarak veriyi çekiyoruz
            OleDbDataAdapter da = new OleDbDataAdapter(sql_search);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // DataGridView'i güncelle
            dataGridView1.DataSource = dt;

            // Arama sonuçları bulunamazsa kullanıcıyı bilgilendirin
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Arama kriterlerine uygun üye bulunamadı.");
            }
        }
        void ug()
        {
            string uyeNo = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string sorgu = "UPDATE uyeyonetimi SET " +
                "isim = '" + textBox4.Text + "', " +
                "soyisim = '" + textBox5.Text + "', " +
                "dogumTarihi = '" + dateTimePicker3.Value + "', " +
                "cinsiyet = '" + comboBox3.Text + "', " +
                "telno = '" + maskedTextBox3.Text + "', " +
                "eposta = '" + textBox6.Text + "', " +
                "uyelikPlani = '" + comboBox4.Text + "', " +
                "uyelikBaslangicTarihi = '" + dateTimePicker4.Value + "', " +
                "acilDurumIletisimBilgileri = '" + maskedTextBox4.Text + "' " +
                "WHERE uyeNo = " + uyeNo;

            OleDbCommand sql_edit = new OleDbCommand(sorgu, conn);
            conn.Open();
            sql_edit.ExecuteNonQuery();
            conn.Close();

        }

        void us()
        {
            string uyeNo = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string sorgu = "DELETE FROM uyeyonetimi WHERE uyeNo = " + uyeNo;

            OleDbCommand sql_sil = new OleDbCommand(sorgu, conn);
            conn.Open();
            sql_sil.ExecuteNonQuery();
            conn.Close();

            textBox9.Text = string.Empty;       // textBox9'u temizle
            textBox10.Text = string.Empty;      // textBox10'u temizle
            dateTimePicker5.Value = DateTime.Now; // dateTimePicker5'i varsayılan değere ayarla
            comboBox5.SelectedIndex = -1;      // comboBox5'i temizle
            maskedTextBox5.Text = string.Empty; // maskedTextBox5'i temizle
            textBox11.Text = string.Empty;      // textBox11'i temizle
            comboBox6.SelectedIndex = -1;      // comboBox6'yı temizle
            dateTimePicker6.Value = DateTime.Now; // dateTimePicker6'yı varsayılan değere ayarla
            maskedTextBox6.Text = string.Empty;

        }


        private void btn_ekle_Click(object sender, EventArgs e)//ÜYE EKLE
        {
            ue();
            vg();
        }
        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            ug();
            vg();
        }
        private void uyeyonetimi_Load(object sender, EventArgs e)
        {
            vg();
        }

        private void uyeyonetimi_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvclick();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            us();
            vg();
        }

        private void btn_Ara_Click(object sender, EventArgs e)
        {
            ua();
        }
    }
}
