using System;

internal class Program
{
    public static double Average(int[,] massTwo, int n)
    {
        int sum = 0;
        int m = massTwo.GetLength(1);

        for (int i = 0; i < m; i++)
        {
            sum += massTwo[n, i];
        }

        return (double)sum / m;
    }


    private static void Main(string[] args)
    {
        Console.WriteLine("Введите размерность массива: \n");

        int n = Convert.ToInt32(Console.ReadLine());
        int m = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        int[,] massTwo = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Random random = new Random();
                massTwo[i, j] = random.Next(-100, 100);
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(massTwo[i, j] + "  ");
            }
            Console.WriteLine();
        }

        Console.WriteLine();

        Console.WriteLine("Выберите метод сортировки: ");
        Console.WriteLine("1 - сортировка строк массива по возрастанию значений  ");
        Console.WriteLine("2 - сортировка строки массива по возрастанию среднего \r\nарифметического элементов строк ");

        int a = Convert.ToInt32(Console.ReadLine());

        switch (a)
        {
            case 1:
                Console.WriteLine();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m - 1; j++)
                    {
                        for (int k = 0; k < m - j - 1; k++)
                        {
                            if (massTwo[i, k] > massTwo[i, k + 1]) // меняем местами, если текущий элемент больше следующего
                            {
                                int temp = massTwo[i, k];
                                massTwo[i, k] = massTwo[i, k + 1];
                                massTwo[i, k + 1] = temp;
                            }
                        }
                    }
                }
                break;
            case 2:
                Console.WriteLine();
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - 1 - i; j++)
                    {
                        double average1 = Average(massTwo, j);
                        double average2 = Average(massTwo, j + 1);

                        if (average1 > average2)
                        {
                            // Перемещаем строку с меньшим средним арифметическим вниз
                            for (int k = 0; k < m; k++)
                            {
                                int temp = massTwo[j, k];
                                massTwo[j, k] = massTwo[j + 1, k];
                                massTwo[j + 1, k] = temp;
                            }
                        }
                    }
                }
                break;
        }

        // Вывод отсортированного массива
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(massTwo[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}