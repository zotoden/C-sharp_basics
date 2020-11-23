using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой. Регистр можно не учитывать:
//разработав собственный алгоритм.

namespace Zotov_DZ5
{
    class Task_3
    {
        public void Start()
        {
            Console.Clear();
            Console.WriteLine("Введите первую строку");
            string a = Console.ReadLine();
            Console.WriteLine("Введите вторую строку");
            string b = Console.ReadLine();
            if (anagramm(a, b))
                Console.WriteLine("Строки содержат одинаковые символы");
            else
                Console.WriteLine("Строки содержат разные символы");
            Console.ReadKey();
        }

        private bool anagramm(string a, string b)
        {
            if (a.Length != b.Length)
                return false;
            if (a.Equals(b))
                return true;
            int[] let = new int[159];
            a = a.ToUpper();
            b = b.ToUpper();
            for (int i = 0; i < a.Length; i++)      //считаем количество каждого символа
            {
                if (a[i] < 127)                     //с 1 по 126 элемент UNICODE - это буквы латинского алфавита и знаки
                    let[a[i] - 1]++;
                else
                {
                    if (a[i] == 'Ё')                 //буква Ё находится отдельно от всей кириллицы, считаем в последний элемент
                        let[158]++;
                    else
                        let[a[i] - 914]++;             //кириллица начинается с 1040 символа в UNICODE, а в нашем массиве с 126 элемента
                }
            }
            for (int i = 0; i < b.Length; i++)      //то же самое во второй строке, только уменьшаем количество
            {
                if (b[i] < 127)
                    let[b[i] - 1]--;
                else
                {
                    if (b[i] == 'Ё')
                        let[158]--;
                    else
                        let[b[i] - 914]--;
                }
            }
            for (int i = 0; i < 159; i++)       //если весь массив равен 0, то каждый символ попался одинаковое количество раз
                if (let[i] != 0)
                    return false;
            return true;
        }
    }
}
