using System;
using System.IO;

// Дописать класс для работы с одномерным массивом. 
// Реализовать конструктор, создающий массив заданной размерности и заполняющий массив числами от начального значения с заданным шагом. 
// Создать свойство Sum, которые возвращают сумму элементов массива, метод Inverse, меняющий знаки у всех элементов массива, 
// метод Multi, умножающий каждый элемент массива на определенное число, свойство MaxCount, возвращающее количество максимальных элементов. 
// В Main продемонстрировать работу класса.
// Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.

namespace Zotov_DZ4
{
    class Task_2
    {
        public void start()
        {
            Console.Clear();
            Console.WriteLine("Данная программа демонстрирует работу класса ArrayHandler");
            Helper helper = new Helper();
            Console.WriteLine("Введите размер нового массива");
            int size1 = helper.readInt();
            Console.WriteLine("Введите начальный элемент массива");
            int init1 = helper.readInt();
            Console.WriteLine("Введите шаг прогрессии");
            int step1 = helper.readInt();
            ArrayHandler array1 = new ArrayHandler(size1, init1, step1);
            Console.Clear();
            Console.WriteLine("Полученный массив:");
            array1.printArray();
            string path1 = "text1.txt";
            array1.writeToFile(path1);
            Console.WriteLine($"Сумма элементов массива: {array1.sum()}");
            Console.WriteLine($"Самое большое число в нем: {array1.max()}");
            Console.WriteLine($"Количество максимальных элементов: {array1.maxCount()}");
            array1.inverse();
            Console.WriteLine("Поменяли знаки у всех чисел, новый массив:");
            array1.printArray();
            Console.WriteLine("На какое число умножим каждый элемент?");
            int x = helper.readInt();
            array1.multi(x);
            Console.WriteLine($"Умножили каждый элемент на {x}. Новый массив:");
            array1.printArray();
            Console.WriteLine("Нажмите любую кнопку, чтобы продолжить");
            Console.ReadKey();
            Console.Clear();
            string path2 = "txt.txt";
            Console.WriteLine("В файле txt.txt записан следующий текст:");
            StreamReader sr = new StreamReader(path2);
            while(!sr.EndOfStream)
            {
                Console.WriteLine(sr.ReadLine());
            }
            sr.Close();
            Console.WriteLine("");
            Console.WriteLine("Считаем из него все числа");
            ArrayHandler array2 = new ArrayHandler(path2);
            Console.WriteLine("Полученный массив:");
            array2.printArray();
            Console.WriteLine($"Сумма элементов массива: {array2.sum()}");
            Console.WriteLine($"Самое большое число в нем: {array2.max()}");
            Console.WriteLine($"Количество максимальных элементов: {array2.maxCount()}");
            Console.WriteLine("Нажмите любую кнопку, чтобы продолжить");
            Console.ReadKey();
            Console.Clear();
        }
    }

    class ArrayHandler
    {
        private int[] array;
        private int length;

        public ArrayHandler ()  //конструктор по умолчанию
        {
            array = new int[0];
            length = 0;
        }
        public ArrayHandler (int size, int initV, int step)  //конструктор, получающий размерность, начальное число и шаг арифметической прогрессии
        {
            array = new int[size];
            length = size;
            for(int i = 0; i<size; i++)
            {
                array[i] = initV + i * step;
            }
        }


        public ArrayHandler (StreamReader sr) //конструктор от потока, работает только при условии, что каждое новое число начинается с новой строки
        {
            array = new int[0];
            length = 0;
            int number;
            bool flag;
            while(!sr.EndOfStream)
            {
                flag = int.TryParse(sr.ReadLine(), out number);
                if (flag)
                {
                    Array.Resize(ref array, ++length);
                    array[length - 1] = number;
                }
            }
        }
        public ArrayHandler (string path)   //конструктор от строки - пути к файлу, который считывает числа из файла, игнорируя другие символы, знаки и пробелы
        {
            StreamReader sr = new StreamReader(path);
            array = new int[0];
            int symb;
            int current = 0;
            length = 0;
            bool isNegative = false;
            bool toWrite = false;
            while (!sr.EndOfStream)
            {
                symb = sr.Read();
                if (symb>=48 && symb<=57)
                {
                    current = current * 10 + (symb - 48);
                    toWrite = true;
                }
                else
                {
                    if (toWrite)
                    {
                        Array.Resize(ref array, ++length);
                        if (isNegative)
                            current *= (-1);
                        array[length - 1] = current;
                        current = 0;
                        isNegative = false;
                        toWrite = false;
                    }
                    if (symb == 45)                    //если  стоит минус, то число после него отрицательное, если 2 минуса - положительное, и т.д.
                        isNegative = !isNegative; 
                    else
                        isNegative = false;
                }
            }
            if (toWrite)
            {
                Array.Resize(ref array, ++length);
                if (isNegative)
                    current *= (-1);
                array[length - 1] = current;
            }
        }

        public void addFromFile (string path)   //добавляет все числа из полученного файла в массив, вне зависимости от способа их записи
        {
            StreamReader sr = new StreamReader(path);
            int symb;
            int current = 0;
            bool isNegative = false;
            bool toWrite = false;
            while (!sr.EndOfStream)
            {
                symb = sr.Read();
                if (symb >= 48 && symb <= 57)
                {
                    current = current * 10 + (symb - 48);
                    toWrite = true;
                }
                else
                {
                    if (toWrite)
                    {
                        Array.Resize(ref array, ++length);
                        if (isNegative)
                            current *= (-1);
                        array[length - 1] = current;
                        current = 0;
                        isNegative = false;
                        toWrite = false;
                    }
                    if (symb == 45)
                        isNegative = !isNegative;
                    else
                        isNegative = false;
                }
            }
            if (toWrite)
            {
                Array.Resize(ref array, ++length);
                if (isNegative)
                    current *= (-1);
                array[length - 1] = current;
            }
        }

        public void addFromFileLines (string path) //добавляет числа из файла, при условии что каждое число начинается с новой строки
        {
            StreamReader sr = new StreamReader(path);
            int number;
            bool flag;
            while (!sr.EndOfStream)
            {
                flag = int.TryParse(sr.ReadLine(), out number);
                if (flag)
                {
                    Array.Resize(ref array, ++length);
                    array[length - 1] = number;
                }
            }
        }

        public void writeToFileLines (string path)  //запись массива в файл: каждое число с новой строки
        {
            StreamWriter sw = new StreamWriter(path);
            for (int i = 0; i < length; i++)
                sw.WriteLine(array[i]);
            sw.Close();
            Console.WriteLine($"Массив записан в {path}.");
        }

        public void writeToFile (string path)  //запись массива в файл: в одну строку
        {
            StreamWriter sw = new StreamWriter(path);
            for (int i = 0; i < length; i++)
            {
                sw.Write(array[i]);
                sw.Write("  ");
            }
            sw.WriteLine("");
            sw.Close();
            Console.WriteLine($"Массив записан в {path}.");
        }

        public int sum()  //метод, возвращающий сумму чисел в массиве
        {
            int res = 0;
            for (int i = 0; i<array.Length; i++)
            {
                res += array[i];
            }
            return res;
        }

        public void inverse ()  //метод, меняющий знаки у элементов массива
        {
            for (int i=0; i<length; i++)
            {
                array[i] *= (-1);
            }
        }

        public void multi (int x)  //метод, умножающий каждый элемент массива на х
        {
            for (int i =0; i<length; i++)
            {
                array[i] *= x;
            }
        }

        public int max ()  //метод, возвращающий максимальный по значению элемент
        {
            if (length > 0)
            {
                int res = array[0];
                for (int i = 0; i < length; i++)
                    if (array[i] > res)
                        res = array[i];
                return res;
            }
            else
                return 0;
        }

        public int min ()  //метод, возвращающий минимальный по значению элемент
        {
            if (length > 0)
            {
                int res = array[0];
                for (int i = 0; i < length; i++)
                    if (array[i] < res)
                        res = array[i];
                return res;
            }
            else
                return 0;
        }

        public int maxCount()  //метод, возвращающий количество максимальных элементов
        {
            if (length > 0)
            {
                int res = 0;
                int max = array[0];
                for (int i = 1; i < length; i++)
                {
                    if (array[i] == max)
                    {
                        res++;
                    }
                    else
                    if (array[i] > max)
                    {
                        res = 1;
                        max = array[i];
                    }

                }
                return res;
            }
            else
                return 0;
        }

        public int maxCount(out int max)  //метод, возвращающий количество максимальных элементов и сам максимум
        {
            if (length > 0)
            {
                int res = 0;
                max = array[0];
                for (int i = 1; i < length; i++)
                {
                    if (array[i] == max)
                    {
                        res++;
                    }
                    else
                    if (array[i] > max)
                    {
                        res = 1;
                        max = array[i];
                    }

                }
                return res;
            }
            else
            {
                max = 0;
                return 0;
            }
        }

        public void printArray ()   //вывод в консоль
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write($"{array[i]}  ");
            }
            Console.WriteLine("");
        }

        public int get(int i)  
        {
            return array[i];
        }

        public bool set(int numb, int i)
        {
            if (i < length)
            {
                array[i] = numb;
                return true;
            }
            else
                return false;    
        }

        public void add(int numb)
        {
            Array.Resize(ref array, ++length);
            array[length - 1] = numb;
        }

    }
}
