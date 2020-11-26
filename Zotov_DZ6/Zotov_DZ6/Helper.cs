using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zotov_DZ6
{
    class Helper
    {
        public int choose (int a, int b)  //метод считывающий с консоли число между a и b включительно
        {
            int i;
            bool flag;
            do
            {
                flag = int.TryParse(Console.ReadLine(), out i);
                if (flag)
                    if (i > b || i < a)
                        flag = false;
            }
            while (!flag);
            return i;
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
