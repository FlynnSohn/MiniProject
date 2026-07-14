using UnityEngine;
using System.Collections.Generic;
using System;


[CreateAssetMenu(fileName = "MonsterData", menuName = "Monsters/MonsterData")]
public class MonsterData : ScriptableObject
{
    [SerializeField] private string monsterName;
    [SerializeField] private int maxHp;

    [SerializeField] private Sprite monsterImage;
    [SerializeField] private List<MonsterPattern> pattern;
    [SerializeField] private List<MonsterSkill> skillList;

    public class MonsterSkill
    {

    }

}
[Serializable]
public class MonsterPattern
{

}

