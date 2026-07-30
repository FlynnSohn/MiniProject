

public class Card
{
    public CardData Data { get; }
    public int Cost => Data.Cost;


    // private readonly string cardName;
    // private readonly string effectDescription;
    // private readonly CardType cardtype;
    // private int energy;
    // private readonly bool exhaustible;
    // private readonly CardRarity cardRarity;

    // 한 단계 거쳐서 생성
    public Card(CardData data) => Data = data;

    public CardDestination Destination => Data.Destination;
}

