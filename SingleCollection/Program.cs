using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int firstArraySize = 5;
        int secondArraySize = 5;

        HashSet<string> mergedCollection = new HashSet<string>();

        string[] firstArray = GenerateRandomArray(firstArraySize);
        Console.Write("Первый массив:");
        PrintCollection(firstArray);
        MergeArrayToSingleCollection(firstArray, mergedCollection);

        string[] secondArray = GenerateRandomArray(secondArraySize);
        Console.Write("\nВторой массив:");
        PrintCollection(secondArray);
        MergeArrayToSingleCollection(secondArray, mergedCollection);

        Console.Write("\nОбъединенный массив:");
        PrintCollection(mergedCollection);

        Console.ReadLine();
    }

    static void MergeArrayToSingleCollection(string[] array, HashSet<string> singleCollection)
    {
        foreach (string value in array)
        {
            singleCollection.Add(value);
        }
    }

    static string[] GenerateRandomArray(int length)
    {
        int minValue = 1;
        int maxValue = 10;

        Random random = new Random(Guid.NewGuid().GetHashCode());
        string[] resultArray = new string[length];

        for (int i = 0; i < length; i++)
        {
            resultArray[i] = random.Next(minValue, maxValue).ToString();
        }

        return resultArray;
    }

    static void PrintCollection(IEnumerable<string> collection)
    {
        foreach (string value in collection)
        {
            Console.Write(value + " ");
        }
    }
}
