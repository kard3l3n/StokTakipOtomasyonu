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
	public partial class marka : Form
	{
		public marka()
		{
			InitializeComponent();
		}
		SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-CIN21FE\KAR;Integrated Security=SSPI;Initial Catalog=Stok_Takip");
		bool durum;
		private void markaengelle()
		{
			durum = true;
			baglanti.Open();
			SqlCommand komut = new SqlCommand("select * from markabilgileri", baglanti);
			SqlDataReader read = komut.ExecuteReader();
			while (read.Read())
			{
				if (comboBox1.Text==read["kategori"].ToString()  &&  textBox1.Text == read["marka"].ToString() || comboBox1.Text==" " || textBox1.Text == " ")
				//kategoriden markadan daha önde girilmiş bir değer mi? ya da boş girilmiş mi?diye bakıyor.
				{
					durum = false;
				}

			}
			baglanti.Close();

		}



		private void button1_Click(object sender, EventArgs e)
		{
			markaengelle();
			if (durum == true)//true ise ekliyor.
			{
				baglanti.Open();
				SqlCommand komut = new SqlCommand("insert into markabilgileri(kategori,marka) values('" + comboBox1.Text + "','" + textBox1.Text + "')", baglanti);
				komut.ExecuteNonQuery();
				baglanti.Close();
				textBox1.Text = "";
				comboBox1.Text = "";
				MessageBox.Show("marka eklendi");

			}
			else
			{
				MessageBox.Show("böyle bir kategori ve marka var","uyarı");
			}
			textBox1.Text = " ";
			comboBox1.Text = " ";
		}

		private void marka_Load(object sender, EventArgs e)
		{
			kategorigetir();
			
		}
		private void kategorigetir()
		{
			baglanti.Open();
			SqlCommand komut = new SqlCommand("select* from kategoribilgileri", baglanti);
			SqlDataReader read = komut.ExecuteReader();
			while (read.Read())
			{
				comboBox1.Items.Add(read["kategori"].ToString());

			}
			baglanti.Close();
		}
	}
}
