using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    /// <summary>
    /// The List<int> is row based. Which means that the key is given in row based manner.
    /// </summary>
    public class HillCipher : ICryptographicTechnique<string, string>, ICryptographicTechnique<List<int>, List<int>>
    {
        public List<int> Analyse(List<int> plainText, List<int> cipherText)
        {
            double palin_cols_ = Math.Ceiling(plainText.Count / 2.0);
            int palin_cols = Convert.ToInt32(palin_cols_);
            int[,] plainText_matrix = new int[2, palin_cols];
            int[,] cipher_matrix = new int[2, palin_cols];
            int k = 0;
            for (int i = 0; i < palin_cols; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    plainText_matrix[j, i] = plainText[k++];
                }

            }
            k = 0;
            for (int i = 0; i < palin_cols; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    cipher_matrix[j, i] = plainText[k++];
                }

            }
            List<int> mayBeKey = new List<int>();
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    for (int kk = 0; kk < 26; kk++)
                    {
                        for (int l = 0; l < 26; l++)
                        {
                            mayBeKey = new List<int>(new[] { i, j, kk, l });
                            List<int> aa = Encrypt(plainText, mayBeKey);
                            if (aa.SequenceEqual(cipherText))
                            {
                                return mayBeKey;
                            }

                        }
                    }
                }
            }


            throw new InvalidAnlysisException();
        }

        public string Analyse(string plainText, string cipherText)
        {
            throw new NotImplementedException();
        }

        public List<int> Decrypt(List<int> cipherText, List<int> key)
        {
            throw new NotImplementedException();
        }

        public string Decrypt(string cipherText, string key)
        {
            throw new NotImplementedException();
        }

        public List<int> Encrypt(List<int> plainText, List<int> key)
        {
          
            double rows_ = Math.Sqrt(key.Count());
            int rows = Convert.ToInt32(rows_);
            double palin_cols_ = Math.Ceiling(plainText.Count / rows_);
            int palin_cols = Convert.ToInt32(palin_cols_);
            int key_cols = rows;
            List<int> CT = new List<int>();
            int[,] plainText_matrix = new int[rows, palin_cols];
            int[,] key_matrix = new int[rows, key_cols];
            int k = 0;
            for (int i = 0; i < palin_cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    plainText_matrix[j, i] = plainText[k++];
                }

            }
            k = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < key_cols; j++)
                {
                    key_matrix[i, j] = key[k++];
                }

            }
            Console.WriteLine("PLain");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < palin_cols; j++)
                {
                    Console.Write(plainText_matrix[i, j]);
                    Console.Write(' ');
                }
                Console.Write("\n");

            }
            Console.WriteLine("key");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < key_cols; j++)
                {
                    Console.Write(key_matrix[i, j]);
                    Console.Write(' ');
                }
                Console.Write("\n");
            }

            for (int i = 0; i < palin_cols; i++)
            {
                int[] arr = new int[rows];
                int index = 0;
                for (int j = 0; j < rows; j++)
                {
                    arr[index++] = plainText_matrix[j, i];
                }

                for (int j = 0; j < rows; j++)
                {
                    int sum = 0;
                    index = 0;
                    for (int h = 0; h < key_cols; h++)
                    {
                        sum += key_matrix[j, h] * arr[index++];
                    }
                    int x = sum % 26 >= 0 ? sum % 26 : sum % 26 + 26;
                    CT.Add(x);

                }


            }

            for (int i = 0; i < CT.Count; i++)
            {
                Console.Write(CT[i]);
                Console.Write("     ");
            }
                return CT;

        }

        public string Encrypt(string plainText, string key)
        {
            throw new NotImplementedException();
        }

        public List<int> Analyse3By3Key(List<int> plain3, List<int> cipher3)
        {
            throw new NotImplementedException();
        }

        public string Analyse3By3Key(string plain3, string cipher3)
        {
            throw new NotImplementedException();
        }
    }
}
