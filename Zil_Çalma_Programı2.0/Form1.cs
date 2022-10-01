using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Zil_Çalma_Programı2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        SqlConnection baglantı = new SqlConnection();


        string[] Sesler = new string[30];

        string[] BuGününSesler = new string[30];

        string[] ZilÇalmaZamanları = new string[30];

        bool[] BuGününZilDurumu = new bool[30];

        int SeçiliLabel = -1;

        string VarsayılanSes;



        string adres;
        private void Form1_Load(object sender, EventArgs e)
        {
            adres = System.IO.File.ReadAllText(@"C:\Veri_Tabanı.txt");
            baglantı.ConnectionString = adres;

            comboBox2.Items.Add(" ");
            Sesleri_Listele();
            varsayılan_Zil_Sesini_Ayarla();

            for (int i = 0; i <= 29; i++)
            {
                Sesler[i] = " ";
            }
            Tarih_Kontrolü(DateTime.Now.Year.ToString() + '-' + DateTime.Now.Month.ToString() + '-' + DateTime.Now.Day.ToString());

            ZilİsimleriniLabeleYükle(DateTime.Now.Year.ToString() + '-' + DateTime.Now.Month.ToString() + '-' + DateTime.Now.Day.ToString());

            timer1.Start();

        }

        private void Tarih_Kontrolü(string tarih)
        {
            Ses_Kontrolü(tarih);

            baglantı.Open();
            SqlCommand da = new SqlCommand("SELECT * FROM ZilDurum WHERE (tarih=@tarih)", baglantı);
            da.Parameters.AddWithValue("@tarih", tarih);
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(da);
            da1.Fill(dt1);
            baglantı.Close();

            try
            {
                if (dt1.Rows[0]["tarih"] != null)
                {
                    if (dt1.Rows[0]["ÖGZ1"].ToString() == "True")
                        BTNZilDurum1.BackColor = Color.Blue;
                    else
                        BTNZilDurum1.BackColor = Color.Red;
                    if (dt1.Rows[0]["ÖGZ2"].ToString() == "True")
                        BTNZilDurum4.BackColor = Color.Blue;
                    else
                        BTNZilDurum4.BackColor = Color.Red;
                    if (dt1.Rows[0]["ÖGZ3"].ToString() == "True")
                        BTNZilDurum7.BackColor = Color.Blue;
                    else
                        BTNZilDurum7.BackColor = Color.Red;
                    if (dt1.Rows[0]["ÖGZ4"].ToString() == "True")
                        BTNZilDurum10.BackColor = Color.Blue;
                    else
                        BTNZilDurum10.BackColor = Color.Red;
                    if (dt1.Rows[0]["ÖGZ5"].ToString() == "True")
                        BTNZilDurum13.BackColor = Color.Blue;
                    else
                        BTNZilDurum13.BackColor = Color.Red;
                    if (dt1.Rows[0]["ÖGZ6"].ToString() == "True")
                        BTNZilDurum16.BackColor = Color.Blue;
                    else
                        BTNZilDurum16.BackColor = Color.Red;
                    if (dt1.Rows[0]["ÖGZ7"].ToString() == "True")
                        BTNZilDurum19.BackColor = Color.Blue;
                    else
                        BTNZilDurum19.BackColor = Color.Red;
                    if (dt1.Rows[0]["ÖGZ8"].ToString() == "True")
                        BTNZilDurum22.BackColor = Color.Blue;
                    else
                        BTNZilDurum22.BackColor = Color.Red;
                    if (dt1.Rows[0]["ÖGZ9"].ToString() == "True")
                        BTNZilDurum25.BackColor = Color.Blue;
                    else
                        BTNZilDurum25.BackColor = Color.Red;
                    if (dt1.Rows[0]["ÖGZ10"].ToString() == "True")
                        BTNZilDurum28.BackColor = Color.Blue;
                    else
                        BTNZilDurum28.BackColor = Color.Red;


                    if (dt1.Rows[0]["ÖMGZ1"].ToString() == "True")
                        BTNZilDurum2.BackColor = Color.Blue;
                    else
                        BTNZilDurum2.BackColor = Color.Red;

                    if (dt1.Rows[0]["ÖMGZ2"].ToString() == "True")
                        BTNZilDurum5.BackColor = Color.Blue;
                    else
                        BTNZilDurum5.BackColor = Color.Red;

                    if (dt1.Rows[0]["ÖMGZ3"].ToString() == "True")
                        BTNZilDurum8.BackColor = Color.Blue;
                    else
                        BTNZilDurum8.BackColor = Color.Red;

                    if (dt1.Rows[0]["ÖMGZ4"].ToString() == "True")
                        BTNZilDurum11.BackColor = Color.Blue;
                    else
                        BTNZilDurum11.BackColor = Color.Red;

                    if (dt1.Rows[0]["ÖMGZ5"].ToString() == "True")
                        BTNZilDurum14.BackColor = Color.Blue;
                    else
                        BTNZilDurum14.BackColor = Color.Red;

                    if (dt1.Rows[0]["ÖMGZ6"].ToString() == "True")
                        BTNZilDurum17.BackColor = Color.Blue;
                    else
                        BTNZilDurum17.BackColor = Color.Red;

                    if (dt1.Rows[0]["ÖMGZ7"].ToString() == "True")
                        BTNZilDurum20.BackColor = Color.Blue;
                    else
                        BTNZilDurum20.BackColor = Color.Red;

                    if (dt1.Rows[0]["ÖMGZ8"].ToString() == "True")
                        BTNZilDurum23.BackColor = Color.Blue;
                    else
                        BTNZilDurum23.BackColor = Color.Red;

                    if (dt1.Rows[0]["ÖMGZ9"].ToString() == "True")
                        BTNZilDurum26.BackColor = Color.Blue;
                    else
                        BTNZilDurum26.BackColor = Color.Red;

                    if (dt1.Rows[0]["ÖMGZ10"].ToString() == "True")
                        BTNZilDurum29.BackColor = Color.Blue;
                    else
                        BTNZilDurum29.BackColor = Color.Red;


                    if (dt1.Rows[0]["DBZ1"].ToString() == "True")
                        BTNZilDurum3.BackColor = Color.Blue;
                    else
                        BTNZilDurum3.BackColor = Color.Red;

                    if (dt1.Rows[0]["DBZ2"].ToString() == "True")
                        BTNZilDurum6.BackColor = Color.Blue;
                    else
                        BTNZilDurum6.BackColor = Color.Red;

                    if (dt1.Rows[0]["DBZ3"].ToString() == "True")
                        BTNZilDurum9.BackColor = Color.Blue;
                    else
                        BTNZilDurum9.BackColor = Color.Red;

                    if (dt1.Rows[0]["DBZ4"].ToString() == "True")
                        BTNZilDurum12.BackColor = Color.Blue;
                    else
                        BTNZilDurum12.BackColor = Color.Red;

                    if (dt1.Rows[0]["DBZ5"].ToString() == "True")
                        BTNZilDurum15.BackColor = Color.Blue;
                    else
                        BTNZilDurum15.BackColor = Color.Red;

                    if (dt1.Rows[0]["DBZ6"].ToString() == "True")
                        BTNZilDurum18.BackColor = Color.Blue;
                    else
                        BTNZilDurum18.BackColor = Color.Red;

                    if (dt1.Rows[0]["DBZ7"].ToString() == "True")
                        BTNZilDurum21.BackColor = Color.Blue;
                    else
                        BTNZilDurum21.BackColor = Color.Red;

                    if (dt1.Rows[0]["DBZ8"].ToString() == "True")
                        BTNZilDurum24.BackColor = Color.Blue;
                    else
                        BTNZilDurum24.BackColor = Color.Red;

                    if (dt1.Rows[0]["DBZ9"].ToString() == "True")
                        BTNZilDurum27.BackColor = Color.Blue;
                    else
                        BTNZilDurum27.BackColor = Color.Red;

                    if (dt1.Rows[0]["DBZ10"].ToString() == "True")
                        BTNZilDurum30.BackColor = Color.Blue;
                    else
                        BTNZilDurum30.BackColor = Color.Red;



                    string[] parcalar = monthCalendar1.SelectionStart.ToString().Split('.', ':', ' ');
                    groupBox2.Text = parcalar[0] + ':' + parcalar[1] + ':' + parcalar[2];

                }
            }
            catch (Exception)
            {
                VarsayılanlaraDön();
            }

        }

        private void Ses_Kontrolü(string tarih)
        {
            try
            {
                baglantı.Open();
                SqlCommand azda = new SqlCommand("SELECT * FROM ZilSesi WHERE (tarih=@tarih)", baglantı);
                azda.Parameters.AddWithValue("@tarih", tarih);
                DataTable azdt1 = new DataTable();
                SqlDataAdapter azda1 = new SqlDataAdapter(azda);
                azda1.Fill(azdt1);
                baglantı.Close();


                if (azdt1.Rows[0]["tarih"].ToString() != null)
                {

                    baglantı.Open();
                    SqlCommand zda = new SqlCommand("SELECT * FROM ZilSesi WHERE (tarih=@tarih)", baglantı);
                    zda.Parameters.AddWithValue("@tarih", tarih);
                    DataTable zdt1 = new DataTable();
                    SqlDataAdapter zda1 = new SqlDataAdapter(zda);
                    zda1.Fill(zdt1);
                    baglantı.Close();

                    for (int i = 0; i < 30; i++)
                    {
                        Sesler[i] = zdt1.Rows[0]["ZS" + Convert.ToString(i + 1)].ToString();

                    }
                }
            }
            catch (Exception)
            {
                for (int i = 0; i < 30; i++)
                {
                    Sesler[i] = " ";

                }
            }

            if (SeçiliLabel != -1)
            {
                comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[SeçiliLabel]);
            }

        }

        private void VarsayılanlaraDön()
        {
            BTNZilDurum1.BackColor = Color.Blue;
            BTNZilDurum2.BackColor = Color.Blue;
            BTNZilDurum3.BackColor = Color.Blue;
            BTNZilDurum4.BackColor = Color.Blue;
            BTNZilDurum5.BackColor = Color.Blue;
            BTNZilDurum6.BackColor = Color.Blue;
            BTNZilDurum7.BackColor = Color.Blue;
            BTNZilDurum8.BackColor = Color.Blue;
            BTNZilDurum9.BackColor = Color.Blue;
            BTNZilDurum10.BackColor = Color.Blue;
            BTNZilDurum11.BackColor = Color.Blue;
            BTNZilDurum12.BackColor = Color.Blue;
            BTNZilDurum13.BackColor = Color.Blue;
            BTNZilDurum14.BackColor = Color.Blue;
            BTNZilDurum15.BackColor = Color.Blue;
            BTNZilDurum16.BackColor = Color.Blue;
            BTNZilDurum17.BackColor = Color.Blue;
            BTNZilDurum18.BackColor = Color.Blue;
            BTNZilDurum19.BackColor = Color.Blue;
            BTNZilDurum20.BackColor = Color.Blue;
            BTNZilDurum21.BackColor = Color.Blue;
            BTNZilDurum22.BackColor = Color.Blue;
            BTNZilDurum23.BackColor = Color.Blue;
            BTNZilDurum24.BackColor = Color.Blue;
            BTNZilDurum25.BackColor = Color.Blue;
            BTNZilDurum26.BackColor = Color.Blue;
            BTNZilDurum27.BackColor = Color.Blue;
            BTNZilDurum28.BackColor = Color.Blue;
            BTNZilDurum29.BackColor = Color.Blue;
            BTNZilDurum30.BackColor = Color.Blue;
        }

        private void Sesleri_Listele()
        {
            string[] dosyalar = System.IO.Directory.GetFiles("Sesler");

            foreach (var item in dosyalar)
            {
                listBox1.Items.Add(item.Replace(@"Sesler\", ""));
                comboBox2.Items.Add(item.Replace(@"Sesler\", ""));
                comboBox1.Items.Add(item.Replace(@"Sesler\", ""));
            }

        }

        private void varsayılan_Zil_Sesini_Ayarla()
        {
            baglantı.Open();

            SqlCommand VSSes = new SqlCommand("SELECT * FROM VarsayılanZilSesi", baglantı);
            DataTable dt11 = new DataTable();
            SqlDataAdapter da11 = new SqlDataAdapter(VSSes);
            da11.Fill(dt11);


            VarsayılanSes = dt11.Rows[0]["Varsayılan_Zil_Sesi"].ToString();

            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(VarsayılanSes);

            baglantı.Close();
        }

        private void ZilİsimleriniLabeleYükle(string tarih)
        {
            CBZilSeç.Items.Clear();
            CBdakika.Items.Clear();
            CBSaat.Items.Clear();

            for (int i = 1; i <= 10; i++)
            {
                CBZilSeç.Items.Add(i.ToString() + ". Öğrenci Giriş Zili");
                CBZilSeç.Items.Add(i.ToString() + ". Öğretmen Giriş Zili");
                CBZilSeç.Items.Add(i.ToString() + ". Desr Bitiş Zili");
            }

            for (int i = 5; i < 22; i++)
            {
                CBSaat.Items.Add(i.ToString());
            }

            for (int i = 0; i < 61; i++)
            {
                CBdakika.Items.Add(i.ToString());

            }

            baglantı.Open();
            SqlCommand da = new SqlCommand("SELECT * FROM ZilÇalmaZamanı", baglantı);
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(da);
            da1.Fill(dt1);
            baglantı.Close();

            for (int i = 0; i < 30; i++)
            {
                ZilÇalmaZamanları[i] = dt1.Rows[0]["ZS" + Convert.ToString(i + 1)].ToString();
            }



            baglantı.Open();
            SqlCommand zda = new SqlCommand("SELECT * FROM ZilDurum WHERE (tarih=@tarih)", baglantı);
            zda.Parameters.AddWithValue("@tarih", tarih);
            DataTable zdt1 = new DataTable();
            SqlDataAdapter zda1 = new SqlDataAdapter(zda);
            zda1.Fill(zdt1);
            baglantı.Close();

            try
            {


                if (zdt1.Rows[0]["ÖGZ1"] != null)
                {

                    int a = 0;
                    for (int i = 1; i <= 10; i++)
                    {
                        BuGününZilDurumu[a] = Convert.ToBoolean(zdt1.Rows[0]["ÖGZ" + i.ToString()]);
                        a++;
                        BuGününZilDurumu[a] = Convert.ToBoolean(zdt1.Rows[0]["ÖMGZ" + i.ToString()]);
                        a++;
                        BuGününZilDurumu[a] = Convert.ToBoolean(zdt1.Rows[0]["DBZ" + i.ToString()]);
                        a++;
                    }
                }
            }
            catch (Exception)
            {
                for (int i = 0; i < 30; i++)
                {
                    BuGününZilDurumu[i] = false;
                }
            }


            try
            {


                baglantı.Open();
                SqlCommand azda = new SqlCommand("SELECT * FROM ZilSesi WHERE (tarih=@tarih)", baglantı);
                azda.Parameters.AddWithValue("@tarih", tarih);
                DataTable azdt1 = new DataTable();
                SqlDataAdapter azda1 = new SqlDataAdapter(azda);
                azda1.Fill(azdt1);
                baglantı.Close();

                for (int i = 0; i < 30; i++)
                {
                    BuGününSesler[i] = azdt1.Rows[0]["ZS" + Convert.ToString(i + 1)].ToString();
                }

            }
            catch (Exception)
            {
                for (int i = 0; i < 30; i++)
                {
                    BuGününSesler[i] = " ";
                }
            }
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Ses_Kaydet_Click(object sender, EventArgs e)
        {

            try
            {
                openFileDialog1.Filter = "Media File(*.mpg,*.dat,*.avi,*.wmv,*.wav,*.mp3)|*.wav;*.mp3;*.mpg;*.dat;*.avi;*.wmv";
                openFileDialog1.Title = "Dosya Seç";


                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Directory.Move(openFileDialog1.FileName, @"Sesler\" + openFileDialog1.SafeFileName);
                    baglantı.Open();
                    string kayit = "insert into Sesler (Sesler) values (@Sesler)";
                    SqlCommand komut = new SqlCommand(kayit, baglantı);
                    komut.Parameters.AddWithValue("@Sesler", openFileDialog1.SafeFileName);
                    komut.ExecuteNonQuery();
                    baglantı.Close();

                    listBox1.Items.Add(openFileDialog1.SafeFileName);
                    comboBox1.Items.Add(openFileDialog1.SafeFileName);
                    comboBox2.Items.Add(openFileDialog1.SafeFileName);

                    MessageBox.Show("İşlem Başarılı", "İşlem Başarılı");

                }
            }
            catch (Exception)
            {
                MessageBox.Show("işlem başarısız! Zaten var olan bir dosyayı yüklemeye çalışıyor olabilirsiniz", "İşlem Başarısız!");
            }
        }

        private void Ses_Sil_Click(object sender, EventArgs e)
        {
            try
            {

                if (listBox1.SelectedIndex != -1)
                {

                    DialogResult result1 = MessageBox.Show("Sesi Silmekten eminmisiniz!",
                                                        "Sesi Sil", MessageBoxButtons.YesNo);
                    if (result1 == DialogResult.Yes)
                    {
                        if (listBox1.SelectedIndex != -1)
                        {

                            string Sesİsmi = listBox1.SelectedItem.ToString();

                            baglantı.Open();
                            string kayit = "DELETE FROM Sesler WHERE Sesler = @Sesler";
                            SqlCommand komut = new SqlCommand(kayit, baglantı);
                            komut.Parameters.AddWithValue("@Sesler", Sesİsmi);
                            komut.ExecuteNonQuery();
                            baglantı.Close();

                            System.IO.File.Delete(@"Sesler\" + Sesİsmi);

                            int a = listBox1.SelectedIndex;

                            comboBox2.Items.RemoveAt(a + 1);
                            comboBox1.Items.RemoveAt(a);

                            listBox1.Items.RemoveAt(a);

                        }
                    }
                }
            }
            catch (Exception)
            {

            }

        }

        private void BTNkaydet_Click(object sender, EventArgs e)
        {

            DialogResult result1 = MessageBox.Show("Verileri kaydetmeye eminmisiniz!",
                                                    "Verileri Kaydet", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {


                string[] parcalar = monthCalendar1.SelectionStart.ToString().Split('.', ':', ' ');
                string SeçiliTarih = parcalar[2] + '-' + parcalar[1] + '-' + parcalar[0];


                baglantı.Open();
                SqlCommand da = new SqlCommand("SELECT * FROM ZilDurum WHERE (tarih=@tarih)", baglantı);
                da.Parameters.AddWithValue("@tarih", SeçiliTarih);
                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(da);
                da1.Fill(dt1);
                baglantı.Close();

                try
                {
                    if (dt1.Rows[0]["tarih"] != null)
                    {
                        baglantı.Open();

                        string kayit = "update ZilDurum set ÖGZ1=@ÖGZ1 , ÖGZ2=@ÖGZ2, ÖGZ3=@ÖGZ3 , ÖGZ4=@ÖGZ4 , ÖGZ5=@ÖGZ5 , ÖGZ6=@ÖGZ6 , ÖGZ7=@ÖGZ7 , ÖGZ8=@ÖGZ8 , ÖGZ9=@ÖGZ9 , ÖGZ10=@ÖGZ10 , ÖMGZ1=@ÖMGZ1 , ÖMGZ2=@ÖMGZ2 , ÖMGZ3=@ÖMGZ3 , ÖMGZ4=@ÖMGZ4 , ÖMGZ5=@ÖMGZ5 , ÖMGZ6=@ÖMGZ6 , ÖMGZ7=@ÖMGZ7 , ÖMGZ8=@ÖMGZ8 , ÖMGZ9=@ÖMGZ9 , ÖMGZ10=@ÖMGZ10 , DBZ1=@DBZ1 , DBZ2=@DBZ2  , DBZ3=@DBZ3, DBZ4=@DBZ4, DBZ5=@DBZ5, DBZ6=@DBZ6, DBZ7=@DBZ7, DBZ8=@DBZ8, DBZ9=@DBZ9, DBZ10=@DBZ10  where tarih=@tarih";
                        SqlCommand komut = new SqlCommand(kayit, baglantı);

                        komut.Parameters.AddWithValue("@tarih", SeçiliTarih);


                        if (BTNZilDurum1.BackColor == Color.Red)
                            komut.Parameters.AddWithValue("@ÖGZ1", false);
                        else
                            komut.Parameters.AddWithValue("@ÖGZ1", true);

                        if (BTNZilDurum2.BackColor == Color.Red)
                            komut.Parameters.AddWithValue("@ÖMGZ1", false);
                        else
                            komut.Parameters.AddWithValue("@ÖMGZ1", true);

                        if (BTNZilDurum3.BackColor == Color.Red)
                            komut.Parameters.AddWithValue("@DBZ1", false);
                        else
                            komut.Parameters.AddWithValue("@DBZ1", true);

                        if (BTNZilDurum4.BackColor == Color.Red)
                            komut.Parameters.AddWithValue("@ÖGZ2", false);
                        else
                            komut.Parameters.AddWithValue("@ÖGZ2", true);

                        if (BTNZilDurum5.BackColor == Color.Red)
                            komut.Parameters.AddWithValue("@ÖMGZ2", false);
                        else
                            komut.Parameters.AddWithValue("@ÖMGZ2", true);

                        if (BTNZilDurum6.BackColor == Color.Red)
                            komut.Parameters.AddWithValue("@DBZ2", false);
                        else
                            komut.Parameters.AddWithValue("@DBZ2", true);

                        if (BTNZilDurum7.BackColor == Color.Red)
                            komut.Parameters.AddWithValue("@ÖGZ3", false);
                        else
                            komut.Parameters.AddWithValue("@ÖGZ3", true);

                        if (BTNZilDurum8.BackColor == Color.Red)
                            komut.Parameters.AddWithValue("@ÖMGZ3", false);
                        else
                            komut.Parameters.AddWithValue("@ÖMGZ3", true);

                        if (BTNZilDurum9.BackColor == Color.Red)
                            komut.Parameters.AddWithValue("@DBZ3", false);
                        else
                            komut.Parameters.AddWithValue("@DBZ3", true);

                        if (BTNZilDurum10.BackColor == Color.Red)
                            komut.Parameters.AddWithValue("@ÖGZ4", false);
                        else
                            komut.Parameters.AddWithValue("@ÖGZ4", true);

                        if (BTNZilDurum11.BackColor == Color.Red)
                            komut.Parameters.AddWithValue("@ÖMGZ4", false);
                        else
                            komut.Parameters.AddWithValue("@ÖMGZ4", true);

                        if (BTNZilDurum12.BackColor == Color.Red)
                            komut.Parameters.AddWithValue("@DBZ4", false);
                        else
                            komut.Parameters.AddWithValue("@DBZ4", true);

                        if (BTNZilDurum13.BackColor == Color.Red)
                            komut.Parameters.AddWithValue("@ÖGZ5", false);
                        else
                            komut.Parameters.AddWithValue("@ÖGZ5", true);

                        if (BTNZilDurum14.BackColor == Color.Red)
                            komut.Parameters.AddWithValue("@ÖMGZ5", false);
                        else
                            komut.Parameters.AddWithValue("@ÖMGZ5", true);

                        if (BTNZilDurum15.BackColor == Color.Red)
                            komut.Parameters.AddWithValue("@DBZ5", false);
                        else
                            komut.Parameters.AddWithValue("@DBZ5", true);

                        if (BTNZilDurum16.BackColor == Color.Red)
                            komut.Parameters.AddWithValue("@ÖGZ6", false);
                        else
                            komut.Parameters.AddWithValue("@ÖGZ6", true);

                        if (BTNZilDurum17.BackColor == Color.Red)
                            komut.Parameters.AddWithValue("@ÖMGZ6", false);
                        else
                            komut.Parameters.AddWithValue("@ÖMGZ6", true);

                        if (BTNZilDurum18.BackColor == Color.Red)
                            komut.Parameters.AddWithValue("@DBZ6", false);
                        else
                            komut.Parameters.AddWithValue("@DBZ6", true);

                        if (BTNZilDurum19.BackColor == Color.Red)
                            komut.Parameters.AddWithValue("@ÖGZ7", false);
                        else
                            komut.Parameters.AddWithValue("@ÖGZ7", true);

                        if (BTNZilDurum20.BackColor == Color.Red)
                            komut.Parameters.AddWithValue("@ÖMGZ7", false);
                        else
                            komut.Parameters.AddWithValue("@ÖMGZ7", true);

                        if (BTNZilDurum21.BackColor == Color.Red)
                            komut.Parameters.AddWithValue("@DBZ7", false);
                        else
                            komut.Parameters.AddWithValue("@DBZ7", true);

                        if (BTNZilDurum22.BackColor == Color.Red)
                            komut.Parameters.AddWithValue("@ÖGZ8", false);
                        else
                            komut.Parameters.AddWithValue("@ÖGZ8", true);

                        if (BTNZilDurum23.BackColor == Color.Red)
                            komut.Parameters.AddWithValue("@ÖMGZ8", false);
                        else
                            komut.Parameters.AddWithValue("@ÖMGZ8", true);

                        if (BTNZilDurum24.BackColor == Color.Red)
                            komut.Parameters.AddWithValue("@DBZ8", false);
                        else
                            komut.Parameters.AddWithValue("@DBZ8", true);

                        if (BTNZilDurum25.BackColor == Color.Red)
                            komut.Parameters.AddWithValue("@ÖGZ9", false);
                        else
                            komut.Parameters.AddWithValue("@ÖGZ9", true);

                        if (BTNZilDurum26.BackColor == Color.Red)
                            komut.Parameters.AddWithValue("@ÖMGZ9", false);
                        else
                            komut.Parameters.AddWithValue("@ÖMGZ9", true);

                        if (BTNZilDurum27.BackColor == Color.Red)
                            komut.Parameters.AddWithValue("@DBZ9", false);
                        else
                            komut.Parameters.AddWithValue("@DBZ9", true);

                        if (BTNZilDurum28.BackColor == Color.Red)
                            komut.Parameters.AddWithValue("@ÖGZ10", false);
                        else
                            komut.Parameters.AddWithValue("@ÖGZ10", true);

                        if (BTNZilDurum29.BackColor == Color.Red)
                            komut.Parameters.AddWithValue("@ÖMGZ10", false);
                        else
                            komut.Parameters.AddWithValue("@ÖMGZ10", true);

                        if (BTNZilDurum30.BackColor == Color.Red)
                            komut.Parameters.AddWithValue("@DBZ10", false);
                        else
                            komut.Parameters.AddWithValue("@DBZ10", true);
                        komut.ExecuteNonQuery();


                        string Seskayit = "update ZilSesi set tarih = @tarih, ZS1 = @ZS1,ZS2= @ZS2,ZS3= @ZS3,ZS4= @ZS4,ZS5= @ZS5,ZS6= @ZS6,ZS7= @ZS7,ZS8= @ZS8,ZS9= @ZS9,ZS10= @ZS10,ZS11= @ZS11,ZS12= @ZS12,ZS13= @ZS13,ZS14= @ZS4,ZS15= @ZS15,ZS16= @ZS16,ZS17= @ZS17,ZS18= @ZS18,ZS19= @ZS19,ZS20= @ZS20,ZS21= @ZS21,ZS22= @ZS22,ZS23= @ZS23,ZS24= @ZS24,ZS25= @ZS25,ZS26= @ZS26,ZS27= @ZS27,ZS28= @ZS28,ZS29= @ZS29,ZS30 = @ZS30 where tarih = @tarih";
                        SqlCommand Seskomut = new SqlCommand(Seskayit, baglantı);

                        Seskomut.Parameters.AddWithValue("@tarih", SeçiliTarih);

                        Seskomut.Parameters.AddWithValue("@ZS1", Sesler[0]);
                        Seskomut.Parameters.AddWithValue("@ZS2", Sesler[1]);
                        Seskomut.Parameters.AddWithValue("@ZS3", Sesler[2]);
                        Seskomut.Parameters.AddWithValue("@ZS4", Sesler[3]);
                        Seskomut.Parameters.AddWithValue("@ZS5", Sesler[4]);
                        Seskomut.Parameters.AddWithValue("@ZS6", Sesler[5]);
                        Seskomut.Parameters.AddWithValue("@ZS7", Sesler[6]);
                        Seskomut.Parameters.AddWithValue("@ZS8", Sesler[7]);
                        Seskomut.Parameters.AddWithValue("@ZS9", Sesler[8]);
                        Seskomut.Parameters.AddWithValue("@ZS10", Sesler[9]);
                        Seskomut.Parameters.AddWithValue("@ZS11", Sesler[10]);
                        Seskomut.Parameters.AddWithValue("@ZS12", Sesler[11]);
                        Seskomut.Parameters.AddWithValue("@ZS13", Sesler[12]);
                        Seskomut.Parameters.AddWithValue("@ZS14", Sesler[13]);
                        Seskomut.Parameters.AddWithValue("@ZS15", Sesler[14]);
                        Seskomut.Parameters.AddWithValue("@ZS16", Sesler[15]);
                        Seskomut.Parameters.AddWithValue("@ZS17", Sesler[16]);
                        Seskomut.Parameters.AddWithValue("@ZS18", Sesler[17]);
                        Seskomut.Parameters.AddWithValue("@ZS19", Sesler[18]);
                        Seskomut.Parameters.AddWithValue("@ZS20", Sesler[19]);
                        Seskomut.Parameters.AddWithValue("@ZS21", Sesler[20]);
                        Seskomut.Parameters.AddWithValue("@ZS22", Sesler[21]);
                        Seskomut.Parameters.AddWithValue("@ZS23", Sesler[22]);
                        Seskomut.Parameters.AddWithValue("@ZS24", Sesler[23]);
                        Seskomut.Parameters.AddWithValue("@ZS25", Sesler[24]);
                        Seskomut.Parameters.AddWithValue("@ZS26", Sesler[25]);
                        Seskomut.Parameters.AddWithValue("@ZS27", Sesler[26]);
                        Seskomut.Parameters.AddWithValue("@ZS28", Sesler[27]);
                        Seskomut.Parameters.AddWithValue("@ZS29", Sesler[28]);
                        Seskomut.Parameters.AddWithValue("@ZS30", Sesler[29]);
                        Seskomut.ExecuteNonQuery();

                        baglantı.Close();

                        MessageBox.Show("Kayıt işlemi başarılı", "Kayıt Başarılı");

                    }
                }



                catch (Exception)
                {
                    baglantı.Open();
                    string kayit = "insert into ZilDurum(tarih,ÖGZ1, ÖGZ2, ÖGZ3, ÖGZ4, ÖGZ5, ÖGZ6, ÖGZ7, ÖGZ8, ÖGZ9, ÖGZ10, ÖMGZ1, ÖMGZ2, ÖMGZ3, ÖMGZ4, ÖMGZ5, ÖMGZ6, ÖMGZ7, ÖMGZ8, ÖMGZ9, ÖMGZ10, DBZ1, DBZ2 , DBZ3, DBZ4, DBZ5, DBZ6, DBZ7, DBZ8, DBZ9, DBZ10) values (@tarih,@ÖGZ1, @ÖGZ2, @ÖGZ3, @ÖGZ4, @ÖGZ5, @ÖGZ6, @ÖGZ7, @ÖGZ8, @ÖGZ9, @ÖGZ10, @ÖMGZ1, @ÖMGZ2, @ÖMGZ3, @ÖMGZ4, @ÖMGZ5, @ÖMGZ6, @ÖMGZ7, @ÖMGZ8, @ÖMGZ9, @ÖMGZ10, @DBZ1, @DBZ2 , @DBZ3, @DBZ4, @DBZ5, @DBZ6, @DBZ7, @DBZ8, @DBZ9, @DBZ10)";

                    SqlCommand komut = new SqlCommand(kayit, baglantı);

                    komut.Parameters.AddWithValue("@tarih", SeçiliTarih);


                    if (BTNZilDurum1.BackColor == Color.Red)
                        komut.Parameters.AddWithValue("@ÖGZ1", false);
                    else
                        komut.Parameters.AddWithValue("@ÖGZ1", true);

                    if (BTNZilDurum2.BackColor == Color.Red)
                        komut.Parameters.AddWithValue("@ÖMGZ1", false);
                    else
                        komut.Parameters.AddWithValue("@ÖMGZ1", true);

                    if (BTNZilDurum3.BackColor == Color.Red)
                        komut.Parameters.AddWithValue("@DBZ1", false);
                    else
                        komut.Parameters.AddWithValue("@DBZ1", true);

                    if (BTNZilDurum4.BackColor == Color.Red)
                        komut.Parameters.AddWithValue("@ÖGZ2", false);
                    else
                        komut.Parameters.AddWithValue("@ÖGZ2", true);

                    if (BTNZilDurum5.BackColor == Color.Red)
                        komut.Parameters.AddWithValue("@ÖMGZ2", false);
                    else
                        komut.Parameters.AddWithValue("@ÖMGZ2", true);

                    if (BTNZilDurum6.BackColor == Color.Red)
                        komut.Parameters.AddWithValue("@DBZ2", false);
                    else
                        komut.Parameters.AddWithValue("@DBZ2", true);

                    if (BTNZilDurum7.BackColor == Color.Red)
                        komut.Parameters.AddWithValue("@ÖGZ3", false);
                    else
                        komut.Parameters.AddWithValue("@ÖGZ3", true);

                    if (BTNZilDurum8.BackColor == Color.Red)
                        komut.Parameters.AddWithValue("@ÖMGZ3", false);
                    else
                        komut.Parameters.AddWithValue("@ÖMGZ3", true);

                    if (BTNZilDurum9.BackColor == Color.Red)
                        komut.Parameters.AddWithValue("@DBZ3", false);
                    else
                        komut.Parameters.AddWithValue("@DBZ3", true);

                    if (BTNZilDurum10.BackColor == Color.Red)
                        komut.Parameters.AddWithValue("@ÖGZ4", false);
                    else
                        komut.Parameters.AddWithValue("@ÖGZ4", true);

                    if (BTNZilDurum11.BackColor == Color.Red)
                        komut.Parameters.AddWithValue("@ÖMGZ4", false);
                    else
                        komut.Parameters.AddWithValue("@ÖMGZ4", true);

                    if (BTNZilDurum12.BackColor == Color.Red)
                        komut.Parameters.AddWithValue("@DBZ4", false);
                    else
                        komut.Parameters.AddWithValue("@DBZ4", true);

                    if (BTNZilDurum13.BackColor == Color.Red)
                        komut.Parameters.AddWithValue("@ÖGZ5", false);
                    else
                        komut.Parameters.AddWithValue("@ÖGZ5", true);

                    if (BTNZilDurum14.BackColor == Color.Red)
                        komut.Parameters.AddWithValue("@ÖMGZ5", false);
                    else
                        komut.Parameters.AddWithValue("@ÖMGZ5", true);

                    if (BTNZilDurum15.BackColor == Color.Red)
                        komut.Parameters.AddWithValue("@DBZ5", false);
                    else
                        komut.Parameters.AddWithValue("@DBZ5", true);

                    if (BTNZilDurum16.BackColor == Color.Red)
                        komut.Parameters.AddWithValue("@ÖGZ6", false);
                    else
                        komut.Parameters.AddWithValue("@ÖGZ6", true);

                    if (BTNZilDurum17.BackColor == Color.Red)
                        komut.Parameters.AddWithValue("@ÖMGZ6", false);
                    else
                        komut.Parameters.AddWithValue("@ÖMGZ6", true);

                    if (BTNZilDurum18.BackColor == Color.Red)
                        komut.Parameters.AddWithValue("@DBZ6", false);
                    else
                        komut.Parameters.AddWithValue("@DBZ6", true);

                    if (BTNZilDurum19.BackColor == Color.Red)
                        komut.Parameters.AddWithValue("@ÖGZ7", false);
                    else
                        komut.Parameters.AddWithValue("@ÖGZ7", true);

                    if (BTNZilDurum20.BackColor == Color.Red)
                        komut.Parameters.AddWithValue("@ÖMGZ7", false);
                    else
                        komut.Parameters.AddWithValue("@ÖMGZ7", true);

                    if (BTNZilDurum21.BackColor == Color.Red)
                        komut.Parameters.AddWithValue("@DBZ7", false);
                    else
                        komut.Parameters.AddWithValue("@DBZ7", true);

                    if (BTNZilDurum22.BackColor == Color.Red)
                        komut.Parameters.AddWithValue("@ÖGZ8", false);
                    else
                        komut.Parameters.AddWithValue("@ÖGZ8", true);

                    if (BTNZilDurum23.BackColor == Color.Red)
                        komut.Parameters.AddWithValue("@ÖMGZ8", false);
                    else
                        komut.Parameters.AddWithValue("@ÖMGZ8", true);

                    if (BTNZilDurum24.BackColor == Color.Red)
                        komut.Parameters.AddWithValue("@DBZ8", false);
                    else
                        komut.Parameters.AddWithValue("@DBZ8", true);

                    if (BTNZilDurum25.BackColor == Color.Red)
                        komut.Parameters.AddWithValue("@ÖGZ9", false);
                    else
                        komut.Parameters.AddWithValue("@ÖGZ9", true);

                    if (BTNZilDurum26.BackColor == Color.Red)
                        komut.Parameters.AddWithValue("@ÖMGZ9", false);
                    else
                        komut.Parameters.AddWithValue("@ÖMGZ9", true);

                    if (BTNZilDurum27.BackColor == Color.Red)
                        komut.Parameters.AddWithValue("@DBZ9", false);
                    else
                        komut.Parameters.AddWithValue("@DBZ9", true);

                    if (BTNZilDurum28.BackColor == Color.Red)
                        komut.Parameters.AddWithValue("@ÖGZ10", false);
                    else
                        komut.Parameters.AddWithValue("@ÖGZ10", true);

                    if (BTNZilDurum29.BackColor == Color.Red)
                        komut.Parameters.AddWithValue("@ÖMGZ10", false);
                    else
                        komut.Parameters.AddWithValue("@ÖMGZ10", true);

                    if (BTNZilDurum30.BackColor == Color.Red)
                        komut.Parameters.AddWithValue("@DBZ10", false);
                    else
                        komut.Parameters.AddWithValue("@DBZ10", true);




                    komut.ExecuteNonQuery();

                    string Seskayit = "insert into ZilSesi (tarih, ZS1,ZS2,ZS3,ZS4,ZS5,ZS6,ZS7,ZS8,ZS9,ZS10,ZS11,ZS12,ZS13,ZS14,ZS15,ZS16,ZS17,ZS18,ZS19,ZS20,ZS21,ZS22,ZS23,ZS24,ZS25,ZS26,ZS27,ZS28,ZS29,ZS30) values (@tarih,@ZS1,@ZS2,@ZS3,@ZS4,@ZS5,@ZS6,@ZS7,@ZS8,@ZS9,@ZS10,@ZS11,@ZS12,@ZS13,@ZS14,@ZS15,@ZS16,@ZS17,@ZS18,@ZS19,@ZS20,@ZS21,@ZS22,@ZS23,@ZS24,@ZS25,@ZS26,@ZS27,@ZS28,@ZS29,@ZS30 )";
                    SqlCommand Seskomut = new SqlCommand(Seskayit, baglantı);

                    Seskomut.Parameters.AddWithValue("@tarih", SeçiliTarih);

                    Seskomut.Parameters.AddWithValue("ZS1", Sesler[0]);
                    Seskomut.Parameters.AddWithValue("ZS2", Sesler[1]);
                    Seskomut.Parameters.AddWithValue("ZS3", Sesler[2]);
                    Seskomut.Parameters.AddWithValue("ZS4", Sesler[3]);
                    Seskomut.Parameters.AddWithValue("ZS5", Sesler[4]);
                    Seskomut.Parameters.AddWithValue("ZS6", Sesler[5]);
                    Seskomut.Parameters.AddWithValue("ZS7", Sesler[6]);
                    Seskomut.Parameters.AddWithValue("ZS8", Sesler[7]);
                    Seskomut.Parameters.AddWithValue("ZS9", Sesler[8]);
                    Seskomut.Parameters.AddWithValue("ZS10", Sesler[9]);
                    Seskomut.Parameters.AddWithValue("ZS11", Sesler[10]);
                    Seskomut.Parameters.AddWithValue("ZS12", Sesler[11]);
                    Seskomut.Parameters.AddWithValue("ZS13", Sesler[12]);
                    Seskomut.Parameters.AddWithValue("ZS14", Sesler[13]);
                    Seskomut.Parameters.AddWithValue("ZS15", Sesler[14]);
                    Seskomut.Parameters.AddWithValue("ZS16", Sesler[15]);
                    Seskomut.Parameters.AddWithValue("ZS17", Sesler[16]);
                    Seskomut.Parameters.AddWithValue("ZS18", Sesler[17]);
                    Seskomut.Parameters.AddWithValue("ZS19", Sesler[18]);
                    Seskomut.Parameters.AddWithValue("ZS20", Sesler[19]);
                    Seskomut.Parameters.AddWithValue("ZS21", Sesler[20]);
                    Seskomut.Parameters.AddWithValue("ZS22", Sesler[21]);
                    Seskomut.Parameters.AddWithValue("ZS23", Sesler[22]);
                    Seskomut.Parameters.AddWithValue("ZS24", Sesler[23]);
                    Seskomut.Parameters.AddWithValue("ZS25", Sesler[24]);
                    Seskomut.Parameters.AddWithValue("ZS26", Sesler[25]);
                    Seskomut.Parameters.AddWithValue("ZS27", Sesler[26]);
                    Seskomut.Parameters.AddWithValue("ZS28", Sesler[27]);
                    Seskomut.Parameters.AddWithValue("ZS29", Sesler[28]);
                    Seskomut.Parameters.AddWithValue("ZS30", Sesler[29]);
                    Seskomut.ExecuteNonQuery();

                    baglantı.Close();
                    MessageBox.Show("Kayıt işlemi başarılı", "Kayıt Başarılı");
                }
            }

            ZilİsimleriniLabeleYükle(DateTime.Now.Year.ToString() + '-' + DateTime.Now.Month.ToString() + '-' + DateTime.Now.Day.ToString());
        }

        private void button21_Click(object sender, EventArgs e)
        {

        }

        private void BTNkaydetme_Click(object sender, EventArgs e)
        {
            string[] parcalar = monthCalendar1.SelectionStart.ToString().Split('.', ':', ' ');

            string SeçiliTarih = parcalar[2] + '-' + parcalar[1] + '-' + parcalar[0];

            Tarih_Kontrolü(SeçiliTarih);

        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            string[] parcalar = monthCalendar1.SelectionStart.ToString().Split('.', ':', ' ');

            string SeçiliTarih = parcalar[2] + '-' + parcalar[1] + '-' + parcalar[0];

            Tarih_Kontrolü(SeçiliTarih);

        }
        bool varsayılan_Ses_ilk_girdi_değeri = false;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (varsayılan_Ses_ilk_girdi_değeri != false)
            {
                DialogResult result1 = MessageBox.Show("Varsayılan sesi kaydetmeye eminmisiniz!",
                                                    "Verileri Kaydet", MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    baglantı.Open();

                    string kayit = "update VarsayılanZilSesi set Varsayılan_Zil_Sesi=@Yeni_Ses where Varsayılan_Zil_Sesi=@tarih";
                    SqlCommand komut = new SqlCommand(kayit, baglantı);

                    komut.Parameters.AddWithValue("@tarih", VarsayılanSes);
                    komut.Parameters.AddWithValue("@Yeni_Ses", comboBox1.SelectedItem);

                    komut.ExecuteNonQuery();

                    baglantı.Close();

                    VarsayılanSes = comboBox1.SelectedItem.ToString();
                }
            }
            varsayılan_Ses_ilk_girdi_değeri = true;
        }




        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SeçiliLabel != -1)
            {
                if (comboBox2.SelectedIndex != -1)
                {
                    Sesler[SeçiliLabel] = comboBox2.SelectedItem.ToString();
                }
            }

        }

        private void labelÇizgisiniKaldır()
        {
            l1.BorderStyle = BorderStyle.None;
            l2.BorderStyle = BorderStyle.None;
            l3.BorderStyle = BorderStyle.None;
            l4.BorderStyle = BorderStyle.None;
            l5.BorderStyle = BorderStyle.None;
            l6.BorderStyle = BorderStyle.None;
            l7.BorderStyle = BorderStyle.None;
            l8.BorderStyle = BorderStyle.None;
            l9.BorderStyle = BorderStyle.None;
            l10.BorderStyle = BorderStyle.None;
            l11.BorderStyle = BorderStyle.None;
            l12.BorderStyle = BorderStyle.None;
            l13.BorderStyle = BorderStyle.None;
            l14.BorderStyle = BorderStyle.None;
            l15.BorderStyle = BorderStyle.None;
            l16.BorderStyle = BorderStyle.None;
            l17.BorderStyle = BorderStyle.None;
            l18.BorderStyle = BorderStyle.None;
            l19.BorderStyle = BorderStyle.None;
            l20.BorderStyle = BorderStyle.None;
            l21.BorderStyle = BorderStyle.None;
            l22.BorderStyle = BorderStyle.None;
            l23.BorderStyle = BorderStyle.None;
            l24.BorderStyle = BorderStyle.None;
            l25.BorderStyle = BorderStyle.None;
            l26.BorderStyle = BorderStyle.None;
            l27.BorderStyle = BorderStyle.None;
            l28.BorderStyle = BorderStyle.None;
            l29.BorderStyle = BorderStyle.None;
            l30.BorderStyle = BorderStyle.None;
        }

        private void l30_Click(object sender, EventArgs e)
        {
            labelÇizgisiniKaldır();
            l30.BorderStyle = BorderStyle.FixedSingle;
            SeçiliLabel = 29;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[29]);

        }

        private void l29_Click(object sender, EventArgs e)
        {
            labelÇizgisiniKaldır();
            l29.BorderStyle = BorderStyle.FixedSingle;
            SeçiliLabel = 28;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[28]);

        }

        private void l28_Click(object sender, EventArgs e)
        {
            labelÇizgisiniKaldır();
            l28.BorderStyle = BorderStyle.FixedSingle;
            SeçiliLabel = 27;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[27]);
        }

        private void l27_Click(object sender, EventArgs e)
        {
            labelÇizgisiniKaldır();
            l27.BorderStyle = BorderStyle.FixedSingle;
            SeçiliLabel = 26;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[26]);

        }

        private void l26_Click(object sender, EventArgs e)
        {
            labelÇizgisiniKaldır();
            l26.BorderStyle = BorderStyle.FixedSingle;
            SeçiliLabel = 25;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[25]);
        }

        private void l25_Click(object sender, EventArgs e)
        {

            labelÇizgisiniKaldır();
            l25.BorderStyle = BorderStyle.FixedSingle;
            SeçiliLabel = 24;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[24]);

        }

        private void l24_Click(object sender, EventArgs e)
        {
            labelÇizgisiniKaldır();
            l24.BorderStyle = BorderStyle.FixedSingle;
            SeçiliLabel = 23;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[23]);

        }

        private void l23_Click(object sender, EventArgs e)
        {
            labelÇizgisiniKaldır();
            l23.BorderStyle = BorderStyle.FixedSingle;
            SeçiliLabel = 22;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[22]);

        }

        private void l22_Click(object sender, EventArgs e)
        {
            labelÇizgisiniKaldır();
            l22.BorderStyle = BorderStyle.FixedSingle;
            SeçiliLabel = 21;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[21]);

        }

        private void l21_Click(object sender, EventArgs e)
        {
            labelÇizgisiniKaldır();
            l21.BorderStyle = BorderStyle.FixedSingle;
            SeçiliLabel = 20;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[20]);

        }

        private void l20_Click(object sender, EventArgs e)
        {

            labelÇizgisiniKaldır();
            l20.BorderStyle = BorderStyle.FixedSingle;
            SeçiliLabel = 19;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[19]);
        }

        private void l19_Click(object sender, EventArgs e)
        {

            labelÇizgisiniKaldır();
            l19.BorderStyle = BorderStyle.FixedSingle;
            SeçiliLabel = 18;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[18]);
        }

        private void l18_Click(object sender, EventArgs e)
        {
            labelÇizgisiniKaldır();
            l18.BorderStyle = BorderStyle.FixedSingle;
            SeçiliLabel = 17;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[17]);
        }

        private void l17_Click(object sender, EventArgs e)
        {
            labelÇizgisiniKaldır();
            l17.BorderStyle = BorderStyle.FixedSingle;
            SeçiliLabel = 16;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[16]);
        }

        private void l16_Click(object sender, EventArgs e)
        {
            labelÇizgisiniKaldır();
            l16.BorderStyle = BorderStyle.FixedSingle;
            SeçiliLabel = 15;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[15]);
        }

        private void l15_Click(object sender, EventArgs e)
        {
            labelÇizgisiniKaldır();
            l15.BorderStyle = BorderStyle.FixedSingle;
            SeçiliLabel = 14;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[14]);
        }

        private void l14_Click(object sender, EventArgs e)
        {
            labelÇizgisiniKaldır();
            l14.BorderStyle = BorderStyle.FixedSingle;
            SeçiliLabel = 13;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[13]);
        }

        private void l13_Click(object sender, EventArgs e)
        {
            labelÇizgisiniKaldır();
            l13.BorderStyle = BorderStyle.FixedSingle;
            SeçiliLabel = 12;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[12]);
        }

        private void l12_Click(object sender, EventArgs e)
        {
            labelÇizgisiniKaldır();
            l12.BorderStyle = BorderStyle.FixedSingle;
            SeçiliLabel = 11;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[11]);
        }

        private void l11_Click(object sender, EventArgs e)
        {
            labelÇizgisiniKaldır();
            l11.BorderStyle = BorderStyle.FixedSingle;
            SeçiliLabel = 10;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[10]);
        }

        private void l10_Click(object sender, EventArgs e)
        {
            labelÇizgisiniKaldır();
            l10.BorderStyle = BorderStyle.FixedSingle;
            SeçiliLabel = 9;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[9]);
        }

        private void l9_Click(object sender, EventArgs e)
        {
            labelÇizgisiniKaldır();
            l9.BorderStyle = BorderStyle.FixedSingle;
            SeçiliLabel = 8;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[8]);
        }

        private void l8_Click(object sender, EventArgs e)
        {
            labelÇizgisiniKaldır();
            l8.BorderStyle = BorderStyle.FixedSingle;
            SeçiliLabel = 7;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[7]);
        }

        private void l7_Click(object sender, EventArgs e)
        {
            labelÇizgisiniKaldır();
            l7.BorderStyle = BorderStyle.FixedSingle;
            SeçiliLabel = 6;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[6]);

        }

        private void l6_Click(object sender, EventArgs e)
        {
            labelÇizgisiniKaldır();
            l6.BorderStyle = BorderStyle.FixedSingle;
            SeçiliLabel = 5;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[5]);

        }

        private void l5_Click(object sender, EventArgs e)
        {

            labelÇizgisiniKaldır();
            l5.BorderStyle = BorderStyle.FixedSingle;
            SeçiliLabel = 4;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[4]);
        }

        private void l4_Click(object sender, EventArgs e)
        {

            labelÇizgisiniKaldır();
            l4.BorderStyle = BorderStyle.FixedSingle;
            SeçiliLabel = 3;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[3]);
        }

        private void l3_Click(object sender, EventArgs e)
        {

            labelÇizgisiniKaldır();
            l3.BorderStyle = BorderStyle.FixedSingle;
            SeçiliLabel = 2;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[2]);
        }

        private void l2_Click(object sender, EventArgs e)
        {
            labelÇizgisiniKaldır();
            l2.BorderStyle = BorderStyle.FixedSingle;
            SeçiliLabel = 1;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[1]);
        }

        private void l1_Click(object sender, EventArgs e)
        {

            labelÇizgisiniKaldır();
            l1.BorderStyle = BorderStyle.FixedSingle;
            SeçiliLabel = 0;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Sesler[0]);
        }

        private void BTNZilDurum30_Click(object sender, EventArgs e)
        {
            if (BTNZilDurum30.BackColor == Color.Red)
                BTNZilDurum30.BackColor = Color.Blue;
            else
                BTNZilDurum30.BackColor = Color.Red;
        }

        private void BTNZilDurum2_Click(object sender, EventArgs e)
        {
            if (BTNZilDurum2.BackColor == Color.Red)
                BTNZilDurum2.BackColor = Color.Blue;
            else
                BTNZilDurum2.BackColor = Color.Red;
        }

        private void BTNZilDurum3_Click(object sender, EventArgs e)
        {
            if (BTNZilDurum3.BackColor == Color.Red)
                BTNZilDurum3.BackColor = Color.Blue;
            else
                BTNZilDurum3.BackColor = Color.Red;
        }

        private void BTNZilDurum4_Click(object sender, EventArgs e)
        {
            if (BTNZilDurum4.BackColor == Color.Red)
                BTNZilDurum4.BackColor = Color.Blue;
            else
                BTNZilDurum4.BackColor = Color.Red;
        }

        private void BTNZilDurum5_Click(object sender, EventArgs e)
        {
            if (BTNZilDurum5.BackColor == Color.Red)
                BTNZilDurum5.BackColor = Color.Blue;
            else
                BTNZilDurum5.BackColor = Color.Red;
        }

        private void BTNZilDurum6_Click(object sender, EventArgs e)
        {
            if (BTNZilDurum6.BackColor == Color.Red)
                BTNZilDurum6.BackColor = Color.Blue;
            else
                BTNZilDurum6.BackColor = Color.Red;
        }

        private void BTNZilDurum7_Click(object sender, EventArgs e)
        {
            if (BTNZilDurum7.BackColor == Color.Red)
                BTNZilDurum7.BackColor = Color.Blue;
            else
                BTNZilDurum7.BackColor = Color.Red;
        }

        private void BTNZilDurum8_Click(object sender, EventArgs e)
        {
            if (BTNZilDurum8.BackColor == Color.Red)
                BTNZilDurum8.BackColor = Color.Blue;
            else
                BTNZilDurum8.BackColor = Color.Red;
        }

        private void BTNZilDurum9_Click(object sender, EventArgs e)
        {
            if (BTNZilDurum9.BackColor == Color.Red)
                BTNZilDurum9.BackColor = Color.Blue;
            else
                BTNZilDurum9.BackColor = Color.Red;
        }

        private void BTNZilDurum10_Click(object sender, EventArgs e)
        {
            if (BTNZilDurum10.BackColor == Color.Red)
                BTNZilDurum10.BackColor = Color.Blue;
            else
                BTNZilDurum10.BackColor = Color.Red;
        }

        private void BTNZilDurum11_Click(object sender, EventArgs e)
        {
            if (BTNZilDurum11.BackColor == Color.Red)
                BTNZilDurum11.BackColor = Color.Blue;
            else
                BTNZilDurum11.BackColor = Color.Red;
        }

        private void BTNZilDurum12_Click(object sender, EventArgs e)
        {
            if (BTNZilDurum12.BackColor == Color.Red)
                BTNZilDurum12.BackColor = Color.Blue;
            else
                BTNZilDurum12.BackColor = Color.Red;
        }

        private void BTNZilDurum13_Click(object sender, EventArgs e)
        {
            if (BTNZilDurum13.BackColor == Color.Red)
                BTNZilDurum13.BackColor = Color.Blue;
            else
                BTNZilDurum13.BackColor = Color.Red;
        }

        private void BTNZilDurum14_Click(object sender, EventArgs e)
        {
            if (BTNZilDurum14.BackColor == Color.Red)
                BTNZilDurum14.BackColor = Color.Blue;
            else
                BTNZilDurum14.BackColor = Color.Red;
        }

        private void BTNZilDurum15_Click(object sender, EventArgs e)
        {
            if (BTNZilDurum15.BackColor == Color.Red)
                BTNZilDurum15.BackColor = Color.Blue;
            else
                BTNZilDurum15.BackColor = Color.Red;
        }

        private void BTNZilDurum16_Click(object sender, EventArgs e)
        {
            if (BTNZilDurum16.BackColor == Color.Red)
                BTNZilDurum16.BackColor = Color.Blue;
            else
                BTNZilDurum16.BackColor = Color.Red;
        }

        private void BTNZilDurum17_Click(object sender, EventArgs e)
        {
            if (BTNZilDurum17.BackColor == Color.Red)
                BTNZilDurum17.BackColor = Color.Blue;
            else
                BTNZilDurum17.BackColor = Color.Red;
        }

        private void BTNZilDurum18_Click(object sender, EventArgs e)
        {
            if (BTNZilDurum18.BackColor == Color.Red)
                BTNZilDurum18.BackColor = Color.Blue;
            else
                BTNZilDurum18.BackColor = Color.Red;
        }

        private void BTNZilDurum19_Click(object sender, EventArgs e)
        {
            if (BTNZilDurum19.BackColor == Color.Red)
                BTNZilDurum19.BackColor = Color.Blue;
            else
                BTNZilDurum19.BackColor = Color.Red;
        }

        private void BTNZilDurum20_Click(object sender, EventArgs e)
        {
            if (BTNZilDurum20.BackColor == Color.Red)
                BTNZilDurum20.BackColor = Color.Blue;
            else
                BTNZilDurum20.BackColor = Color.Red;
        }

        private void BTNZilDurum21_Click(object sender, EventArgs e)
        {
            if (BTNZilDurum21.BackColor == Color.Red)
                BTNZilDurum21.BackColor = Color.Blue;
            else
                BTNZilDurum21.BackColor = Color.Red;
        }

        private void BTNZilDurum22_Click(object sender, EventArgs e)
        {
            if (BTNZilDurum22.BackColor == Color.Red)
                BTNZilDurum22.BackColor = Color.Blue;
            else
                BTNZilDurum22.BackColor = Color.Red;
        }

        private void BTNZilDurum23_Click(object sender, EventArgs e)
        {
            if (BTNZilDurum23.BackColor == Color.Red)
                BTNZilDurum23.BackColor = Color.Blue;
            else
                BTNZilDurum23.BackColor = Color.Red;
        }

        private void BTNZilDurum24_Click(object sender, EventArgs e)
        {
            if (BTNZilDurum24.BackColor == Color.Red)
                BTNZilDurum24.BackColor = Color.Blue;
            else
                BTNZilDurum24.BackColor = Color.Red;
        }

        private void BTNZilDurum25_Click(object sender, EventArgs e)
        {
            if (BTNZilDurum25.BackColor == Color.Red)
                BTNZilDurum25.BackColor = Color.Blue;
            else
                BTNZilDurum25.BackColor = Color.Red;
        }

        private void BTNZilDurum26_Click(object sender, EventArgs e)
        {
            if (BTNZilDurum26.BackColor == Color.Red)
                BTNZilDurum26.BackColor = Color.Blue;
            else
                BTNZilDurum26.BackColor = Color.Red;
        }

        private void BTNZilDurum27_Click(object sender, EventArgs e)
        {
            if (BTNZilDurum27.BackColor == Color.Red)
                BTNZilDurum27.BackColor = Color.Blue;
            else
                BTNZilDurum27.BackColor = Color.Red;
        }

        private void BTNZilDurum29_Click(object sender, EventArgs e)
        {
            if (BTNZilDurum29.BackColor == Color.Red)
                BTNZilDurum29.BackColor = Color.Blue;
            else
                BTNZilDurum29.BackColor = Color.Red;
        }

        private void BTNZilDurum1_Click(object sender, EventArgs e)
        {
            if (BTNZilDurum1.BackColor == Color.Red)
                BTNZilDurum1.BackColor = Color.Blue;
            else
                BTNZilDurum1.BackColor = Color.Red;
        }

        private void BTNZilDurum28_Click(object sender, EventArgs e)
        {
            if (BTNZilDurum28.BackColor == Color.Red)
                BTNZilDurum28.BackColor = Color.Blue;
            else
                BTNZilDurum28.BackColor = Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (CBdakika.SelectedIndex != -1 && CBSaat.SelectedIndex != -1 && CBZilSeç.SelectedIndex != -1)
            {

                baglantı.Open();

                string kayit = "update ZilÇalmaZamanı set " + "ZS" + Convert.ToString(CBZilSeç.SelectedIndex + 1) + "=@saati";
                SqlCommand komut = new SqlCommand(kayit, baglantı);

                komut.Parameters.AddWithValue("@saati", CBSaat.SelectedItem.ToString() + " " + CBdakika.SelectedItem.ToString());

                komut.ExecuteNonQuery();
                baglantı.Close();

                CBZilSeç.SelectedIndex = -1;
                CBSaat.SelectedIndex = -1;
                CBdakika.SelectedIndex = -1;


                ZilİsimleriniLabeleYükle(DateTime.Now.Year.ToString() + '-' + DateTime.Now.Month.ToString() + '-' + DateTime.Now.Day.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 30; i++)
            {
                string[] parcalar = ZilÇalmaZamanları[i].Split(' ');
                if (DateTime.Now.Hour.ToString() == parcalar[0] && DateTime.Now.Minute.ToString() == parcalar[1])
                {
                    if (BuGününZilDurumu[i] == true)
                    {
                        if (BuGününSesler[i] == null || BuGününSesler[i] == " ")
                        {
                            axWindowsMediaPlayer1.URL = @"Sesler\" + VarsayılanSes;
                        }
                        else
                        {
                            axWindowsMediaPlayer1.URL = @"Sesler\" + BuGününSesler[i];
                        }
                        timer2.Start();
                        timer1.Stop();
                    }
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = null;

            timer1.Start();
            timer2.Stop();

        }
    }
}
// BTNkaydet.PerformClick();    tıklanmış gibi yapıyor