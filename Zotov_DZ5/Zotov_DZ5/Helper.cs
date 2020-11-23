using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zotov_DZ5
{
    class Helper
    {
        public string ReadFromFile (string path)
        {
            StreamReader sr = new StreamReader(path);
            StringBuilder sb = new StringBuilder();
            while (!sr.EndOfStream)
            {
                sb.Append(sr.ReadLine());
            }
            return sb.ToString();
        }

        public int readInt()
        {
            int i;
            bool flag;
            do
            {
                flag = int.TryParse(Console.ReadLine(), out i);
            }
            while (!flag);
            return i;
        }

        public double readDouble()
        {
            double i;
            bool flag;
            do
            {
                flag = double.TryParse(Console.ReadLine(), out i);
            }
            while (!flag);
            return i;
        }
    }
}
