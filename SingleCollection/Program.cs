using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        const int FirstArraySize = 5;
        const int SecondArraySize = 5;

        HashSet<string> mergedCollection = new HashSet<string>();

        string[] firstArray = GenerateRandomArray(FirstArraySize);
        Console.Write("Первый массив:");
        PrintCollection(firstArray);
        MergeArrayToSingleCollection(firstArray, mergedCollection);

        string[] secondArray = GenerateRandomArray(SecondArraySize);
        Console.Write("\nВторой массив:");
        PrintCollection(secondArray);
        MergeArrayToSingleCollection(secondArray, mergedCollection);

        Console.Write("\nОбъединенный массив:");
        PrintCollection(mergedCollection);

        Console.ReadLine();
    }

    static void MergeArrayToSingleCollection(string[] array, HashSet<string> singleCollection)
    {
        foreach (string item in array)
        {
            singleCollection.Add(item);
        }
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

    static void PrintCollection(IEnumerable<string> collection)
    {
        foreach (string item in collection)
        {
            Console.Write(item + " ");
        }
    }
}
