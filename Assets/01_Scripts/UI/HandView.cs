using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class HandView : MonoBehaviour
{
    [SerializeField] private CardView cardViewPrefab;
    [SerializeField] Transform handRoot;
    [SerializeField] private float spacing = 1.8f;
    [SerializeField] private int baseSortingOrder;
    private readonly Dictionary<Card, CardView> views = new();
    private readonly List<Card> removeBuffer = new();
    private CardPiles piles;

    public void Begin(BattleContext ctx)
    {
        piles = ctx.CardPiles;
        piles.OnPilesChanged += Sync;
        Sync();

    }


    private void OnDestroy()
    {
        if (piles != null) piles.OnPilesChanged -= Sync;
    }

    private void Sync()
    {
        // 손패에서 없어진 카드 뷰 제거
        removeBuffer.Clear();
        foreach (var pair in views)
        {
            if (!piles.Hand.Contains(pair.Key)) removeBuffer.Add(pair.Key);
        }

        foreach (Card card in removeBuffer)
        {
            Destroy(views[card].gameObject);
            views.Remove(card);
        }

        // 새로 들어온 카드의 뷰 생성
        foreach (Card card in piles.Hand)
        {
            if (views.ContainsKey(card)) continue;
            CardView view = Instantiate(cardViewPrefab, handRoot);
            view.Bind(card);
            views.Add(card, view);
        }
        Layout();
    }
    /// <summary>
    /// 손패에 있는 카드 데이터의 뷰들을 손패 위치에 배치하고 sorting order 부여
    /// </summary>
    public void Layout()
    {
        int count = piles.Hand.Count;
        for (int i = 0; i < count; i++)
        {
            CardView view = views[piles.Hand[i]];
            float offsetX = (i - (count - 1) / 2f) * spacing;
            view.transform.position = handRoot.position + new Vector3(offsetX, 0f, 0f);

            // 이 아래 코드 아직 확실x
            view.SetSortingOrder(baseSortingOrder + i * 10);
        }

    }
}
