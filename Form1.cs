using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatZastita18039
{
    public partial class Form1 : Form
    {
        

        private Enigma desni, srednji, levi, refl;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //DefaultnaPodesavanja();
        }



        private void btnFajl_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                byte[] bajtovi = File.ReadAllBytes(openFileDialog2.FileName);
               
                richTextBoxFajl.Text = Encoding.UTF8.GetString(bajtovi);

            }
        }

 

            private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cBAlogoritmi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cBAlogoritmi.SelectedItem.ToString()=="ENIGMA")
            {
            
                gBkey.Visible = false;
                GBCBC.Visible = false;
                gBSlike.Visible = false;
                DefaultnaPodesavanja();


            }
            else
            {
               
                gBkey.Visible = true;
                GBCBC.Visible = false;
                gBSlike.Visible = false;


            }
            if (cBAlogoritmi.SelectedItem.ToString()=="TEA CBC")
            {
                GBCBC.Visible = true;
                gBSlike.Visible = false;




            }
            if (cBAlogoritmi.SelectedItem.ToString() == "RC4 BMP")
            {
                gBSlike.Visible = true;
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (cBAlogoritmi.SelectedItem.ToString() == "RC4")
            {
                byte[] bajtovi = File.ReadAllBytes(openFileDialog2.FileName);
                RC44 rc4 = new RC44(Encoding.UTF8.GetBytes(richTextBoxKey.Text));
                rc4.AlgoritamZaKljuc();
                rc4.PRGA(bajtovi);
                byte[] enkripcija = rc4.Encript();
                richTextBoxEncrypt.Text = Encoding.UTF8.GetString(enkripcija);
                FileInfo fi = new FileInfo(openFileDialog2.FileName);
                string ekstenzija = fi.Extension;
                File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\enkriptovano" +ekstenzija,enkripcija);
            }
            else if (cBAlogoritmi.SelectedItem.ToString() == "TEA CBC")
            {
                byte[] bajtovi = File.ReadAllBytes(openFileDialog2.FileName);
                richTextBoxFajl.Text = Encoding.UTF8.GetString(bajtovi);
                TEA caj = new TEA();
                byte[] vektor = Encoding.UTF8.GetBytes(rTBVektor.Text);
                if (vektor.Length < 8)
                {
                    byte[] newIv = new byte[8];
                    Array.Copy(vektor, newIv, vektor.Length);
                    for (int i = vektor.Length; i < 8; i++)
                    {
                        newIv[i] = 0;
                    }
                    vektor = newIv;
                }
                else if (vektor.Length > 8)
                {
                    byte[] newIv = new byte[8];
                    Array.Copy(vektor, newIv, 8);
                    vektor = newIv;
                }
                FileInfo fi = new FileInfo(openFileDialog2.FileName);
                string ekstenzija = fi.Extension;
                byte[] enkriptovano = caj.EncryptByteCBC(bajtovi, richTextBoxKey.Text, vektor, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\enkriptovano" + ekstenzija);
                richTextBoxEncrypt.Text = Encoding.UTF8.GetString(enkriptovano);

            }
            else if(cBAlogoritmi.SelectedItem.ToString()=="ENIGMA")
            {
                byte[] bajtovi = File.ReadAllBytes(openFileDialog2.FileName);
                richTextBoxFajl.Text = Encoding.UTF8.GetString(bajtovi);
                char[] ulaz = richTextBoxFajl.Text.ToUpper().ToCharArray();
                richTextBoxEncrypt.Text = "";
                for (int i = 0; i < ulaz.Length; i++)
                {
                    if (ulaz[i] >= 65 && ulaz[i] <= 90)
                    {
                        desni.Rotiraj(ulaz[i]);
                        richTextBoxEncrypt.AppendText("" + desni.Izlaz());

                    }
                }
                byte[] enkriptovano = Encoding.UTF8.GetBytes(richTextBoxEncrypt.Text);
                FileInfo fi = new FileInfo(openFileDialog2.FileName);
                string ekstenzija = fi.Extension;
                File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\enkriptovano" + ekstenzija, enkriptovano);

            }
            else if (cBAlogoritmi.SelectedItem.ToString() == "RC4 BMP")
            {
             

                byte[] a = File.ReadAllBytes(openFileDialog2.FileName);
                FileStream b = File.OpenWrite(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\enkriptovano" + DateTime.Now.Ticks + ".bmp");

                int pos = a[10] + 256 * (a[11] + 256 * (a[12] + 256 *a[13]));
                byte[] hederGlupi = a.Take(pos).ToArray();
                byte[] zapravoSlika = a.Skip(pos).ToArray();
                RC44 rc4 = new RC44(Encoding.UTF8.GetBytes(richTextBoxKey.Text));
                rc4.AlgoritamZaKljuc();
                rc4.PRGA(zapravoSlika);
                byte[] enkripcija = rc4.Encript();
                b.Write(hederGlupi, 0, hederGlupi.Count());
                b.Write(enkripcija, 0, enkripcija.Count());
             
                b.Close();


                pB1.Image = Image.FromFile(openFileDialog2.FileName);
                pB2.Image= Image.FromFile(b.Name);



            }
            else if (cBAlogoritmi.SelectedItem.ToString() == "TEA")
            {
                byte[] bajtovi = File.ReadAllBytes(openFileDialog2.FileName);
                richTextBoxFajl.Text = Encoding.UTF8.GetString(bajtovi);
                FileInfo fi = new FileInfo(openFileDialog2.FileName);
                string ekstenzija = fi.Extension;
                TEA caj = new TEA();
                byte[] enkriptovanoo=caj.EncryptFile(bajtovi, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\enkriptovano" + ekstenzija, richTextBoxKey.Text);
                richTextBoxEncrypt.Text = Encoding.UTF8.GetString(enkriptovanoo);

            }

            else if (cBAlogoritmi.SelectedItem.ToString() == "TEA CRC")
            {
                byte[] bajtovi = File.ReadAllBytes(openFileDialog2.FileName);
                richTextBoxFajl.Text = Encoding.UTF8.GetString(bajtovi);
                uint polinomKonst = 0xedb88320;
                uint krajna = 0xffffffff;
                uint pocetna= 0xffffffff;
                FileInfo fi = new FileInfo(openFileDialog2.FileName);
                string ekstenzija = fi.Extension;
                TEA caj = new TEA();
                byte[] enkriptovanoo = caj.EncryptFile(bajtovi, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\enkriptovano" + ekstenzija, richTextBoxKey.Text);
                uint hesh = CRC32Algortihm(bajtovi, pocetna, polinomKonst, krajna);
                richTextBoxEncrypt.Text = hesh.ToString();

            }


        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {

            if (cBAlogoritmi.SelectedItem.ToString() == "RC4")
            {
                    byte[] bajtovi = File.ReadAllBytes(openFileDialog2.FileName);
                    RC44 rc4 = new RC44(Encoding.UTF8.GetBytes(richTextBoxKey.Text));
                    rc4.AlgoritamZaKljuc();
                    rc4.PRGA(bajtovi);
                    byte[] dekripcija = rc4.Decryption(bajtovi);
                    richTextBoxDecrypt.Text = Encoding.UTF8.GetString(dekripcija);
                    FileInfo fi = new FileInfo(openFileDialog2.FileName);
                    string ekstenzija = fi.Extension;
                    File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\dekriptovano" + ekstenzija, dekripcija);
            }
     
            else if (cBAlogoritmi.SelectedItem.ToString() == "ENIGMA")
            {
                byte[] bajtovi = File.ReadAllBytes(openFileDialog2.FileName);
                richTextBoxFajl.Text = Encoding.UTF8.GetString(bajtovi);

                char[] chIn = richTextBoxFajl.Text.ToUpper().ToCharArray();
                richTextBoxDecrypt.Text = "";
                for (int i = 0; i < chIn.Length; i++)
                {
                    if (chIn[i] >= 65 && chIn[i] <= 90)
                    {
                        desni.Rotiraj(chIn[i]);
                        richTextBoxDecrypt.AppendText("" + desni.Izlaz());

                    }
                }
                byte[] dekriptovano = Encoding.UTF8.GetBytes(richTextBoxDecrypt.Text);
                FileInfo fi = new FileInfo(openFileDialog2.FileName);
                string ekstenzija = fi.Extension;
                File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\dekriptovano" + ekstenzija, dekriptovano);


            }
            else if(cBAlogoritmi.SelectedItem.ToString()== "TEA CBC")
            {
                byte[] bajtovi = File.ReadAllBytes(openFileDialog2.FileName);
                richTextBoxFajl.Text = Encoding.UTF8.GetString(bajtovi);
                byte[] vektor = Encoding.UTF8.GetBytes(rTBVektor.Text);
                if (vektor.Length < 8)
                {
                    byte[] newIv = new byte[8];
                    Array.Copy(vektor, newIv, vektor.Length);
                    for (int i = vektor.Length; i < 8; i++)
                    {
                        newIv[i] = 0;
                    }
                    vektor = newIv;
                }
                else if (vektor.Length > 8)
                {
                    byte[] newIv = new byte[8];
                    Array.Copy(vektor, newIv, 8);
                    vektor = newIv;
                }
                TEA caj = new TEA();
                FileInfo fi = new FileInfo(openFileDialog2.FileName);
                string ekstenzija = fi.Extension;
                byte[] dekriptovano = caj.DecryptByteCBC(openFileDialog2.FileName, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\dekriptovano" + ekstenzija, richTextBoxKey.Text, vektor);
                richTextBoxDecrypt.Text = Encoding.UTF8.GetString(dekriptovano);
                
               


            }
            // }
            else if (cBAlogoritmi.SelectedItem.ToString() == "RC4 BMP")
            {

                byte[] a = File.ReadAllBytes(openFileDialog2.FileName);

                //fsr.Read(a, 0, Convert.ToInt32(fsr.Length));
                FileStream b = File.OpenWrite(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\dekriptovano" + DateTime.Now.Ticks + ".bmp");

                int pos = a[10] + 256 * (a[11] + 256 * (a[12] + 256 * a[13]));
                byte[] hederGlupi = a.Take(pos).ToArray();
                byte[] zapravoSlika = a.Skip(pos).ToArray();
                RC44 rc4 = new RC44(Encoding.UTF8.GetBytes(richTextBoxKey.Text));
                rc4.AlgoritamZaKljuc();
                rc4.PRGA(zapravoSlika);
                byte[] enkripcija = rc4.Decryption(zapravoSlika);
                b.Write(hederGlupi, 0, hederGlupi.Count());
                b.Write(enkripcija, 0, enkripcija.Count());

                b.Close();

                pB1.Image = Image.FromFile(openFileDialog2.FileName);
                pB2.Image = Image.FromFile(b.Name);

            }

            else if (cBAlogoritmi.SelectedItem.ToString() == "TEA")
            {
                byte[] bajtovi = File.ReadAllBytes(openFileDialog2.FileName);
                richTextBoxFajl.Text = Encoding.UTF8.GetString(bajtovi);
                FileInfo fi = new FileInfo(openFileDialog2.FileName);
                string ekstenzija = fi.Extension;
                TEA caj = new TEA();
               byte[] dek= caj.DecryptFile(openFileDialog2.FileName, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\dekriptovano" + ekstenzija, richTextBoxKey.Text);
                richTextBoxDecrypt.Text = Encoding.UTF8.GetString(dek);
            }
            else if (cBAlogoritmi.SelectedItem.ToString() == "TEA CRC")
            {
                byte[] bajtovi = File.ReadAllBytes(openFileDialog2.FileName);
                richTextBoxFajl.Text = Encoding.UTF8.GetString(bajtovi);
                uint polinomKonst = 0xedb88320;
                uint krajna = 0xffffffff;
                uint pocetna = 0xffffffff;
                TEA caj = new TEA();
                FileInfo fi = new FileInfo(openFileDialog2.FileName);
                string ekstenzija = fi.Extension;
                byte[] dek = caj.DecryptFile(openFileDialog2.FileName, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\dekriptovano" + ekstenzija, richTextBoxKey.Text);
                ;
                uint hesh = CRC32Algortihm(dek, pocetna, polinomKonst, krajna);
                richTextBoxDecrypt.Text = hesh.ToString();

            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void DefaultnaPodesavanja()
        {
            levi = new Enigma( "BDFHJLCPRTXVZNYEIWGAKMUSQO",  'R');
            srednji = new Enigma("AJDKSIRUXBLHWTMCQGZNPYFVOE",  'T');
            desni = new Enigma( "EKMFLGDQVZNTOWYHXUSPAIBRCJ",  'O');
            refl = new Enigma("YRUHQSLDPXNGOKMIEBFZCWVJAT",  '\0');
            levi.PostaviSledeciRotor(srednji);
            srednji.PostaviPrethodniRotor(levi);

            srednji.PostaviSledeciRotor(desni);
            desni.PostaviPrethodniRotor(srednji);

            desni.PostaviSledeciRotor(refl);
            refl.PostaviPrethodniRotor(desni);
        }

        private uint CRC32Algortihm(byte[] bajtovi,uint pocetna,uint polinomKonst,uint kraj)
        {
            uint crc32 = pocetna;
            int i = 0;
            while(i<bajtovi.Length)
            {
                crc32 = crc32 ^ bajtovi[i];
                int j = 0;
                while(j<8)
                {
                    if((crc32&1)!=1)
                    {
                        crc32 = crc32 >> 1;
                    }
                    else
                    {
                        crc32 = (crc32 >> 1) ^ polinomKonst;
                    }
                    j++;
                }
                i++;

            }
            uint k= crc32 ^ kraj;
            return k;



        }
    }
}
