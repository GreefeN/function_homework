using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Program
    {
        // Задание 2.
        // 1. Создать метод, принимающий  текст и возвращающий слово, содержащее минимальное количество букв
        // 2.* Создать метод, принимающий  текст и возвращающий слово(слова) с максимальным количеством букв 
        // Примечание: слова в тексте могут быть разделены символами (пробелом, точкой, запятой) 
        // Пример: Текст: "A ББ ВВВ ГГГГ ДДДД  ДД ЕЕ ЖЖ ЗЗЗ"
        // 1. Ответ: А
        // 2. ГГГГ, ДДДД

        static void Main(string[] args)
        {
            string text = "AAA ББ ВВВВ Г ДДДД  ДД ЕЕ ЖЖЖЖ ЗЗЗ";

            Console.WriteLine("Слово из текста с минимальной длиной: ");
            string resultWord = MinWordOutput(text);
            Console.WriteLine($"{resultWord}\n");

            Console.WriteLine("Слово или слова максимальной длины: ");
            string[] resultMaxWords = MaxWordsOutput(text);
            foreach (string e in resultMaxWords) Console.Write($"{e} ");
            Console.ReadKey();
        }

        /// <summary>
        /// принимает текст, и возвращает слово с минимальным количеством букв
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static string MinWordOutput(string s)
        {
            char[] separators = { '.', ',', ':', ';', ' ' };    //массив для разделителей текста
            string[] arr = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);  //разбивка входящего текста на массив слов, с удалением пустых строк
            string minWord = arr[0];    //базовое значение

            for (int i = 1; i < arr.Length; i++)    //перебор массива слов для поиска минимальной длины
            {
                minWord = arr[i].Length < minWord.Length ? arr[i] : minWord;
            }

            return minWord;
        }

        /// <summary>
        /// примает текст и возвращает слово(слова) с максимальным количеством букв
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static string[] MaxWordsOutput(string s)
        {
            char[] separators = { '.', ',', ':', ';', ' ' };    //массив для разделителей текста
            string[] arr = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);  //разбивка входящего текста на массив слов, с удалением пустых строк
            int maxLenght = 0;

            foreach (string e in arr)   //получаем максимальную длину слова в массиве
            {
                maxLenght = e.Length > maxLenght ? e.Length : maxLenght;
            }

            int count = 0; //счётчик длинных слов
            foreach (string e in arr) //узнаем количество слов в массиве с максимальной длиной, для создания массива содержащего их
            {
                if (e.Length == maxLenght) count++;
            }

            string[] maxWords = new string[count]; //создаем массива максимально длинных слов для вывода
            int id = 0; //index в массиве длинных слов
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Length == maxLenght) //проверяем слово из входящего массива на максимальную длину
                {
                    maxWords[id++] = arr[i]; //присваиваем значения массиву длинных слов
                }
            }

            return maxWords;
        }

    }
}
