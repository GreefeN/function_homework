using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_005
{
    class Program
    {
        // Задание 1.
        //Напишите как минимум четыре метода.
        // 1. Первый метод умножает матрицу на число.Для этого он принимает в качестве параметров матрицу и число,
        //    на которое будет происходить умножение.В качестве результата этот метод возвращает новую матрицу, а исходная матрица остаётся неизменной.
        // 2. Второй метод производит сложение двух матриц. В качестве параметров он принимает две матрицы, а в качестве результата возвращает новую матрицу.
        //    Исходные матрицы в процессе выполнения метода не изменяются.
        // 3. Третий метод аналогичен предыдущему, только выполняется не сложение, а вычитание.
        // 4. Четвёртый метод выполняет перемножение двух матриц. В качестве параметров он принимает две матрицы,
        //    а в качестве результата возвращает новую матрицу.Исходные матрицы остаются неизменными.

        static void Main(string[] args)
        {
            Random rnd = new Random();  //передается в методы для автозаполнения массивов, вынесен из тела методов что б создать экземпляр один раз и не расходовать память
            int[,] resultMatrix; //матрица для хранения результата операции

            Console.WriteLine("Умножение матрицы на число: ");
            int[,] arr1 = CreateMatrix(rnd);   //используем перегрузку создания матриц
            Console.Write("Введите число для умножения: ");
            int m = int.Parse(Console.ReadLine());
            resultMatrix = MultiplyMatrixByNumber(arr1, m); //умножаем матрицу на число
            PrintMatrix(arr1);
            PrintMatrix(resultMatrix);

            Console.ReadKey();
            Console.Clear();

            //начало операций над 2 матрицами
            int[,] matrix1,
                   matrix2;
            CreateMatrix(out matrix1, out matrix2, rnd); //используем перегрузку создания матриц
            Console.Clear();
            Console.WriteLine("Исходные матрицы: ");
            PrintMatrix(matrix1);
            PrintMatrix(matrix2);
            Console.WriteLine("Сложение двух матриц: ");
            resultMatrix = SumMatrix(matrix1, matrix2); //складываем 2 матрицы
            PrintMatrix(resultMatrix);
            Console.WriteLine();
            Console.WriteLine("Вычитание двух матриц: ");
            resultMatrix = SubtractionMatrix(matrix1, matrix2); //разность 2 матриц
            PrintMatrix(resultMatrix);

            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Перемножение двух матриц: ");
            CreateMultiplyMatrix(out matrix1, out matrix2, rnd);
            Console.Clear();
            Console.WriteLine("Исходные матрицы: ");
            PrintMatrix(matrix1);
            PrintMatrix(matrix2);
            Console.WriteLine("Результат перемножения: ");
            resultMatrix = MultiplyTwoMatrix(matrix1, matrix2);
            PrintMatrix(resultMatrix);

            Console.ReadKey();
        }

        /// <summary>
        /// создание двумерной матрицы с автозаполнением
        /// </summary>
        /// <param name="r">количество строк</param>
        /// <param name="c">количество колонок</param>
        /// <param name="random">переменная для генерации чисел</param>
        /// <returns></returns>
        static int[,] CreateMatrix(Random random)
        {
            int r,  //строки
                c;  //колонки

            while (true) //проверка ввода пользователя
            {
                Console.Write("Введите колчество строк: ");
                r = int.Parse(Console.ReadLine());
                Console.Write("Введите количество колонок: ");
                c = int.Parse(Console.ReadLine());
                if (r <= 0 || c <= 0) continue;
                else break;
            }

            int[,] a = new int[r, c];   //создание матрицы

            for (int i = 0; i < r; i++)    //цикл заполнения значениями матрицу
            {
                for (int l = 0; l < c; l++)
                {
                    a[i, l] = random.Next(10);
                }
            }

            return a;
        }

        /// <summary>
        /// создание двух двумерных матриц с автозаполнением
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        static void CreateMatrix(out int[,] m1, out int[,] m2, Random random)
        {
            int r,  //строки
                c;  //колонки

            while (true) //проверка ввода пользователя
            {
                Console.Write("Введите колчество строк: ");
                r = int.Parse(Console.ReadLine());
                Console.Write("Введите количество колонок: ");
                c = int.Parse(Console.ReadLine());
                if (r <= 0 || c <= 0) continue;
                else break;
            }

            //создаем 2 матрицы указанного размера
            m1 = new int[r, c];
            m2 = new int[r, c];

            for (int i = 0; i < r; i++)    //цикл заполнения значениями матриц
            {
                for (int l = 0; l < c; l++)
                {
                    m1[i, l] = random.Next(10);
                    m2[i, l] = random.Next(10);
                }
            }
        }

        /// <summary>
        /// создание двух матриц с автозаполнением с возможностью перемножения
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        static void CreateMultiplyMatrix(out int[,] m1, out int[,] m2, Random random)
        {
            int r,  //строки первой матрицы
                c,  //колонки первой матрицы, строки второй матрицы
                c2; //колонки второй матрицы

            while (true) //проверка ввода пользователя
            {
                Console.Write("Введите колчество строк для первой матрицы: ");
                r = int.Parse(Console.ReadLine());
                Console.Write("Введите количество колонок для первой матрицы и строк для второй матрицы: ");
                c = int.Parse(Console.ReadLine());
                Console.Write("Введите колчество строк для второй матрицы: ");
                c2 = int.Parse(Console.ReadLine());
                if (r <= 0 || c <= 0 || c2 <= 0) continue;
                else break;
            }

            m1 = new int[r, c];
            m2 = new int[c, c2];

            for (int i = 0; i < r; i++) //перебор строк первого массива
            {
                for (int l = 0; l < c; l++) //перебор колонок первого массива и строк второго массива
                {
                    m1[i, l] = random.Next(10);
                    for (int k = 0; k < c2; k++)    //перебор колонок второго массива
                    {
                        m2[l, k] = random.Next(10);
                    }
                }
            }
        }

        /// <summary>
        /// вывод в консоль входящей матрицы
        /// </summary>
        /// <param name="a"></param>
        static void PrintMatrix(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int l = 0; l < a.GetLength(1); l++)
                {
                    if (l == a.GetUpperBound(1)) Console.Write($"{a[i, l],4}\n");   //печать последнего значения в строке с переходом на новую строку
                    else Console.Write($"{a[i, l],4}");
                }
            }

            Console.WriteLine();
        }

        /// <summary>
        /// умножение матрицы int[,] a на число b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static int[,] MultiplyMatrixByNumber(int[,] a, int b)
        {
            int[,] matrix = new int[a.GetLength(0), a.GetLength(1)];    //создаем матрицу для результата внутри метода

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int l = 0; l < a.GetLength(1); l++)
                {
                    matrix[i, l] = a[i, l] * b; //присвоение значения матрице для операций, соответствующего значения входящей матрицы умноженного на число
                }
            }

            return matrix;
        }

        /// <summary>
        /// сложение двух матриц
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static int[,] SumMatrix(int[,] a, int[,] b)
        {
            int[,] matrix = new int[a.GetLength(0), a.GetLength(1)]; //создаем матрицу для результата внутри метода

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int l = 0; l < a.GetLength(1); l++)
                {
                    matrix[i, l] = a[i, l] + b[i, l];
                }
            }

            return matrix;
        }

        /// <summary>
        /// вычитание двух матриц
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static int[,] SubtractionMatrix(int[,] a, int[,] b)
        {
            int[,] matrix = new int[a.GetLength(0), a.GetLength(1)]; //создаем матрицу для результата внутри метода

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int l = 0; l < a.GetLength(1); l++)
                {
                    matrix[i, l] = a[i, l] - b[i, l];
                }
            }

            return matrix;
        }

        /// <summary>
        /// перемножение двух матриц
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static int[,] MultiplyTwoMatrix(int[,] a, int[,] b)
        {
            int[,] matrix = new int[a.GetLength(0), b.GetLength(1)];    //матрица размерностью количество строк первой матриц и количество колонок вторйо матрицы

            for (int i = 0; i < a.GetLength(0); i++) //перебор строк первой матрицы
            {
                for (int l = 0; l < b.GetLength(1); l++)    //перебор колонок второй матрицы
                {
                    for (int k = 0; k < b.GetLength(0); k++)    //перебор колонок первой матрица и строк второй матрицы
                    {
                        matrix[i, l] += a[i, k] * b[k, l];
                    }
                }
            }

            return matrix;
        }
    }
}
