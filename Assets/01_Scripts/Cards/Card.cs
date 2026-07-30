

using System.Collections.Generic;

public class Card
{
    public CardData Data { get; }
    public int Cost => Data.Cost;


    // 한 단계 거쳐서 생성
    public Card(CardData data) => Data = data;

    public CardDestination Destination => Data.Destination;

    public bool NeedsTarget
    {
        get
        {
            for (int i = 0; i < Data.CardEffects.Count; i++)
            {
                if (Data.CardEffects[i].Scope == TargetScope.Target)
                    return true;
            }
            return false;
        }

    }

}

