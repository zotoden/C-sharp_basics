using System;

namespace Zotov_DZ4
{
    class Helper
    {
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
