// Задача 1: Задайте двумерный массив. Напишите программу, 
// которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

int[,] CreateBaseArray(int row, int col, int min, int max)
{
    int[,] array = new int[row, col];
    Random rnd = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++) 
        {
            array[i, j] = rnd.Next(min, max);
        }
    }
    return array;
}

int[,] SortedRowArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            int minPosition = j;
            for (int k = j + 1; k < array.GetLength(1); k++)
            {
                if (array[i, k] > array[i, minPosition]) minPosition = k;
            }
            int tmp = array[i, j];
            array[i, j] = array[i, minPosition];
            array[i, minPosition] = tmp;
        }

    }
    return array;
}


void PrintArray(int[,] array)
{
    // Console.WriteLine();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.WriteLine();
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j] + " ");
        }
    }
    Console.WriteLine();
}

int row = 3;
int col = 4;
int min = 1;
int max = 10;

int[,] baseArray = CreateBaseArray(row, col, min, max);
Console.WriteLine("Базовый массив: ");
PrintArray(baseArray);
Console.WriteLine();
Console.WriteLine("Упорядоченный в строках массив: ");
PrintArray(SortedRowArray(baseArray));
Console.WriteLine();