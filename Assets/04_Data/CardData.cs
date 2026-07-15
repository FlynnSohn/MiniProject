using UnityEngine;

using System;
using System.Collections.Generic;

public enum CardType
{
    Attack = 0,
    Skill = 1,
    Power = 2
}
public enum CardRarity
{
    Basic = 0,
    Common = 1,
    Uncommon = 2,
    Rare = 3
}
[CreateAssetMenu(fileName = "CardData", menuName = "Card/CardData")]
public class CardData : ScriptableObject
{
    //[Header("# Main Info")]
    [SerializeField] private string cardName;
    [SerializeField] private string effectDescription;
    [SerializeField] private CardType cardtype;
    [SerializeField] private int energy;
    [SerializeField] private bool exhaustible;

    [SerializeField] private CardRarity cardRarity;

    [SerializeReference, SubclassSelector] private List<IEffectBase> cardEffects = new List<IEffectBase>();
    // 카드 효과 종류: 데미지 입히기, 에너지 얻기, 방어력 얻기, 카드 소멸시키기, 카드 뽑기
    // 적용방식: 1회, 이번 턴, 이번 전투 


    public IReadOnlyList<IEffectBase> CardEffects => cardEffects;

}


