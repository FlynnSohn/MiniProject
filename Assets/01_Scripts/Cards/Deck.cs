using System.Collections.Generic;


public class Deck
{
    private readonly List<CardData> myDeck = new();
    public IReadOnlyList<CardData> MyDeck => myDeck;

    public void Add(CardData data)
    {
        myDeck.Add(data);
    }

    // public void Remove(CardData data) // 지금 범위의 게임엔 필요 없다.
    // {
    //     myDeck.Remove(data);
    // }
}
