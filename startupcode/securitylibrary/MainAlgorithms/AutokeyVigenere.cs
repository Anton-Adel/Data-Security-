using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class AutokeyVigenere : ICryptographicTechnique<string, string>
    {
        public string Analyse(string plainText, string cipherText)
        {
            int[] plainvalue = new int[plainText.Length];
            int[] cipervalue = new int[plainText.Length];
            int[] keyvalue = new int[plainText.Length];
            char[] key = new char[plainText.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainvalue[i] = Convert.ToInt32(plainText[i]);
                
                //cipervalue[i] = Convert.ToInt32(cipherText[i]);
                //keyvalue[i] = ((cipervalue[i] % 26) - plainvalue[i]);
                //key[i] = Convert.ToChar(keyvalue[i]);
            }
            Console.WriteLine(plainvalue);
            string s = new string(key);
            s = s.ToLower();
            return s;
        }

        public string Decrypt(string cipherText, string key)
        {
            int[] ciperstream = new int[cipherText.Length];
            int[] keystream = new int[cipherText.Length];
            char[] plaintext = new char[cipherText.Length];
            int[] plain = new int[cipherText.Length];
            for (int i = 0; i < cipherText.Length; i++)
            {
                ciperstream[i] = Convert.ToInt32(cipherText[i]);
            }

            for (int i = 0; i < key.Length; i++)
            {
                keystream[i] = Convert.ToInt32(key[i]);

            }
            for (int i = 0; i < cipherText.Length; i++)
            {
                plain[i] = ((ciperstream[i] - keystream[i]) % 26);
                for (int j = key.Length; j < cipherText.Length; j++)
                {
                    keystream[j] = plain[i];
                }
                plaintext[i] = Convert.ToChar(plain[i]);
            }

            String s = new String(plaintext);
            s = s.ToLower();
            return s;
        }

        public string Encrypt(string plainText, string key)
        {
             char[] ciper = new char[plainText.Length];
            int[] plainvalue = new int[plainText.Length];
            int[] keystream = new int[plainText.Length];
            int[] cipervalue = new int[plainText.Length];
       
            for (int i = 0; i < plainText.Length; i++)
            {
                plainvalue[i] = Convert.ToInt32(plainText[i]);
            }


            for (int i = 0; i < key.Length; i++)
            {
                keystream[i] = Convert.ToInt32(key[i]);

            }

            for (int i = key.Length; i < plainText.Length; i++)
            {
                int j = 0;

                keystream[i] = Convert.ToInt32(plainText[j]);
                j++;

            }

            for (int i = 0; i < plainText.Length; i++)
            {
                cipervalue[i] = ((plainvalue[i] + keystream[i]) % 26);
                ciper[i] = Convert.ToChar(cipervalue[i]);
             
            }

            String c = new String(ciper);
            c = c.ToUpper();
            return c;
        }
        }
    }

