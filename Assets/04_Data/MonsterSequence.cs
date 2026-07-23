using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterSequence", menuName = "MonsterSequence/MonsterSequence")]
public class MonsterSequence : ScriptableObject
{
    [SerializeField] private List<MonsterData> monsterSequences = new();
    public IReadOnlyList<MonsterData> MonsterSequences => monsterSequences;
}
