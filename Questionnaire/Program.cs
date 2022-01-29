using System;

namespace Questionnaire
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string name;
            int age;
            string horoscopeSign;
            string placeOfWork;

            Console.WriteLine("Здравствуйте! Заполните, пожалуйста, форму:");
            Console.Write("Как вас зовут?: ");
            name = Console.ReadLine();
            Console.Write("Сколько вам лет?: ");
            age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Кто вы по гороскопу?: ");
            horoscopeSign = Console.ReadLine();
            Console.Write("Где вы работаете?: ");
            placeOfWork = Console.ReadLine();

            Console.WriteLine($"Вас зовут {name}, вам {age} год, вы {horoscopeSign} и работаете {placeOfWork}.");
        }
    }
}
