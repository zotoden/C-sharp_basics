using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zotov_DZ6
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Добрый день!");
            Helper helper = new Helper();
            bool flag = true;
            int ch;
            while (flag)
            {
                Console.WriteLine("Какое задание вы хотите проверить?");
                Console.WriteLine("1. Таблица аргументов и значений функции;");
                Console.WriteLine("2. Метод нахождения минимального значения функции на промежутке");
                Console.WriteLine("");
                ch = helper.choose(1, 2);
                switch (ch)
                {
                    case 1:
                        {
                            Task_1 task_1 = new Task_1();
                            task_1.Start();
                            break;
                        }
                    case 2:
                        {
                            Task_2 task_2 = new Task_2();
                            task_2.Start();
                            break;
                        }
                }
                Console.Clear();
                Console.WriteLine("Хотите продолжить проверку? (1 - да, 2 - нет)");
                if (helper.choose(1, 2) == 2)
                    flag = false;
                Console.Clear();
            }
            Console.WriteLine("Большое спасибо. Всего хорошего!");
            Console.ReadKey();
        }
    }

}
