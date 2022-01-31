using System;

namespace Polyclinic
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int onePersonTime = 10;
            int peopleCount;
            int waitingTime;
            int hour;
            int minute;

            Console.Write("Введите кол-во старушек: ");
            peopleCount = Convert.ToInt32(Console.ReadLine());

            waitingTime = peopleCount * onePersonTime;
            //60 minutes in one hour
            hour = waitingTime / 60;
            minute = waitingTime % 60;

            Console.WriteLine($"Вы должны отстоять в очереди {hour} часа и {minute} минут.");
        }
    }
}