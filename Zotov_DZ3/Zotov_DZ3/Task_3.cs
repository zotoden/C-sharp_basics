using System;

//Зотов Данила

//Описать класс дробей - рациональных чисел, являющихся отношением двух целых чисел. Предусмотреть методы сложения, вычитания, умножения и деления дробей. 
//Написать программу, демонстрирующую все разработанные элементы класса.
//Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
//Добавить упрощение дробей.

namespace Zotov_DZ3
{
    class Task_3
    {
        public void start()
        {
            Console.Clear();
            Helper helper = new Helper();
            Console.WriteLine("Первое число:");
            Console.WriteLine("Введите числитель:");
            int numer = helper.readInt();
            Console.WriteLine("Введите знаменатель:");
            int denom = helper.readInt();
            Fraction x1 = new Fraction(numer, denom);
            Console.Clear();
            Console.WriteLine("Второе число:");
            Console.WriteLine("Введите числитель:");
            numer = helper.readInt();
            Console.WriteLine("Введите знаменатель:");
            denom = helper.readInt();
            Fraction x2 = new Fraction(numer, denom);
            Console.Clear();
            Console.WriteLine($"Даны дроби: {x1.ToString()} и {x2.ToString()}:");
            Console.WriteLine($"Их сумма: {x1.plus(x2).ToString()}");
            Console.WriteLine($"Их разность: {x1.minus(x2).ToString()}");
            Console.WriteLine($"Их произведение: {x1.multiply(x2).ToString()}");
            Console.WriteLine($"Их частное: {x1.divide(x2).ToString()}");
            Console.WriteLine("");
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
            Console.ReadKey();
        }

    }

    class Fraction
    {
        public int numer;   //числитель
        public int denom;   //знаменатель
        
        public Fraction() 
        {
            numer = 0;
            denom = 1;
        }

        public Fraction(int n, int d)
        {
            if (d == 0)
                throw new ArgumentException("Знаменатель не может быть равен 0");

            else
            {
                numer = n;
                denom = d;
            }
        }

        public Fraction plus (Fraction x2)
        {
            Fraction res = new Fraction();
            res.numer = numer * x2.denom + x2.numer * denom;
            res.denom = denom * x2.denom;
            res.simplify();
            return res;
        }

        public Fraction minus(Fraction x2)
        {
            Fraction res = new Fraction();
            res.numer = numer * x2.denom - x2.numer * denom;
            Console.WriteLine(res.numer);
            res.denom = denom * x2.denom;
            Console.WriteLine(res.denom);
            res.simplify();
            return res;
        }

        public Fraction multiply(Fraction x2)
        {
            Fraction res = new Fraction();
            res.numer = numer * x2.numer;
            res.denom = denom * x2.denom;
            res.simplify();
            return res;
        }

        public Fraction divide(Fraction x2)
        {
            Fraction res = new Fraction();
            res.numer = numer * x2.denom;
            res.denom = denom * x2.numer;
            res.simplify();
            return res;
        }


        public Fraction simplify()  //метод сокращения
        {
            if (denom < 0)
            {
                numer *= -1;
                denom *= -1;
            }
            int s = gcd (numer, denom);
            numer /= s;
            denom /= s;
            return this;   
        }

        public double ToDouble()
        {
            return (double)numer / denom;
        }

        public string ToString()
        {
            if (numer == 0)
                return "0";
            if (denom == 1)
                return numer.ToString();
            return numer + "/" + denom;
        }


        public int gcd (int a, int b)   //метод, находящий наибольший общий делитель
        {
            if (a < 0)
                a *= -1;
            if (a == 1 || b == 1)
                return 1;
            if (a == b)
                return a;
            do
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }
            while (a != b);
            return a;
        }
    }
}
