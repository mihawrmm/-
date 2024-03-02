using System;
class Program
{
    static void Main(string[] args)
    {
        double[] array = { 3.5, -2.7, 0, 1.2, 5.1, -4.3, 2.8, -6.1, 0.9 };

        double minElement = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < minElement)
            {
                minElement = array[i];
            }
        }
       
        double sumBetweenPositives = 0;
        int firstPositiveIndex = -1;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > 0)
            {
                if (firstPositiveIndex == -1)
                {
                    firstPositiveIndex = i;
                }
                else
                {
                    for (int j = firstPositiveIndex + 1; j < i; j++)
                    {
                        sumBetweenPositives += array[j];
                    }
                    break;
                }
            }
        }

        Array.Sort(array, (x, y) => (x == 0 && y != 0) ? -1 : ((x != 0 && y == 0) ? 1 : 0));

        Console.WriteLine($"Мінімальний елемент масиву: {minElement}");
        Console.WriteLine($"Сума елементів масиву, розташованих між першим і другим додатніми елементами: {sumBetweenPositives}");
        Console.WriteLine("Перетворений масив:");
        foreach (var item in array)
        {
            Console.Write($"{item} ");
        }
    }
}

