using System;

enum Suit { Heart, Square, Cross, Spade }
enum Rank { Ace, King, Queen, Jack, Ten, Nine, Eight, Seven, Six, Five, Four, Three, Two }

class Card
{
    public Suit Suit { get; }
    public Rank Rank { get; }

    public Card(Suit suit, Rank rank)
    {
        Suit = suit;
        Rank = rank;
    }

    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }
}

class CardDeck
{
    private List<Card> cards = new List<Card>();

    public CardDeck()
    {
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                cards.Add(new Card(suit, rank));
            }
        }
    }

    public void Shuffle()
    {
        Random rand = new Random();
        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = rand.Next(n + 1);
            Card temp = cards[k];
            cards[k] = cards[n];
            cards[n] = temp;
        }
    }

    public override string ToString()
    {
        string result = "";
        foreach (Card card in cards)
        {
            result += card + "\n";
        }
        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        CardDeck deck = new CardDeck();
        Console.WriteLine(deck);
        deck.Shuffle();
        Console.WriteLine("\nShuffled Deck:\n" + deck);
    }
}
