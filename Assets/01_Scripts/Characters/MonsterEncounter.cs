using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// 전투 한 판에 등장하는 몬스터 몪음
/// </summary>
[Serializable]
public class MonsterEncounter
{
    [SerializeField] private string label; // 식별용
    [SerializeField] private List<MonsterData> monsters = new();

    public IReadOnlyList<MonsterData> Monsters => monsters;
    public int Count => monsters.Count;

}
