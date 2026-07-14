using UnityEngine;
using TMPro;
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
[Serializable]
public class Card : ScriptableObject
{
    SpriteRenderer cardImageSr;
    SpriteRenderer cardFrameSr;
    SpriteRenderer cardBorderSr;
    SpriteRenderer cardTypeSr;

    TextMeshPro cardNameText;
    TextMeshPro cardEffectText;
    TextMeshPro cardTypeText;
    TextMeshPro cardEnergyText;

    string name;
    string effect;
    CardType cardtype;
    int energy;

    int upgradeLevel;
    CardRarity cardRarity;

    public Card(string _name)
    {
        name = _name;
    }
    public Card Clone()
    {
        return new Card(name);
    }

    public interface ICardEffect
    {

    }

    [CreateAssetMenu(fileName = "CardData", menuName = "Cards/CardData")]
    public class CardData : ScriptableObject
    {
        public List<Card> cardList = new List<Card>();
    }
}


