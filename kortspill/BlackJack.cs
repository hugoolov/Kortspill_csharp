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
        
        Console.WriteLine($"Dealer: {DealersFirstCard.CardValue} of {DealersFirstCard.CardType} and the second one is hidden");
        Console.WriteLine($"You: {PlayersFirstCard.CardValue} of {PlayersFirstCard.CardType} and {PlayersSecondCard.CardValue} of {PlayersSecondCard.CardType}");
        Console.WriteLine($"Your sum is {playersSum} "); 
        playerChoice();
        Console.WriteLine($"Dealer revels second card: {DealersFirstCard.CardValue} of {DealersFirstCard.CardType} and {PlayersSecondCard.CardValue} of {PlayersSecondCard.CardType}");
        Console.WriteLine($"His sum is {dealersSum} ");

        dealersTurn();
        dealersTurn();
        outcome();
    }

    private void dealersTurn()
    {
        if (dealersSum < 17  && playersSum < 22 || dealersSum < playersSum)
        {
            DealerHit();
        }
        else
        {
            outcome();
        }
    }

    public void playerChoice()
    {
        Console.WriteLine("Hit or stay (h/s)");
        string hitOrStay = Console.ReadLine().ToLower();
        
        if(hitOrStay == "h"){
            PlayerHit();
        }else if (hitOrStay == "s")
        {
            playerStays();
        }
    }

    private void playerStays()
    {
        Console.WriteLine($"You chose to stay and your sum is {playersSum}");
    }

    public void PlayerHit()
    {
        Card playersExtraCard = Draw();
        playersSum = (int)playersExtraCard.CardValue + playersSum;
        if (playersSum > 21)
        {
            playerBust();
        }
        Console.WriteLine(playersExtraCard.CardValue + " of " + playersExtraCard.CardType);
        Console.WriteLine("Your sum now " + playersSum);
    }

    private void playerBust()
    {
        Console.WriteLine("Bust, you have lost");
        EndOfGame();
    }

    public void DealerHit()
    {
        Card DealersExtraCard = Draw();
        dealersSum = (int)DealersExtraCard.CardValue + dealersSum;
        
        Console.WriteLine("Dealer hits, he got " + DealersExtraCard.CardValue + " of " + DealersExtraCard.CardType);
        Console.WriteLine("Dealers sum now " + dealersSum);
        
        
    }

    public void outcome()
    {
        if (dealersSum > playersSum && dealersSum < 21)
        {
            Console.WriteLine("You lose");
            EndOfGame();
        }else if (playersSum == dealersSum)
        {
            Console.WriteLine("It's a tie");
            EndOfGame();
        }
        else if (dealersSum < playersSum && playersSum < 21)
        {
            Console.WriteLine("You won");
            EndOfGame();
        }
    }

    public void EndOfGame()
    {
        Console.WriteLine("Do you want to play again? (y/n)");
        String playAgain = Console.ReadLine().ToLower();
        if (playAgain == "y")
        {
            DealCards();
        }
        else
        {
            Console.WriteLine("Game is closed");
            return;
        }
    }
}
