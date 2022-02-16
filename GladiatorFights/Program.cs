using System;
using System.Collections.Generic;

namespace GladiatorFights
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Gladiator gladiator1 = null;
            Gladiator gladiator2 = null;
            Random random = new Random();
            List<Gladiator> gladiators = new List<Gladiator>();

            gladiators.Add(new Spartacus());
            gladiators.Add(new Nero());
            gladiators.Add(new Crixus());
            gladiators.Add(new Flamma());
            gladiators.Add(new Spiculus());

            Arena arena = new Arena(gladiators);

            while (gladiator1 == null || gladiator2 == null)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 13);
                arena.ShowAllGladiators();
                Console.SetCursorPosition(0, 0);


                Console.WriteLine("Выберите гладиатора");

                if (gladiator1==null)
                {
                    arena.ChooseGladiator(ref gladiator1);
                    gladiators.Remove(gladiator1);
                }
                else
                {
                    arena.ChooseGladiator(ref gladiator2);
                }

                Console.ReadKey();
            }

            Console.Clear();
            Console.WriteLine($"{gladiator1.Name}   VS   {gladiator2.Name}");
            Console.WriteLine("Нажмите Enter чтобы начать сражение гладиаторов");
            Console.ReadKey();
            Console.Clear();
            arena.Fight(gladiator1, gladiator2);
            Console.ReadLine();
        }
    }

    class Arena
    {
        private List<Gladiator> _gladiators = new List<Gladiator>();

        public Arena(List<Gladiator> gladiators)
        {
            _gladiators = gladiators;
        }


        public void ShowAllGladiators()
        {
            foreach (var gladiator in _gladiators)
            {
                gladiator.ShowInfo();
            }
        }

        public void ChooseGladiator(ref Gladiator fightGladiator)
        {
            string gladiatorName;

            Console.Write("Введите имя гладиатора: ");
            gladiatorName = Console.ReadLine();

            foreach (var gladiator in _gladiators)
            {
                if (gladiator.Name.ToLower() == gladiatorName.ToLower())
                {
                    Console.WriteLine($"Выбран гладиатор {gladiator.Name}");
                    fightGladiator = gladiator;
                }
            }

            if (fightGladiator == null)
            {
                Console.Write("Такого гладиатора нет");
            }
        }

        public void Fight(Gladiator gladiator1, Gladiator gladiator2)
        {
            bool isFight = true;
            Random random = new Random();

            Console.WriteLine($"{gladiator1.Name} - {gladiator1.Health} здоровья   VS   {gladiator2.Name} - {gladiator2.Health} здоровья\n\n");
            System.Threading.Thread.Sleep(3000);

            while (isFight)
            {
                gladiator1.Attack(gladiator2);
                gladiator2.Attack(gladiator1);
                Console.WriteLine(gladiator1.Health + " / " + gladiator2.Health);

                if (gladiator1.Health <= 0 && gladiator2.Health <= 0)
                {
                    Console.WriteLine("\nОба гладиатора мертвы");
                    isFight = false;
                }
                else if (gladiator1.Health <= 0)
                {
                    Console.WriteLine($"\nГладиатор {gladiator1.Name} убит");
                    isFight = false;
                }
                else if (gladiator2.Health <= 0)
                {
                    Console.WriteLine($"\nГладиатор {gladiator2.Name} убит");
                    isFight = false;
                }
            }
        }
    }

    class Gladiator
    {
        protected int Armor;
        protected int Damage;
        protected int ReactionSpeed;

        public string Name { get; private set; }

        public float Health { get; private set; }

        public Gladiator(string name, int health, int armor, int damage)
        {
            Name = name;
            Health = health;
            Armor = armor;
            Damage = damage;

            SetReactionSpeed();
        }

        public void Attack(Gladiator defensiveGladiator)
        {
            Console.Write($"{Name} нанес удар - ");

            if (defensiveGladiator.IsDefend() == false)
            {
                TakeDamage(defensiveGladiator);
                Console.Write($"и забрал {Damage} жизней у соперника");
            }
            else
            {
                Console.Write($"{defensiveGladiator.Name} успел защититься от удара щитом");
            }
            Console.WriteLine();
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Гладиатор {Name}: Здоровье - {Health}, Броня - {Armor}, Урон - {Damage}, Скорость реакции - {ReactionSpeed}");
        }

        protected virtual void TakeDamage(Gladiator defensiveGladiator)
        {
            defensiveGladiator.Health -= Damage - defensiveGladiator.Armor;
        }

        private bool IsDefend()
        {
            int minProtectionSpeed = 0;
            int maxProtectionSpeed = 100;
            Random random = new Random();

            if (ReactionSpeed >= random.Next(minProtectionSpeed, maxProtectionSpeed))
            {
                CoverWithShield();
                return true;
            }

            return false;
        }

        private void SetReactionSpeed()
        {
            int minReactionSpeed = 0;
            int maxReactionSpeed = 100;
            Random random = new Random();

            ReactionSpeed = random.Next(minReactionSpeed, maxReactionSpeed);
        }

        private void CoverWithShield()
        {
            int shieldPower = 2;
            Armor += shieldPower;
        }
    }

    class Spartacus : Gladiator
    {
        public Spartacus() : base("SPARTACUS", 140, 5, 20) { }

        protected override void TakeDamage(Gladiator defensiveGladiator)
        {

            BeatWithSword();
            base.TakeDamage(defensiveGladiator);
        }

        private void BeatWithSword()
        {
            int swordDamage = 5;
            int swordWeight = 5;

            Damage += swordDamage;
            ReactionSpeed -= swordWeight;
        }
    }

    class Nero : Gladiator
    {
        public Nero() : base("NERO", 110, 8, 30) { }

        protected override void TakeDamage(Gladiator defensiveGladiator)
        {
            StabWithDagger();
            base.TakeDamage(defensiveGladiator);
        }

        private void StabWithDagger()
        {
            int daggerDamage = 3;
            int daggerWeight = 2;

            Damage += daggerDamage;
            ReactionSpeed -= daggerWeight;
        }
    }

    class Crixus : Gladiator
    {

        public Crixus() : base("CRICUS", 100, 7, 35) { }

        protected override void TakeDamage(Gladiator defensiveGladiator)
        {
            HitWithTrident();
            base.TakeDamage(defensiveGladiator);
        }

        private void HitWithTrident()
        {
            int tridentDamage = 6;
            int tridentWeight = 6;

            Damage += tridentDamage;
            ReactionSpeed -= tridentWeight;
        }
    }
    class Flamma : Gladiator
    {
        public Flamma() : base("FLAMMA", 150, 5, 15) { }

        protected override void TakeDamage(Gladiator defensiveGladiator)
        {
            Baton();
            base.TakeDamage(defensiveGladiator);
        }

        private void Baton()
        {
            int batonDamage = 2;
            int batonWeight = 4;

            Damage += batonDamage;
            ReactionSpeed -= batonWeight;
        }
    }

    class Spiculus : Gladiator
    {
        public Spiculus() : base("SPICULUS", 80, 10, 60) { }

        protected override void TakeDamage(Gladiator defensiveGladiator)
        {
            ThrowSpear();
            base.TakeDamage(defensiveGladiator);
        }

        private void ThrowSpear()
        {
            int spearDamage = 7;
            int spearWeight = 7;

            Damage += spearDamage;
            ReactionSpeed -= spearWeight;
        }
    }
}

