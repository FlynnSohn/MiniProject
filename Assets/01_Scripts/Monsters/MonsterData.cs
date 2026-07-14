using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "MonsterData", menuName = "Monsters/MonsterData")]
public class MonsterData : ScriptableObject
{
    string monsterName;
    int damage;
    int hp;
    List<MonsterSkill> skillList = new List<MonsterSkill>();

    public class MonsterSkill
    {

    }
}

