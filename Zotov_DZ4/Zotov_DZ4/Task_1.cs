using System;

//Дан целочисленный массив из 20 элементов. Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно. 
//Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых хотя бы одно число делится на 3.

namespace Zotov_DZ4
{
    class Task_1
    {

        public void start()
        {
            Console.Clear();
            Console.WriteLine("Данная программа рассчитывает в случайно сгенерированном массиве количество пар, \nв которых хотя бы ондно число кратно трём");
            Console.ReadKey();
            Console.Clear();
            int[] arr = new int[20];
            Random random = new Random();
            Console.Write("Сгенерированный массив: ");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(-10000, 10001);
                Console.Write(arr[i]);
                Console.Write("  ");
            }
            Console.WriteLine();
            int counter = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] % 3 == 0)
                {
                    counter++;
                    Console.WriteLine($"Пара: {arr[i]} {arr[i+1]}");
                }
                else
                    if (arr[i + 1] % 3 == 0)
                    {
                        counter++;
                        Console.WriteLine($"Пара: {arr[i]} {arr[i + 1]}");
                    }
            }
            Console.WriteLine($"Количество пар: {counter}");
            Console.WriteLine();
            Console.WriteLine("Нажмите любую кнопку, чтобы продолжить");
            Console.ReadKey();
        }



    }
}
