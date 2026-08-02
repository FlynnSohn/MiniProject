using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "MonsterPatternData", menuName = "Monster/MonsterPatternData")]
public class MonsterPatternData : ScriptableObject
{
    [SerializeReference, SubclassSelector] private List<IEffectBase> monsterEffectPatterns = new();

    public IReadOnlyList<IEffectBase> MonsterEffectPatterns => monsterEffectPatterns;

}
