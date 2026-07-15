using UnityEngine;
using System.Collections.Generic;
using System;

public enum MonsterType
{
    Normal = 0,
    Elite = 1,
    Boss = 2
}

[CreateAssetMenu(fileName = "MonsterData", menuName = "Monster/MonsterData")]
public class MonsterData : ScriptableObject
{
    [SerializeField] private string monsterName;
    [SerializeField] private int maxHp;
    [SerializeField] private Sprite monsterImage;
    [SerializeField] private MonsterType monsterType;
    [SerializeField] private List<MonsterPatternData> monsterPatterns = new();

}

// 몬스터 공격도 카드처럼 만들어서 쌓기로 했다.



