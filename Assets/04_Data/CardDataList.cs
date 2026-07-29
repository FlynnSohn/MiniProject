using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardDataList", menuName = "CardDataList/CardDataList")]
public class CardDataList : ScriptableObject
{
    [SerializeField] private List<CardData> cardList = new List<CardData>();
    public IReadOnlyList<CardData> CardList => cardList;
}
