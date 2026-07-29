

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
}

// 카드데이터 참조는 가지고 있어야 한다. 왜냐하면 어떤 카드인지 타겟을 정확히 알아야 하니까.


