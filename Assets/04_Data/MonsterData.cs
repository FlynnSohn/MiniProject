using UnityEngine;
using System.Collections.Generic;
using System;


[CreateAssetMenu(fileName = "MonsterData", menuName = "Monsters/MonsterData")]
public class MonsterData : ScriptableObject
{
    string monsterName;
    int maxHp;

    Sprite monsterImage;
    List<MonsterPattern> pattern;
    List<MonsterSkill> skillList;

    public class MonsterSkill
    {

    }

}
[Serializable]
public class MonsterPattern
{

}

