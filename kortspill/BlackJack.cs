namespace kortspill;


public class BlackJack : CardDeck
{
    private int dealersSum;
    int playersSum;
    public void DealCards()
    {
        CreateDeck();
        Console.WriteLine("Black Jack");
        Card DealersFirstCard = Draw();
        Card DealersSecondCard = Draw();
        Card PlayersFirstCard = Draw();
        Card PlayersSecondCard = Draw();
        dealersSum = (int)DealersFirstCard.CardValue + (int)DealersSecondCard.CardValue;
        playersSum = (int)PlayersFirstCard.CardValue + (int)PlayersSecondCard.CardValue;
        Console.WriteLine($"{DealersFirstCard.CardValue} of {DealersFirstCard.CardType} and {DealersSecondCard.CardValue} of {DealersSecondCard.CardType}");
        Console.WriteLine($"His sum is {dealersSum} ");
        Console.WriteLine($"{PlayersFirstCard.CardValue} of {PlayersFirstCard.CardType} and {PlayersSecondCard.CardValue} of {PlayersSecondCard.CardType}");
        Console.WriteLine($"Your sum is {playersSum} ");
        Console.WriteLine("Do you want to hit or stay? (h/s)");
        string hitOrStay = Console.ReadLine().ToLower();
        if (hitOrStay == "h")
        {
            PlayerHit();
            if (playersSum == 21)
            {
                Console.WriteLine("You won");
                return;
            }
        }

        if (playersSum > 21)
        {
            Console.WriteLine("You lose");
        }
        else
        {
            Console.WriteLine("Do you want to hit or stay? (h/s)");
            hitOrStay = Console.ReadLine();
            if (hitOrStay == "h")
            {
                PlayerHit();
                if (playersSum == 21)
                {
                    Console.WriteLine("You won");
                    return;
                }
                if (playersSum > 21)
                {
                    Console.WriteLine("You lose");
                }
            }
            else
            {
                Console.WriteLine($"You stay on {playersSum}");
            }

            if (dealersSum < 17)
            {
                DealerHit();
                outcome();
            }
            else
            {
                Console.WriteLine($"Dealers stays on {dealersSum}");
                outcome();
            }
        }
        
    }

    public void PlayerHit()
    {
        Card playersThirdCard = Draw();
        playersSum = (int)playersThirdCard.CardValue + playersSum;
        Console.WriteLine(playersThirdCard.CardValue + " of " + playersThirdCard.CardType);
        Console.WriteLine("Your sum now " + playersSum);
    }
    public void DealerHit()
    {
        Card DealersThirdCard = Draw();
        dealersSum = (int)DealersThirdCard.CardValue + dealersSum;
        Console.WriteLine(DealersThirdCard.CardValue + " of " + DealersThirdCard.CardType);
        Console.WriteLine("Dealers sum now " + dealersSum);
    }

    public void outcome()
    {
        if (playersSum < dealersSum)
        {
            Console.WriteLine("You lose");
        }else if (playersSum == dealersSum)
        {
            Console.WriteLine("It's a tie");
        }
        else
        {
            Console.WriteLine("You won");
        }
    }
    
}
