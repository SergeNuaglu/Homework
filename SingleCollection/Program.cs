using System;
using System.Collections.Generic;

namespace SingleCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int maximumRandomNumber = 10;

            Console.Write("Первый массив: ");
            int generatedNumbers = 5;
            var firstArray = new string[generatedNumbers];
            FillArray(firstArray, random, generatedNumbers, maximumRandomNumber);

            Console.Write("Второй массив: ");
            generatedNumbers = 4;
            var secondArray = new string[generatedNumbers];
            FillArray(secondArray, random, generatedNumbers, maximumRandomNumber);

            List<string> mergeList = MergeArrays(true, firstArray, secondArray);

            Console.Write("Объединённая коллекция: {");

            for (var i = 0; i < mergeList.Count; i++)
            {
                Console.Write($"\"{mergeList[i]}\"");

                if (i != mergeList.Count - 1)
                {
                    Console.Write(", ");
                }
            }

            Console.WriteLine("}");

            Console.ReadKey();
        }

        private static List<string> MergeArrays(bool removeDuplicates, params string[][] arrays)
        {
            var resultList = new List<string>();

            foreach (string[] dataArray in arrays)
            {
                foreach (string data in dataArray)
                {
                    var isDataAdd = true;

                    if (removeDuplicates)
                    {
                        for (var i = 0; i < resultList.Count; i++)
                        {
                            if (resultList[i] == data)
                            {
                                isDataAdd = false;
                                break;
                            }
                        }
                    }

                    if (isDataAdd)
                    {
                        resultList.Add(data);
                    }
                }
            }

            return resultList;
        }

        private static void FillArray(string[] stringsArray, Random random, int generatedNumbers, int maximumRandomNumber)
        {
            Console.Write("{");

            for (int i = 0; i < generatedNumbers; i++)
            {
                int randomNumber = random.Next(maximumRandomNumber);
                stringsArray[i] = randomNumber.ToString();

                Console.Write($"\"{randomNumber}\"");

                if (i != generatedNumbers - 1)
                {
                    Console.Write(", ");
                }
            }

            Console.WriteLine("}");
        }
    }
}
