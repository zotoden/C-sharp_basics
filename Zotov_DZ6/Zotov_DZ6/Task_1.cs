using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Изменить программу вывода функции так, чтобы можно было передавать функции типа double (double,double). 
//Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).

namespace Zotov_DZ6
{
    public delegate double Fun(double a, double x);
    class Task_1
    {
        public void Table(Fun F, double a, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(a, x));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }

        public void Table2 (Fun F, double a, double b, double x, double z)
        {
            Console.WriteLine("----- A ------- X -------- Y -----");
            while (a <= b)
            {
                for (double i = x; i<=z; i+=1)
                {
                    Console.WriteLine("| {0,8:0.000} | {1,8:0.000} | {2,8:0.000} |", a, i, F(a, i));
                }
                a+=1;
            }        
            Console.WriteLine("----------------------------------");

        }


        public double MyFun1 (double a, double x)
        {
            return a * Math.Sin(x);
        }
        public double MyFun2 (double a, double x)
        {
            return a * x * x;
        }

        public void Start ()
        {
            Console.Clear();
            Helper helper = new Helper();
            Console.WriteLine("Данная программа выводит две таблицы значений функции");
            Console.WriteLine("Первая функция: F(x) = a*sin(x)");
            Console.WriteLine("Вторая функция: F(a,x) = a*x^2");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Первая функция: F(x) = a*sin(x). \nВведите постоянную А:");
            double a = helper.readDouble();
            Console.WriteLine("Введите начальное значение Х:");
            double x = helper.readDouble();
            Console.WriteLine("Введите конечное значение Х:");
            double b = helper.readDouble();
            Console.Clear();
            Table(MyFun1, a, x, b);
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Вторая функция: F(a,x) = a*x^2. \nВведите начальное значение А:");
            a = helper.readDouble();
            Console.WriteLine("Введите конечное значение А:");
            b = helper.readDouble();
            Console.WriteLine("Введите начальное значение Х:");
            x = helper.readDouble();
            Console.WriteLine("Введите конечное значение Х:");
            double z = helper.readDouble();
            Console.Clear();
            Table2(MyFun2, a, b, x, z);
            Console.ReadKey();
        }

    }
}
