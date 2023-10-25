using System;
using System.Collections.Generic;

class Program
{
    private static void Main()
    {
        const string MenuDrawCard = "1";
        const string MenuShowCards = "2";
        const string MenuExit = "3";

        Deck deck = new Deck();
        Player player = new Player();
        bool isGame = true;

        while (isGame)
        {
            Console.WriteLine("============= МЕНЮ =============");
            Console.WriteLine($"{MenuDrawCard}. Вытянуть карту");
            Console.WriteLine($"{MenuShowCards}. Информация о вытянутых картах");
            Console.WriteLine($"{MenuExit}. Выход");
            Console.WriteLine("================================");
            Console.Write("Выберите номер действия: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case MenuDrawCard:
                    player.AddCard(deck.GetCard());
                    break;
                case MenuShowCards:
                    player.DisplayCards();
                    break;
                case MenuExit:
                    isGame = false;
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }

            if (isGame)
            {
                deck.Shuffle();
            }
        }
    }
}

class Card
{
    public Card(string suit, string rank)
    {
        Suit = suit;
        Rank = rank;
    }

    public string Suit { get; set; }
    public string Rank { get; set; }

    public override string ToString()
    {
        return $"{Suit}  {Rank}";
    }
}

class Deck
{
    private List<Card> _cards;

    public Deck()
    {
        Initialize();
        Shuffle();
    }

    public void Shuffle()
    {
        var random = new Random();
        Card card;

        for (int i = _cards.Count - 1; i > 0; i--)
        {
            int randomCardIndex = random.Next(0, _cards.Count);
            card = _cards[i];
            _cards[i] = _cards[randomCardIndex];
            _cards[randomCardIndex] = card;
        }
    }


    public Card GetCard()
    {
        const int TopCardIndex = 0;

        if (_cards.Count == 0)
        {
            Console.WriteLine("Колода пуста.");
            return null;
        }

        Card card = _cards[TopCardIndex];
        _cards.Remove(card);
        return card;
    }

    private void Initialize()
    {
        _cards = new List<Card>();
        string[] suits = { "Черви", "Бубны", "Крести", "Пики" };
        string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз" };

        foreach (string suit in suits)
        {
            foreach (string rank in ranks)
            {
                _cards.Add(new Card(suit, rank));
            }
        }
    }
}

class Player
{
    private List<Card> _cards = new List<Card>();

    public void AddCard(Card card)
    {
        _cards.Add(card);
        Console.WriteLine($"Вытянута карта: {card}");
    }

    public void DisplayCards()
    {
        Console.WriteLine("Вытянутые карты: ");

        foreach (Card card in _cards)
        {
            if (card != null)
            {
                Console.WriteLine(card.ToString());
            }
        }
    }
}
