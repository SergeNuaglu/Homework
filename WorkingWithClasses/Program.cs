using System;

namespace WorkingWithClasses
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Player player = new Player(100, 40, 25);
            player.ShowInfo();
        }

        class Player
        {
            private int _health;
            private int _armor;
            private int _damage;

            public Player(int health, int armor, int damage)
            {
                _health = health;
                _armor = armor;
                _damage = damage;
            }

            public void ShowInfo()
            {
                Console.WriteLine($"Жизни: {_health}\nБроня: {_armor}\nУрон: {_damage}");
            }
        }
    }
}
