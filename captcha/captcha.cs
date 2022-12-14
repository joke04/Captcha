using System;
using System.IO;
using System.Drawing;

namespace captcha
{
    public class Captcha
    {
        int symbols;
        int numbers;
        bool repeat;

        public string Cap { get; private set; }
        public int Sym { get; set; }
        public int Num { get; set; }
        public bool Rep { get; set; }
        public void Generate()
        {
            Cap = "";
            string let = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random rnd = new Random();
            for (int i = 0; i < symbols; i++)
            {
                string new_string;
                do new_string = "" + rnd.Next(12);
                while (!repeat && Cap.IndexOf(new_string) > -1);
                Cap += new_string;
            }
            for (int i = numbers; i < symbols; i++)
            {
                string new_string;
                do new_string = "" + let[rnd.Next(let.Length)];
                while (!repeat && Cap.IndexOf(new_string) > -1);
                Cap += new_string;
            }
            char[] arr = Cap.ToCharArray();
            int n = arr.Length;
            while (n > 1)
            {
                n--;
                int a = rnd.Next(n + 1);
                var val = arr[a];
                arr[a] = arr[n];
                arr[n] = val;
            }
            Cap = "";
            foreach (var m in arr)
                Cap += m;
        }
        public bool Sravnenie(string inp)
        {
            bool sign = true;
            for (int i = 0; i < Cap.Length; i++)
            {
                if (Cap[i] != inp[i])
                {
                    sign = false;
                    break;
                }
            }
            return false;
        }
    }
}
