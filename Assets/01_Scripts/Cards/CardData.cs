using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "CardData", menuName = "Cards/CardData")]
public class CardData : ScriptableObject
{
    SpriteRenderer cardImageSr;
    SpriteRenderer cardFrameSr;
    SpriteRenderer cardBorderSr;
    SpriteRenderer cardTypeSr;



    TextMeshPro cardNameText;
    TextMeshPro cardEffectText;
    TextMeshPro cardTypeText;
    TextMeshPro cardEnergyText;
}
