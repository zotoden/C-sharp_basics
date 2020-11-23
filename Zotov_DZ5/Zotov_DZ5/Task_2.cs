using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Разработать класс Message, содержащий следующие статические методы для обработки текста:
//а) Вывести только те слова сообщения, которые содержат не более n букв.
//б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
//в) Найти самое длинное слово сообщения.
//г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
//Продемонстрировать работу программы на текстовом файле
namespace Zotov_DZ5
{
    class Task_2
    {
        public void Start ()
        {
            Console.Clear();
            Helper helper = new Helper();
            string text = helper.ReadFromFile("text.txt");
            Console.WriteLine("Изначальный текст: \n");
            Console.WriteLine(text);
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Слова не более, чем с 5 буквами:");
            Message.PrintShorterWords(text, 5);
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Слова без \"ь\" на конце");
            Console.WriteLine(Message.DeleteEndingWith(text, 'ь'));
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Самое длинное слово:");
            Console.WriteLine(Message.Longest(text));
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Самые длинные слова:");
            Console.WriteLine(Message.LongestWords(text));
            Console.ReadKey();
            Console.Clear();
        }
    }
}
