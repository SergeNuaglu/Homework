using System;
using System.Collections.Generic;

namespace War
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Battlefield battlefield = new Battlefield();

            battlefield.CreatePlatoons();
            battlefield.MakeWar();
            battlefield.ShowWinner();
            Console.ReadKey();
        }
    }

    class Battlefield
    {
        private Platoon _platoon1;
        private Platoon _platoon2;

        public void CreatePlatoons()
        {
            bool isReady = false;
            int platoonNumber = 1;
            Platoon platoon1 = null;
            Platoon platoon2 = null;

            while (isReady == false)
            {
                List<Warrior> warriors = new List<Warrior>();

                warriors.Add(new Commander());
                warriors.Add(new RifleShooter());
                warriors.Add(new RifleShooter());
                warriors.Add(new RifleShooter());
                warriors.Add(new MachineGunShooter());
                warriors.Add(new GrenadeGunShooter());
                warriors.Add(new TankShooter());

                if (platoon1 == null)
                {
                    platoon1 = new Platoon(warriors,platoonNumber++);
                }
                else
                {
                    platoon2 = new Platoon(warriors,platoonNumber);
                    isReady = true;
                }
            }

            _platoon1 = platoon1;
            _platoon2 = platoon2;
        }

        public void MakeWar()
        {
            bool isWar = true;

            while (isWar)
            {
                Console.Clear();
                ShowStatistics(_platoon1);
                _platoon1.Fight(_platoon2);
                Console.ReadKey();
                ShowStatistics(_platoon2);
                _platoon2.Fight(_platoon1);

                if (_platoon1.GetTotalHealth() <= 0 || _platoon2.GetTotalHealth() <= 0)
                {
                    isWar = false;
                }

                Console.ReadKey();
            }
        }

        public void ShowStatistics(Platoon platoon)
        {
            Console.WriteLine($"Статистика {platoon.Number}-ого взвода:  Общее состояние - {platoon.GetTotalHealth()}\n");
            platoon.ShowAllWarriors();
        }
     
        public void ShowWinner()
        {
            int totalHealth1 = _platoon1.GetTotalHealth();
            int totalHealth2 = _platoon2.GetTotalHealth();

            if (totalHealth1 <= 0 && totalHealth2 <= 0)
            {
                Console.WriteLine("\nОба взвода уничтожили друг друга...");
            }
            else if (totalHealth1 <= 0)
            {
                Console.WriteLine($"\n{_platoon1.Number}-й взвод погиб...");
            }
            else if (totalHealth2 <= 0)
            {
                Console.WriteLine($"\n{_platoon2.Number}-й взвод погиб...");
            }
        }
    }

    class Platoon
    {
        private Commander _commander;
        private int _totalHealth;
        private List<Warrior> _warriors = new List<Warrior>();

        public int Number { get; private set; }



        public Platoon(List<Warrior> warriors, int number)
        {
            _warriors = warriors;
            Number = number;
        }

        public void ShowAllWarriors()
        {
            foreach (var warrior in _warriors)
            {
                warrior.ShowInfo();
            }
            Console.WriteLine();
        }

        public int GetTotalHealth()
        {
            int totalHealth = 0;

            foreach (var warrior in _warriors)
            {
                totalHealth += warrior.Health;
            }

            _totalHealth = totalHealth;
            return _totalHealth;
        }

        public void Fight(Platoon enemyPlatoon)
        {
            if (IsCommanderAlive())
            {
                if (_commander.IsOrderAttack(_totalHealth))
                {
                    Console.WriteLine($"{_commander.Position} {Number}-ого взвода: В АТАКУ!\n");
                    Attack(enemyPlatoon);
                }
                else
                {
                    Console.WriteLine($"\n{_commander.Position} {Number}-ого взвода: В ОКОПЫ!\n");
                    Defend();
                }
            }
            else
            {
                Console.WriteLine($"{Number} взвод идет в атаку без командира");
                Attack(enemyPlatoon);
            }
        }

        private bool IsCommanderAlive()
        {
            foreach (var warrior in _warriors)
            {
                if (warrior is Commander)
                {
                    _commander = (Commander)warrior;
                    return true;
                }
            }

            return false;
        }

        private void Attack(Platoon enemyPlatoon)
        {
            int totalDamage = 0;
            
            foreach (var warrior in _warriors)
            {
                totalDamage += warrior.GetShotsDamage();
            }

            Console.WriteLine();
            enemyPlatoon.TakeTotalDamage(totalDamage);
        }

        private void Defend()
        {
            foreach (var warrior in _warriors)
            {
                warrior.IncreaseHealth();
            }
        }

        private void TakeTotalDamage(int totalDamage)
        {
            Random random = new Random();
            int index;
            int damagePerIteration = 1;

            for (int i = 1; i < totalDamage; i++)
            {
                if (_warriors.Count != 0)
                {
                    index = random.Next(0, _warriors.Count - 1);
                    _warriors[index].TakeDamage(damagePerIteration);

                    if (_warriors[index].Health <= 0)
                    {
                        ShowDeadWarrior(_warriors[index]);
                    }
                }
            }
        }

        private void ShowDeadWarrior(Warrior warrior)
        {
            Console.WriteLine($"{warrior.Position} {Number}-ого взвода погиб");
            _warriors.Remove(warrior);
        }
    }

    class Warrior
    {
        protected Weapon Weapon;
        protected int Armor;

        public int Health { get; private set; }

        public string Position { get; private set; }

        public Warrior(string position, Weapon weapon, int health, int armor)
        {
            Position = position;
            Weapon = weapon;
            Health = health;
            Armor = armor;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Position} / {Health}хп");
        }

        public int GetShotsDamage()
        {
            Random random = new Random();
            int shotsCount = 0;
            int minShotsCount = 1;
            int maxShotsCount = Weapon.ShotsBeforeRecharge;

            if (Weapon.ShotsBeforeRecharge <= 0)
            {
                Console.WriteLine($"{Position} перезаряжается");
                Weapon.Recharge();
            }
            else
            {
                shotsCount = random.Next(minShotsCount, maxShotsCount);
                Weapon.SetShotsBeforeRecharge(shotsCount);
                Console.WriteLine($"{Position} сделал {shotsCount} выстрелов");
            }

            return shotsCount * Weapon.Damage;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public void IncreaseHealth()
        {
            int startingHealth = 100;

            if (Health < startingHealth)
            {
                Health += Armor;
            }
        }            
    }

    class Commander : Warrior
    {
        public Commander() : base("Командир", new Pistol(), 100, 30) { }

        public bool IsOrderAttack(int platoonHealth)
        {
            Random random = new Random();
            int minFearLevel = 0;
            int maxFearLevel = platoonHealth;
            int fearLevel;

            fearLevel = random.Next(minFearLevel, maxFearLevel);

            if (fearLevel < platoonHealth - fearLevel)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class RifleShooter : Warrior
    {
        public RifleShooter() : base("Стрелок", new Rifle(), 100, 10) { }
    }

    class MachineGunShooter : Warrior
    {
        public MachineGunShooter() : base("Пулеметчик", new MachineGun(), 100, 7) { }
    }

    class GrenadeGunShooter : Warrior
    {
        public GrenadeGunShooter() : base("Гранатометчик", new GrenadeGun(), 100, 5) { }
    }

    class TankShooter : Warrior
    {
        public TankShooter() : base("Танкист", new Tank(), 100, 25) { }
    }

    class Weapon
    {
        private int _bulletsInBoth;

        public int Damage { get; private set; }

        public int ShotsBeforeRecharge { get; private set; }


        public Weapon(int damage, int bulletInBoth)
        {
            Damage = damage;
            _bulletsInBoth = bulletInBoth;
            ShotsBeforeRecharge = bulletInBoth;
        }


        public void SetShotsBeforeRecharge(int shotsCount)
        {
            ShotsBeforeRecharge -= shotsCount;
        }

        public void Recharge()
        {
            ShotsBeforeRecharge = _bulletsInBoth;
        }
    }

    class Pistol : Weapon
    {
        public Pistol() : base(2, 8) { }
    }

    class Rifle : Weapon
    {
        public Rifle() : base(4, 30) { }
    }

    class MachineGun : Weapon
    {
        public MachineGun() : base(5, 45) { }
    }

    class GrenadeGun : Weapon
    {
        public GrenadeGun() : base(10, 2) { }
    }

    class Tank : Weapon
    {
        public Tank() : base(20, 1) { }
    }
}
