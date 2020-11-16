using System;
using System.Text;

//Зотов Данила

//С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке). 
//Требуется подсчитать сумму всех нечетных положительных чисел. 
//Сами числа и сумму вывести на экран, используя tryParse;

namespace Zotov_DZ3
{
    class Task_2
    {
        public void start()
        {
            
            Console.Clear();
            Console.WriteLine("Введите числа (каждое с новой строки)");
            StringBuilder sb = new StringBuilder();    //к сожалению, не понял, как выводить с помощью tryParse, поэтому StringBuilder
            Helper helper = new Helper();
            int res = 0;
            int read = helper.readInt();
            while (read != 0)
            {
                if (read > 0 && read % 2 == 1)
                {
                    res += read;
                    sb.Append(read + " ");
                }
                read = helper.readInt();
            }
            string numbers = sb.ToString();
            Console.Clear();
            Console.WriteLine("Нечетные положительные числа: " + numbers);
            Console.WriteLine($"Их сумма: {res}");
            Console.WriteLine("");
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
            Console.ReadKey();
        }

    }
}
