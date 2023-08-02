using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatZastita18039
{
    public class TEA
    {
        public TEA()
        { }


        public uint delta = 0x9e3779b9;



        public void Encrpit(ref uint vv0, ref uint vv1, uint[] k)
        {
            uint v0 = vv0;
            uint v1 = vv1;
            uint sum = 0;
            uint k0 = k[0], k1 = k[1], k2 = k[2], k3 = k[3];
            for (uint i = 0; i < 32; i++)
            {
                sum += delta;
                v0 += ((v1 << 4) + k0) ^ (v1 + sum) ^ ((v1 >> 5) + k1);
                v1 += ((v0 << 4) + k2) ^ (v0 + sum) ^ ((v0 >> 5) + k3);
            }
            vv0 = v0;
            vv1 = v1;

        }
        public void Decrypt(ref uint vv0, ref uint vv1, uint[] k)
        {
            uint v0 = vv0;
            uint v1 = vv1;
            uint sum = 0xC6EF3720;
            uint k0 = k[0], k1 = k[1], k2 = k[2], k3 = k[3];
            for (uint i = 0; i < 32; i++)
            {
                v1 -= ((v0 << 4) + k2) ^ (v0 + sum) ^ ((v0 >> 5) + k3);
                v0 -= ((v1 << 4) + k0) ^ (v1 + sum) ^ ((v1 >> 5) + k1);
                sum -= delta;

            }
            vv0 = v0;
            vv1 = v1;

        }

        public uint[] KreirajKljuc(string kljuc)
        {
            if (kljuc.Length == 0)
                throw new ArgumentException("Kljuc mora biti duzine od 1 do 16 karaktera");

            kljuc = kljuc.PadRight(16, ' ').Substring(0, 16);
            uint[] kreirajKljuc = new uint[4];
            byte[] kljucByte = Encoding.UTF8.GetBytes(kljuc);
            int j = 0;
            int i = 0;
            while (i < kljuc.Length)
            {
                kreirajKljuc[j++] = BitConverter.ToUInt32(kljucByte, i);
                i += 4;
            }
            return kreirajKljuc;
        }

        //probica

        public byte[] EncryptFile(byte[] data, string outFile, string k)
        {
            uint[] key = KreirajKljuc(k);
            int originalLength = data.Length;

            if (data.Length % 8 != 0)
            {
                Array.Resize(ref data, data.Length + (8 - data.Length % 8));
            }

            uint[] words = new uint[data.Length / 4];
            Buffer.BlockCopy(data, 0, words, 0, data.Length);

            for (int i = 0; i < words.Length; i += 2)
            {
                Encrpit(ref words[i], ref words[i + 1], key);

            }

            byte[] encryptedData = new byte[words.Length * 4];
            Buffer.BlockCopy(words, 0, encryptedData, 0, encryptedData.Length);
            using (BinaryWriter writer = new BinaryWriter(File.Open(outFile, FileMode.Create)))
            {
                writer.Write(originalLength);
                writer.Write(encryptedData);
            }


            return encryptedData;
        }

        public byte[] DecryptFile(string inFile, string outFile, string k)
        {
            uint[] key = KreirajKljuc(k);
            using (BinaryReader reader = new BinaryReader(File.Open(inFile, FileMode.Open)))
            {
                int originalLength = reader.ReadInt32();
                byte[] data = reader.ReadBytes((int)reader.BaseStream.Length - 4);

                uint[] words = new uint[data.Length / 4];
                Buffer.BlockCopy(data, 0, words, 0, data.Length);

                for (int i = 0; i < words.Length; i += 2)
                {
                    Decrypt(ref words[i], ref words[i + 1], key);
                }

                byte[] decryptedData = new byte[words.Length * 4];
                Buffer.BlockCopy(words, 0, decryptedData, 0, decryptedData.Length);

                byte[] finalData = new byte[originalLength];
                Array.Copy(decryptedData, finalData, originalLength);
                File.WriteAllBytes(outFile, finalData);
                return finalData;
            }
        }


        public byte[] EncryptByteCBC(byte[] data, string k, byte[] iv, string outFile)
        {
            uint[] key = KreirajKljuc(k);
            int originalLength = data.Length;

            if (data.Length % 8 != 0)
            {
                Array.Resize(ref data, data.Length + (8 - data.Length % 8));
            }

            uint[] words = new uint[data.Length / 4];
            Buffer.BlockCopy(data, 0, words, 0, data.Length);
            uint iv0 = BitConverter.ToUInt32(iv, 0);
            uint iv1 = BitConverter.ToUInt32(iv, 4);

            for (int i = 0; i < words.Length; i += 2)
            {
                words[i] = words[i] ^ iv0;
                words[i + 1] = words[i + 1] ^ iv1;
                Encrpit(ref words[i], ref words[i + 1], key);
                iv0 = words[i];
                iv1 = words[i + 1];

            }

            byte[] encryptedData = new byte[words.Length * 4];
            Buffer.BlockCopy(words, 0, encryptedData, 0, encryptedData.Length);
            using (BinaryWriter writer = new BinaryWriter(File.Open(outFile, FileMode.Create)))
            {
                writer.Write(originalLength);
                writer.Write(encryptedData);
            }


            return encryptedData;
        }

        public byte[] DecryptByteCBC(string inFile, string outFile, string k, byte[] iv)
        {
            uint[] key = KreirajKljuc(k);
            using (BinaryReader reader = new BinaryReader(File.Open(inFile, FileMode.Open)))
            {
                int originalLength = reader.ReadInt32();
                byte[] data = reader.ReadBytes((int)reader.BaseStream.Length - 4);

                uint[] words = new uint[data.Length / 4];
                Buffer.BlockCopy(data, 0, words, 0, data.Length);
                uint iv0 = BitConverter.ToUInt32(iv, 0);
                uint iv1 = BitConverter.ToUInt32(iv, 4);

                for (int i = 0; i < words.Length; i += 2)
                {
                    uint t0 = words[i];
                    uint t1 = words[i + 1];
                    Decrypt(ref words[i], ref words[i + 1], key);

                    words[i] = words[i] ^ iv0;
                    words[i + 1] = words[i + 1] ^ iv1;
                    iv0 = t0;
                    iv1 = t1;

                }

                byte[] decryptedData = new byte[words.Length * 4];
                Buffer.BlockCopy(words, 0, decryptedData, 0, decryptedData.Length);

                byte[] finalData = new byte[originalLength];
                Array.Copy(decryptedData, finalData, originalLength);
                File.WriteAllBytes(outFile, finalData);
                return finalData;
            }

        }





    }
}
