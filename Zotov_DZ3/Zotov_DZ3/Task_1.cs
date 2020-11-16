using System;

//Зотов Данила

//Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса;


namespace Zotov_DZ3
{
    class Task_1
    {
        public void start()
        {
            Console.Clear();
            Helper helper = new Helper();
            Complex comp1 = new Complex();
            Complex comp2 = new Complex();
            Console.WriteLine("Первое число:");
            Console.WriteLine("Введите действительную часть");
            comp1.re = helper.readDouble();
            Console.WriteLine("Введите мнимую единицу");
            comp1.im = helper.readDouble();
            Console.Clear();
            Console.WriteLine("Второе число:");
            Console.WriteLine("Введите действительную часть");
            comp2.re = helper.readDouble();
            Console.WriteLine("Введите мнимую единицу");
            comp2.im = helper.readDouble();
            Console.Clear();
            Console.WriteLine($"Даны числа: {comp1.ToString()} и {comp2.ToString()}");
            Console.WriteLine($"Сумма чисел равна {comp1.Plus(comp2).ToString()}");
            Console.WriteLine($"Разность чисел равна {comp1.Minus(comp2).ToString()}");
            Console.WriteLine($"Произведение чисел равно {comp1.Multiply(comp2).ToString()}");
            Console.WriteLine("");
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
            Console.ReadKey();
        }

    }
    class Complex
    {
        public double im;
        public double re;

        public Complex()
        {
            im = 0;
            re = 0;
        }

        public Complex(double im, double re)
        {
            this.im = im;
            this.re = re;
        }
        public Complex Plus(Complex x2)
        {
            Complex x3 = new Complex();
            x3.im = x2.im + im;
            x3.re = x2.re + re;
            return x3;
        }

        public Complex Minus (Complex x2)
        {
            Complex x3 = new Complex();
            x3.im = im - x2.im;
            x3.re = re - x2.re;
            return x3;
        }

        public Complex Multiply (Complex x2)
        {
            Complex x3 = new Complex();
            x3.re = re * x2.re - im * x2.im;
            x3.im = re * x2.im + im * x2.re;
            return x3;
        }


        public string ToString()
        {
            if (im == 0)
                return re.ToString();
            else
                if (re == 0)
                    return im + "i";
                else
                    return re + "+" + im + "i";
        }
    }

}
