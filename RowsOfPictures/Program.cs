using System;

namespace RowsOfPictures
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int picturesCount = 52;
            int picturesInRow = 3;
            int filledRows;
            int picturesOverflow;

            filledRows = picturesCount / picturesInRow;
            picturesOverflow = picturesCount % picturesInRow;

            Console.WriteLine("Количество заполненных рядов: " + filledRows);
            Console.WriteLine("Количество картинок сверх меры: " + picturesOverflow);
        }
    }
}
