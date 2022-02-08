using System;
using System.Collections.Generic;

namespace Dictionary
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Dictionary<string, string> humanStructure = new Dictionary<string, string>();

            humanStructure.Add("Голова", "В ней находятся мозг, органы зрения, вкуса, обоняния, слуха и рот.");
            humanStructure.Add("Шея", "Соединяет голову с туловищем.");
            humanStructure.Add("Туловище", "Тело без головы и конечностей.");
            humanStructure.Add("Рука", "Верхняя конечность человека от плеча до пальцев, а также от запястья до пальцев.");
            humanStructure.Add("Нога", "Одна из двух нижних конечностей.");

            Console.Write("Введите часть тела: ");
            SearchValues(Console.ReadLine(), humanStructure);
        }

        static void SearchValues(string word, Dictionary<string,string> dictionary)
        {
            if (dictionary.ContainsKey(word))
            {
                Console.WriteLine(word + " - " + dictionary[word]);
            }
            else
            {
                Console.WriteLine("Слово не найдено");
            }
        }
    }
}
