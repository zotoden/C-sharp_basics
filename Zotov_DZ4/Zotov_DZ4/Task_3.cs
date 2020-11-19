using System;
using System.IO;

//Решить задачу с логинами из предыдущего урока, только логины и пароли считать из файла в массив. 
//Создайте структуру Account, содержащую Login и Password.


namespace Zotov_DZ4
{
    class Task_3
    {
        public void start()
        {
            Console.Clear();
            Console.WriteLine("Данная программа считывает из файла варианты логинов и паролей и подает их на проверку. Количество попыток ограничено.\n" +
                "Если ни один пароль не подошел и еще остались попытки, программа предлагает пользователю самому попробовать ввести данные.");
            Console.ReadKey();
            Console.Clear();
            string path = "logins_pass.txt";
            string l;
            string p;
            StreamReader sr = new StreamReader(path);
            LoginPassword[] data = new LoginPassword[0];
            while (!sr.EndOfStream)
            {
                l = sr.ReadLine();
                p = sr.ReadLine();
                Array.Resize(ref data, data.Length + 1);
                data[data.Length - 1] = new LoginPassword(l, p);
            }
            LoginDetails checker = new LoginDetails();
            bool pass = false;
            for (int i = 0; i < data.Length; i++)
            {
                pass = checker.checkFromArray(data[i]);
                if (pass == true)
                {
                    Console.WriteLine("Доступ разрешен.");
                    break;
                }
            }
            if (pass == false)
            {
                pass = checker.checkFromConsole();
                if (pass == true)
                    Console.WriteLine("Доступ разрешен");
                else
                    Console.WriteLine("В доступе отказано");
            }
            Console.ReadKey();
            Console.Clear();
                
        }
        
        struct LoginPassword                   //структура, хранящая логин и пароль из файла
        {
            private string login;
            private string password;

            public LoginPassword(string l, string p)
            {
                login = l;
                password = p;
            }

            public void print()
            {
                Console.WriteLine(login);
                Console.WriteLine(password);
            }

            public string getLogin()
            {
                return login;
            }

            public string getPassword ()
            {
                return password;
            }
        }

        class LoginDetails   //класс, осуществляющий проверку логина и пароля
        {
            private string login;
            private string password;
            private int attemptsLeft;

            public LoginDetails ()  //конструктор по умолчанию - дефолтные логин и пароль
            {
                login = "root";
                password = "Geekbrains";
                attemptsLeft = 5;
            }
            public LoginDetails (string path)  //альтернативный конструктор, считывающий логин и пароль из файла
            {
                StreamReader sr = new StreamReader(path);
                login = sr.ReadLine();
                password = sr.ReadLine();
                attemptsLeft = 5;
                sr.Close();
            }

            public bool checkFromConsole()
            {
                Console.Clear();
                if (attemptsLeft > 0)
                {
                    string gotLog;
                    string gotPass;
                    do
                    {
                        Console.WriteLine("Введите логин:");
                        gotLog = Console.ReadLine();
                        Console.WriteLine("Введите пароль:");
                        gotPass = Console.ReadLine();
                        if (gotLog.Equals(login) && gotPass.Equals(password))
                            return true;
                        attemptsLeft--;
                        Console.Clear();
                        if (attemptsLeft != 0)
                        {
                            Console.WriteLine("Неверный логин и (или) пароль");
                            Console.WriteLine($"Осталось попыток: {attemptsLeft}");
                            Console.ReadKey();
                        }
                    }
                    while (attemptsLeft != 0);
                    return false;
                }
                else
                {
                    Console.WriteLine("У вас больше нет попыток");
                    Console.ReadKey();
                    return false;
                }
            }

            public bool checkFromArray (LoginPassword lp)
            {

                Console.Clear();
                if (attemptsLeft > 0)
                {
                    Console.WriteLine($"Ваш логин: {lp.getLogin()}");
                    Console.WriteLine($"Ваш пароль: {lp.getPassword()}");
                    Console.ReadKey();
                    if (lp.getLogin().Equals(login) && lp.getPassword().Equals(password))
                        return true;
                    attemptsLeft--;
                    Console.Clear();
                    if (attemptsLeft != 0)
                    {
                        Console.WriteLine("Неверный логин и (или) пароль");
                        Console.WriteLine($"Осталось попыток: {attemptsLeft}");
                        Console.ReadKey();
                    }
                    return false;
                }
                else
                {
                    Console.WriteLine("У вас больше нет попыток");
                    return false;
                }
            }
        }
    }
}
