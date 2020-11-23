using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Создать программу, которая будет проверять корректность ввода логина. 
//Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой

namespace Zotov_DZ5
{
    class Task_1
    {
        public void Start()
        {
            Console.Clear();
            bool flag = false;
            string login;
            Console.WriteLine("Введите логин:");
            while (!flag)
            {
                login = Console.ReadLine();
                if (checkLogin(login))
                {
                    Console.Clear();
                    flag = true;
                    Console.WriteLine("Логин корректен");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Некорректный логин, введите другой:");
                    Console.ReadKey();
                }
            }
        }

        private bool checkLogin (string login)
        {
            if (login.Length < 2 || login.Length > 10)
                return false;
            if (Char.IsNumber(login[0]))
                return false;            
            for (int i = 0; i<login.Length; i++)
                {
                    if (!(Char.IsNumber(login[i]) || (Char.ToLower(login[i])>'a' && Char.ToLower(login[i])<'z')))
                        return false;
                }
            return true;
        }
    }
}
