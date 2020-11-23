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
    static class Message
    {
        public static void PrintShorterWords(string text, int value)
        {
            if (text.Length > 0)
            {
                StringBuilder word = new StringBuilder();
                int letters = 0;
                for (int i = 0; i < text.Length; i++)
                {
                    if (Char.IsLetter(text[i]))
                    {
                        letters++;
                        word.Append(text[i]);
                    }
                    else
                    {
                        if (letters > 0)
                        {
                            if (letters <= value)
                            {
                                Console.Write(word + " ");
                            }
                            letters = 0;
                            word.Clear();
                        }

                    }
                }
            }
        }

        public static string DeleteEndingWith (string text, char c)
        {
            if (text.Length > 0)
            {
                StringBuilder res = new StringBuilder();
                StringBuilder word = new StringBuilder();
                for (int i = 0; i < text.Length; i++)
                {
                    if (Char.IsLetter(text[i]))
                        word.Append(text[i]);
                    else
                    {
                        if (word.Length > 0)
                        {
                            if (word[word.Length - 1] != c)
                                res.Append(word);
                        }
                        word.Clear();
                        if (text[i] == ' ' && i != text.Length - 1 && Char.IsLetter(text[i + 1]))
                            word.Append(text[i]);
                        else
                            res.Append(text[i]);
                    }
                }
                return res.ToString();
            }
            else
                return text;
        }

        public static string Longest (string text)
        {
            if (text.Length > 0)
            {
                string res = "";
                int maxLen = 0;
                int len = 0;
                StringBuilder word = new StringBuilder();
                for (int i = 0; i < text.Length; i++)
                {
                    if (Char.IsLetter(text[i]))
                    {
                        word.Append(text[i]);
                        len++;
                    }
                    else
                    {
                        if (len > 0)
                        {
                            if (len > maxLen)
                            {
                                res = word.ToString();
                                maxLen = len;
                            }
                            len = 0;
                            word.Clear();
                        }
                    }
                }
                return res;
            }
            else
                return text;
        }

        public static string LongestWords (string text)
        {
            if (text.Length > 0)
            {
                StringBuilder res = new StringBuilder();
                int maxLen = 0;
                StringBuilder word = new StringBuilder();
                int len = 0;
                for (int i = 0; i < text.Length; i++)
                {
                    if (Char.IsLetter(text[i]))
                    {
                        word.Append(text[i]);
                        len++;
                    }
                    else
                    {
                        if (len > 0)
                        {
                            if (len == maxLen)
                            {
                                res.Append(word);
                            }
                            else
                                if (len > maxLen)
                            {
                                res.Clear();
                                res.Append(word);
                                res.Append(' ');
                                maxLen = len;
                            }
                            word.Clear();
                            len = 0;
                        }
                    }
                }
                return res.ToString();
            }
            else
                return text;
        }
    }
}
