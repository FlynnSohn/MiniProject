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

}


