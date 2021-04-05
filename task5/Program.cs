using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    class Program
    {
        // *Задание 5
        // Вычислить, используя рекурсию, функцию Аккермана:
        // A(2, 5), A(1, 2)
        // A(n, m) = m + 1, если n = 0,
        //         = A(n - 1, 1), если n <> 0, m = 0,
        //         = A(n - 1, A(n, m - 1)), если n> 0, m > 0.
        // 
        // Весь код должен быть откоммментирован

        static void Main(string[] args)
        {
            uint[] nm1 = { 2, 5 };
            uint[] nm2 = { 1, 2 };

            Console.WriteLine(FunctionOfAccerman(nm1[0], nm1[1])); //13
            Console.WriteLine(FunctionOfAccerman(nm2[0], nm2[1])); //4
            Console.ReadKey();
        }

        /// <summary>
        /// рекурсивная функция Аккермана, вычисляет число на основе двух введенных натуральных чисел
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        static uint FunctionOfAccerman(uint n, uint m)
        {
            if (n == 0) return m + 1;   //базовый случай, выхода из рекурсии
            else if (n != 0 && m == 0) return FunctionOfAccerman(n - 1, 1); //вызов функции аккермана при m = 0
            else if (n > 0 && m > 0) return FunctionOfAccerman(n - 1, FunctionOfAccerman(n, m - 1)); //вызов функции с m и n больше 0
            else return 0; //выход из функции, при остальных не учтённых выше условиях
        }
    }
}
