using System;

namespace Практика_Задание_12_2_3
{
    class Практика_Задание_12
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Сортировка перемешиванием");
            Console.Write("Введите длину одномерного массива: ");
            int n = int.Parse(Console.ReadLine());
            //Массив упорядоченный по возрастанию

            Console.WriteLine("Массив упорядоченный по возрастанию");
            int[] ascOrderedArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                ascOrderedArray[i] = i;
                Console.Write($"{ascOrderedArray[i]} ");
            }
            Console.WriteLine();

            Console.WriteLine("Массив упорядоченный по убыванию");
            //Массив упорядоченный по убыванию

            int[] descOrderedArray = new int[n];
            for (int i = n - 1; i >= 0; i--)
            {
                descOrderedArray[i] = i;
                Console.Write($"{descOrderedArray[i]} ");
            }
            Console.WriteLine();

            //Неупорядоченный массив
            Console.WriteLine("Неупорядоченный массив");
            Random rand = new Random();
            int[] unorderedArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                unorderedArray[i] = rand.Next(-100, 100);
                Console.Write($"{unorderedArray[i]} ");
            }
            int[] ascOrderedArray2 = (int [])ascOrderedArray.Clone();
            int[] descOrderedArray2 = (int[])descOrderedArray.Clone();
            int[] unorderedArray2 = (int[])unorderedArray.Clone();

            Console.WriteLine();

            Console.WriteLine("Отсортированный упорядоченный по возрастанию массив: {0}", string.Join(", ", ShakerSort(ascOrderedArray)));
            Console.WriteLine($"Счетчик пересылок: {transfers}");
            Console.WriteLine($"Счетчик сравнений: {comparisons}");
            transfers = 0;
            comparisons = 0;

            Console.WriteLine("Отсортированный упорядоченный по убыванию массив: {0}", string.Join(", ", ShakerSort(descOrderedArray)));
            Console.WriteLine($"Счетчик пересылок: {transfers}");
            Console.WriteLine($"Счетчик сравнений: {comparisons}");
            transfers = 0;
            comparisons = 0;

            Console.WriteLine("Отсортированный неупорядоченный массив: {0}", string.Join(", ", ShakerSort(unorderedArray)));
            Console.WriteLine($"Счетчик пересылок: {transfers}");
            Console.WriteLine($"Счетчик сравнений: {comparisons}");
            transfers = 0;
            comparisons = 0;

            Console.WriteLine("Отсортированный упорядоченный по возрастанию массив: {0}", string.Join(", ", InsertionSort(ascOrderedArray2)));
            Console.WriteLine($"Счетчик пересылок: {transfers}");
            Console.WriteLine($"Счетчик сравнений: {comparisons}");
            transfers = 0;
            comparisons = 0;

            Console.WriteLine("Отсортированный упорядоченный по убыванию массив: {0}", string.Join(", ", InsertionSort(descOrderedArray2)));
            Console.WriteLine($"Счетчик пересылок: {transfers}");
            Console.WriteLine($"Счетчик сравнений: {comparisons}");
            transfers = 0;
            comparisons = 0;

            Console.WriteLine("Отсортированный неупорядоченный массив: {0}", string.Join(", ", InsertionSort(unorderedArray2)));
            Console.WriteLine($"Счетчик пересылок: {transfers}");
            Console.WriteLine($"Счетчик сравнений: {comparisons}");
            transfers = 0;
            comparisons = 0;

            Console.ReadKey();
        }
        //счетчик пересылок (т.е. перемещений элементов с одного места на другое)
        public static int transfers;
        //счетчик сравнений
        public static int comparisons;

        //Сортировка перемешиванием 

        //метод обмена элементов
        static void Swap_2(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
            transfers++;
        }

        //сортировка перемешиванием
        static int[] ShakerSort(int[] array)
        {
            for (var i = 0; i < array.Length / 2; i++)
            {
                var swapFlag = false;
                //проход слева направо
                for (var j = i; j < array.Length - i - 1; j++)
                {
                    comparisons++;
                    if (array[j] > array[j + 1])
                    {
                        Swap_2(ref array[j], ref array[j + 1]);
                        swapFlag = true;
                    }
                }

                //проход справа налево
                for (var j = array.Length - 2 - i; j > i; j--)
                {
                    comparisons++;
                    if (array[j - 1] > array[j])
                    {
                        Swap_2(ref array[j - 1], ref array[j]);
                        swapFlag = true;
                    }
                }

                //если обменов не было выходим
                if (!swapFlag)
                {
                    break;
                }
            }

            return array;
        }
        //Сортировка простыми вставками

        //метод обмена элементов
        static void Swap_3(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
            transfers++;
        }

        //сортировка вставками
        static int[] InsertionSort(int[] array)
        {
            for (var i = 1; i < array.Length; i++)
            {
                var key = array[i];
                var j = i;
                
                while ((j > 1) && (array[j - 1] > key))
                {
                    Swap_3(ref array[j - 1], ref array[j]);
                    transfers++;
                    j--;
                    comparisons++;
                }
                comparisons++;
                array[j] = key;
            }
            return array;
        }
    }
}
