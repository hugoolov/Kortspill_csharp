namespace kortspill;


public class BlackJack : CardDeck
{
    public void DealCards()
    {
        CreateDeck();
        Console.WriteLine("Black Jack");
        Card DealersFirstCard = Draw();
        Card DealersSecondCard = Draw();
        Card PlayersFirstCard = Draw();
        Card PlayersSecondCard = Draw();
        Console.WriteLine($"{DealersFirstCard.CardValue} of {DealersFirstCard.CardType} and {DealersSecondCard.CardValue} of {DealersSecondCard.CardType}");
        Console.WriteLine($"His sum is {(int)(DealersFirstCard.CardValue) + (int)(DealersSecondCard.CardValue)} ");
    }

    
}
