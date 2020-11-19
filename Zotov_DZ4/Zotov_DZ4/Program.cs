using System;


//Зотов Данила. Домашнее задание №4.


namespace Zotov_DZ4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добрый день!");
            Helper helper = new Helper();
            bool flag = true;
            int ch;
            while (flag)
            {
                Console.WriteLine("Какое задание вы хотите проверить?");
                Console.WriteLine("1. Количество пар с кратным числом;");
                Console.WriteLine("2. Класс для работы с одномерным массивом");
                Console.WriteLine("3. Логин - пароль");
                Console.WriteLine("4. Класс для работы с двумерным массивом");
                Console.WriteLine("");
                ch = helper.readInt();
                switch (ch)
                {
                    case 1:
                        {
                            Task_1 task_1 = new Task_1();
                            task_1.start();
                            break;
                        }
                    case 2:
                        {
                            Task_2 task_2 = new Task_2();
                            task_2.start();
                            break;
                        }
                    case 3:
                        {
                            Task_3 task_3 = new Task_3();
                            task_3.start();
                            break;
                        }
                    case 4:
                        {
                            Task_4 task_4 = new Task_4();
                            task_4.start();
                            break;
                        }
                }
                Console.Clear();
                Console.WriteLine("Хотите продолжить проверку? (1 - да, 2 - нет)");
                if (helper.readInt() == 2)
                    flag = false;
                Console.Clear();
            }
            Console.WriteLine("Большое спасибо. Всего хорошего!");
            Console.ReadKey();
        }
    }
}
