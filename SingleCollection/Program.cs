using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        const int FirstArraySize = 5;
        const int SecondArraySize = 5;

        string[] firstArray = GenerateRandomArray(FirstArraySize);
        Console.Write("Первый массив:");
        PrintArray(firstArray);

        string[] secondArray = GenerateRandomArray(SecondArraySize);
        Console.Write("\nВторой массив:");
        PrintArray(secondArray);

        HashSet<string> mergedCollection = new HashSet<string>();

        foreach (string item in firstArray)
        {
            mergedCollection.Add(item);
        }

        foreach (string item in secondArray)
        {
            mergedCollection.Add(item);
        }

        string[] resultArray = new string[mergedCollection.Count];
        mergedCollection.CopyTo(resultArray);

        Console.Write("\nОбъединенный массив:");
        PrintArray(resultArray);

        Console.ReadLine();
    }

    static string[] GenerateRandomArray(int length)
    {
        const int MinValue = 1;
        const int MaxValue = 10;

        Random random = new Random(Guid.NewGuid().GetHashCode());
        string[] resultArray = new string[length];

        for (int i = 0; i < length; i++)
        {
            resultArray[i] = random.Next(MinValue, MaxValue).ToString();
        }

        return resultArray;
    }

    static void PrintArray(string[] array)
    {
        foreach (string item in array)
        {
            Console.Write(item + " ");
        }
    }
}
