namespace kortspill;

public class Card
{
    internal CardType CardType{get;set;}
    public CardValue CardValue{get;set;}
    public Card (CardValue value, CardType type)
    {
        CardType = type;
        CardValue = value;
    }
}
