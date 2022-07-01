using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SecurityLibrary
{
    public class Columnar : ICryptographicTechnique<string, List<int>>
    {
        public List<int> Analyse(string plainText, string cipherText)
        {
            throw new NotImplementedException();
        }

        public string Decrypt(string cipherText, List<int> key)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();


            cipherText = cipherText.ToLower();

            string PT = "";
            int cols = key.Count;
            double key_ = Convert.ToDouble(cols);
            double x = (cipherText.Length) / key_;
            x = Math.Ceiling(x);
            int counter = 0;
            int rows = Convert.ToInt32(x);
            bool check = false;
            if (cipherText.Length % 4 != 0)
            {
                check = true;
                String xx = cipherText;
                while (xx.Length % x != 0)
                {
                    xx = xx.Insert(xx.Length - 1, "x");
                    Console.WriteLine(xx.Length);
                    counter++;
                }
            }
            int lenght_ = cipherText.Length;
            int sub_ = 0;
            for (int i = 0; i < counter; i++)
            {

                cipherText = cipherText.Insert(lenght_ - sub_, "x");
                sub_ += 3;

            }

            Console.WriteLine(cipherText);
            char[,] arr = new char[rows, cols];
            for (int i = 0; i < cols; i++)
            {
                dic.Add(key[i], i);
            }
            var sortedDict = from entry in dic orderby entry.Key ascending select entry;
            int[] rightcols = new int[cols];
            int index = 0;
            foreach (KeyValuePair<int, int> d in sortedDict)
            {
                rightcols[index++] = d.Value;
                Console.WriteLine(d.Value);

            }
            int k = 0;

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (k < cipherText.Length)
                        arr[j, rightcols[i]] = cipherText[k++];
                }

            }


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(arr[i, j]);

                }

                Console.Write("\n");
            }


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    PT += arr[i, j];

                }


            }




            if (check == true)
                if (PT[PT.Length - 1] == 'x')
                {
                    PT = PT.Remove(PT.Length - 1, 1);
                    for (int i = 0; i < PT.Length; i++)
                    {
                        if (PT[PT.Length - 1] == 'x')
                        {
                            PT = PT.Remove(PT.Length - 1, 1);
                        }
                        else
                            break;

                    }





                }

            return PT;
        }

        public string Encrypt(string plainText, List<int> key)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            plainText = plainText.ToLower();
            int cols = key.Count;
            double key_ = Convert.ToDouble(cols);
            double x = (plainText.Length) / key_;
            x = Math.Ceiling(x);
            int rows = Convert.ToInt32(x);
            char[,] arr = new char[rows, cols];

            string CT = "";
            int k = 0;

            for (int i = 0; i < cols; i++)
            {
                dic.Add(key[i], i);
            }
            var sortedDict = from entry in dic orderby entry.Key ascending select entry;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (k < plainText.Length)
                        arr[i, j] = plainText[k++];
                    else
                    {
                        arr[i, j] = 'x';
                    }

                }

            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(arr[i, j]);

                }

                Console.Write("\n");
            }

            int[] rightcols = new int[cols];
            int index = 0;
            foreach (KeyValuePair<int, int> d in sortedDict)
            {

                rightcols[index++] = d.Value;
                Console.WriteLine(d.Value);

            }

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    CT += arr[j, rightcols[i]];

                }

            }


            return CT;
        }
    }
}
