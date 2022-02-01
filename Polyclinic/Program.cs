using System;

namespace Polyclinic
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int peopleCount;
            int minutesPerPerson = 10;
            int totalMinutes;
            int hoursBeforeAdmission;
            int minutesBeforeAdmission;

            Console.Write("Введите кол-во старушек: ");
            peopleCount = Convert.ToInt32(Console.ReadLine());

            totalMinutes = peopleCount * minutesPerPerson;
            hoursBeforeAdmission = totalMinutes / 60;
            minutesBeforeAdmission = totalMinutes % 60;

            Console.WriteLine($"Вы должны отстоять в очереди {hoursBeforeAdmission} часа и {minutesBeforeAdmission} минут.");
        }
    }
}
<<<<<<< HEAD
=======

>>>>>>> c6c5898413aeef46415c1e29a05eb92c6421777a
