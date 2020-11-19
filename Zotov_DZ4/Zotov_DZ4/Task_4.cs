using System;

//Реализовать класс для работы с двумерным массивом. Реализовать конструктор, заполняющий массив случайными числами. 
//Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, 
//свойство, возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, 
//метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out)
//Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
//Обработать возможные исключительные ситуации при работе с файлами.

namespace Zotov_DZ4
{
    class Task_4
    {
        public void start ()
        {
            Console.Clear();
            Helper helper = new Helper();
            Console.WriteLine("Введите количество строк массива");
            int sizeY = helper.readInt();
            Console.WriteLine("Введите количество столбцов массива");
            int sizeX = helper.readInt();
            MatrixHandler matrix = new MatrixHandler(sizeY, sizeX);
            Console.WriteLine("Получившийся массив:");
            matrix.print();
            Console.WriteLine("Сумма чисел в массиве:");
            Console.WriteLine(matrix.sum());
            Console.WriteLine("Сумма чисел больше 900000:");
            Console.WriteLine(matrix.sumMore(900000));
            Console.WriteLine("Максимальный элемент:");
            Console.WriteLine(matrix.max());
            Console.WriteLine("Минимальный элемент:");
            Console.WriteLine(matrix.min());
            Console.WriteLine();
            Console.WriteLine("Нажмите любую кнопку, чтобы продолжить");
            Console.ReadKey();
        }

    }

    class MatrixHandler
    {
        private int[,] array;
        private int sizeY;
        private int sizeX;

        public MatrixHandler(int sizeY, int sizeX)
        {
            array = new int[sizeY, sizeX];
            Random random = new Random();
            for (int i = 0; i < sizeY; i++)
                for (int j = 0; j < sizeX; j++)
                    array[i, j] = random.Next(-1000000, 1000001);
            this.sizeY = sizeY;
            this.sizeX = sizeX;
        }

        public int sum ()
        {
            int res = 0;
            for (int i = 0; i < sizeY; i++)
                for (int j = 0; j < sizeX; j++)
                    res += array[i, j];
            return res;
        }

        public int sumMore (int x)
        {
            int res = 0;
            for (int i = 0; i < sizeY; i++)
                for (int j = 0; j < sizeX; j++)
                    if (array[i, j] > x)
                        res += array[i, j];
            return res;
        }
        
        public int get (int y, int x)
        {
            return array[y, x];
        }

        public void set (int value, int y, int x)
        {
            array[y, x] = value;
        }

        public int max ()
        {
            int max = array[0, 0];
            for (int i = 0; i < sizeY; i++)
                for (int j = 0; j < sizeX; j++)
                    if (array[i, j] > max)
                        max = array[i, j];
            return max;
        }

        public int min()
        {
            int min = array[0, 0];
            for (int i = 0; i < sizeY; i++)
                for (int j = 0; j < sizeX; j++)
                    if (array[i, j] < min)
                        min = array[i, j];
            return min;
        }

        public int maxIndex ()
        {
            int max = array[0, 0];
            int res = 1;
            for (int i = 0; i < sizeY; i++)
                for (int j = 0; j < sizeX; j++)
                {
                    if (array[i, j] > max)
                    {
                        res = 1;
                        max = array[i, j];
                    }
                    else
                        if (max == array[i, j])
                        res++;
                }
            return res;
        }

        public int maxIndex(ref int max)
        {
            max = array[0, 0];
            int res = 1;
            for (int i = 0; i < sizeY; i++)
                for (int j = 0; j < sizeX; j++)
                {
                    if (array[i, j] > max)
                    {
                        res = 1;
                        max = array[i, j];
                    }
                    else
                        if (max == array[i, j])
                        res++;
                }
            return res;
        }

        public void print()
        {
            for (int i=0; i<sizeY; i++)
            {
                for (int j = 0; j < sizeX; j++)
                    Console.Write($"{array[i, j]}  ");
                Console.WriteLine();
            }
        }


    }

}
