using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
//а) Сделайте меню с различными функциями и предоставьте пользователю выбор, для какой функции и на каком отрезке находить минимум.
//б) Используйте массив(или список) делегатов, в котором хранятся различные функции.
//в) *Переделайте функцию Load, чтобы она возвращала массив считанных значений. Пусть она
//возвращает минимум через параметр.

namespace Zotov_DZ6
{
    public delegate double Func(double x);

    class Task_2
    {
        public void Start()
        {
            Console.Clear();
            Helper helper = new Helper();
            Console.WriteLine("Данная программа находит минимальное значение функции на заданном отрезке");
            Console.ReadKey();
            List<Function> list = CreateList();
            Console.Clear();
            Console.WriteLine("Выберите функцию:");
            for (int i=0; i< list.Count; i++)
                Console.WriteLine($"{i + 1}. {list[i].funcToStr}");
            Func func = list[helper.choose(1, list.Count) - 1].func;
            Console.Clear();
            Console.WriteLine("Введите начальное значение промежутка Х:");
            double x = helper.readDouble();
            Console.WriteLine("Введите конечное значение промежутка Х:");
            double b = helper.readDouble();
            Console.Clear();
            double minX;
            double minY = MinY(func, x, b, out minX);
            Console.WriteLine($"Минимальное значение функции на промежутке от {x} до {b} равно {minY} при Х = {minX:0.00000}");
            Console.WriteLine("Нажмите любую кнопку, чтобы продолжить");
            Console.ReadKey();
            Console.Clear();

        }


        public struct Function  //структура, которая хранит саму функцию и ее строчный вариант для использования в консоли
                                //нужна для того, чтобы не переписывать работу консоли при изменении функций
        {
            public Func func;
            public string funcToStr;
            public Function(Func f, string s)
            {
                func = f;
                funcToStr = s;
            }

            public string getString()
            {
                return funcToStr;
            }

            public Func getFunc()
            {
                return func;
            }
        }
        private List<Function> CreateList()   //создает коллекцию структур, хранящих делегаты
        {
            List<Function> list = new List<Function>();
            list.Add(new Function(delegate (double x) { return x * x * x / 2; }, "F(x)=(x^3)/2"));
            list.Add(new Function(delegate (double x) { return Math.Cos(x); }, "F(x)=cos(x)"));
            list.Add(new Function(delegate (double x) { return (Math.Abs(x) - 5) * x; }, "F(x)=(|x|-5)*x"));
            list.Add(new Function(delegate (double x) {return x* x + 2 * x - 5; }, "F(x)=(x^2)+2x-5"));
            list.Add(new Function(delegate (double x) {return 5 / (x + 2.5); }, "F(x)=5/(x+2.5)"));
            return list;
        }


        public double MinY(Func F, double x, double b, out double minX)  //возвращает минимальное значение функции на промежутке от Х до В с шагом 0,00001
        {
            double min = F(x);
            minX = x;
            x += 0.00001;
            while (x <= b)
            {
                if (F(x) < min)
                {
                    min = F(x);
                    minX = x;
                }

                x += 0.00001;
            }
            return min;
        }

        public double[] Load(string fileName, out double min)  //новый метод Load, который считывает числа в возвращаемый массив и возвращает минимальное через параметр 
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            List<double> list = new List<double>();
            min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {

                d = bw.ReadDouble();
                list.Add(d);
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return list.ToArray();
        }

        public static void SaveFunc(string fileName, Func F, double a, double b, double h ) //измененный метод из методички, запись в файл (добавлен делегат)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }

        public void PrintDoubleArray(double[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
                Console.Write($"{arr[i]}, ");
            Console.Write(arr[arr.Length - 1]);
            Console.WriteLine();
        }
    }
}
