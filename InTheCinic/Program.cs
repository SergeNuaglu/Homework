using System;

namespace InTheCinic
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int timeForOnePerson = 10;
            int peopleCount;
            int waitingTime;
            int hours;
            int minutes;

            Console.Write("Введите кол-во старушек: ");
            peopleCount = Convert.ToInt32(Console.ReadLine());

            waitingTime = peopleCount * timeForOnePerson;
            minutes = waitingTime % 60;
            hours = (waitingTime - minutes) / 60;

            Console.WriteLine($"Вы должны отстоять в очереди {hours} часа и {minutes} минут.");
        }
    }
}
