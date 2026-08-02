using System.Collections.Generic;

/// <summary>
/// 전투 중 살아이쓴 적들을 소유
/// </summary>
public class Enemies
{
    private readonly List<Monster> monsters = new();
    public IReadOnlyList<Monster> Monsters => monsters;
    public int Count => monsters.Count;

    public void Add(Monster monster) => monsters.Add(monster);

    /// <summary>
    /// 살아있는 적 목록. 전체공격 카드, 타겟팅에 사용
    /// </summary>
    public List<Monster> GetAliveMonsters()
    {
        List<Monster> alive = new();
        foreach (var m in monsters)
        {
            if (!m.IsDead) alive.Add(m);
        }
        return alive;
    }
    /// <summary>
    /// 몬스터 사망 처리
    /// </summary>
    public void DoDie()
    {
        for (int i = monsters.Count - 1; i >= 0; i--)
        {
            if (monsters[i].IsDead)
            {
                monsters[i].Die();
                monsters.RemoveAt(i);
            }
        }
    }
    public bool AllMonstersDead
    {
        get
        {
            foreach (Monster m in monsters)
            {
                if (!m.IsDead) return false;
            }
            return true;
        }
    }
}
