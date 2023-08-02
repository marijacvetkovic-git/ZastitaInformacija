using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatZastita18039
{
    public class RC44
    {

        public byte[] s = new byte[256];
        public string enkriptovano;
        public string dekriptovano;
        public byte[] kljuc;
        public byte[] kNiz;
        public byte[] cNiz;
        public byte[] tekst;
        public byte[] tekstPov;

        public RC44(byte[] kljucc)
        {
            kljuc = kljucc;
            int i = 0;
            while (i <= 255)
            {
                s[i] = (byte)i;
                i++;
            }
        }

        public void AlgoritamZaKljuc()
        {
            int j = 0;
            for (int i = 0; i <= 255; i++)
            {
                j = (j + s[i] + kljuc[i % kljuc.Length]) % 256;
                byte help;
                help = s[i];
                s[i] = s[j];
                s[j] = help;

            }

        }
        public void PRGA(byte[] filetext)
        {
            int i = 0;
            int j = 0;
            tekst = filetext;
            kNiz = new byte[tekst.Length];

            for (int p = 0; p < tekst.Length; p++)
            {
                i = (i + 1) % 256;
                j = (j + s[i]) % 256;

                byte help;
                help = s[i];
                s[i] = s[j];
                s[j] = help;
                byte K = s[(s[i] + s[j]) % 256];
                kNiz[p] = K;
            }

        }
        public byte[] Encript()
        {
            cNiz = new byte[kNiz.Length];

            for (int p = 0; p < kNiz.Length; p++)
            {
                cNiz[p] = (byte)(tekst[p] ^ kNiz[p]);

            }
            enkriptovano = Encoding.Unicode.GetString(cNiz);
            return cNiz;
        }

        public byte[] Decryption(byte[] cNizz)
        {
            tekstPov = new byte[kNiz.Length];
            for (int p = 0; p < kNiz.Length; p++)
            {
                tekstPov[p] = (byte)(cNizz[p] ^ kNiz[p]);

            }
            dekriptovano = Encoding.Unicode.GetString(tekstPov);
            return tekstPov;

        }







    }
}
