using System;
using System.Collections.Generic;

class Program
{
    const string MenuDrawCard = "1";
    const string MenuShowCards = "2";
    const string MenuExit = "3";

    static void Main()
    {
        Deck deck = new Deck();
        Player player = new Player();

        while (true)
        {
            Console.WriteLine("============= МЕНЮ =============");
            Console.WriteLine($"{MenuDrawCard}. Вытянуть карту");
            Console.WriteLine($"{MenuShowCards}. Информация о вытянутых картах");
            Console.WriteLine($"{MenuExit}. Выход");
            Console.WriteLine("================================");
            Console.Write("Выберите действие (1/2/3): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case MenuDrawCard:                  
                    player.PullCard(deck.GetCard());
                    break;
                case MenuShowCards:
                    player.DisplayCards();
                    break;
                case MenuExit:
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
}

class Card
{
    public string Suit { get; set; }
    public string Rank { get; set; }

    public Card(string suit, string rank)
    {
        Suit = suit;
        Rank = rank;
    }

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
    }

    public Card GetCard()
    {
        const int MinCardsCount = 1;
        const int TopCardIndex = 0;

        Shuffle();

        if (_cards.Count < MinCardsCount)
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

        Shuffle();
    }

    private void Shuffle()
    {
        var random = new Random();
        int cardsCount = _cards.Count;

        while (cardsCount > 1)
        {
            cardsCount--;

            int randomCardIndex = random.Next(cardsCount + 1);
            Card card = _cards[randomCardIndex];
            _cards[randomCardIndex] = _cards[cardsCount];
            _cards[cardsCount] = card;
        }
    }
}

class Player
{
    private List<Card> _cards = new List<Card>();

    public void PullCard(Card card)
    {
        _cards.Add(card);
        Console.WriteLine($"Вытянута карта: {card}");
    }

    public void DisplayCards()
    {
        Console.WriteLine("Вытянутые карты: ");

        foreach (Card card in _cards)
        {
            Console.WriteLine(card.ToString());
        }
    }
}
