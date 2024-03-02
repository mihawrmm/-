using System;

class Program
{
    static void Main(string[] args)
    {
        int[,] array2D = {
            { 1, 2, 3 },
            { 4, -1, -2 },
            { -3, -4, -5 }
        };

        Console.WriteLine("Двовимірний масив:");
        for (int i = 0; i < array2D.GetLength(0); i++)
        {
            for (int j = 0; j < array2D.GetLength(1); j++)
            {
                Console.Write(array2D[i, j] + " ");
            }
            Console.WriteLine();
        }

        int lowerRight = array2D[array2D.GetLength(0) - 1, array2D.GetLength(1) - 1];
        int lowerLeft = array2D[array2D.GetLength(0) - 1, 0];
        Console.WriteLine($"Елемент у нижньому правому куті: {lowerRight}");
        Console.WriteLine($"Елемент у нижньому лівому куті: {lowerLeft}");
        Console.WriteLine($"Менший елемент: {(lowerRight < lowerLeft ? lowerRight : lowerLeft)}");

        int upperRight = array2D[0, array2D.GetLength(1) - 1];
        Console.WriteLine($"Елемент у верхньому правому куті: {upperRight}");
        Console.WriteLine($"Менший елемент: {(upperRight < lowerLeft ? upperRight : lowerLeft)}");
    }
}

