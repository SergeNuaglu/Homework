using System;

namespace MageVsBoss
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            int timeCount = 0;
            int powerHit = 2;
            string spell;
            bool isFight = false;
            bool isMagnetWork;
            bool isMirrorWork = true;
            bool isStoneWork = true;
            bool isFireWork = true;
            bool isPlay = true;
            int mageHealth = 100;
            int fireDamage = 35;
            int staffDamage = 5;
            int mirrorRefillTime = 3;
            int stoneRefillTime = 2;
            int fireRefillTime = 6;
            int nextMirrorTime = timeCount;
            int nextStoneTime = timeCount;
            int nextFireTime = timeCount;
            int timeBeforeUseMirror = 0;
            int timeBeforeUseStone = 0;
            int timeBeforeUseFire = 0;
            int bossHealth = 180;
            int bossDamage = 15;
            int magnetPower = 1;
            int magnetWorkingChance = 25;
            int minMagnetWorkingChance = 0;
            int maxMagnetWorkingChance = 100;

            Console.WriteLine("MageVsBoss\n");
            Console.WriteLine("После 333 лет странствий по межгалоктическим коридорам" +
                "\nваша сущность в теле теневого мага была заслана на задворки вселенной №18273, " +
                "\nкоторую паработил Квазихрон - похититель времени. Он подменил живое время искусственным квазивременем" +
                "\nи теперь с помощью волнового магнита может влиять на него." +
                "\nВы настигли Квазихрона врасплох на планете Тюй. " +
                "\nВам на руку то, что именно здесь волновой магнит работает с перебоями и способен отбросывать квазивремя только на несколько" +
                "\nквазисекунд назад." +
                "\nТеневой маг владеет 4 - мя мощными заклинаниями." +
                "\nВот только могут возникнуть проблемы с восполнением их энергии, если волновой магнит включен...\n");
            Console.WriteLine("Нажмите любую клавишу чтобы вступить в схватку с Квазихроном...");
            Console.ReadKey();

            while (isPlay)
            {
                Console.Clear();
                Console.WriteLine("Заклинание / Руна   /  Квазисек. до заряда  / Урон / Описание" +
                    "\nЗЕРКАЛО      q         " + timeBeforeUseMirror +
                    "                      " + (bossDamage + staffDamage) + "     Зеркальный щит. Отражает обратно на врага его аткаку в связке с магией посоха" +
                    "\nКАМЕНЬ       w         " + timeBeforeUseStone +
                    "                      " + staffDamage * powerHit + "     Каменные тиски. Обездвиживают врага и дает возможность магу использовать усиленный удар магического посоха" +
                    "\nОГОНЬ        e         " + timeBeforeUseFire +
                    "                      " + fireDamage + "     Огненное дыхание. Испепеляет все на своем пути" +
                    "\nПОСОХ        r         - " +
                    "                     " + staffDamage + "      Верный магический посох. Отнимает мало хп, но никогда не истощается\n");
                Console.WriteLine("ВРЕМЯ:     " + timeCount + "-я   квазисек." +
                    "\nКВАЗИХРОН: " + bossHealth + "хп" +
                    "\nМАГ:       " + mageHealth + "хп\n");
                Console.Write("Произнесите руну заклинания: ");
                spell = Console.ReadLine();

                switch (spell)
                {
                    case "q":
                        if (isMirrorWork)
                        {
                            bossHealth -= (bossDamage + staffDamage);
                            nextMirrorTime = timeCount + mirrorRefillTime;
                            isFight = true;
                            isMirrorWork = false;
                        }
                        break;
                    case "w":
                        if (isStoneWork)
                        {
                            bossHealth -= staffDamage * powerHit;
                            nextStoneTime = timeCount + stoneRefillTime;
                            isFight = true;
                            isStoneWork = false;
                        }
                        break;
                    case "e":
                        if (isFireWork)
                        {
                            bossHealth -= fireDamage;
                            mageHealth -= bossDamage;
                            nextFireTime = timeCount + fireRefillTime;
                            isFight = true;
                            isFireWork = false;
                        }
                        break;
                    case "r":
                        bossHealth -= staffDamage;
                        mageHealth -= bossDamage;
                        isFight = true;
                        break;
                    default:
                        isFight = false;
                        break;
                }

                if (isFight == false)
                {
                    Console.WriteLine("Еще мало энергии или неправильно произнесли руну...");
                    Console.WriteLine("Any Key чтобы попробовать снова");
                    Console.ReadKey();
                }

                if (isFight)
                {
                    isMagnetWork = magnetWorkingChance >= random.Next(minMagnetWorkingChance, maxMagnetWorkingChance);

                    if (isMagnetWork && timeCount != 0)
                    {
                        Console.WriteLine("СРАБОТАЛ ВОЛНОВОЙ МАГНИТ!");

                        if (timeCount >= magnetPower)
                        {
                            Console.WriteLine("Any Key чтобы перенестись на " + magnetPower + " квазисекунды назад");
                            Console.ReadKey();
                            timeCount = --timeCount - magnetPower;
                        }
                        else
                        {
                            Console.WriteLine("Any Key чтобы перенестись на " + timeCount + " квазисекунды назад");
                            Console.ReadKey();
                            timeCount -= --timeCount;
                        }
                    }

                    if (isMirrorWork == false)
                    {
                        timeBeforeUseMirror = nextMirrorTime - timeCount;

                        if (timeBeforeUseMirror <= 0)
                        {
                            isMirrorWork = true;
                        }
                    }

                    if (isStoneWork == false)
                    {
                        timeBeforeUseStone = nextStoneTime - timeCount;

                        if (timeBeforeUseStone <= 0)
                        {
                            isStoneWork = true;
                        }
                    }

                    if (isFireWork == false)
                    {
                        timeBeforeUseFire = nextFireTime - timeCount;

                        if (timeBeforeUseFire <= 0)
                        {
                            isFireWork = true;
                        }
                    }

                    timeCount++;
                    isMagnetWork = false;
                    isFight = false;
                }

                if (mageHealth <= 0 || bossHealth <= 0)
                {
                    isPlay = false;
                }
            }

            Console.Clear();

            if (mageHealth <= 0 && bossHealth <= 0)
            {
                Console.WriteLine("Вы одолели Квазихрона ценой собственной жизни..");
            }
            else if (bossHealth <= 0)
            {
                Console.WriteLine("Ура! Благодаря вам вселенная №18273 освобождена от ига Квазихрона!");
            }
            else if (mageHealth <= 0)
            {
                Console.WriteLine("Увы! Квазихрон вам не по зубам!");
            }

            Console.ReadKey();
        }
    }
}
