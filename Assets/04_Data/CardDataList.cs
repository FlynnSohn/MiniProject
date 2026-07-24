using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardDataList", menuName = "CardDataList/CardDataList")]
public class CardDataList : ScriptableObject
{
    public List<CardData> cardList = new List<CardData>();

}
