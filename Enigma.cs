using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatZastita18039
{
    public class Enigma
    {
        private Enigma prethodni;
        private Enigma sledeci;
        private string rasporedSlova;
        private byte pomeraj;
        private System.Windows.Forms.Label labela;
        private char prvoSlovo;
        private char ulazni='\0';
        private int duzina=26;
        private int A= 65;
        

        public Enigma(string tekst,char pocetak)
        {
            rasporedSlova = tekst;
            prvoSlovo = pocetak;
            pomeraj = 0;
        }
   
        public void Rotiraj(char k)
        {
            char k1 = k;
            k1 = (char)((k1 - this.A + pomeraj) % this.duzina + this.A);
            this.ulazni = k;

            if (this.sledeci != null)
            {
                k1 = rasporedSlova.Substring((k1 - this.A), 1).ToCharArray()[0];

                if (((k1 - this.A - pomeraj) % this.duzina + this.A) < this.A)
                {
                    k1 = (char)((k1 - this.A + this.duzina - pomeraj) % this.duzina + this.A);
                }
                else
                {
                    k1 = (char)((k1 - this.A - pomeraj) % this.duzina + this.A);
                }
                this.sledeci.Rotiraj(k1);
            }
            

        }
        public char Izlaz()
        {
            char k = '\0';
            if (this.sledeci == null)
            {
                k = this.rasporedSlova.Substring((this.ulazni - this.A), 1).ToCharArray()[0];
                k = (char)((k - this.A + this.prethodni.pomeraj) % this.duzina + this.A);
            }
            else
            {
                k = this.sledeci.Izlaz();
                string k1 = "" + k;
                int pozicija = rasporedSlova.IndexOf(k1);
                if (this.pomeraj <= pozicija)
                {
                    pozicija = pozicija - this.pomeraj;
                }
                else
                {
                    pozicija = this.duzina - (pomeraj - pozicija);
                }
                if (this.prethodni != null)
                {
                    pozicija = (pozicija + this.prethodni.pomeraj) % this.duzina;
                }
                k = (char)(this.A + pozicija);


            }
            return k;

        }
        public void PostaviSledeciRotor(Enigma sledeci)
        {
            this.sledeci = sledeci;
        }
        public void PostaviPrethodniRotor(Enigma prethodni)
        {
            this.prethodni = prethodni;
        }
        public bool PostojiPrethodni()
        {
            if (prethodni == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public bool PostojiSledeci()
        {
            if (sledeci == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

     
    }
}
