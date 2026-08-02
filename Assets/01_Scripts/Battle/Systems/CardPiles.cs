using System;
using System.Collections.Generic;



public class CardPiles
{
    // 이게 카드데이터가 아니라 카드로 해야 할까
    private readonly List<Card> exhaustPile;
    private readonly List<Card> discardPile;
    private readonly List<Card> drawPile;
    private readonly List<Card> removedPile;
    private readonly List<Card> hand;

    private const int HandLimit = 10;
    private readonly Random rand;

    public IReadOnlyList<Card> Hand => hand;
    public int DrawCount => drawPile.Count;
    public int DiscardCount => discardPile.Count;
    public int ExhaustCount => exhaustPile.Count;
    public int RemovedCount => removedPile.Count;

    public event Action<Card> OnDrawn;
    public event Action OnPilesChanged;

    private Card cardInPlay; // null이면 사용중 카드 없음


    // 생성 시점은 전투가 시작할 때, BattleSetup에서.
    // CardPiles에서 Init을 두고 BattleSetup에서 호출


    public CardPiles(Deck deck)
    {
        // 카드 복사본 받기

        exhaustPile = new List<Card>();
        discardPile = new List<Card>();
        drawPile = new List<Card>();
        hand = new List<Card>();
        removedPile = new List<Card>();

        rand = new Random();

        // 덱 내의 카드 데이터 기반으로 카드 복사본 생성
        foreach (var data in deck.MyDeck)
            drawPile.Add(new Card(data));
        Shuffle(drawPile);
    }


    public void Draw(int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (Hand.Count >= HandLimit) break;

            if (DrawCount == 0) RefillDrawPile();
            if (DrawCount == 0) break;

            Card card = drawPile[^1];
            drawPile.RemoveAt(drawPile.Count - 1);
            hand.Add(card);
            OnDrawn?.Invoke(card);
        }

        OnPilesChanged?.Invoke();
    }

    // 턴 종료
    public void DiscardHand()
    {
        for (int i = hand.Count - 1; i >= 0; i--)
        {
            Card card = hand[i];
            Move(card, hand, discardPile);
        }
        OnPilesChanged?.Invoke();
    }

    // 사용된 카드의 행선지 처리
    private void Move(Card card, List<Card> from, List<Card> to)
    {

        if (from.Remove(card))
        {
            to.Add(card);
        }
        else
        {
            UnityEngine.Debug.LogError("해당 카드가 없습니다.");
        }
    }

    private void RefillDrawPile()
    {
        Shuffle(discardPile);
        foreach (var card in discardPile)
        {
            drawPile.Add(card);
        }
        discardPile.Clear();
    }

    private void Shuffle(List<Card> pile)
    {

        for (int i = pile.Count - 1; i > 0; i--)
        {
            int randomIndex = rand.Next(0, i + 1);
            (pile[i], pile[randomIndex]) = (pile[randomIndex], pile[i]);
        }
    }

    public bool TakeFromHand(Card card)
    {
        if (cardInPlay != null)
        {
            UnityEngine.Debug.LogError("이미 플레이 중인 카드가 있습니다.");
            return false;
        }

        bool removed = hand.Remove(card);
        if (removed)
        {
            cardInPlay = card;
            OnPilesChanged?.Invoke();
        }


        return removed;
    }


    public void ResolveCardInPlay()
    {
        if (cardInPlay == null)
        {
            UnityEngine.Debug.LogError(" 플레이 중인 카드가 없습니다.");
            return;
        }
        switch (cardInPlay.Destination)
        {
            case CardDestination.Discard:
                discardPile.Add(cardInPlay);
                cardInPlay = null;
                break;
            case CardDestination.Exhaust:
                Exhaust(cardInPlay);
                break;
            case CardDestination.Removed:
                removedPile.Add(cardInPlay);
                cardInPlay = null;
                break;
            default:
                UnityEngine.Debug.LogError(" 처리되지 않은 Destination.");
                break;
        }
        OnPilesChanged?.Invoke();
    }
    public void Exhaust(Card card)
    {

        if (cardInPlay == card)
        {
            exhaustPile.Add(cardInPlay);
            cardInPlay = null;
        }
        else
        {
            Move(card, hand, exhaustPile);
        }

    }

}
