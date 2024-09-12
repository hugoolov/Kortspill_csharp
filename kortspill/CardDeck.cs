using System.Security.Cryptography;

namespace kortspill;

public class CardDeck 
{
    public List<Card> deck { get; set; }

    public CardDeck()
    {
        deck = new List<Card>();
    }

    public void CreateDeck()
    {
        foreach (CardType type in Enum.GetValues(typeof(CardType)))
        {
            foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
            {
                if (value != CardValue.None)
                {
                    Card card = new Card(value, type);
                    deck.Add(card);
                }
            }
        }
    }

    public Card Draw()
    {
        if (deck.Count == 0) 
        {
            throw new InvalidOperationException("No cards left in the deck!");
        }
        Random random = new Random();
        int index = random.Next(deck.Count);
        Card randomCard = deck[index];  // Access the card first
        deck.RemoveAt(index);           // Then remove it from the deck
        return randomCard;
    }

   /* public void HiLoGame()
    {
        Card dealersCard = Draw();
        Card playersCard = Draw();
        Console.WriteLine($"Guess if your card is higher or lower than {dealersCard.CardValue} h/l");
        string userAnswer = Console.ReadLine().ToLower();
        if ((userAnswer == "h" && dealersCard.CardValue < playersCard.CardValue)||(userAnswer == "l" && playersCard.CardValue < dealersCard.CardValue))
        {
            Console.WriteLine($"Your card is {playersCard.CardValue} and you have won");
        }else if (dealersCard.CardValue == playersCard.CardValue)
        {
            Console.WriteLine($"Your card is {playersCard.CardValue} and you have drawn");
        }
        else
        {
            Console.WriteLine($"Your card is {playersCard.CardValue} and you have lost");
        }
    }

    public void DisplayDeck()
    {
        foreach (var card in deck)
        {
            Console.WriteLine($"{card.CardValue} of {card.CardType}");
        }
    }*/
}

