using System;
using System.Collections.Generic;

namespace GladiatorFights
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<Gladiator> gladiators = new List<Gladiator>();

            gladiators.Add(new Spartacus());
            gladiators.Add(new Nero());
            gladiators.Add(new Crixus());
            gladiators.Add(new Flamma());
            gladiators.Add(new Spiculus());
            Arena arena = new Arena(gladiators);
            arena.ChooseGladiator();
            Console.WriteLine("Нажмите Enter чтобы начать сражение гладиаторов");
            Console.ReadKey();
            Console.Clear();
            arena.Fight();
            arena.ShowWinner();
            Console.ReadKey();
        }
    }

    class Arena
    {
        private Gladiator _gladiator1;
        private Gladiator _gladiator2;
        private List<Gladiator> _gladiators = new List<Gladiator>();

        public Arena(List<Gladiator> gladiators)
        {
            _gladiators = gladiators;
        }

        public void ChooseGladiator()
        {
            Gladiator fightGladiator1 = null;
            Gladiator fightGladiator2 = null;
            string gladiatorName;

            while (fightGladiator1 == null || fightGladiator2 == null)
            {
                Console.Clear();
                ShowAllGladiators();               
                Console.WriteLine("\n\nВыберите гладиаторов");
                Console.Write("\nВведите имя гладиатора: ");
                gladiatorName = Console.ReadLine();

                foreach (var gladiator in _gladiators)
                {
                    if (gladiator.Name.ToLower() == gladiatorName.ToLower())
                    {
                        if (fightGladiator1==null)
                        {
                            Console.WriteLine($"Выбран гладиатор {gladiator.Name}");
                            fightGladiator1 = gladiator;
                        }
                        else
                        {
                            Console.WriteLine($"Выбран гладиатор {gladiator.Name}");
                            fightGladiator2 = gladiator;
                        }
                    }
                }
              
                Console.ReadKey();
            }

            _gladiator1 = fightGladiator1;
            _gladiator2 = fightGladiator2;
        }

        public void Fight()
        {
            bool isFight = true;

            Console.WriteLine($"{_gladiator1.Name} - {_gladiator1.Health} здоровья   VS   {_gladiator2.Name} - {_gladiator2.Health} здоровья\n\n");

            while (isFight)
            {
                _gladiator1.Attack(_gladiator2);
                _gladiator2.Attack(_gladiator1);
                Console.WriteLine(_gladiator1.Health + " / " + _gladiator2.Health);

                if (_gladiator1.Health <= 0 || _gladiator2.Health <= 0)
                {
                    isFight = false;
                }
            }
        }

        public void ShowWinner()
        {
            if (_gladiator1.Health <= 0 && _gladiator2.Health <= 0)
            {
                Console.WriteLine("\nОба гладиатора мертвы");
            }
            else if (_gladiator1.Health <= 0)
            {
                Console.WriteLine($"\nГладиатор {_gladiator1.Name} убит");
            }
            else if (_gladiator2.Health <= 0)
            {
                Console.WriteLine($"\nГладиатор {_gladiator2.Name} убит");
            }
        }

        private void ShowAllGladiators()
        {
            foreach (var gladiator in _gladiators)
            {
                gladiator.ShowInfo();
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
                defensiveGladiator.TakeDamage(Damage);                
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

        protected virtual void TakeDamage(int damage)
        {
            Health -= damage + Armor;
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
            int maxReactionSpeed = 60;
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

        protected override void TakeDamage(int damage)
        {

            BeatWithSword();
            base.TakeDamage(Damage);
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

        protected override void TakeDamage(int damage)
        {
            StabWithDagger();
            base.TakeDamage(Damage);
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

        protected override void TakeDamage(int damage)
        {
            HitWithTrident();
            base.TakeDamage(Damage);
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

        protected override void TakeDamage(int damage)
        {
            Baton();
            base.TakeDamage(Damage);
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

        protected override void TakeDamage(int damage)
        {
            ThrowSpear();
            base.TakeDamage(Damage);
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

