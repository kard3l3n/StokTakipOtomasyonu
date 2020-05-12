using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApp78
{
	public partial class musterilistele : Form
	{
		SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-CIN21FE\KAR;Integrated Security=SSPI;Initial Catalog=Stok_Takip");
		DataSet daset = new DataSet();


		public musterilistele()
		{
			InitializeComponent();
		}

		private void musterilistele_Load(object sender, EventArgs e)
		{
			kayıtgoster();//method çağırdık
		}
		private void kayıtgoster()
		{
			baglanti.Open();
			SqlDataAdapter adtr = new SqlDataAdapter("select*from musteri", baglanti);// musteri tablosunu dolaştı.
			adtr.Fill(daset, "musteri");
			dataGridView1.DataSource = daset.Tables["musteri"];//datagridview1 verileri girdi.
			baglanti.Close();
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			textBox1.Text = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
			textBox2.Text = dataGridView1.CurrentRow.Cells["adsoyad"].Value.ToString();
			textBox3.Text = dataGridView1.CurrentRow.Cells["telefon"].Value.ToString();
			textBox4.Text = dataGridView1.CurrentRow.Cells["adres"].Value.ToString();
			textBox5.Text = dataGridView1.CurrentRow.Cells["email"].Value.ToString();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			baglanti.Open();
			SqlCommand komut = new SqlCommand("update musteri set adsoyad=@adsoyad,telefon=@telefon,adres=@adres,email=@email where tc=@tc",baglanti);
			komut.Parameters.AddWithValue("@tc", textBox1.Text);
			komut.Parameters.AddWithValue("@adsoyad", textBox2.Text);
			komut.Parameters.AddWithValue("@telefon", textBox3.Text);
			komut.Parameters.AddWithValue("@adres", textBox4.Text);
			komut.Parameters.AddWithValue("@email", textBox5.Text);
			komut.ExecuteNonQuery();
			baglanti.Close();
			daset.Tables["musteri"].Clear();//eski verileri musteri tablosundan siliyor.
			kayıtgoster();
			MessageBox.Show("güncellendi");
			
			foreach (Control item in this.Controls)
			{
				if (item is TextBox)
				{
					item.Text = " ";
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			baglanti.Open();
			SqlCommand komut = new SqlCommand("delete from musteri where tc='"+dataGridView1.CurrentRow.Cells["tc"].Value.ToString()+"' ",baglanti);
			//tc ye göre siliyor.
			komut.ExecuteNonQuery();
			baglanti.Close();
			daset.Tables["musteri"].Clear();
			kayıtgoster();
			MessageBox.Show("kayıt silindi");
			
		}

		private void textBox6_TextChanged(object sender, EventArgs e)
		{

			DataTable tablo = new DataTable();
			baglanti.Open();
			SqlDataAdapter adtr = new SqlDataAdapter("select* from musteri where tc like '%"+textBox6.Text+"%' ",baglanti);
			adtr.Fill(tablo);
			dataGridView1.DataSource = tablo;
			baglanti.Close();
			

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
