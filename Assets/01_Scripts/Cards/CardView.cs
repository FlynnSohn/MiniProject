using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class CardView : MonoBehaviour
{
    [Header("# Renderers")]
    [SerializeField] private SpriteRenderer cardImageSr;
    [SerializeField] private SpriteRenderer cardFrameSr;
    [SerializeField] private SpriteRenderer cardBorderSr;
    [SerializeField] private SpriteRenderer cardTypeSr;

    [Header("# Texts")]
    [SerializeField] private TextMeshPro cardNameText;
    [SerializeField] private TextMeshPro cardEffectText; // 변경 가능성
    [SerializeField] private TextMeshPro cardTypeText;
    [SerializeField] private TextMeshPro cardCostText; // 변경 가능성

    [Header("# Style Tables")]
    [SerializeField] private Sprite[] borderByType; // cardtype  순서 atk, ski, pow
    [SerializeField] private Color[] colorByRarity; // 순서 basic common unique rare
    [SerializeField] private SpriteRenderer[] rarityTintTargets;


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
        CardData data = card.Data;

        cardNameText.text = data.CardName;
        cardEffectText.text = data.EffectDescription;
        cardTypeText.text = ToLabel(data.CardType);
        cardCostText.text = card.Cost.ToString();

        cardImageSr.sprite = data.CardImage;

        ApplyBorder(data.CardType);
        ApplyRarityColor(data.CardRarity);
    }

    private void ApplyBorder(CardType type)
    {
        int i = (int)type;
        if (i < 0 || i >= borderByType.Length)
        {
            Debug.LogError("borderByType 값이 지정 범위를 벗어남");
            return;
        }
        cardBorderSr.sprite = borderByType[i];
    }

    private void ApplyRarityColor(CardRarity rarity)
    {
        int i = (int)rarity;
        if (i < 0 || i >= colorByRarity.Length)
        {
            Debug.LogError("colorByRarity 값이 지정 범위를 벗어남");
            return;
        }
        Color c = colorByRarity[i];
        for (int j = 0; j < rarityTintTargets.Length; j++)
        {
            rarityTintTargets[j].color = c;
        }
    }

    private static string ToLabel(CardType type) => type switch
    {
        CardType.Attack => "공격",
        CardType.Skill => "스킬",
        CardType.Power => "파워",
        _ => type.ToString()
    };

    // 이 아래 코드 아직 확실x
    public void SetSortingOrder(int order) => sortingGroup.sortingOrder = order;
}
