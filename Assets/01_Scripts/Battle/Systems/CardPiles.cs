using System;
using System.Collections.Generic;


public class CardPiles
{
    // 이게 카드데이터가 아니라 카드로 해야 할까
    private readonly List<CardData> exhaustPile;
    private readonly List<CardData> discardPile;
    private readonly List<CardData> drawPile;
    private readonly List<Card> hand;

    private readonly int handLimit = 5;
    private readonly Random rng;

    public IReadOnlyList<Card> Hand => hand;
    public int DrawCount => drawPile.Count;
    public int DiscardCount => discardPile.Count;
    public int ExhaustCount => exhaustPile.Count;

    public event Action<Card> OnDrawn;
    public event Action OnPilesChanged;




    // 뽑을 더미는 리스트의 제일 앞(0)부터
    // 드로우에서 뽑을 더미가 부족하면 일단 한 장씩 뽑다가 비면 채운다. 일단 남은 카드들을 무조건 뽑아야 하니까
    // 피셔에이츠 셔플 사용. 성능 & 뽑기 확률 공정성을 위함

    // 생성 시점은 전투가 시작할 때, BattleSetup에서.
    // CardPiles에서 Init을 두고 BattleSetup에서 호출
    // 
    // Deck에서 List<CardData>정보를 복사해 drawPile에 두고 전투가 끝나면 폐기한다.
    // 아...잠깐, 리스트를 복사하면 내부 정보는 같이 공유하나??? 그럼 foreach로 카드데이터를 하나씩 복사해서 draw에 넣어줘야 할까?
    // Deck에 카드 데이터 복사본 넘기는 함수 존재, SetCardPiles정도?

    // 손패 상한 handLimit을 넘으면 뽑기 스킵.
    // 이 값은 바뀔 수 있음.


    public CardPiles(Deck deck, int _handLimit)
    {
        // 카드 복사본 받기
        // 
        handLimit = _handLimit;
        List<Card> clonedDeck = new();
        for (int i = 0; i < handLimit; i++)
        {

        }
        Shuffle(clonedDeck);
    }


    public void Draw(int count)
    {

    }
    // 턴 종료
    public void DiscardHand()
    {

    }
    // 사용된 카드의 행선지 처리
    private void Move(Card card, List<Card> from, List<Card> to)
    {

    }
    private void RefillDrawPile()
    {

    }
    private void Shuffle(List<Card> pile)
    {

        for (int i = pile.Count - 1; i > 0; i--)
        {
            int randomIndex = rng.Next(0, i + i);
            (pile[i], pile[randomIndex]) = (pile[randomIndex], pile[i]);
        }
    }

}
