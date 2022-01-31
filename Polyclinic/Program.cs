using System;

namespace Polyclinic
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int peopleCount;
            int minutesOfWaiting;
            int hoursBeforeAdmission;
            int minutesBeforeAdmission;

            Console.Write("Введите кол-во старушек: ");
            peopleCount = Convert.ToInt32(Console.ReadLine());

            minutesOfWaiting = peopleCount * 10;
            hoursBeforeAdmission = minutesOfWaiting / 60;
            minutesBeforeAdmission = minutesOfWaiting % 60;

            Console.WriteLine($"Вы должны отстоять в очереди {hoursBeforeAdmission} часа и {minutesBeforeAdmission} минут.");
        }
    }
}
