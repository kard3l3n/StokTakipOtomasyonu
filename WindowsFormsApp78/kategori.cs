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
	public partial class kategori : Form
	{
		public kategori()
		{
			InitializeComponent();
		}
		SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-CIN21FE\KAR;Integrated Security=SSPI;Initial Catalog=Stok_Takip");
		bool durum;
		private void kategoriengelle()//böyle bir kategori var mı yok mu diye kontrol eder.
		{
			durum = true;
			baglanti.Open();
			SqlCommand komut = new SqlCommand("select * from kategoribilgileri",baglanti);
			SqlDataReader read = komut.ExecuteReader();
			while (read.Read())
			{
				if (textBox1.Text==read["kategori"].ToString() || textBox1.Text==" ")//boş girildiyse ya da önceden varsa
				{
					durum = false;
				}

			}
			baglanti.Close();

		}



		private void kategori_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			kategoriengelle();
			if (durum == true)
			{
				baglanti.Open();
				SqlCommand komut = new SqlCommand("insert into kategoribilgileri(kategori) values('" + textBox1.Text + "')", baglanti);
				komut.ExecuteNonQuery();
				baglanti.Close();
				textBox1.Text = " ";
				MessageBox.Show("kategori eklendi");

			}
			else
			{
				MessageBox.Show("böyle bir kategori var");
				
			}
			textBox1.Text = " ";
			
		}
	}
}
