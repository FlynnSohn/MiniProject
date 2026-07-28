using UnityEngine;
using TMPro;

public class CardView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer cardImageSr;
    [SerializeField] private SpriteRenderer cardFrameSr;
    [SerializeField] private SpriteRenderer cardBorderSr;
    [SerializeField] private SpriteRenderer cardTypeSr;

    [SerializeField] private TextMeshPro cardNameText;
    [SerializeField] private TextMeshPro cardEffectText; // 변경 가능성
    [SerializeField] private TextMeshPro cardTypeText;
    [SerializeField] private TextMeshPro cardEnergyText; // 변경 가능성

    public Card Card { get; private set; }
    public void Bind(Card card)
    {


    }

}
// 근데 이럴 거면 CardData에 이미지 등도 달려있어야 할 것 같다. 