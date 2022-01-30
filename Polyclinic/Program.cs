using System;

namespace Polyclinic
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int timeForOnePerson = 10;
            int oldWomenCount;
            int waitingTime;
            int hour;
            int minute;

            Console.Write("Введите кол-во старушек: ");
            oldWomenCount = Convert.ToInt32(Console.ReadLine());

            waitingTime = oldWomenCount * timeForOnePerson;
            hour = waitingTime / 60;
            minute = waitingTime % 60;

            Console.WriteLine($"Вы должны отстоять в очереди {hour} часа и {minute} минут.");
        }
    }
}