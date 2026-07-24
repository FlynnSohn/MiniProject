using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Encounter들의 모음
/// </summary>
[CreateAssetMenu(fileName = "MonsterSequence", menuName = "Monster/MonsterSequence")]
public class MonsterSequence : ScriptableObject
{
    [SerializeField] private List<MonsterEncounter> encounters = new();
    public IReadOnlyList<MonsterEncounter> Encounters => encounters;

    /// <summary>
    /// 무한 탑: 목록 끝을 넘어가면 순환한다.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public MonsterEncounter GetAt(int index)
    {
        if (encounters.Count == 0) return null;
        return encounters[index % encounters.Count];
    }
}
