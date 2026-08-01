using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class CardView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer cardImageSr;
    [SerializeField] private SpriteRenderer cardFrameSr;
    [SerializeField] private SpriteRenderer cardBorderSr;
    [SerializeField] private SpriteRenderer cardTypeSr;

    [SerializeField] private TextMeshPro cardNameText;
    [SerializeField] private TextMeshPro cardEffectText; // 변경 가능성
    [SerializeField] private TextMeshPro cardTypeText;
    [SerializeField] private TextMeshPro cardCostText; // 변경 가능성

    [SerializeField] private Sprite[] frameByType; // cardtype enum 순서 atk, ski, pow

    // [SerializeField] private Sprite[] typeIconByType;


    private SortingGroup sortingGroup;

    public Card Card { get; private set; }

    void Awake()
    {
        sortingGroup = GetComponent<SortingGroup>();
    }

    public int SortingOrder => sortingGroup.sortingOrder;
    public void Bind(Card card)
    {
        Card = card;

        cardNameText.text = card.Data.CardName;
        cardEffectText.text = card.Data.EffectDescription;
        cardTypeText.text = card.Data.CardType.ToString();
        cardCostText.text = card.Cost.ToString();

        //cardImageSr.sprite = card.Data.CardImage;

        int t = (int)card.Data.CardType;
        if (t >= 0 && t < frameByType.Length) cardFrameSr.sprite = frameByType[t];

    }
    // 이 아래 코드 아직 확실x
    public void SetSortingOrder(int order)
    {
        sortingGroup.sortingOrder = order;
    }

}
