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
using System.Speech.Recognition;// ses ile arama yapabilmek için speech.recognition kütüphanesini ekledim 
namespace WindowsFormsApp78
{
	public partial class Form1 : Form
	{
		SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();// recEngine adlı sınıf oluşturdum

		public Form1()
		{
			InitializeComponent();
		}
		SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-CIN21FE\KAR;Integrated Security=SSPI;Initial Catalog=Stok_Takip");
		//sql ile kendi kullanıcıadımla bağlantı yaptım.
		DataSet daset = new DataSet();
		

		private void sepetlistele()// sepet tablosundan sepetteki ürünleri listeledim
		{
			baglanti.Open();
			SqlDataAdapter adtr = new SqlDataAdapter("select *from sepet",baglanti);
			adtr.Fill(daset,"sepet");
			dataGridView1.DataSource = daset.Tables["sepet"];
			dataGridView1.Columns[0].Visible = false;
			dataGridView1.Columns[1].Visible = false;
			dataGridView1.Columns[2].Visible = false;

			baglanti.Close();

		}
		private void button12_Click(object sender, EventArgs e)//ses tanıma için yaptım.button12 tıklantığında multiple ile istenildiği kadar aratılabilinir.
		{
			recEngine.RecognizeAsync(RecognizeMode.Multiple);
			
		}

		private void Form1_Load(object sender, EventArgs e)//Burda ses tanıma için kütüphane oluşturdum.
		{
			Choices commands = new Choices();
			commands.Add(new string[] { "add customet","customer list","add product","product list","sales list","brand","category"});
			GrammarBuilder gbuilder = new GrammarBuilder();
			gbuilder.Append(commands);
			Grammar grammar = new Grammar(gbuilder);
			recEngine.LoadGrammarAsync(grammar);
			recEngine.SetInputToDefaultAudioDevice();
			recEngine.SpeechRecognized += ses_tanidiginda;

		}

		private void ses_tanidiginda(object sender, SpeechRecognizedEventArgs e)
		{
			if(e.Result.Text=="add customer")//add costumer dediğinde müşteri ekle sayfasını açar.
			{
				frmmusteriekle ekleme = new frmmusteriekle();
				ekleme.ShowDialog();

			}

			if (e.Result.Text == "customer list")//customer list dediğinde müşteri listesi sayfasını açar.
			{
				musterilistele listeleme = new musterilistele();
				listeleme.ShowDialog();

			}
			if (e.Result.Text == "add product")//add product dediğinde ürün ekle sayfasını açar.
			{
				urunekle ekleme = new urunekle();
				ekleme.ShowDialog();

			}

			if (e.Result.Text == "product list")//product list dediğinde ürün listesi sayfasını açar.
			{
				Urunlisteleme listeleme = new Urunlisteleme();
				listeleme.ShowDialog();

			}
			if (e.Result.Text == "sales list")//sales list dediğinde satışlar listesi sayfasını açar.
			{
				satislistele sat = new satislistele();
				sat.ShowDialog();

			}
			if (e.Result.Text == "brand")//brand dediğinde marka sayfasını açar.
			{
				marka _marka = new marka();
				_marka.ShowDialog();

			}
			if (e.Result.Text == "category")//category dediğinde kategori sayfasını açar.
			{
				kategori kategori = new kategori();
				kategori.ShowDialog();
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			frmmusteriekle ekle = new frmmusteriekle();
			ekle.ShowDialog();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			musterilistele listele = new musterilistele();
			listele.ShowDialog();
		}


		private void hesapla()
		{
			try
			{
				baglanti.Open();
				SqlCommand komut = new SqlCommand("select sum(toplamfiyati) from sepet",baglanti);
				label10.Text = komut.ExecuteScalar() + "TL";
				baglanti.Close();
			}
			catch(Exception)
			{
				;

			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			urunekle ekle = new urunekle();
			ekle.ShowDialog();//urunekle form sayfasını açar.
		}

		private void button11_Click(object sender, EventArgs e)
		{
			kategori kategori = new kategori();
			kategori.ShowDialog();//kategori form sayfasını açmaya yarar.
		}

		private void button10_Click(object sender, EventArgs e)
		{
			marka _marka = new marka();
			_marka.ShowDialog();//_marka form sayfasını gösterir.
		}

		private void button8_Click(object sender, EventArgs e)
		{
			Urunlisteleme listele = new Urunlisteleme();
			listele.ShowDialog();//listele form sayfasını  gösterir.
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			if (textBox1.Text==" ")
			{
				textBox2.Text = " ";
				textBox3.Text = " ";
			}
			baglanti.Open();
			SqlCommand komut = new SqlCommand("select * from musteri where tc like '"+ textBox1.Text+"' ", baglanti);
			SqlDataReader read = komut.ExecuteReader();
			while (read.Read())
			{
				textBox2.Text = read["adsoyad"].ToString();
				textBox3.Text = read["telefon"].ToString();
			}
			baglanti.Close();
		}

		private void textBox4_TextChanged(object sender, EventArgs e)
		{
			temizle();
			baglanti.Open();
			SqlCommand komut = new SqlCommand("select *from urun where barkodno like '" + textBox4.Text + "' ", baglanti);
			SqlDataReader read = komut.ExecuteReader();
			while (read.Read())
			{
				textBox5.Text = read["urunadi"].ToString();
				textBox7.Text = read["satisfiyati"].ToString();

			}
			
			baglanti.Close();

		}

		private void temizle()
		{
			if (textBox4.Text == " ")
			{
				foreach (Control item in groupBox2.Controls)
				{
					if (item is TextBox)
					{
						if (item != textBox6)
						{
							item.Text = " ";
						}
					}



				}
			}
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		bool durum;
		private void barkotkontrol()
		{
			durum = true;
			baglanti.Open();
			SqlCommand komut = new SqlCommand("select * from sepet",baglanti);
			SqlDataReader read = komut.ExecuteReader();
			while(read.Read()){
				if (textBox4.Text==read["barkodno"].ToString())
				{
					durum = false;

				}
			}
			baglanti.Close();
		}
		
		private void button1_Click(object sender, EventArgs e)
		{

			barkotkontrol();
			if (durum == true)
			{
				baglanti.Open();
				SqlCommand komut = new SqlCommand("insert into sepet(tc,adsoyad,telefon,barkodno,urunadi,miktari,satisfiyati,toplamfiyati,tarih) values(@tc,@adsoyad,@telefon,@barkodno,@urunadi,@miktari,@satisfiyati,@toplamfiyati,@tarih)", baglanti);
				komut.Parameters.AddWithValue("@tc", textBox1.Text);
				komut.Parameters.AddWithValue("@adsoyad", textBox2.Text);
				komut.Parameters.AddWithValue("@telefon", textBox3.Text);
				komut.Parameters.AddWithValue("@barkodno", textBox4.Text);
				komut.Parameters.AddWithValue("@urunadi", textBox5.Text);
				komut.Parameters.AddWithValue("@miktari", int.Parse(textBox6.Text));
				komut.Parameters.AddWithValue("@satisfiyati", double.Parse(textBox7.Text));
				komut.Parameters.AddWithValue("@toplamfiyati", double.Parse(textBox8.Text));
				komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
				komut.ExecuteNonQuery();
				baglanti.Close();
			}
			else
			{
			

			}
		
			textBox6.Text = "1";
			sepetlistele();
			hesapla();
			foreach (Control item in groupBox2.Controls)
			{
				if (item is TextBox)
				{
					if (item != textBox6)
					{
						item.Text = " ";
					}
				}

			}

		}

		private void textBox6_TextChanged(object sender, EventArgs e)
		{
			try
			{
				textBox8.Text = (double.Parse(textBox6.Text) * double.Parse(textBox7.Text)).ToString();
			}
			catch(Exception)
			{
				;
			}
		}

		private void textBox7_TextChanged(object sender, EventArgs e)
		{
			try
			{
				textBox8.Text = (double.Parse(textBox6.Text) * double.Parse(textBox7.Text)).ToString();
			}
			catch (Exception)
			{
				;
			}
			
			

		}

		private void button2_Click(object sender, EventArgs e)
		{
			baglanti.Open();
			SqlCommand komuta = new SqlCommand("delete from sepet where barkodno='"+dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString()+"'",baglanti);
			komuta.ExecuteNonQuery();
			hesapla();
			baglanti.Close();
			MessageBox.Show("ürün sepetten çıkarıldı");
			daset.Tables["sepet"].Clear();
			sepetlistele();
			


		}

		private void button9_Click(object sender, EventArgs e)
		{
			satislistele sat = new satislistele();
			sat.ShowDialog();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			baglanti.Open();
			SqlCommand komuta = new SqlCommand("delete from sepet where barkodno='" + dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString() + "'", baglanti);
			komuta.ExecuteNonQuery();
			
			baglanti.Close();
			MessageBox.Show("ürün sepetten çıkarıldı");
			daset.Tables["sepet"].Clear();
			sepetlistele();
			hesapla();


		}

		private void label10_Click(object sender, EventArgs e)
		{

		}

		private void button4_Click(object sender, EventArgs e)
		{
			for(int i=0;i< dataGridView1.Rows.Count - 1; i++)
			{
				baglanti.Open();
				SqlCommand komut = new SqlCommand("insert into satis(tc,adsoyad,telefon,barkodno,urunadi,miktari,satisfiyati,toplamfiyati,tarih) values(@tc,@adsoyad,@telefon,@barkodno,@urunadi,@miktari,@satisfiyati,@toplamfiyati,@tarih)", baglanti);
				komut.Parameters.AddWithValue("@tc", textBox1.Text);
				komut.Parameters.AddWithValue("@adsoyad", textBox2.Text);
				komut.Parameters.AddWithValue("@telefon", textBox3.Text);
				komut.Parameters.AddWithValue("@barkodno",dataGridView1.Rows[i].Cells["barkodno"].Value.ToString());
				komut.Parameters.AddWithValue("@urunadi", dataGridView1.Rows[i].Cells["urunadi"].Value.ToString());
				komut.Parameters.AddWithValue("@miktari", int.Parse(dataGridView1.Rows[i].Cells["miktari"].Value.ToString()));
				komut.Parameters.AddWithValue("@satisfiyati", double.Parse(dataGridView1.Rows[i].Cells["satisfiyati"].Value.ToString()));
				komut.Parameters.AddWithValue("@toplamfiyati", double.Parse(dataGridView1.Rows[i].Cells["toplamfiyati"].Value.ToString()));
				komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
				komut.ExecuteNonQuery();

				SqlCommand komut2 = new SqlCommand("update urun set miktari=miktari -'" + int.Parse(dataGridView1.Rows[i].Cells["miktari"].Value.ToString()) + "'where barkodno='" + dataGridView1.Rows[i].Cells["barkodno"].Value.ToString() + "'", baglanti);
				komut2.ExecuteNonQuery();
				baglanti.Close();
			
				

			}
			baglanti.Open();
			SqlCommand komut3 = new SqlCommand("delete from sepet",baglanti);//sepetetten ürün silmeye yarar.
			komut3.ExecuteNonQuery();
			baglanti.Close();
			daset.Tables["sepet"].Clear();
			sepetlistele();
			hesapla();

		}

		private void button12_Click_1(object sender, EventArgs e)
		{
			recEngine.RecognizeAsync(RecognizeMode.Multiple);
		}

		private void label4_Click(object sender, EventArgs e)
		{

		}
	}
}
