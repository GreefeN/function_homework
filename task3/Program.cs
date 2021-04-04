using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {
        // Задание 3. Создать метод, принимающий текст. 
        // Результатом работы метода должен быть новый текст, в котором
        // удалены все кратные рядом стоящие символы, оставив по одному 
        // Пример: ПППОООГГГООООДДДААА >>> ПОГОДА
        // Пример: Ххххоооорррооошшшиий деееннннь >>> хороший день

        static void Main(string[] args)
        {
            string text = "ПППОООГГГООООДДДААА";
            char[] letters = ReturnStringWithoutDuplicate(text);

            Console.ReadKey();
        }


        static char[] ReturnStringWithoutDuplicate(string s)
        {
            char[] letters = new char[s.Length]; //массив символов из входящей строки
            for (int i = 0; i < letters.Length; i++)    //заполняем массив символов
            {
                letters[i] = s[i];
            }



            return letters;

        }
    }
}
