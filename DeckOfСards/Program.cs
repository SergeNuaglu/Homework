using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("============= МЕНЮ =============");
            Console.WriteLine("1. Вытянуть карту");
            Console.WriteLine("2. Информация о вытянутых картах");
            Console.WriteLine("3. Выход");
            Console.WriteLine("================================");

            var game = new Game();

            var selectedMenu = '\0';

            while (selectedMenu != '3')
            {
                Console.Write("\nВыберите пункт меню: ");
                selectedMenu = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (selectedMenu)
                {
                    case '1':
                        game.GivePlayerRandomCard();
                        break;
                    case '2':
                        game.ShowPlayerCards();
                        break;
                    default:
                        Console.WriteLine("Такого пункта меню не существует");
                        break;
                }
            }
        }
    }

    internal sealed class Game
    {
        private readonly Deck _deck = new Deck();
        private readonly Player _player = new Player();

        public Game()
        {
            _deck.Form();
        }

        public void GivePlayerRandomCard()
        {
            Card card = _deck.PickUpRandomCard();

            if (card == null)
            {
                Console.WriteLine("В колоде закончились карты");
            }
            else
            {
                _player.PullCard(card);
            }
        }

        public void ShowPlayerCards()
        {
            _player.ShowPullCardsInformation();
        }
    }

    internal sealed class Player
    {
        private readonly Deck _deck = new Deck();

        public void PullCard(Card card)
        {
            _deck.AddCard(card);
            Console.WriteLine($"Вытянута {card}");
        }

        public void ShowPullCardsInformation()
        {
            _deck.ShowCardsInformation();
        }
    }

    internal sealed class Card
    {
        private readonly Rank _rank;
        private readonly Suit _suit;

        public Card(Rank rank, Suit suit)
        {
            _rank = rank;
            _suit = suit;
        }

        public enum Suit
        {
            Буби,
            Крести,
            Черви,
            Вини
        }

        public enum Rank
        {
            Шесть,
            Семь,
            Восемь,
            Девять,
            Десять,
            Валет,
            Дама,
            Король,
            Туз
        }

        public override string ToString()
        {
            return $"{_rank} {_suit}";
        }
    }

    internal sealed class Deck
    {
        private readonly List<Card> _cards = new List<Card>();

        public void Form()
        {
            foreach (Card.Rank cardRank in Enum.GetValues(typeof(Card.Rank)))
            {
                foreach (Card.Suit cardSuit in Enum.GetValues(typeof(Card.Suit)))
                {
                    var card = new Card(cardRank, cardSuit);
                    _cards.Add(card);
                }
            }
        }

        public void AddCard(Card card)
        {
            _cards.Add(card);
        }

        public Card PickUpRandomCard()
        {
            if (_cards.Count == 0)
            {
                return null;
            }

            var random = new Random();
            int randomIndex = random.Next(_cards.Count);

            Card randomCard = _cards[randomIndex];
            _cards.RemoveAt(randomIndex);

            return randomCard;
        }

        public void ShowCardsInformation()
        {
            if (_cards.Count == 0)
            {
                Console.WriteLine("В колоде отсутствуют карты");
            }

            for (var i = 0; i < _cards.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {_cards[i]}");
            }
        }
    }
}